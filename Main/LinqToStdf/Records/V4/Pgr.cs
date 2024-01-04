// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Pin Group Record [1-62] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Associates a name with a group of pins.</br></para>
    ///     <para>Frequency: <br> * Optional</br>
    ///                      <br> * One per pin group defined in the test program.</br></para>
    ///     <para>Location:  <br> After all the PMRs whose PMR index values are listed in the PMR_INDX array of this
    ///                           record; and before the first PLR that uses this record's GRP_INDX value.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(ushort), RecordProperty = "GroupIndex", NameInSpec = "GRP_INDX"),
    StringFieldLayout(FieldIndex = 1, IsOptional = true, RecordProperty = "GroupName", NameInSpec = "GRP_NAM"),
    FieldLayout(FieldIndex = 2, FieldType = typeof(ushort), IsOptional = true, NameInSpec = "INDX_CNT"),
    ArrayFieldLayout(FieldIndex = 3, FieldType = typeof(ushort), IsOptional = true, ArrayLengthFieldIndex = 2, RecordProperty = "PinIndexes", NameInSpec = "PMR_INDX")]
    public class Pgr : StdfRecord
    {
        public override string FullName => "Pin Group Record";
        public override RecordType RecordType => new RecordType(1, 62);

        /// <summary>
        ///     <br>Unique index associated with pin group</br>
        ///     <br>GRP_INDX (U*2)</br></summary>
        /// <remarks>While ushort, valid PGR Indexes must be 32,768 - 65,535</remarks>
        public ushort GroupIndex { get; set; }

        /// <summary>
        ///     <br>Name of pin group  </br>
        ///     <br>GRP_NAM (C*n)</br>
        /// </summary>
        public string? GroupName { get; set; }

        //INDX_CNT U*2 Count (k) of PMR indexes

        /// <summary>
        /// <br>Array of indexes for pins in the group</br>
        /// <br>PMR_INDX (kxU*2)</br>
        /// </summary>
        public ushort[]? PinIndexes { get; set; }

    }
}

