// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Part Information Record [5-10] </summary>
    ///<remarks>
    ///     <para>Function: <br>  Acts as a marker to indicate where testing of a particular part begins for each part
    ///                           tested by the test program. The PIR and the Part Results Record (PRR) bracket all the
    ///                           stored information pertaining to one tested part.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per part tested.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial sequence "FAR-(ATRs)-MIR-(RDR)-(SDRs)", and before the corresponding PRR.
    ///                           Sent before testing each part.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "HeadNumber", NameInSpec = "HEAD_NUM"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)1, PersistMissingValue = true, RecordProperty = "SiteNumber", NameInSpec = "SITE_NUM")]
    public class Pir : StdfRecord, IHeadSiteIndexable
    {
        public override string FullName => "Part Information Record";
        public override RecordType RecordType => new RecordType(5, 10);


        public byte? HeadNumber { get; set; }

        public byte? SiteNumber { get; set; }
    }
}

