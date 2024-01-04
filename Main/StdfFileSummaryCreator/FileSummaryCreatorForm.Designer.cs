namespace StdfFileSummaryCreator
{
    partial class FileSummaryCreatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSummaryCreatorForm));
            ccb_name = new ComboBox();
            ccb_recTypeNums = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ccb_ContinuousRec = new ComboBox();
            lblProcessing = new Label();
            lblInstructions = new Label();
            SuspendLayout();
            // 
            // ccb_name
            // 
            ccb_name.DropDownStyle = ComboBoxStyle.DropDownList;
            ccb_name.FormattingEnabled = true;
            ccb_name.Items.AddRange(new object[] { "Short Names", "Full Names" });
            ccb_name.Location = new Point(335, 67);
            ccb_name.Margin = new Padding(2);
            ccb_name.MaxDropDownItems = 2;
            ccb_name.Name = "ccb_name";
            ccb_name.Size = new Size(108, 23);
            ccb_name.TabIndex = 3;
            // 
            // ccb_recTypeNums
            // 
            ccb_recTypeNums.DropDownStyle = ComboBoxStyle.DropDownList;
            ccb_recTypeNums.FormattingEnabled = true;
            ccb_recTypeNums.Items.AddRange(new object[] { "Include", "Exclude" });
            ccb_recTypeNums.Location = new Point(335, 89);
            ccb_recTypeNums.Margin = new Padding(2);
            ccb_recTypeNums.Name = "ccb_recTypeNums";
            ccb_recTypeNums.Size = new Size(108, 23);
            ccb_recTypeNums.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(242, 69);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 5;
            label1.Text = "Name Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 89);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 6;
            label2.Text = "Record Numbers (ex: 1-90)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 114);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(164, 15);
            label3.TabIndex = 7;
            label3.Text = "Count of Continuous Records";
            // 
            // ccb_ContinuousRec
            // 
            ccb_ContinuousRec.DropDownStyle = ComboBoxStyle.DropDownList;
            ccb_ContinuousRec.FormattingEnabled = true;
            ccb_ContinuousRec.Items.AddRange(new object[] { "Include", "Exclude" });
            ccb_ContinuousRec.Location = new Point(335, 114);
            ccb_ContinuousRec.Margin = new Padding(2);
            ccb_ContinuousRec.Name = "ccb_ContinuousRec";
            ccb_ContinuousRec.Size = new Size(108, 23);
            ccb_ContinuousRec.TabIndex = 8;
            // 
            // lblProcessing
            // 
            lblProcessing.AutoSize = true;
            lblProcessing.Font = new Font("Segoe UI", 33F, FontStyle.Regular, GraphicsUnit.Point);
            lblProcessing.Location = new Point(224, 157);
            lblProcessing.Margin = new Padding(2, 0, 2, 0);
            lblProcessing.Name = "lblProcessing";
            lblProcessing.Size = new Size(264, 60);
            lblProcessing.TabIndex = 9;
            lblProcessing.Text = "Processing...";
            lblProcessing.Visible = false;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstructions.Location = new Point(37, 15);
            lblInstructions.Margin = new Padding(2, 0, 2, 0);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(605, 41);
            lblInstructions.TabIndex = 10;
            lblInstructions.Text = "Drag and drop a file into this UI to kick it off.";
            // 
            // FileSummaryCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 244);
            Controls.Add(lblInstructions);
            Controls.Add(lblProcessing);
            Controls.Add(ccb_ContinuousRec);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ccb_recTypeNums);
            Controls.Add(ccb_name);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FileSummaryCreatorForm";
            Text = "Stdf File Summary Creator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox ccb_name;
        private ComboBox ccb_recTypeNums;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ccb_ContinuousRec;
        private Label lblProcessing;
        private Label lblInstructions;
    }
}