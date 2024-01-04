
namespace StdfFileSummaryCreator
{
    enum LEVEL
    {
        File = 0,
        Lot = 1,
        Wafer = 2,
        Part = 5,
        TestProgram = 10,
        TestExecution = 15,
        ProgramSegment = 20,
        GenericData = 50,
        Exception = 127,
        ImageSoftware = 180,
        IG900Software = 181
    }

    public class TypeSingleton
    {
        private static volatile TypeSingleton _instance = new TypeSingleton();
        private static object _instanceLock = new object();
        private Dictionary<byte, Level> recTypes = new Dictionary<byte, Level>();
        private TypeSingleton()
        {
            recTypes.Add(0, new Level(0, "File"));
            recTypes[0].subLevels.Add(10, new Level(10, "FAR", "File Attribute Record"));
            recTypes[0].subLevels.Add(20, new Level(20, "ATR", "Audit Trail Record"));
            recTypes[0].subLevels.Add(30, new Level(30, "VUR", "Version Update Record")); //stdf V4-2007

            recTypes.Add(1, new Level(1, "Lot"));
            recTypes[1].subLevels.Add(10, new Level(10, "MIR", "Master Information Record"));
            recTypes[1].subLevels.Add(20, new Level(20, "MRR", "Master Results Record"));
            recTypes[1].subLevels.Add(30, new Level(30, "PCR", "Part Count Record"));
            recTypes[1].subLevels.Add(40, new Level(40, "HBR", "Hardware Bin Record"));
            recTypes[1].subLevels.Add(50, new Level(50, "SBR", "Software Bin Record"));
            recTypes[1].subLevels.Add(60, new Level(60, "PMR", "Pin Map Record"));
            recTypes[1].subLevels.Add(62, new Level(62, "PGR", "Pin Group Record"));
            recTypes[1].subLevels.Add(63, new Level(63, "PLR", "Pin List Record"));
            recTypes[1].subLevels.Add(70, new Level(70, "RDR", "Retest Data Record"));
            recTypes[1].subLevels.Add(80, new Level(80, "SDR", "Site Description Record"));
            recTypes[1].subLevels.Add(90, new Level(90, "PSR", "Pattern Sequence Record")); //stdf V4-2007
            recTypes[1].subLevels.Add(91, new Level(91, "NMR", "Name Map Record")); //stdf V4-2007
            recTypes[1].subLevels.Add(92, new Level(92, "CNR", "Cell Name Record")); //stdf V4-2007
            recTypes[1].subLevels.Add(93, new Level(93, "SSR", "Scan Structure Record")); //stdf V4-2007
            recTypes[1].subLevels.Add(94, new Level(94, "SCR", "Scan Chain Record")); //stdf V4-2007


            recTypes.Add(2, new Level(2, "Wafer"));
            recTypes[2].subLevels.Add(10, new Level(10, "WIR", "Wafer Information Record"));
            recTypes[2].subLevels.Add(20, new Level(20, "WRR", "Wafer Results Record"));
            recTypes[2].subLevels.Add(30, new Level(30, "WCR", "Wafer Configuration Record"));

            recTypes.Add(5, new Level(5, "Die"));
            recTypes[5].subLevels.Add(10, new Level(10, "PIR", "Part Information Record"));
            recTypes[5].subLevels.Add(20, new Level(20, "PRR", "Part Results Record"));

            recTypes.Add(10, new Level(10, "TestProgram"));
            recTypes[10].subLevels.Add(30, new Level(30, "TSR", "Test Synopsis Record"));

            recTypes.Add(15, new Level(15, "TestExecution"));
            recTypes[15].subLevels.Add(10, new Level(10, "PTR", "Parametric Test Record"));
            recTypes[15].subLevels.Add(15, new Level(15, "MPR", "Multiple-Result Parametric Record"));
            recTypes[15].subLevels.Add(20, new Level(20, "FTR", "Functional Test Record"));
            recTypes[15].subLevels.Add(30, new Level(30, "STR", "Scan Test Record")); //stdf V4-2007

            recTypes.Add(20, new Level(20, "ProgramSegment"));
            recTypes[20].subLevels.Add(10, new Level(10, "BPS", "Begin Program Section Record"));
            recTypes[20].subLevels.Add(20, new Level(20, "EPS", "End Program Section Record"));

            recTypes.Add(50, new Level(50, "GenericData"));
            recTypes[50].subLevels.Add(10, new Level(10, "GDR", "Generic Data Record"));
            recTypes[50].subLevels.Add(30, new Level(30, "DTR", "Datalog Text Record"));

            recTypes.Add(180, new Level(180, "ImageSoftware")); //Reserved for use by Image software
            recTypes.Add(181, new Level(181, "IG900Software")); //Reserved for use by IG900 software

            recTypes.Add(254, new Level(254, "CUSTOM"));
            recTypes[254].subLevels.Add(254, new Level(254, "SOS", "Start Of Stream"));
            recTypes[254].subLevels.Add(255, new Level(255, "EOS", "End Of Stream"));

            recTypes.Add(255, new Level(255, "UNKNOWN"));
            recTypes[255].subLevels.Add(255, new Level(255, "UNKNOWN"));
        }

        public static TypeSingleton getInstance()
        {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new TypeSingleton();
            return _instance;
        }

        public (string shortName, string fullName) ToNames(byte type, byte? subtype)
        {
            string shortName = "UNKNOWN";
            string longName = "UNKNOWN";
            try
            {
                if (subtype == null)
                {
                    shortName = recTypes[type].ShortName;
                    longName = recTypes[type].FullName;
                }
                else
                {
                    shortName = recTypes[type].subLevels[subtype.Value].ShortName;
                    longName = recTypes[type].subLevels[subtype.Value].FullName;
                }
            }
            catch { }
            
            return (shortName, longName);
        }

        public string ToShortName(byte type, byte? subtype)
        {
            return ToNames(type, subtype).shortName;
        }
        public string ToFullNames(byte type, byte? subtype)
        {
            return ToNames(type, subtype).fullName;
        }
        public (byte type, byte subType) ToCodeName(string shortName)
        {
            try
            {
                var result = recTypes.SelectMany(o => o.Value.subLevels.Values
                                     .Where(p => p.ShortName == shortName.ToUpper())
                                     .Select(p => (o.Key, p.code)))
                                     .Single();
                return result;
            }
            catch
            {
                return (0,0);
            }
        }
        public string ToFullName(string shortName)
        {
            try
            {
                var result = recTypes.SelectMany(o => o.Value.subLevels.Values
                                     .Where(p => p.ShortName == shortName.ToUpper()))
                                     .Single().FullName;
                return result;
            }
            catch
            {
                return "UNKNOWN";
            }
        }

    }
}
