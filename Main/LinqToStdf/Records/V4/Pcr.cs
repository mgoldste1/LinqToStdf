// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Part Count Record [1-30] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the part count totals for one or all test sites.Each data stream must have at
    ///                           least one PCR to show the part count.</br></para>
    ///     <para>Frequency: <br> * Obligatory.</br>
    ///                      <br> * At least one PCR in the file: either one summary PCR for all test sites
    ///                             (HEAD_NUM = 255), or one PCR for each head/site combination, or both.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial "FAR-(ATRs)-MIR-(RDR)-(SDRs)" sequence and before the MRR.
    ///                           When data is being recorded in real time, this record will usually appear near the end of the data stream.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM"),
    FieldLayout(FieldIndex = 2, FieldType = typeof(uint), RecordProperty = "PartCount", NameInSpec = ""),
    FieldLayout(FieldIndex = 3, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "RetestCount", NameInSpec = ""),
    FieldLayout(FieldIndex = 4, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "AbortCount", NameInSpec = ""),
    FieldLayout(FieldIndex = 5, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "GoodCount", NameInSpec = ""),
    FieldLayout(FieldIndex = 6, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "FunctionalCount", NameInSpec = "")]
    public class Pcr : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Part Count Record";
        public override RecordType RecordType => new RecordType(1, 30);

        /// <summary>
        ///     <br>Lot disposition code</br>
        ///     <br>DISP_COD (C*1)</br></summary>
        /// <remarks>Supplied by the user to indicate the disposition of the lot of parts (or of the tester itself,
        ///          in the case of checker or AEL data). The meaning of DISP_COD values are user-defined.
        ///          A valid value is an ASCII alphanumeric character (0 - 9 or A - Z). A space indicates a
        ///          missing value.</remarks>


        public byte? HeadNumber { get; set; }

        public byte? SiteNumber { get; set; }

        /// <summary>
        ///     <br>Number of parts tested</br>
        ///     <br>PART_CNT (U*4)</br>
        /// </summary>
        public uint PartCount { get; set; }

        /// <summary>
        ///     <br>Number of parts retested</br>
        ///     <br>RTST_CNT (U*4)</br>
        /// </summary>
        public uint? RetestCount { get; set; }

        /// <summary>
        ///     <br>Number of aborts during testing</br>
        ///     <br>ABRT_CNT (U*4)</br>
        /// </summary>
        public uint? AbortCount { get; set; }

        /// <summary>
        ///     <br>Number of good (passed) parts tested</br>
        ///     <br>GOOD_CNT (U*4)</br></summary>
        ///<remarks>A part is considered good when it is binned into one of the “passing” hardware bins. A
        ///         part is considered functional when it is good enough to test, whether it passes or not.
        ///         Parts that are incomplete or have shorts or opens are considered non-functional.</remarks>
        public uint? GoodCount { get; set; }

        /// <summary>
        ///     <br>Number of functional parts tested</br>
        ///     <br>FUNC_CNT (U*4)</br></summary>
        ///<remarks>A part is considered good when it is binned into one of the “passing” hardware bins. A
        ///         part is considered functional when it is good enough to test, whether it passes or not.
        ///         Parts that are incomplete or have shorts or opens are considered non-functional.</remarks>
        public uint? FunctionalCount { get; set; }
    }
}
