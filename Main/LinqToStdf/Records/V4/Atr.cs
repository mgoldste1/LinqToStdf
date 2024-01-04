// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Audit Trail Record [0-20] </summary>
    ///<remarks> 
    ///     <para>Function:  <br> Used to record any operation that alters the contents of the STDF file.The name of the
    ///                           program and all its parameters should be recorded in the ASCII field provided in this
    ///                           record.Typically, this record will be used to track filter programs that have been
    ///                           applied to the data.</br></para>
    ///     <para>Frequency: <br> * Optional</br>
    ///                      <br> * One for each filter or other data transformation program applied to the STDF data.</br></para>
    ///     <para>Location:  <br> Between the File Attributes Record (FAR) and the Master Information Record (MIR).
    ///                           The filter program that writes the altered STDF file must write its ATR immediately
    ///                           after the FAR (and hence before any other ATRs that may be in the file). In this way,
    ///                           multiple ATRs will be in reverse chronological order.</br></para></remarks>

    [TimeFieldLayout(FieldIndex = 0, RecordProperty = "ModifiedTime", NameInSpec = "MOD_TIM"),
     StringFieldLayout(FieldIndex = 1, RecordProperty = "CommandLine", NameInSpec = "CMD_LINE")]
    public class Atr : StdfRecord
    {

        public override string FullName => "Audit Trail Record";
        public override RecordType RecordType => new RecordType(0, 20);

        /// <summary>
        ///   <para>Date & time of STDF file modification</para>
        ///   <para>MOD_TIM (U*4)</para>
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        ///   <para>Command line of program  </para>
        ///   <para>CMD_LINE (C*n)</para>
        /// </summary>
        public string? CommandLine { get; set; }


    }
}
