// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    /// <summary>
    /// Base class for HBRs and SBRs
    /// </summary>
    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM")]
    public abstract class BinSummaryRecord : StdfRecord, IHeadSiteIndexable {
        public override string FullName { get => "BinSummaryRecord"; }
        public abstract BinType BinType { get; }
        public byte? HeadNumber { get; set; }

        public byte? SiteNumber { get; set; }

        /// <summary>
        /// <br>Hardware bin number</br>
        /// <br>HBIN_NUM (U*2)</br>
        /// <br>While ushort, valid bins must be 0 - 32,767</br>
        /// </summary>
        public ushort BinNumber { get; set; }

        /// <summary>
        /// <br>Number of parts in bin</br>
        /// <br>HBIN_CNT (U*4)</br>
        /// </summary>
        public uint BinCount { get; set; }

        /// <summary>
        /// <br>Pass/fail indication </br>
        /// <br>HBIN_PF (C*1)</br>
        /// <br>Known values are P, F</br>
        /// </summary>
        public string? BinPassFail { get; set; }

        /// <summary>
        /// <br>Name of hardware bin</br>
        /// <br>HBIN_NAM (C*n)</br>
        /// </summary>
        public string? BinName { get; set; }
    }
}
