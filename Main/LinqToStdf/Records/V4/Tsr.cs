// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Test Synopsis Record [10-30] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the test execution and failure counts for one parametric or functional test in
    ///                           the test program.Also contains static information, such as test name.The TSR is
    ///                           related to the Functional Test Record (FTR), the Parametric Test Record (PTR), and the
    ///                           Multiple Parametric Test Record (MPR) by test number, head number, and site
    ///                           number.</br></para>
    ///     <para>Frequency: <br> * Obligatory, one for each test executed in the test program per Head and site.</br>
    ///                      <br> * Optional summary per test head and/or test site.</br>
    ///                      <br> * May optionally be used to identify unexecuted tests.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial sequence (see page 14) and before the MRR.
    ///                           When test data is being generated in real-time, these records will appear after the last PRR.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
    StringFieldLayout(FieldIndex = 2, Length = 1, MissingValue = " ", RecordProperty = "TestType", NameInSpec = "TEST_TYP"),
    FieldLayout(FieldIndex = 3, FieldType = typeof(uint), RecordProperty = "TestNumber", NameInSpec = "TEST_NUM"),
    FieldLayout(FieldIndex = 4, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "ExecutedCount", NameInSpec = "EXEC_CNT"),
    FieldLayout(FieldIndex = 5, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "FailedCount", NameInSpec = "FAIL_CNT"),
    FieldLayout(FieldIndex = 6, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "AlarmCount", NameInSpec = "ALRM_CNT"),
    StringFieldLayout(FieldIndex = 7, IsOptional = true, RecordProperty = "TestName", NameInSpec = "TEST_NAM"),
    StringFieldLayout(FieldIndex = 8, IsOptional = true, RecordProperty = "SequencerName", NameInSpec = "SEQ_NAME"),
    StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "TestLabel", NameInSpec = "TEST_LBL"),
    FieldLayout(FieldIndex = 10, IsOptional = true, FieldType = typeof(byte)/*, MissingValue = (byte)0xC8, RecordProperty = "OptionalFlags", NameInSpec = "OPT_FLAG"*/),
    FlaggedFieldLayout(FieldIndex = 11, FieldType = typeof(float), IsOptional = true, FlagIndex = 10, FlagMask = (byte)0x04, RecordProperty = "TestTime", NameInSpec = "TEST_TIM"),
    FlaggedFieldLayout(FieldIndex = 12, FieldType = typeof(float), IsOptional = true, FlagIndex = 10, FlagMask = (byte)0x01, RecordProperty = "TestMin", NameInSpec = "TEST_MIN"),
    FlaggedFieldLayout(FieldIndex = 13, FieldType = typeof(float), IsOptional = true, FlagIndex = 10, FlagMask = (byte)0x02, RecordProperty = "TestMax", NameInSpec = "TEST_MAX"),
    FlaggedFieldLayout(FieldIndex = 14, FieldType = typeof(float), IsOptional = true, FlagIndex = 10, FlagMask = (byte)0x10, RecordProperty = "TestSum", NameInSpec = "TST_SUMS"),
    FlaggedFieldLayout(FieldIndex = 15, FieldType = typeof(float), IsOptional = true, FlagIndex = 10, FlagMask = (byte)0x20, RecordProperty = "TestSumOfSquares", NameInSpec = "TST_SQRS")]
    public class Tsr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Test Synopsis Record";
        public override RecordType RecordType => new RecordType(10, 30);
        public byte? HeadNumber { get; set; }
        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <br>Test type</br>
        ///     <br>TEST_TYP (C*1)</br></summary>
        /// <remarks>Known values are: P(arametric test), F(unctional test), M(ultiple-result parametric test), or a space(Unknown) </remarks>
        public string? TestType { get; set; }

        /// <summary>
        ///     <br>Test number</br>
        ///     <br>TEST_NUM (U*4)</br>
        /// </summary>
        public uint TestNumber { get; set; }

        /// <summary>
        ///     <br>Number of test executions</br>
        ///     <br>EXEC_CNT (U*4)</br></summary>
        /// <remarks>is optional, but is strongly recommended because it is needed to compute
        ///          values for complete final summary sheets.</remarks>
        public uint? ExecutedCount { get; set; }

        /// <summary>
        ///     <br>Number of test failures</br>
        ///     <br>FAIL_CNT (U*4)</br></summary>
        /// <remarks>is optional, but is strongly recommended because it is needed to compute
        ///          values for complete final summary sheets.</remarks>
        public uint? FailedCount { get; set; }

        /// <summary>
        ///     <br>Number of alarmed tests</br>
        ///     <br>ALRM_CNT (U*4)</br></summary>
        /// <remarks>is optional, but is strongly recommended because it is needed to compute
        ///          values for complete final summary sheets.</remarks>
        public uint? AlarmCount { get; set; }

        /// <summary>
        ///     <br>Test name</br>
        ///     <br>TEST_NAM (C*n)</br>
        /// </summary>
        public string? TestName { get; set; }

        /// <summary>
        ///     <br>Sequencer (program segment/flow) name</br>
        ///     <br>SEQ_NAME (C*n)</br>
        /// </summary>
        public string? SequencerName { get; set; }

        /// <summary>
        ///     <br>Test label or text</br>
        ///     <br>TEST_LBL (C*n)</br>
        /// </summary>
        public string? TestLabel { get; set; }



        /// <summary>
        ///     <br>Optional data flag</br>
        ///     <br>OPT_FLAG (B*1)</br>
        /// </summary>
        /// <remarks>
        ///  <br>bit 0 set = TEST_MIN value is invalid</br>
        ///  <br>bit 1 set = TEST_MAX value is invalid</br>
        ///  <br>bit 2 set = TEST_TIM value is invalid</br>
        ///  <br>bit 3 is reserved for future use and must be 1</br>
        ///  <br>bit 4 set = TST_SUMS value is invalid</br>
        ///  <br>bit 5 set = TST_SQRS value is invalid</br>
        ///  <br>bits 6 - 7 are reserved for future use and must be 1</br>
        /// </remarks>
        
        //cant seem to get the round trip test working when i save this value
        //public byte? OptionalFlags { set; get; }


        /// <summary>
        ///     <br>Average test execution time in seconds</br>
        ///     <br>TEST_TIM (R*4)</br>
        /// </summary>
        public float? TestTime { get; set; }

        /// <summary>
        ///     <br>Lowest test result value</br>
        ///     <br>TEST_MIN (R*4)</br>
        /// </summary>
        public float? TestMin { get; set; }

        /// <summary>
        ///     <br>Highest test result value</br>
        ///     <br>TEST_MAX (R*4)</br>
        /// </summary>
        public float? TestMax { get; set; }

        /// <summary>
        ///     <br>Sum of test result values</br>
        ///     <br>TST_SUMS (R*4)</br></summary>
        /// <remarks>Useful in calculating the mean and standard deviation for a single lot or when
        ///          combining test data from multiple STDF files</remarks>
        public float? TestSum { get; set; }

        /// <summary>
        ///     <br>Sum of squares of test result values</br>
        ///     <br>TST_SQRS (R*4)</br></summary>
        /// <remarks>Useful in calculating the mean and standard deviation for a single lot or when
        ///          combining test data from multiple STDF files</remarks>
        public float? TestSumOfSquares { get; set; }
    }
}
