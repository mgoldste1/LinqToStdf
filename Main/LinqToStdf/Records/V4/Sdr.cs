// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Site Description Record [1-80] </summary>
    ///<remarks>
    ///    <para>Function:   <br> Contains the configuration information for one or more test sites, connected to one test
    ///                           head, that compose a site group.</br></para>
    ///     <para>Frequency: <br> * Optional</br>
    ///                      <br> * One for each site or group of sites that is differently configured.</br></para>
    ///     <para>Location:  <br> Immediately after the MIR and RDR (if an RDR is used).</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = byte.MaxValue, RecordProperty = "SiteGroup", NameInSpec = "SITE_GRP"),
    FieldLayout(FieldIndex = 2, FieldType = typeof(byte), MissingValue = (byte)0x00, RecordProperty = "SiteCount", NameInSpec = "SITE_CNT"),
    ArrayFieldLayout(FieldIndex = 3, FieldType = typeof(byte), ArrayLengthFieldIndex = 2, RecordProperty = "SiteNumbers", NameInSpec = "SITE_NUM"),
    StringFieldLayout(FieldIndex = 4, IsOptional = true, RecordProperty = "HandlerType", NameInSpec = "HAND_TYP"),
    StringFieldLayout(FieldIndex = 5, IsOptional = true, RecordProperty = "HandlerId", NameInSpec = "HAND_ID"),
    StringFieldLayout(FieldIndex = 6, IsOptional = true, RecordProperty = "CardType", NameInSpec = "CARD_TYP"),
    StringFieldLayout(FieldIndex = 7, IsOptional = true, RecordProperty = "CardId", NameInSpec = "CARD_ID"),
    StringFieldLayout(FieldIndex = 8, IsOptional = true, RecordProperty = "LoadboardType", NameInSpec = "LOAD_TYP"),
    StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "LoadboardId", NameInSpec = "LOAD_ID"),
    StringFieldLayout(FieldIndex = 10, IsOptional = true, RecordProperty = "DibType", NameInSpec = "DIB_TYP"),
    StringFieldLayout(FieldIndex = 11, IsOptional = true, RecordProperty = "DibId", NameInSpec = "DIB_ID"),
    StringFieldLayout(FieldIndex = 12, IsOptional = true, RecordProperty = "CableType", NameInSpec = "CABL_TYP"),
    StringFieldLayout(FieldIndex = 13, IsOptional = true, RecordProperty = "CableId", NameInSpec = "CABL_ID"),
    StringFieldLayout(FieldIndex = 14, IsOptional = true, RecordProperty = "ContactorType", NameInSpec = "CONT_TYP"),
    StringFieldLayout(FieldIndex = 15, IsOptional = true, RecordProperty = "ContactorId", NameInSpec = "CONT_ID"),
    StringFieldLayout(FieldIndex = 16, IsOptional = true, RecordProperty = "LaserType", NameInSpec = "LASR_TYP"),
    StringFieldLayout(FieldIndex = 17, IsOptional = true, RecordProperty = "LaserId", NameInSpec = "LASR_ID"),
    StringFieldLayout(FieldIndex = 18, IsOptional = true, RecordProperty = "ExtraType", NameInSpec = "EXTR_TYP"),
    StringFieldLayout(FieldIndex = 19, IsOptional = true, RecordProperty = "ExtraId", NameInSpec = "EXTR_ID")]
    public class Sdr : StdfRecord, IHeadIndexable
    {
        public override string FullName => "Site Description Record";
        public override RecordType RecordType => new RecordType(1, 80);



        public byte? HeadNumber { get; set; }

        /// <summary>
        ///     <br>Site group number</br>
        ///     <br>SITE_GRP (U*1)</br>
        /// </summary>
        public byte? SiteGroup { get; set; }

        /// <summary>
        ///     <br>Number (k) of test sites in site group</br>
        ///     <br>SITE_CNT U*1</br></summary>
        /// <remarks>SITE_CNT tells how many sites are in the site group that
        ///          the current SDR configuration applies to. </remarks>
        public byte? SiteCount { get; set; }


        /// <summary>
        ///     <br>Array of test site numbers</br>
        ///     <br>SITE_NUM (kxU*1)</br>
        /// </summary>

        public byte[]? SiteNumbers { get; set; }

        /// <summary>
        ///     <br>Handler or prober type</br>
        ///     <br>HAND_TYP (C*n)</br>
        /// </summary>
        public string? HandlerType { get; set; }

        /// <summary>
        ///     <br>Handler or prober ID</br>
        ///     <br>HAND_ID (C*n)</br>
        /// </summary>
        public string? HandlerId { get; set; }

        /// <summary>
        ///     <br>Probe card type</br>
        ///     <br>CARD_TYP (C*n)</br>
        /// </summary>
        public string? CardType { get; set; }

        /// <summary>
        ///     <br>Probe card ID</br>
        ///     <br>CARD_ID (C*n)</br>
        /// </summary>
        public string? CardId { get; set; }

        /// <summary>
        ///     <br>Load board type</br>
        ///     <br>LOAD_TYP (C*n)</br>
        /// </summary>
        public string? LoadboardType { get; set; }

        /// <summary>
        ///     <br>Load board ID</br>
        ///     <br>LOAD_ID (C*n)</br>
        /// </summary>
        public string? LoadboardId { get; set; }

        /// <summary>
        ///     <br>DIB board type</br>
        ///     <br>DIB_TYP (C*n)</br>
        /// </summary>
        public string? DibType { get; set; }

        /// <summary>
        ///     <br>DIB board ID</br>
        ///     <br>DIB_ID (C*n)</br>
        /// </summary>
        public string? DibId { get; set; }

        /// <summary>
        ///     <br>Interface cable type</br>
        ///     <br>CABL_TYP (C*n)</br>
        /// </summary>
        public string? CableType { get; set; }

        /// <summary>
        ///     <br>Interface cable ID</br>
        ///     <br>CABL_ID (C*n)</br>
        /// </summary>
        public string? CableId { get; set; }

        /// <summary>
        ///     <br>Handler contactor type</br>
        ///     <br>CONT_TYP (C*n)</br>
        /// </summary>
        public string? ContactorType { get; set; }

        /// <summary>
        ///     <br>Handler contactor ID</br>
        ///     <br>CONT_ID (C*n)</br>
        /// </summary>
        public string? ContactorId { get; set; }

        /// <summary>
        ///     <br>Laser type</br>
        ///     <br>LASR_TYP (C*n)</br>
        /// </summary>
        public string? LaserType { get; set; }

        /// <summary>
        ///     <br>Laser ID</br>
        ///     <br>LASR_ID (C*n)</br>
        /// </summary>
        public string? LaserId { get; set; }

        /// <summary>
        ///     <br>Extra equipment type field</br>
        ///     <br>EXTR_TYP (C*n)</br>
        /// </summary>
        public string? ExtraType { get; set; }

        /// <summary>
        ///     <br>Extra equipment ID</br>
        ///     <br>EXTR_ID (C*n)</br>
        /// </summary>
        public string? ExtraId { get; set; }
    }
}
