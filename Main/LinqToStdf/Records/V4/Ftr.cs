// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;
    using System.Collections;

    ///<summary> Functional Test Record [15-20] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the results of the single execution of a functional test in the test program.The
    ///                           first occurrence of this record also establishes the default values for all semi-static
    ///                           information about the test.The FTR is related to the Test Synopsis Record (TSR) by test
    ///                           number, head number, and site number.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One or more for each execution of a functional test.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the corresponding Part Information Record (PIR)
    ///                           and before the corresponding Part Result Record (PRR).</br></para>
    ///     <para>Default Data:
    ///                      <br>   * All data starting with the PATG_NUM field has a special function in the STDF file. The
    ///                               for each subsequent FTR with the same test number.If a subsequent FTR has a value
    ///                               for one of these fields, it will be used instead of the default, for that one record only. If
    ///                               the field is blank, the default will be used.This method replaces use of the FDR in STDF V3.</br>
    ///                      <br>   * Unless the default is being overridden, the default data fields should be omitted in
    ///                               order to save space in the file. </br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(uint), RecordProperty = "TestNumber", NameInSpec = "TEST_NUM"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
     FieldLayout(FieldIndex = 2, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
     FieldLayout(FieldIndex = 3, FieldType = typeof(byte), RecordProperty = "TestFlags", NameInSpec = "TEST_FLG"),
     FieldLayout(FieldIndex = 4, FieldType = typeof(byte), IsOptional = true, MissingValue = (byte)0, RecordProperty = "OptionalFlags", NameInSpec = "OPT_FLAG"),
     FlaggedFieldLayout(FieldIndex = 5, FieldType = typeof(uint), FlagIndex = 4, FlagMask = (byte)0x01, RecordProperty = "CycleCount", NameInSpec = "CYCL_CNT"),
     FlaggedFieldLayout(FieldIndex = 6, FieldType = typeof(uint), FlagIndex = 4, FlagMask = (byte)0x02, RecordProperty = "RelativeVectorAddress", NameInSpec = "REL_VADR"),
     FlaggedFieldLayout(FieldIndex = 7, FieldType = typeof(uint), FlagIndex = 4, FlagMask = (byte)0x04, RecordProperty = "RepeatCount", NameInSpec = "REPT_CNT"),
     FlaggedFieldLayout(FieldIndex = 8, FieldType = typeof(uint), FlagIndex = 4, FlagMask = (byte)0x08, RecordProperty = "FailingPinCount", NameInSpec = "NUM_FAIL"),
     FlaggedFieldLayout(FieldIndex = 9, FieldType = typeof(int), FlagIndex = 4, FlagMask = (byte)0x10, RecordProperty = "XFailureAddress", NameInSpec = "XFAIL_AD"),
     FlaggedFieldLayout(FieldIndex = 10, FieldType = typeof(int), FlagIndex = 4, FlagMask = (byte)0x10, RecordProperty = "YFailureAddress", NameInSpec = "YFAIL_AD"),
     FlaggedFieldLayout(FieldIndex = 11, FieldType = typeof(short), FlagIndex = 4, FlagMask = (byte)0x20, RecordProperty = "VectorOffset", NameInSpec = "VECT_OFF"),
     FieldLayout(FieldIndex = 12, FieldType = typeof(ushort), IsOptional = true, MissingValue = (ushort)0, NameInSpec = "RTN_ICNT"),
     FieldLayout(FieldIndex = 13, FieldType = typeof(ushort), IsOptional = true, MissingValue = (ushort)0, NameInSpec = "PGM_ICNT"),
     ArrayFieldLayout(FieldIndex = 14, FieldType = typeof(ushort), ArrayLengthFieldIndex = 12, RecordProperty = "ReturnIndexes", NameInSpec = "RTN_INDX"),
     NibbleArrayFieldLayout(FieldIndex = 15, ArrayLengthFieldIndex = 12, RecordProperty = "ReturnStates", NameInSpec = "RTN_STAT"),
     ArrayFieldLayout(FieldIndex = 16, FieldType = typeof(ushort), ArrayLengthFieldIndex = 13, RecordProperty = "ProgrammedIndexes", NameInSpec = "PGM_INDX"),
     NibbleArrayFieldLayout(FieldIndex = 17, ArrayLengthFieldIndex = 13, RecordProperty = "ProgrammedStates", NameInSpec = "PGM_STAT"),
     FieldLayout(FieldIndex = 18, FieldType = typeof(BitArray), IsOptional = true, RecordProperty = "FailingPinBitfield", NameInSpec = "FAIL_PIN"),
     StringFieldLayout(FieldIndex = 19, IsOptional = true, RecordProperty = "VectorName", NameInSpec = "VECT_NAM"),
     StringFieldLayout(FieldIndex = 20, IsOptional = true, RecordProperty = "TimeSet", NameInSpec = "TIME_SET"),
     StringFieldLayout(FieldIndex = 21, IsOptional = true, RecordProperty = "OpCode", NameInSpec = "OP_CODE"),
     StringFieldLayout(FieldIndex = 22, IsOptional = true, RecordProperty = "TestText", NameInSpec = "TEST_TXT"),
     StringFieldLayout(FieldIndex = 23, IsOptional = true, RecordProperty = "AlarmId", NameInSpec = "ALARM_ID"),
     StringFieldLayout(FieldIndex = 24, IsOptional = true, RecordProperty = "ProgrammedText", NameInSpec = "PROG_TXT"),
     StringFieldLayout(FieldIndex = 25, IsOptional = true, RecordProperty = "ResultText", NameInSpec = "RSLT_TXT"),
     FieldLayout(FieldIndex = 26, FieldType = typeof(byte), IsOptional = true, MissingValue = Byte.MaxValue, RecordProperty = "PatternGeneratorNumber", NameInSpec = "PATG_NUM"),
     FieldLayout(FieldIndex = 27, FieldType = typeof(BitArray), IsOptional = true, RecordProperty = "SpinMap", NameInSpec = "SPIN_MAP")]
    public class Ftr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Functional Test Record";
        public override RecordType RecordType => new RecordType(15, 20);

        /// <summary>
        ///     <para>Test number</para>
        ///     <para>TEST_NUM (U*4)</para>
        /// </summary>
        public uint TestNumber { get; set; }


        public byte? HeadNumber { get; set; }

        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <para>Test flags (fail, alarm, etc.)</para>
        ///     <para>TEST_FLG (B*1)</para></summary>
        /// <remarks><para>Contains the following fields:</para>
        ///          <para>bit 0: 0 = No alarm; 1 = Alarm detected during testing</para>
        ///          <para>bit 1: Reserved for future use — must be 0</para>
        ///          <para>bit 2: 0 = Test result is reliable; 1 = Test result is unreliable</para>
        ///          <para>bit 3: 0 = No timeout; 1 = Timeout occurred</para>
        ///          <para>bit 4: 0 = Test was executed; 1 = Test not executed</para>
        ///          <para>bit 5: 0 = No abort; 1 = Test aborted</para>
        ///          <para>bit 6: 0 = Pass/fail flag (bit 7) is valid; 1 = Test completed with no pass/fail indication</para>
        ///          <para>bit 7: 0 = Test passed; 1 = Test failed</para> </remarks>
        public byte TestFlags { get; set; }

        /// <summary>
        ///     <br>Optional data flag</br>
        ///     <br>OPT_FLAG (B*1)</br>
        ///     <br>This field is only optional if it is the last field in the record.</br>
        /// </summary>
        /// <remarks>
        ///  <br>bit 0 set = CYCL_CNT data is invalid</br>
        ///  <br>bit 1 set = REL_VADR data is invalid</br>
        ///  <br>bit 2 set = REPT_CNT data is invalid</br>
        ///  <br>bit 3 set = NUM_FAIL data is invalid</br>
        ///  <br>bit 4 set = XFAIL_AD and YFAIL_AD data are invalid</br>
        ///  <br>bit 5 set = VECT_OFF data is invalid(offset defaults to 0)</br>
        ///  <br>bits 6 - 7 are reserved for future use and must be 1</br>
        /// </remarks>
        public byte? OptionalFlags { set; get; }


        /// <summary>
        ///     <para>Cycle count of vector</para>
        ///     <para>CYCL_CNT (U*4)</para>
        ///     <para>OPT_FLAG bit 0 = 1</para>
        /// </summary>
        public uint? CycleCount { get; set; }

        /// <summary>
        ///     <para>Relative vector address</para>
        ///     <para>REL_VADR (U*4)</para>
        ///     <para>OPT_FLAG bit 1 = 1</para>
        /// </summary>
        public uint? RelativeVectorAddress { get; set; }

        /// <summary>
        ///     <para>Repeat count of vector</para>
        ///     <para>REPT_CNT (U*4)</para>
        ///     <para>OPT_FLAG bit 2 = 1</para>
        /// </summary>
        public uint? RepeatCount { get; set; }

        /// <summary>
        ///     <para>Number of pins with 1 or more failures</para>
        ///     <para>NUM_FAIL (U*4)</para>
        ///     <para>OPT_FLAG bit 3 = 1</para>
        /// </summary>
		public uint? FailingPinCount { get; set; }
        /// <summary>
        ///     <para>X logical device failure address</para>
        ///     <para>XFAIL_AD (I*4)</para>
        ///     <para>OPT_FLAG bit 4 = 1</para></summary>
        /// <remarks>The logical device address produced by the memory pattern generator, before going
        ///          through conversion to a physical memory address.This logical address can be different
        ///          from the physical address presented to the DUT pins.</remarks>
		public int? XFailureAddress { get; set; }
        /// <summary>
        ///     <para>Y logical device failure address</para>
        ///     <para>YFAIL_AD (I*4)</para>
        ///     <para>OPT_FLAG bit 4 = 1</para></summary>
        /// <remarks>The logical device address produced by the memory pattern generator, before going
        ///          through conversion to a physical memory address.This logical address can be different
        ///          from the physical address presented to the DUT pins.</remarks>
		public int? YFailureAddress { get; set; }

        /// <summary>
        ///     <para>Offset from vector of interest</para>
        ///     <para>VECT_OFF (I*2)</para>
        ///     <para>OPT_FLAG bit 5 = 1</para></summary>
        /// <remarks>This is the integer offset of this vector (in sequence of execution) from the vector of 
        ///          interest(usually the failing vector). For example, if this FTR contains data for the vector before 
        ///          the vector of interest, this field is set to -1. If this FTR contains data for the third vector after 
        ///          the vector of interest, this field is set to 3. If this FTR is the vector of interest, VECT_OFF is set to 0. 
        ///          It is therefore possible to record an entire sequence of vectors around a failing vector for use with an 
        ///          offline debugger or analysis program.</remarks>
        public short? VectorOffset { get; set; }

        //These fields may be omitted if all data following them is missing or invalid:
        //RTN_ICNT: Count (j) of return data PMR indexes (U*2)
        //PGM_ICNT: Count (k) of programmed state indexes  (U*2)

        /// <summary>
        /// <para>Array of programmed state indexes</para>
        /// <para>PGM_INDX (jxU*2)</para></summary>
        /// <remarks>The size of the RTN_INDX and RTN_STAT arrays is determined by the value of RTN_ICNT. 
        ///          The RTN_STAT field is stored 4 bits per value. The first value is stored in the low order 4 bits of the byte. 
        ///          If the number of indexes is odd, the high order 4 bits of the last byte in RTN_STAT will be padded with zero. 
        ///          The indexes referred to in the RTN_INDX are those defined in the PMR.</remarks>
        public ushort[]? ReturnIndexes { get; set; }

        /// <summary>
        /// <para>Array of returned states</para>
        /// <para>RTN_STAT (jxN*1)</para></summary>
        /// <remarks><para>The size of the RTN_INDX and RTN_STAT arrays is determined by the value of RTN_ICNT. 
        ///                The RTN_STAT field is stored 4 bits per value. The first value is stored in the low order 4 bits of the byte. 
        ///                If the number of indexes is odd, the high order 4 bits of the last byte in RTN_STAT will be padded with zero. 
        ///                The indexes referred to in the RTN_INDX are those defined in the PMR.</para>
        ///          <para>The table of valid returned state values (expressed as hexadecimal digits) is:
        ///                0 = 0 or low; 1 = 1 or high; 2 = midband; 3 = glitch; 4 = undetermined; 5 = failed low;
        ///                6 = failed high; 7 = failed midband; 8 = failed with a glitch; 9 = open; A = short; </para></remarks>

        public byte[]? ReturnStates { get; set; }


        /// <summary>
        ///     <para>Array of programmed state indexes</para>
        ///     <para>PGM_INDX (kxU*2)</para></summary>
        /// <remarks>The size of the PGM_INDX and PGM_STAT arrays is determined by the value of PGM_ICNT.
        ///          The indexes referred to in the PGM_INDX are those defined in the PMR</remarks>
        public ushort[]? ProgrammedIndexes { get; set; }

        /// <summary>
        ///     <para>Array of programmed states</para>
        ///     <para>PGM_STAT (kxN*1)</para></summary>
        /// <remarks>The size of the PGM_INDX and PGM_STAT arrays is determined by the value of PGM_ICNT.
        ///          The indexes referred to in the PGM_INDX are those defined in the PMR. See spec for details.</remarks>

        public byte[]? ProgrammedStates { get; set; }

        /// <summary>
        ///     <para>Failing pin bitfield</para>
        ///     <para>FAIL_PIN (D*n)</para></summary>
        /// <remarks>Encoded with PMR index 0 in bit 0 of the field, PMR index 1 in the 1st position, and so on.
        ///          Bits representing PMR indexes of failing pins are set to 1.</remarks>
        public BitArray? FailingPinBitfield { get; set; }

        /// <summary>
        ///     <para>Vector module pattern name</para>
        ///     <para>VECT_NAM (C*n)</para>
        /// </summary>
        public string? VectorName { get; set; }

        /// <summary>
        ///     <para>Time set name</para>
        ///     <para>TIME_SET (C*n)</para>
        /// </summary>
        // why wasnt TimeSet in here?
        public string? TimeSet { get; set; }

        /// <summary>
        ///     <para>Vector Op Code</para>
        ///     <para>OP_CODE (C*n)</para>
        /// </summary>
		public string? OpCode { get; set; }

        /// <summary>
        ///     <para>Descriptive text or label</para>
        ///     <para>TEST_TXT (C*n)</para>
        /// </summary>
		public string? TestText { get; set; }

        /// <summary>
        ///     <para>Name of alarm</para>
        ///     <para>ALARM_ID (C*n)</para></summary>
        /// <remarks>If the alarm flag (bit 0 of TEST_FLG) is set, this field can optionally contain the name or 
        ///          ID of the alarm or alarms that were triggered. The names of these alarms are tester-dependent.</remarks>
		public string? AlarmId { get; set; }

        /// <summary>
        ///     <para>Additional programmed information</para>
        ///     <para>PROG_TXT (C*n)</para>
        /// </summary>
		public string? ProgrammedText { get; set; }

        /// <summary>
        ///     <para>Additional result information</para>
        ///     <para>RSLT_TXT (C*n)</para>
        /// </summary>
		public string? ResultText { get; set; }

        /// <summary>
        ///     <para>Pattern generator number</para>
        ///     <para>PATG_NUM (U*1)</para>
        /// </summary>
		public byte? PatternGeneratorNumber { get; set; }

        /// <summary>
        ///     <para>Bit map of enabled comparators</para>
        ///     <para>SPIN_MAP (D*n)</para></summary>
        /// <remarks>This field contains an array of bits corresponding to the PMR index numbers 
        ///          of the enabled comparators. The 0th bit corresponds to PMR index 0, the 1st bit corresponds 
        ///          to PMR index 1, and so on. Each comparator that is enabled will have its corresponding 
        ///          PMR index bit set to 1</remarks>
        public BitArray? SpinMap { get; set; }
    }
}
