// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Retest Data Record [1-70] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Signals that the data in this STDF file is for retested parts. The data in this record,
    ///                           combined with information in the MIR, tells data filtering programs what data to
    ///                           replace when processing retest data.</br></para>
    ///     <para>Frequency: <br> * Obligatory if a lot is retested. (not if a device is binned in the reteset bin)</br>
    ///                      <br> * One per data stream.</br></para>
    ///     <para>Location:  <br> If this record is used, it must appear immediately after theMaster Information Record (MIR).</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(ushort)/*, NameInSpec = "NUM_BINS"*/),
    ArrayFieldLayout(FieldIndex = 1, FieldType = typeof(ushort), MissingValue = ushort.MinValue, ArrayLengthFieldIndex = 0, RecordProperty = "RetestBins", NameInSpec = "RTST_BIN")]
    public class Rdr : StdfRecord
    {
        public override string FullName => "Retest Data Record";
        public override RecordType RecordType => new RecordType(1, 70);

        //////////////////////////////////////////////////////////////////////////////////////////
        // NUM_BINS U*2 Number (k) of bins being retested                                       //
        //                                                                                      //
        // NUM_BINS indicates the number of hardware bins being retested and therefore the size //
        // of the RTST_BIN array that follows If NUM_BINS is zero, then all bins in the lot are //
        // being retested and RTST_BIN is omitted.                                              //
        //////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///     <br>Array of retest bin numbers</br>
        ///     <br>RTST_BIN (kxU*2)</br></summary>
        /// <remarks>The LOT_ID, SUBLOT_ID, and TEST_COD of the current STDF file should match those of
        ///          the STDF file that is being retested, so the data can be properly merged at a later time.</remarks>
        public ushort[]? RetestBins { get; set; }
    }
}
