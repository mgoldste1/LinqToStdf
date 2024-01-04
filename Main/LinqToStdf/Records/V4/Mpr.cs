// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Multiple-Result Parametric Record [15-15] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the results of a single execution of a parametric test in the test program
    ///                           where that test returns multiple values.The first occurrence of this record also
    ///                           establishes the default values for all semi-static information about the test, such as
    ///                           limits, units, and scaling.The MPR is related to the Test Synopsis Record (TSR) by test
    ///                           number, head number, and site number.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per multiple-result parametric test execution on each head/site</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the corresponding Part Information Record (PIR)
    ///                           and before the corresponding Part Result Record (PRR).</br></para>
    ///     <para>Default Data:
    ///                     <br>  * All data beginning with the OPT_FLAG field has a special function in the STDF file. The
    ///                             first MPR for each test will have these fields filled in. These values will be the default
    ///                             for each subsequent MPR with the same test number: if a subsequent MPR has a value
    ///                             for one of these fields, it will be used instead of the default, for that one record only; if
    ///                             the field is blank, the default will be used. </br>
    ///                     <br>  * If the MPR is not associated with a test execution (that is, it contains only default
    ///                             information), bit 4 of the TEST_FLG field must be set, and the PARM_FLG field must be
    ///                             zero.</br>
    ///                     <br>  * Unless the default is being overridden, the default data fields should be omitted in
    ///                             order to save space in the file.</br>
    ///                     <br>  * Note that RES_SCAL, LLM_SCAL, HLM_SCAL, UNITS, C_RESFMT, C_LLMFMT, and
    ///                             C_HLMFMT are interdependent. If you are overriding the default value of one, make
    ///                             sure that you also make appropriate changes to the others in order to keep them
    ///                             consistent.</br>
    ///                     <br>  * For character strings, you can override the default with a null value by setting the
    ///                             string length to 1 and the string itself to a single binary 0. </br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(uint), RecordProperty = "TestNumber", NameInSpec = "TEST_NUM"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
     FieldLayout(FieldIndex = 2, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
     FieldLayout(FieldIndex = 3, FieldType = typeof(byte), RecordProperty = "TestFlags", NameInSpec = "TEST_FLG"),
     FieldLayout(FieldIndex = 4, FieldType = typeof(byte), RecordProperty = "ParametricFlags", NameInSpec = "PARM_FLG"),
     FieldLayout(FieldIndex = 5, FieldType = typeof(ushort), NameInSpec = "RTN_ICNT"), //likely need to add a variable so it can be updated when you update the record
     FieldLayout(FieldIndex = 6, FieldType = typeof(ushort), NameInSpec = "RSLT_CNT"), //likely need to add a variable so it can be updated when you update the record
     NibbleArrayFieldLayout(FieldIndex = 7, ArrayLengthFieldIndex = 5, RecordProperty = "PinStates", NameInSpec = "RTN_STAT"),
     ArrayFieldLayout(FieldIndex = 8, FieldType = typeof(float), ArrayLengthFieldIndex = 6, RecordProperty = "Results", NameInSpec = "RTN_RSLT"),
     StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "TestText", NameInSpec = "TEST_TXT"),
     StringFieldLayout(FieldIndex = 10, IsOptional = true, RecordProperty = "AlarmId", NameInSpec = "ALARM_ID"),
     FieldLayout(FieldIndex = 11, FieldType = typeof(byte), IsOptional = true, MissingValue = (byte)0xFF, RecordProperty = "OptionalFlags", NameInSpec = "OPT_FLAG"),
     FlaggedFieldLayout(FieldIndex = 12, FieldType = typeof(sbyte), FlagIndex = 11, FlagMask = (byte)0x01, MissingValue = (sbyte)0, RecordProperty = "ResultScalingExponent", NameInSpec = "RES_SCAL"),
     FlaggedFieldLayout(FieldIndex = 13, FieldType = typeof(sbyte), FlagIndex = 11, FlagMask = (byte)0x50, MissingValue = (sbyte)0, RecordProperty = "LowLimitScalingExponent", NameInSpec = "LLM_SCAL"),
     FlaggedFieldLayout(FieldIndex = 14, FieldType = typeof(sbyte), FlagIndex = 11, FlagMask = (byte)0xA0, MissingValue = (sbyte)0, RecordProperty = "HighLimitScalingExponent", NameInSpec = "HLM_SCAL"),
     FlaggedFieldLayout(FieldIndex = 15, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0x50, MissingValue = Single.NegativeInfinity, RecordProperty = "LowLimit", NameInSpec = "LO_LIMIT"),
     FlaggedFieldLayout(FieldIndex = 16, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0xA0, MissingValue = Single.PositiveInfinity, RecordProperty = "HighLimit", NameInSpec = "HI_LIMIT"),
     FlaggedFieldLayout(FieldIndex = 17, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0x02, MissingValue = (float)0, RecordProperty = "StartingCondition", NameInSpec = "START_IN"),
     FlaggedFieldLayout(FieldIndex = 18, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0x02, MissingValue = (float)0, RecordProperty = "ConditionIncrement", NameInSpec = "INCR_IN"),
     ArrayFieldLayout(FieldIndex = 19, FieldType = typeof(ushort), IsOptional = true, MissingValue = (ushort)0, ArrayLengthFieldIndex = 5, RecordProperty = "PinIndexes", NameInSpec = "RTN_INDX"),
     StringFieldLayout(FieldIndex = 20, IsOptional = true, RecordProperty = "Units", NameInSpec = "UNITS"),
     StringFieldLayout(FieldIndex = 21, IsOptional = true, RecordProperty = "IncrementUnits", NameInSpec = "UNITS_IN"),
     StringFieldLayout(FieldIndex = 22, IsOptional = true, RecordProperty = "ResultFormatString", NameInSpec = "C_RESFMT"),
     StringFieldLayout(FieldIndex = 23, IsOptional = true, RecordProperty = "LowLimitFormatString", NameInSpec = "C_LLMFMT"),
     StringFieldLayout(FieldIndex = 24, IsOptional = true, RecordProperty = "HighLimitFormatString", NameInSpec = "C_HLMFMT"),
     FlaggedFieldLayout(FieldIndex = 25, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0x04, MissingValue = Single.NegativeInfinity, RecordProperty = "LowSpecLimit", NameInSpec = "LO_SPEC"),
     FlaggedFieldLayout(FieldIndex = 26, FieldType = typeof(float), FlagIndex = 11, FlagMask = (byte)0x08, MissingValue = Single.PositiveInfinity, RecordProperty = "HighSpecLimit", NameInSpec = "HI_SPEC")]
    public class Mpr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Multiple-Result Parametric Record";
        public override RecordType RecordType => new RecordType(15, 15);

        /// <summary>
        ///     <br>Test number</br>
        ///     <br>TEST_NUM (U*4)</br></summary>
        /// <remarks>The test number does not implicitly increment for successive values in the result array.</remarks>
        public uint TestNumber { get; set; }


        public byte? HeadNumber { get; set; }

        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <br>Test flags (fail, alarm, etc.)</br>
        ///     <br>TEST_FLG (B*1)</br></summary>
        /// <remarks><para>Contains the following fields:
        ///     <br>bit 0: 0 = No alarm; 1 = Alarm detected during testing</br>
        ///     <br>bit 1: Reserved for future use. Must be zero</br>
        ///     <br>bit 2: 0 = Test results are reliable; 1 = Test results are unreliable</br>
        ///     <br>bit 3: 0 = No timeout; 1 = Timeout occurred</br>
        ///     <br>bit 4: 0 = Test was executed; 1 = Test not executed</br>
        ///     <br>bit 5: 0 = No abort; 1 = Test aborted</br>
        ///     <br>bit 6: 0 = Pass/fail flag (bit 7) is valid;  1 = Test completed with no pass/fail indication</br>
        ///     <br>bit 7: 0 = Test passed; 1 = Test failed</br></para>
        /// </remarks>
        public byte TestFlags { get; set; }

        /// <summary>
        ///     <br>Parametric test flags (drift, etc.)</br>
        ///     <br>PARM_FLG (B*1)</br></summary>
        /// <remarks><para>Is the parametric flag field, and contains the following bits:
        ///                 <br>bit 0: 0 = No scale error; 1 = Scale error</br>
        ///                 <br>bit 1: 0 = No drift error; 1 = Drift error (unstable measurement)</br>
        ///                 <br>bit 2: 0 = No oscillation; 1 = Oscillation detected</br>
        ///                 <br>bit 3: 0 = Measured value not high; 1 = Measured value higher than high test limit</br>
        ///                 <br>bit 4: 0 = Measured value not low; 1 = Measured value lower than low test limit</br>
        ///                 <br>bit 5: 0 = Test failed or test passed standard limits; 1 = Test passed alternate limits</br>
        ///                 <br>bit 6: 0 = If result = low limit, then result is “fail.”; 1 = If result = low limit, then result is “pass.”</br>
        ///                 <br>bit 7: 0 = If result = high limit, then result is “fail.”; 1 = If result = high limit, then result is “pass.”</br></para></remarks>
        public byte ParametricFlags { get; set; }

        //RTN_ICNT U*2 Count (j) of PMR indexes See note
        //RSLT_CNT U*2 Count(k) of returned results See note


        /// <summary>
        ///     <br>Array of returned states</br>
        ///     <br>RTN_STAT (jxN*1)</br></summary>
        /// <remarks>The number of element in the RTN_INDX and RTN_STAT arrays is determined by the
        ///          value of RTN_ICNT. The RTN_STAT field is stored 4 bits per value. The first value is
        ///          stored in the low order 4 bits of the byte. If the number of indexes is odd, the high order
        ///          4 bits of the last byte in RTN_STAT will be padded with zero. The indexes referred to in
        ///          the RTN_INDX are the PMR indexes defined in the Pin Map Record (PMR). The return
        ///          state codes are the same as those defined for the RTN_STAT field in the FTR.
        ///          RTN_ICNT may be omitted if it is zero and it is the last field in the record.</remarks>

        public byte[]? PinStates { get; set; }

        /// <summary>
        ///     <br>Array of returned results</br>
        ///     <br>RTN_RSLT (kxR*4)</br> </summary>
        /// <remarks>RSLT_CNT defines the number of parametric test results in the RTN_RSLT. If this is a
        ///          multiple pin measurement, and if PMR indexes will be specified, then the value of
        ///          RSLT_CNT should be the same as RTN_ICNT. RTN_RSLT is an array of the parametric
        ///          test result values. RSLT_CNT may be omitted if it is zero and it is the last field in the record</remarks>
        public float[]? Results { get; set; }

        /// <summary>
        ///     <br>Descriptive text or label</br>
        ///     <br>TEST_TXT (C*n)</br>
        /// </summary>
        public string? TestText { get; set; }

        /// <summary>
        ///     <br>Name of alarm</br>
        ///     <br>ALARM_ID (C*n)</br></summary>
        /// <remarks>If the alarm flag (bit 0 of TEST_FLG) is set, this field can contain the name or ID of the
        ///          alarms that were triggered. Alarm names are tester-dependent.</remarks>
        public string? AlarmId { get; set; }

        /// <summary>
        ///     <br>Optional data flag</br>
        ///     <br>OPT_FLAG (B*1)</br></summary>
        /// <remarks>
        ///          Is the Optional Data Flag and contains the following bits:
        ///          <br>bit 0 set = RES_SCAL value is invalid. The default set by the first MPR with this test
        ///              number will be used.</br>
        ///          <br>bit 1 set = START_IN and INCR_IN are invalid.</br>
        ///          <br>bit 2 set = No low specification limit.</br>
        ///          <br>bit 3 set = No high specification limit.</br>
        ///          <br>bit 4 set = LO_LIMIT and LLM_SCAL are invalid. The default values set for these fields
        ///              in the first MPR with this test number will be used.</br>
        ///          <br>bit 5 set = HI_LIMIT and HLM_SCAL are invalid. The default values set for these fields
        ///              in the first MPR with this test number will be used.</br>
        ///          <br>bit 6 set = No Low Limit for this test (LO_LIMIT and LLM_SCAL are invalid).</br>
        ///          <br>bit 7 set = No High Limit for this test (HI_LIMIT and HLM_SCAL are invalid).</br>
        ///          <para>The OPT_FLAG field may be omitted if it is the last field in the record</para></remarks>
        public byte? OptionalFlags { get; set; }

        /// <summary>
        ///     <br>Test result scaling exponent</br>
        ///     <br>RES_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 0 = 1</br>
        ///          <br>Known values are: 15, 12, 9, 6, 3, 2, 0, -3, -6, -9, -12</br></remarks>
        public sbyte? ResultScalingExponent { get; set; }

        /// <summary>
        ///     <br>Test low limit scaling exponent</br>
        ///     <br>LLM_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 4 or 6 = 1</br>
        ///          <br>Known values are: 15, 12, 9, 6, 3, 2, 0, -3, -6, -9, -12</br></remarks>
        public sbyte? LowLimitScalingExponent { get; set; }

        /// <summary>
        ///     <br>Test high limit scaling exponent</br>
        ///     <br>HLM_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 5 or 7 = 1</br>
        ///          <br>Known values are: 15, 12, 9, 6, 3, 2, 0, -3, -6, -9, -12</br></remarks>
        /// 
        public sbyte? HighLimitScalingExponent { get; set; }

        /// <summary>
        ///     <br>Test low limit value</br>
        ///     <br>LO_LIMIT (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 4 or 6 = 1</remarks>
        public float? LowLimit { get; set; }

        /// <summary>
        ///     <br>Test high limit value</br>
        ///     <br>HI_LIMIT (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 5 or 7 = 1</remarks>
        public float? HighLimit { get; set; }

        /// <summary>
        ///     <br>Starting input value (condition)</br>
        ///     <br>START_IN (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 1 = 1</remarks>
        public float? StartingCondition { get; set; }

        /// <summary>
        ///     <br>Increment of input condition</br>
        ///     <br>INCR_IN (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 1 = 1</remarks>
        public float? ConditionIncrement { get; set; }

        /// <summary>
        ///     <br>Array of PMR indexes</br>
        ///     <br>RTN_INDX (jxU*2)</br>
        /// </summary>
        public ushort[]? PinIndexes { get; set; }

        /// <summary>
        ///     <br>Units of returned results</br>
        ///     <br>UNITS (C*n)</br>
        /// </summary>
        public string? Units { get; set; }

        /// <summary>
        ///     <br>Input condition units</br>
        ///     <br>UNITS_IN (C*n)</br>
        /// </summary>
        // TODO: is this variable name right? similar to what should be here but different
        public string? IncrementUnits { get; set; }

        /// <summary>
        ///     <br>ANSI C result format string</br>
        ///     <br>C_RESFMT (C*n)</br>
        /// </summary>
        public string? ResultFormatString { get; set; }

        /// <summary>
        ///     <br>ANSI C low limit format string</br>
        ///     <br>C_LLMFMT (C*n)</br>
        /// </summary>
        public string? LowLimitFormatString { get; set; }

        /// <summary>
        ///     <br>ANSI C high limit format string</br>
        ///     <br>C_HLMFMT (C*n)</br>
        /// </summary>
        public string? HighLimitFormatString { get; set; }

        /// <summary>
        ///     <br>Low specification limit value</br>
        ///     <br>LO_SPEC (R*4)</br></summary>
        /// <remarks><br>OPT_FLAG bit 2 = 1</br>
        ///     <br>The specification limits are set in the first MPR and should never change. 
        ///         They use the same scaling and format strings as the corresponding test limits.</br></remarks>
        public float? LowSpecLimit { get; set; }

        /// <summary>
        ///     <br>High specification limit value</br>
        ///     <br>HI_SPEC (R*4)</br></summary>
        /// <remarks><br>OPT_FLAG bit 2 = 1</br>
        ///          <br>The specification limits are set in the first MPR and should never change. 
        ///              They use the same scaling and format strings as the corresponding test limits.</br></remarks>
        public float? HighSpecLimit { get; set; }
    }
}
