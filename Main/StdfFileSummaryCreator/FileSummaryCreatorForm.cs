using LinqToStdf;
using LinqToStdf.Indexing;
using System.Diagnostics;
using System.Text;

namespace StdfFileSummaryCreator
{
    public partial class FileSummaryCreatorForm : Form
    {

        public FileSummaryCreatorForm()
        {
            InitializeComponent();
            ccb_name.SelectedIndex = 0;
            ccb_recTypeNums.SelectedIndex = 0;
            ccb_ContinuousRec.SelectedIndex = 0;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        async void Form1_DragDrop(object sender, DragEventArgs e)
        {
            SetStateOfUI(STATE.PROCESSING);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Count() > 1)
                return;
            var file = new FileInfo(files.First());
            if (!file.Extension.ToUpper().Contains("STD"))
            {
                MessageBox.Show("STD or STDF files only.");
                SetStateOfUI(STATE.FAILED);
                return;
            }

            string retStr = string.Empty;
            try
            {
                var FriendlyNames = this.ccb_name.SelectedIndex == 1;
                var RecTypeNums = this.ccb_recTypeNums.SelectedIndex == 0;
                var ContRecordNums = this.ccb_ContinuousRec.SelectedIndex == 0;
                var result = await Task.Run(() => MakeIndentedSummary(file, FriendlyNames, RecTypeNums, ContRecordNums));

                if (result)
                    SetStateOfUI(STATE.SUCCESS);
                else
                    SetStateOfUI(STATE.FAILED);
            }
            catch (Exception ex)
            {
                SetStateOfUI(STATE.FAILED);
                MessageBox.Show(ex.ToString());
            }

        }
        enum STATE { SUCCESS, FAILED, PROCESSING }
        private void SetStateOfUI(STATE s)
        {
            if (s == STATE.FAILED)
            {
                BackColor = Color.Red;
                lblInstructions.BackColor = Color.IndianRed;
                lblProcessing.BackColor = Color.IndianRed;
                this.Enabled = true;
                lblProcessing.Visible = false;
            }
            if (s == STATE.SUCCESS)
            {
                BackColor = Color.LimeGreen;
                lblInstructions.BackColor = Color.LightGreen;
                lblProcessing.BackColor = Color.LightGreen;
                this.Enabled = true;
                lblProcessing.Visible = false;
            }
            if (s == STATE.PROCESSING)
            {
                BackColor = Color.LightYellow;
                lblInstructions.BackColor = Color.LightGoldenrodYellow;
                lblProcessing.BackColor = Color.LightGoldenrodYellow;
                this.Enabled = false;
                lblProcessing.Visible = true;
            }
        }

        private async Task<bool> MakeIndentedSummary(FileInfo fi, bool friendlyNames, bool RecNums, bool Qtys)
        {
            try
            {
                string FileIn = fi.FullName;
                string FileOut = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(fi.Name) + "_SUMMARY_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
                var input = new StdfFile(FileIn, new NonCachingStrategy());
                var summary = SummarizeStdfFile(input);

                SummaryToIndentedView(summary, FileOut, RecNums, Qtys, friendlyNames);

                //open the file
                Process p = new Process();
                ProcessStartInfo pi = new ProcessStartInfo();
                pi.UseShellExecute = true;
                pi.FileName = FileOut;
                p.StartInfo = pi;

                try
                {
                    p.Start();
                }
                catch (Exception Ex)
                {
                    _ = 43563;
                }


                return true;
            }
            catch
            {
                throw;
            }
        }

        private class RTypeAndCount
        {
            public RecordType rt;
            public int cnt;
        }
        private List<RTypeAndCount> SummarizeStdfFile(StdfFile sFile)
        {
            var rTypeList = sFile.GetRecords().Select(o => o.GetRecordType_Safe()).ToList();

            List<RTypeAndCount> stdfFileSummary = new();

            stdfFileSummary.Add(new RTypeAndCount() { rt = rTypeList.First(), cnt = 1 });
            for (int i = 1; i < rTypeList.Count; i++)
            {
                var latestRow = stdfFileSummary.Last();
                if (latestRow.rt == rTypeList[i])
                    latestRow.cnt = latestRow.cnt + 1;
                else
                    stdfFileSummary.Add(new RTypeAndCount() { rt = rTypeList[i], cnt = 1 });
            }
            return stdfFileSummary;
        }
        private void SummaryToIndentedView(List<RTypeAndCount> summary, string saveLoc, bool OutputRecordTypeInts, bool OutputQuantity, bool UseFriendlyNames)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in summary)
            {
                string indentedString = string.Empty;
                var v = item.rt.Type;
                if (v == 0)
                    indentedString = "";
                else if (v == 1)
                    indentedString = " ";
                else if (v == 2)
                    indentedString = "  ";
                else if (v == 5)
                    indentedString = "   ";
                else if (v == 10)
                    indentedString = "    ";
                else if (v == 15)
                    indentedString = "     ";
                else if (v == 20)
                    indentedString = "      ";
                else if (v == 50)
                    indentedString = "       ";
                else if (v == 180)
                    indentedString = "        ";
                else if (v == 181)
                    indentedString = "         ";
                else
                    indentedString = "?";


                sb.AppendLine(indentedString + GetRecordTypeInfo(item.rt, OutputRecordTypeInts, UseFriendlyNames).ToUpper() + (OutputQuantity ? "(" + item.cnt + ")" : ""));
            }
            if (File.Exists(saveLoc))
                File.Delete(saveLoc);

            File.WriteAllText(saveLoc, sb.ToString());
        }
        private string GetRecordTypeInfo(RecordType rType, bool includeNumbers = true, bool useFullName = false)
        {
            var names = TypeSingleton.getInstance().ToNames(rType.Type, rType.Subtype);
            return (useFullName ? names.fullName : names.shortName) + (includeNumbers ? "(" + rType.Type + "-" + rType.Subtype + ")" : "");
        }
    }

}