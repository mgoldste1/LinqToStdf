// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Wafer Results Record [2-20] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the result information relating to each wafer tested by the job plan.The WRR
    ///                           and the Wafer Information Record(WIR) bracket all the stored information pertaining
    ///                           to one tested wafer.This record is used only when testing at wafer probe time. A
    ///                           WIR/WRR pair will have the same HEAD_NUM and SITE_GRP values.</br></para>
    ///     <para>Frequency: <br> * Obligatory for Wafer sort</br>
    ///                      <br> * One per wafer tested.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the corresponding WIR.
    ///                           Sent after testing each wafer.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = byte.MaxValue, RecordProperty = "SiteGroup", NameInSpec = "SITE_GRP"),
    TimeFieldLayout(FieldIndex = 2, RecordProperty = "FinishTime", NameInSpec = "FINISH_T"),
    FieldLayout(FieldIndex = 3, FieldType = typeof(uint), RecordProperty = "PartCount", NameInSpec = "PART_CNT"),
    FieldLayout(FieldIndex = 4, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "RetestCount", NameInSpec = "RTST_CNT"),
    FieldLayout(FieldIndex = 5, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "AbortCount", NameInSpec = "ABRT_CNT"),
    FieldLayout(FieldIndex = 6, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "GoodCount", NameInSpec = "GOOD_CNT"),
    FieldLayout(FieldIndex = 7, FieldType = typeof(uint), IsOptional = true, MissingValue = uint.MaxValue, RecordProperty = "FunctionalCount", NameInSpec = "FUNC_CNT"),
    StringFieldLayout(FieldIndex = 8, IsOptional = true, RecordProperty = "WaferId", NameInSpec = "WAFER_ID"),
    StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "FabWaferId", NameInSpec = "FABWF_ID"),
    StringFieldLayout(FieldIndex = 10, IsOptional = true, RecordProperty = "FrameId", NameInSpec = "FRAME_ID"),
    StringFieldLayout(FieldIndex = 11, IsOptional = true, RecordProperty = "MaskId", NameInSpec = "MASK_ID"),
    StringFieldLayout(FieldIndex = 12, IsOptional = true, RecordProperty = "UserDescription", NameInSpec = "USR_DESC"),
    StringFieldLayout(FieldIndex = 13, IsOptional = true, RecordProperty = "ExecDescription", NameInSpec = "EXC_DESC")]
    public class Wrr : StdfRecord, IHeadIndexable
    {
        public override string FullName => "Wafer Results Record";
        public override RecordType RecordType => new RecordType(2, 20);
        public byte? HeadNumber { get; set; }

        /// <summary>
        ///     <br>Site group number</br>
        ///     <br>SITE_GRP (U*1)</br></summary>
        /// <remarks>Refers to the site group in the SDR. This is a means of relating the wafer information
        ///          to the configuration of the equipment used to test it.If this information is not known,
        ///          or the tester does not support the concept of site groups, this field should be set to 255.</remarks>
        public byte? SiteGroup { get; set; }

        /// <summary>
        ///     <br>Date and time last part tested</br>
        ///     <br>FINISH_T (U*4)</br>
        /// </summary>
        public DateTime? FinishTime { get; set; }

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
        ///     <br>GOOD_CNT (U*4)</br>
        /// </summary>
        public uint? GoodCount { get; set; }

        /// <summary>
        ///     <br>Number of functional parts tested</br>
        ///     <br>FUNC_CNT (U*4)</br>
        /// </summary>
        public uint? FunctionalCount { get; set; }

        /// <summary>
        ///     <br>Wafer ID</br>
        ///     <br>WAFER_ID (C*n)</br></summary>
        /// <remarks>Is optional, but is strongly recommended in order to make the resultant data files as
        ///          useful as possible.A Wafer ID in the WRR supersedes any Wafer ID found in the WIR.</remarks>
        public string? WaferId { get; set; }

        /// <summary>
        ///     <br>Fab wafer ID</br>
        ///     <br>FABWF_ID (C*n)</br></summary>
        /// <remarks>Is the ID of the wafer when it was in the fabrication process. This facilitates tracking
        ///          of wafers and correlation of yield with fabrication variations.</remarks>
        public string? FabWaferId { get; set; }

        /// <summary>
        ///     <br>Wafer frame ID</br>
        ///     <br>FRAME_ID (C*n)</br></summary>
        /// <remarks>Facilitates tracking of wafers once the wafer has been through the saw step and the
        ///          wafer ID is no longer readable on the wafer itself. This is an important piece of
        ///          information for implementing an inkless binning scheme.</remarks>
        public string? FrameId { get; set; }

        /// <summary>
        ///     <br>Wafer mask ID</br>
        ///     <br>MASK_ID (C*n)</br>
        /// </summary>
        public string? MaskId { get; set; }

        /// <summary>
        ///     <br>Wafer description supplied by user</br>
        ///     <br>USR_DESC (C*n)</br>
        /// </summary>
        public string? UserDescription { get; set; }

        /// <summary>
        ///     <br>Wafer description supplied by exec</br>
        ///     <br>EXC_DESC (C*n)</br>
        /// </summary>
        public string? ExecDescription { get; set; }
    }
}
