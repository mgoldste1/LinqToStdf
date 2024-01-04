// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Parametric Test Record [15-10] </summary>
    ///<remarks>
    ///     <para>Function:  <br>   Contains the results of a single execution of a parametric test in the test program.The
    ///                             first occurrence of this record also establishes the default values for all semi-static
    ///                             information about the test, such as limits, units, and scaling.The PTR is related to the
    ///                             Test Synopsis Record (TSR) by test number, head number, and site number.</br></para>
    ///     <para>Frequency: <br> * Obligatory, one per parametric test execution on each head/site</br></para>
    ///     <para>Location:  <br> * Under normal circumstances, the PTR can appear anywhere in the data stream after
    ///                             the corresponding Part Information Record (PIR) and before the corresponding Part
    ///                             Result Record (PRR).</br>
    ///                      <br> * In addition, to facilitate conversion from STDF V3, if the first PTR for a test contains
    ///                             default information only (no test results), it may appear anywhere after the initial
    ///                             "FAR-(ATRs)-MIR-(RDR)-(SDRs)" sequence, and before the first corresponding PTR, but need not appear
    ///                             between a PIR and PRR.</br></para>
    ///     <para>Default Data: 
    ///                      <br> * All data following the OPT_FLAG field has a special function in the STDF file. The first
    ///                             PTR for each test will have these fields filled in. These values will be the default for each
    ///                             subsequent PTR with the same test number: if a subsequent PTR has a value for one of
    ///                             these fields, it will be used instead of the default, for that one record only; if the field is
    ///                             blank, the default will be used.This method replaces use of the PDR in STDF V3.</br>
    ///                      <br> * If the PTR is not associated with a test execution (that is, it contains only default
    ///                             information), bit 4 of the TEST_FLG field must be set, and the PARM_FLG field must be zero.</br>
    ///                      <br> * Unless the default is being overridden, the default data fields should be omitted in
    ///                             order to save space in the file.</br>
    ///                      <br> * Note that RES_SCAL, LLM_SCAL, HLM_SCAL, UNITS, C_RESFMT, C_LLMFMT, and
    ///                             C_HLMFMT are interdependent. If you are overriding the default value of one, make
    ///                             sure that you also make appropriate changes to the others in order to keep them
    ///                             consistent.</br>
    ///                      <br> * For character strings, you can override the default with a null value by setting the
    ///                             string length to 1 and the string itself to a single binary 0.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(uint), RecordProperty = "TestNumber", NameInSpec = "TEST_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 2, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
    FieldLayout(FieldIndex = 3, FieldType = typeof(byte), RecordProperty = "TestFlags", NameInSpec = "TEST_FLG"),
    FieldLayout(FieldIndex = 4, FieldType = typeof(byte), RecordProperty = "ParametricFlags", NameInSpec = "PARM_FLG"),
    //NOTE: The FlaggedFieldLayout takes into account the test flag that determines if the result is valid.
    //If that bit says it is not valid, this sets the result to null instead of the value in the result field.
    //IMO this is preferable, but in some cases you might want to get the value in the result anyways.
    //In that case comment out the next line and uncomment the line after that.  Round trip test case will break.
    FlaggedFieldLayout(FieldIndex = 5, FieldType = typeof(float), FlagIndex = 3, FlagMask = (byte)0x02, MissingValue = (float)0, RecordProperty = "Result", NameInSpec = "RESULT"),
    //FieldLayout(FieldIndex = 5, FieldType = typeof(float), MissingValue = (float)0, PersistMissingValue = true, RecordProperty = "Result", NameInSpec = "RESULT"),
    StringFieldLayout(FieldIndex = 6, IsOptional = true, RecordProperty = "TestText", NameInSpec = "TEST_TXT"),
    StringFieldLayout(FieldIndex = 7, IsOptional = true, RecordProperty = "AlarmId", NameInSpec = "ALARM_ID"),
    FieldLayout(FieldIndex = 8, FieldType = typeof(byte), IsOptional = true, MissingValue = (byte)0x02, RecordProperty = "OptionalFlags", NameInSpec = "OPT_FLAG"),
    FlaggedFieldLayout(FieldIndex = 9, FieldType = typeof(sbyte), FlagIndex = 8, FlagMask = (byte)0x01, MissingValue = (sbyte)0, RecordProperty = "ResultScalingExponent", NameInSpec = "RES_SCAL"),
    FlaggedFieldLayout(FieldIndex = 10, FieldType = typeof(sbyte), FlagIndex = 8, FlagMask = (byte)0x50, MissingValue = (sbyte)0, RecordProperty = "LowLimitScalingExponent", NameInSpec = "LLM_SCAL"),
    FlaggedFieldLayout(FieldIndex = 11, FieldType = typeof(sbyte), FlagIndex = 8, FlagMask = (byte)0xA0, MissingValue = (sbyte)0, RecordProperty = "HighLimitScalingExponent", NameInSpec = "HLM_SCAL"),
    FlaggedFieldLayout(FieldIndex = 12, FieldType = typeof(float), FlagIndex = 8, FlagMask = (byte)0x50, MissingValue = (float)0, RecordProperty = "LowLimit", NameInSpec = "LO_LIMIT"),
    FlaggedFieldLayout(FieldIndex = 13, FieldType = typeof(float), FlagIndex = 8, FlagMask = (byte)0xA0, MissingValue = (float)0, RecordProperty = "HighLimit", NameInSpec = "HI_LIMIT"),
    StringFieldLayout(FieldIndex = 14, IsOptional = true, RecordProperty = "Units", NameInSpec = "UNITS"),
    StringFieldLayout(FieldIndex = 15, IsOptional = true, RecordProperty = "ResultFormatString", NameInSpec = "C_RESFMT"),
    StringFieldLayout(FieldIndex = 16, IsOptional = true, RecordProperty = "LowLimitFormatString", NameInSpec = "C_LLMFMT"),
    StringFieldLayout(FieldIndex = 17, IsOptional = true, RecordProperty = "HighLimitFormatString", NameInSpec = "C_HLMFMT"),
    FlaggedFieldLayout(FieldIndex = 18, FieldType = typeof(float), FlagIndex = 8, FlagMask = (byte)0x04, MissingValue = (float)0, RecordProperty = "LowSpecLimit", NameInSpec = "LO_SPEC"),
    FlaggedFieldLayout(FieldIndex = 19, FieldType = typeof(float), FlagIndex = 8, FlagMask = (byte)0x08, MissingValue = (float)0, RecordProperty = "HighSpecLimit", NameInSpec = "HI_SPEC")]
    public class Ptr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Parametric Test Record";
        public override RecordType RecordType => new RecordType(15, 10);

        /// <summary>
        ///     <br>Test number</br>
        ///     <br>TEST_NUM (U*4)</br></summary>
        /// <remarks>The test number does not implicitly increment for successive values in the result array.</remarks>
        public uint TestNumber { get; set; }


        public byte? HeadNumber { get; set; }
        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <br>Test flags (fail, alarm, etc.)</br>
        ///     <br>TEST_FLG (B*1)</br>
        /// </summary>
        /// <remarks>
        /// <br>bit 0: 0 = No alarm;
        ///            1 = Alarm detected during testing</br>
        /// <br>bit 1: 0 = The value in the RESULT field is valid (see note on RESULT);
        ///            1 = The value in the RESULT field is not valid.This setting indicates that the
        ///                test was executed, but no datalogged value was taken. You should read
        ///                bits 6 and 7 of TEST_FLG to determine if the test passed or failed.</br>
        /// <br>bit 2: 0 = Test result is reliable;
        ///            1 = Test result is unreliable</br>
        /// <br>bit 3: 0 = No timeout;
        ///            1 = Timeout occurred</br>
        /// <br>bit 4: 0 = Test was executed;
        ///            1 = Test not executed</br>
        /// <br>bit 5: 0 = No abort;
        ///            1 = Test aborted</br>
        /// <br>bit 6: 0 = Pass/fail flag (bit 7) is valid;
        ///            1 = Test completed with no pass/fail indication</br>
        /// <br>bit 7: 0 = Test passed;
        ///            1 = Test failed</br>
        /// </remarks>
        public byte TestFlags { get; set; }

        /// <summary>
        ///     <br>Parametric test flags (drift, etc.)</br>
        ///     <br>PARM_FLG (B*1)</br>
        /// </summary>
        /// <remarks>
        /// <br>bit 0: 0 = No scale error;
        ///		       1 = Scale error</br>
        /// <br>bit 1: 0 = No drift error;
        ///            1 = Drift error (unstable measurement)</br>
        /// <br>bit 2: 0 = No oscillation;
        ///	   		   1 = Oscillation detected</br>
        /// <br>bit 3: 0 = Measured value not high;
        ///			   1 = Measured value higher than high test limit</br>
        /// <br>bit 4: 0 = Measured value not low;
        ///			   1 = Measured value lower than low test limit</br>
        /// <br>bit 5: 0 = Test failed or test passed standard limits;
        ///			   1 = Test passed alternate limits</br>
        /// <br>bit 6: 0 = If result = low limit, then result is “fail.”;
        ///			   1 = If result = low limit, then result is “pass.”</br>
        /// <br>bit 7: 0 = If result = high limit, then result is “fail.”;
        ///			   1 = If result = high limit, then result is “pass."</br></remarks>
        public byte ParametricFlags { get; set; }

        /// <summary>
        ///     <br>Test result</br>
        ///     <br>RESULT (R*4)</br>
        /// </summary>
        /// <remarks>TEST_FLG bit 1 = 1</remarks>
        public float? Result { get; set; }

        /// <summary>
        ///     <br>Test description text or label</br>
        ///     <br>TEST_TXT (C*n)</br>
        /// </summary>
        public string? TestText { get; set; }

        /// <summary>
        ///     <br>Name of alarm</br>
        ///     <br>ALARM_ID (C*n)</br>
        /// </summary>
        public string? AlarmId { get; set; }

        /// <summary>
        ///     <br>Optional data flag</br>
        ///     <br>OPT_FLAG (B*1)</br>
        ///     <br>The OPT_FLAG field may be omitted if it is the last field in the record.</br>
        /// </summary>
        /// <remarks>
        ///     <br>bit 0 set = RES_SCAL value is invalid.The default set by the first PTR with this test number will be used.</br>
        ///     <br>bit 1 reserved for future used and must be 1.</br>
        ///     <br>bit 2 set = No low specification limit.</br>
        ///     <br>bit 3 set = No high specification limit.</br>
        ///     <br>bit 4 set = LO_LIMIT and LLM_SCAL are invalid. The default values set for these fields in the first PTR with this test number will be used.</br>
        ///     <br>bit 5 set = HI_LIMIT and HLM_SCAL are invalid. The default values set for these fields in the first PTR with this test number will be used.</br>
        ///     <br>bit 6 set = No Low Limit for this test (LO_LIMIT and LLM_SCAL are invalid).</br>
        ///     <br>bit 7 set = No High Limit for this test(HI_LIMIT and HLM_SCAL are invalid).</br>
        /// </remarks>
        public byte? OptionalFlags { set; get; }

        /// <summary>
        ///     <br>Test results scaling exponent</br>
        ///     <br>RES_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 0 = 1</br>
        ///          <br>Known values are: 15(femto), 12(pico), 9(nano), 6(micro), 3(milli), 2(percent), 0, -3(Kilo), -6(Mega), -9(Giga), -12(Tera)</br></remarks>
        public sbyte? ResultScalingExponent { get; set; }

        /// <summary>
        ///     <br>Low limit scaling exponent</br>
        ///     <br>LLM_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 4 or 6 = 1</br>
        ///          <br>Known values are: 15(femto), 12(pico), 9(nano), 6(micro), 3(milli), 2(percent), 0, -3(Kilo), -6(Mega), -9(Giga), -12(Tera)</br></remarks>
        public sbyte? LowLimitScalingExponent { get; set; }

        /// <summary>
        ///     <br>High limit scaling exponent</br>
        ///     <br>HLM_SCAL (I*1)</br></summary>
        /// <remarks><br>OPT_FLAG bit 5 or 7 = 1</br>
        ///          <br>Known values are: 15(femto), 12(pico), 9(nano), 6(micro), 3(milli), 2(percent), 0, -3(Kilo), -6(Mega), -9(Giga), -12(Tera)</br></remarks>
        public sbyte? HighLimitScalingExponent { get; set; }

        /// <summary>
        ///     <br>Low test limit value</br>
        ///     <br>LO_LIMIT (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 4 or 6 = 1</remarks>
        public float? LowLimit { get; set; }

        /// <summary>
        ///     <br>High test limit value</br>
        ///     <br>HI_LIMIT (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 5 or 7 = 1</remarks>
        public float? HighLimit { get; set; }

        /// <summary>
        ///     <br>Test units</br>
        ///     <br>UNITS (C*n)</br></summary>
        /// <remarks><para>The values stored as RESULT, LO_LIMIT, HI_LIMIT, LO_SPEC, and HI_SPEC are all normalized to the base
        ///                unit stored as UNITS.The UNITS text string indicates base (whole) units only, with no scaling factor: for
        ///                example, UNITS may be “AMPS” or “VOLTS” but never “uAMPS” or “mVOLTS”. Therefore, the UNITS value
        ///                provides enough information to represent the stored result or limit.In addition, because of this
        ///                normalization, arithmetic can be performed directly on any values for which the UNITS fields agree.</para>
        ///          <para>In displaying a result or limit, however, it is sometimes desirable to use a scale other than the base
        ///                units: for example, “uAMPS” rather than “AMPS”. It is also desirable to indicate the precision to which
        ///                the value was measured. Scaling and precision are indicated by using additional fields.</para>
        ///          <para>Scaling uses the RES_SCAL, LLM_SCAL and HLM_SCAL fields. The _SCAL value is an integer that
        ///                indicates the power of ten of the scaling factor:
        ///                <br>* scaled result = RESULT * (10 ** RES_SCAL)</br>
        ///                <br>* scaled low limit = LO_LIMIT * (10 ** LLM_SCAL</br>
        ///                <br>* scaled high limit = HI_LIMIT * (10 ** HLM_SCAL)</br></para></remarks>
        public string? Units { get; set; }

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
        /// <remarks>OPT_FLAG bit 2 = 1</remarks>
        public float? LowSpecLimit { get; set; }

        /// <summary>
        ///     <br>High specification limit value</br>
        ///     <br>HI_SPEC (R*4)</br></summary>
        /// <remarks>OPT_FLAG bit 3 = 1</remarks>
        public float? HighSpecLimit { get; set; }
    }
}
