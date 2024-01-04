// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Master Results Record [1-20] </summary>
    ///<remarks>
    ///     <para>Function:  <br> The Master Results Record(MRR) is a logical extension of the Master Information
    ///                           Record(MIR). The data can be thought of as belonging with the MIR, but it is not
    ///                           available when the tester writes the MIR information.Each data stream must have
    ///                           exactly one MRR as the last record in the data stream.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per data stream</br></para>
    ///     <para>Location:  <br> Must be the last record in the data stream.</br></para></remarks>

    [TimeFieldLayout(FieldIndex = 0, RecordProperty = "FinishTime", NameInSpec = "FINISH_T"),
     StringFieldLayout(FieldIndex = 1, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "DispositionCode", NameInSpec = "DISP_COD"),
     StringFieldLayout(FieldIndex = 2, IsOptional = true, RecordProperty = "UserDescription", NameInSpec = "USR_DESC"),
     StringFieldLayout(FieldIndex = 3, IsOptional = true, RecordProperty = "ExecDescription", NameInSpec = "EXC_DESC")]
    public class Mrr : StdfRecord
    {
        public override string FullName => "Master Results Record";
        public override RecordType RecordType => new RecordType(1, 20);

        /// <summary>
        ///     <br>Date and time last part tested</br>
        ///     <br>FINISH_T (U*4)</br>
        /// </summary>
        public DateTime? FinishTime { get; set; }

        /// <summary>
        ///     <br>Lot disposition code</br>
        ///     <br>DISP_COD (C*1)</br></summary>
        /// <remarks>Supplied by the user to indicate the disposition of the lot of parts (or of the tester itself,
        ///          in the case of checker or AEL data). The meaning of DISP_COD values are user-defined.
        ///          A valid value is an ASCII alphanumeric character (0 - 9 or A - Z). A space indicates a
        ///          missing value.</remarks>
        public string? DispositionCode { get; set; }

        /// <summary>
        ///     <br>Lot description supplied by user</br>
        ///     <br>USR_DESC (C*n)</br>
        /// </summary>
        public string? UserDescription { get; set; }

        /// <summary>
        ///     <br> Lot description supplied by exec</br>
        ///     <br>EXC_DESC (C*n)</br>
        /// </summary>
        public string? ExecDescription { get; set; }
    }
}
