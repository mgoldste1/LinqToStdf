// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.
using LinqToStdf.Attributes;

namespace LinqToStdf.Records.V4
{

    ///<summary> Software Bin Record [1-50] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Stores a count of the parts associated with a particular logical bin after testing.This
    ///                           bin count can be for a single test site (when parallel testing) or a total for all test sites.
    ///                           The STDF specification also supports a Hardware Bin Record(HBR) for actual physical
    ///                           binning.A part is "physically" placed in a hardware bin after testing.A part can be
    ///                           "logically" associated with a software bin during or after testing.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per software bin for each head/site combination</br>
    ///                      <br> * One per software bin for all head/site combinations together('HEAD_NUM' = 255)</br>
    ///                      <br> * May be included to name unused bins.</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial "FAR-(ATRs)-MIR-(RDR)-(SDRs)" sequence and before the MRR.
    ///                           When data is being recorded in real time, this record usually appears near the end of the data stream.</br></para></remarks>
    [FieldLayout(FieldIndex = 2, FieldType = typeof(ushort), RecordProperty = "BinNumber", NameInSpec = "SBIN_NUM"),
     FieldLayout(FieldIndex = 3, FieldType = typeof(uint), RecordProperty = "BinCount", NameInSpec = "SBIN_CNT"),
     StringFieldLayout(FieldIndex = 4, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "BinPassFail", NameInSpec = "SBIN_PF"),
     StringFieldLayout(FieldIndex = 5, IsOptional = true, RecordProperty = "BinName", NameInSpec = "SBIN_NAM")]
    public class Sbr : BinSummaryRecord
    {
        public override string FullName => "Software Bin Record";
        public override RecordType RecordType => new RecordType(1, 50);

        public override BinType BinType => BinType.Soft;
    }
}
