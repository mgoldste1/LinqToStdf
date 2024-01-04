// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Wafer Information Record [2-10] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Acts mainly as a marker to indicate where testing of a particular wafer begins for each
    ///                           wafer tested by the job plan.The WIR and the Wafer Results Record(WRR) bracket all
    ///                           the stored information pertaining to one tested wafer.This record is used only when
    ///                           testing at wafer probe.A WIR/WRR pair will have the same HEAD_NUM and SITE_GRP values.</br></para>
    ///     <para>Frequency: <br> * Obligatory for Wafer sort</br>
    ///                      <br> * One per wafer tested.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial sequence (see page 14) and before the MRR.
    ///                           Sent before testing each wafer.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = byte.MaxValue, RecordProperty = "SiteGroup", NameInSpec = "SITE_GRP"),
    TimeFieldLayout(FieldIndex = 2, FieldType = typeof(DateTime), RecordProperty = "StartTime", NameInSpec = "START_T"),
    StringFieldLayout(FieldIndex = 3, IsOptional = true, RecordProperty = "WaferId", NameInSpec = "WAFER_ID")]
    public class Wir : StdfRecord, IHeadIndexable
    {
        public override string FullName => "Wafer Information Record";
        public override RecordType RecordType => new RecordType(2, 10);
        public byte? HeadNumber { get; set; }

        /// <summary>
        ///     <br>Site group number</br>
        ///     <br>SITE_GRP (U*1)</br>
        /// </summary>
        public byte? SiteGroup { get; set; }

        /// <summary>
        ///     <br>Date and time first part tested</br>
        ///     <br>START_T (U*4)</br></summary>
        /// <remarks>Refers to the site group in the SDR. This is a means of relating the wafer information
        ///          to the configuration of the equipment used to test it.If this information is not known,
        ///          or the tester does not support the concept of site groups, this field should be set to 255.</remarks>
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     <br>Wafer ID</br>
        ///     <br>WAFER_ID (C*n)</br></summary>
        /// <remarks>Technically optional but highly recommended</remarks>
        public string? WaferId { get; set; }


    }
}
