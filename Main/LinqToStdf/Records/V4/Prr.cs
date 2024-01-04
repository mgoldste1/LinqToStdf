// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Part Results Record [5-20] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the result information relating to each part tested by the test program.The
    ///                           PRR and the Part Information Record(PIR) bracket all the stored information
    ///                           pertaining to one tested part.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per part tested.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the corresponding PIR and before the MRR.
    ///                           Sent after completion of testing each part.</br></para></remarks>
    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
     FieldLayout(FieldIndex = 2, FieldType = typeof(byte), RecordProperty = "PartFlag", NameInSpec = "PART_FLG"),
     FieldLayout(FieldIndex = 3, FieldType = typeof(ushort), RecordProperty = "TestCount", NameInSpec = "NUM_TEST"),
     FieldLayout(FieldIndex = 4, FieldType = typeof(ushort), RecordProperty = "HardBin", NameInSpec = "HARD_BIN"),
     FieldLayout(FieldIndex = 5, FieldType = typeof(ushort), IsOptional = true, MissingValue = ushort.MaxValue, RecordProperty = "SoftBin", NameInSpec = "SOFT_BIN"),
     FieldLayout(FieldIndex = 6, FieldType = typeof(short), IsOptional = true, MissingValue = short.MinValue, RecordProperty = "XCoordinate", NameInSpec = "X_COORD"),
     FieldLayout(FieldIndex = 7, FieldType = typeof(short), IsOptional = true, MissingValue = short.MinValue, RecordProperty = "YCoordinate", NameInSpec = "Y_COORD"),
     FieldLayout(FieldIndex = 8, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MinValue, RecordProperty = "TestTime", NameInSpec = "TEST_T"),
     StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "PartId", NameInSpec = "PART_ID"),
     StringFieldLayout(FieldIndex = 10, IsOptional = true, RecordProperty = "PartText", NameInSpec = "PART_TXT"),
     FieldLayout(FieldIndex = 11, FieldType = typeof(byte)),
     ArrayFieldLayout(FieldIndex = 12, FieldType = typeof(byte), ArrayLengthFieldIndex = 11, RecordProperty = "PartFix"),
     DependencyProperty(FieldIndex = 13, DependentOnIndex = 2, RecordProperty = "SupersedesPartId"),
     DependencyProperty(FieldIndex = 14, DependentOnIndex = 2, RecordProperty = "SupersedesCoords"),
     DependencyProperty(FieldIndex = 15, DependentOnIndex = 2, RecordProperty = "AbnormalTest"),
     DependencyProperty(FieldIndex = 16, DependentOnIndex = 2, RecordProperty = "Failed")]
    public class Prr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Part Results Record";
        public override RecordType RecordType => new RecordType(5, 20);



        public byte? HeadNumber { get; set; }


        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <br>Part information flag</br>
        ///     <br>PART_FLG (B*1)</br></summary>
        ///<remarks>
        /// <br>Contains the following fields:</br>
        ///     <para>bit 0:     <br> * 0 = This is a new part. Its data device does not supersede that of any previous
        ///                               device.</br>
        ///                      <br> * 1 = The PIR, PTR, MPR, FTR, and PRR records that make up the current
        ///                               sequence (identified as having the same HEAD_NUM and SITE_NUM)
        ///                               supersede any previous sequence of records with the same PART_ID. (A
        ///                               repeated part sequence usually indicates a mistested part.)</br></para>
        ///     <para>bit 1:     <br> * 0 = This is a new part. Its data device does not supersede that of any previous device.</br>
        ///                      <br> * 1 = The PIR, PTR, MPR, FTR, and PRR records that make up the current
        ///                               sequence (identified as having the same HEAD_NUM and SITE_NUM)
        ///                               supersede any previous sequence of records with the same X_COORD and
        ///                               Y_COORD. (A repeated part sequence usually indicates a mistested part.)
        ///                               Note: Either Bit 0 or Bit 1 can be set, but not both. (It is also valid to have neither set.)</br></para>
        ///     <para>bit 2:     <br> * 0 = Part testing completed normally</br>
        ///                      <br> * 1 = Abnormal end of testing</br></para>
        ///     <para>bit 3:     <br> * 0 = Part passed</br>
        ///                      <br> * 1 = Part failed</br></para>
        ///     <para>bit 4:     <br> * 0 = Pass/fail flag (bit 3) is valid</br>
        ///                      <br> * 1 = Device completed testing with no pass/fail indication (i.e., bit 3 is invalid)</br></para>
        ///     <para>bits 5 - 7: Reserved for future use — must be 0</para>
        /// </remarks>
        public byte PartFlag { get; set; }

        /// <summary>
        ///     <br>Number of tests executed</br>
        ///     <br>NUM_TEST (U*2)</br>
        /// </summary>
        public ushort TestCount { get; set; }

        /// <summary>
        ///     <br>Hardware bin number</br>
        ///     <br>HARD_BIN (U*2)</br></summary>
        /// <remarks>Has legal values in the range 0 to 32767</remarks>
        public ushort HardBin { get; set; }

        /// <summary>
        ///     <br>Software bin number</br>
        ///     <br>SOFT_BIN (U*2)</br></summary>
        /// <remarks>Has legal values in the range 0 to 32767. A missing value is indicated by the value 65535.</remarks>
        public ushort? SoftBin { get; set; }

        /// <summary>
        ///     <br>(Wafer) X coordinate</br>
        ///     <br>X_COORD (I*2)</br></summary>
        /// <remarks><br>Have legal values in the range -32767 to 32767. A missing value is indicated by the
        ///          value -32768.</br>
        ///          <br>Are all optional, but you should provide either the PART_ID or the X_COORD and
        ///          Y_COORD in order to make the resultant data useful for analysis.</br></remarks>
        public short? XCoordinate { get; set; }

        /// <summary>
        ///     <br>(Wafer) Y coordinate</br>
        ///     <br>Y_COORD (I*2)</br></summary>
        /// <remarks><br>Have legal values in the range -32767 to 32767. A missing value is indicated by the
        ///          value -32768.</br>
        ///          <br>Are all optional, but you should provide either the PART_ID or the X_COORD and
        ///          Y_COORD in order to make the resultant data useful for analysis.</br></remarks>
        public short? YCoordinate { get; set; }

        /// <summary>
        ///     <br>Elapsed test time in milliseconds</br>
        ///     <br>TEST_T (U*4)</br>
        /// </summary>
        public uint? TestTime { get; set; }

        /// <summary>
        ///     <br>Part identification</br>
        ///     <br>PART_ID (C*n)</br>
        /// </summary>
        public string? PartId { get; set; }

        /// <summary>
        ///     <br>Part description text</br>
        ///     <br>PART_TXT (C*n)</br></summary>
        /// <remarks> Optional, but you should provide either the PART_ID or the X_COORD and
        ///           Y_COORD in order to make the resultant data useful for analysis.</br></remarks>
        public string? PartText { get; set; }

        /// <summary>
        ///     <br>Part repair information</br>
        ///     <br>PART_FIX (B*n)</br></summary>
        /// <remarks>This is an application-specific field for storing device repair information. It may be used
        ///          for bit-encoded, integer, floating point, or character information.Regardless of the
        ///          information stored, the first byte must contain the number of bytes to follow.This field
        ///          can be decoded only by an application-specific analysis program.See “Storing Repair
        ///          Information” on page 75 of the STDF V4 spec.</remarks>
        public byte[]? PartFix { get; set; }
        //dependency properties
        static readonly byte _SupersedesPartIdMask = 0x01;
        static readonly byte _SupersedesCoordsMask = 0x02;
        static readonly byte _AbnormalTestMask = 0x04;
        static readonly byte _FailedMask = 0x08;
        static readonly byte _FailFlagInvalidMask = 0x10;

        public bool SupersedesPartId
        {
            get { return (PartFlag & _SupersedesPartIdMask) != 0; }
            set
            {
                if (value) PartFlag |= _SupersedesPartIdMask;
                else PartFlag &= (byte)~_SupersedesPartIdMask;
            }
        }

        public bool SupersedesCoords
        {
            get { return (PartFlag & _SupersedesCoordsMask) != 0; }
            set
            {
                if (value) PartFlag |= _SupersedesCoordsMask;
                else PartFlag &= (byte)~_SupersedesCoordsMask;
            }
        }

        public bool AbnormalTest
        {
            get { return (PartFlag & _AbnormalTestMask) != 0; }
            set
            {
                if (value) PartFlag |= _AbnormalTestMask;
                else PartFlag &= (byte)~_AbnormalTestMask;
            }
        }

        public bool? Failed
        {
            get { return (PartFlag & _FailFlagInvalidMask) != 0 ? (bool?)null : (PartFlag & _FailedMask) != 0; }
            set
            {
                if (value == null)
                {
                    PartFlag &= (byte)~_FailedMask;
                    PartFlag |= _FailFlagInvalidMask;
                }
                else
                {
                    PartFlag &= (byte)~_FailFlagInvalidMask;
                    if ((bool)value) PartFlag |= _FailedMask;
                    else PartFlag &= (byte)~_FailedMask;
                }
            }
        }
    }
}
