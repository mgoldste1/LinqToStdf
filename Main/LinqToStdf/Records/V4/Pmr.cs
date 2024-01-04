// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Pin Map Record [1-60] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Provides indexing of tester channel names, and maps them to physical and logical pin
    ///                           names. Each PMR defines the information for a single channel/pin combination.</br></para>
    ///     <para>Frequency: <br> * Optional</br>
    ///                      <br> * One per channel/pin combination used in the test program.</br>
    ///                      <br> * Reuse of a PMR index number is not permitted.</br></para>
    ///     <para>Location:  <br> After the initial "FAR-(ATRs)-MIR-(RDR)-(SDRs)" sequence and before the first PGR, PLR,
    ///                           FTR, or MPR that uses this record's PMR_INDX value.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(ushort), RecordProperty = "Index", NameInSpec = "PMR_INDX"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(ushort), MissingValue = ushort.MinValue, RecordProperty = "ChannelType", NameInSpec = "CHAN_TYP"),
    StringFieldLayout(FieldIndex = 2, IsOptional = true, RecordProperty = "ChannelName", NameInSpec = "CHAN_NAM"),
    StringFieldLayout(FieldIndex = 3, IsOptional = true, RecordProperty = "PhysicalName", NameInSpec = "PHY_NAM"),
    StringFieldLayout(FieldIndex = 4, IsOptional = true, RecordProperty = "LogicalName", NameInSpec = "LOG_NAM"),
    FieldLayout(FieldIndex = 5, FieldType = typeof(byte), IsOptional = true, MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 6, FieldType = typeof(byte), IsOptional = true, MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM")]
    public class Pmr : StdfRecord
    {
        public override string FullName => "Pin Map Record";
        public override RecordType RecordType => new RecordType(1, 60);

        /// <summary>
        ///     <br>Unique index associated with pin</br>
        ///     <br>PMR_INDX (U*2)</br></summary>
        /// <remarks><br> * This number is used to associate the channel and pin name information with data in
        ///                 the FTR or MPR.Reporting programs can then look up the PMR index and choose which
        ///                 of the three associated names they will use.</br>
        ///          <br> * The range of legal PMR indexes is 1 - 32,767.</br>
        ///          <br> * The size of the FAIL_PIN and SPIN_MAP arrays in the FTR are directly proportional to
        ///                 the highest PMR index number.Therefore, it is important to start PMR indexes with a
        ///                 low number and use consecutive numbers if possible</br></remarks>
        public ushort PinIndex { get; set; }

        /// <summary>
        ///     <br>Channel type</br>
        ///     <br>CHAN_TYP (U*2)</br></summary>
        /// <remarks>The channel type values are tester-specific. Please refer to the tester documentation for
        ///          a list of the valid tester channel types and codes. </remarks>
        public ushort? ChannelType { get; set; }

        /// <summary>
        ///     <br>Channel name</br>
        ///     <br>CHAN_NAM (C*n)</br>
        /// </summary>
        public string? ChannelName { get; set; }

        /// <summary>
        ///     <br>Physical name of pin</br>
        ///     <br>PHY_NAM (C*n)</br>
        /// </summary>
        public string? PhysicalName { get; set; }

        /// <summary>
        ///     <br>Logical name of pin</br>
        ///     <br>LOG_NAM (C*n)</br>
        /// </summary>
        public string? LogicalName { get; set; }

        /// <summary>
        ///     <br>Head number associated with channel</br>
        ///     <br>HEAD_NUM (U*1)</br></summary>
        /// <remarks>If a test system does not support parallel testing and does not have a standard way of
        ///          identifying its single test site or head, these fields should be set to 1. If missing, the
        ///          value of these fields will default to 1.</remarks>
        public byte? HeadNumber { get; set; }

        /// <summary>
        ///     <br>Site number associated with channel</br>
        ///     <br>SITE_NUM (U*1)</br></summary>
        /// <remarks>If a test system does not support parallel testing and does not have a standard way of
        ///          identifying its single test site or head, these fields should be set to 1. If missing, the
        ///          value of these fields will default to 1.</remarks>
        public byte? SiteNumber { get; set; }


        [Obsolete("Pmr.Index has been renamed Pmr.PinIndex to be consistent with Pgr.PinIndexes")]
        public ushort Index
        {
            get { return PinIndex; }
            set { PinIndex = value; }
        }
    }
}
