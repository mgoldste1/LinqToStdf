// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.
namespace LinqToStdf.Records.V4
{
    using Attributes;
    ///<summary> Begin Program Section Record [20-10] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Marks the beginning of a new program section(or sequencer) in the job plan.</br></para>
    ///     <para>Frequency: <br> * Optional </br>
    ///                      <br> * On each entry into the program segment.</br></para>
    ///     <para>Location:  <br> Anywhere after the PIR and before the PRR.</br></para></remarks>
    [StringFieldLayout(FieldIndex = 0, IsOptional = true, RecordProperty = "Name", NameInSpec = "SEQ_NAME")]
    public class Bps : StdfRecord
    {
        public override string FullName => "Begin Program Section";
        public override RecordType RecordType => new RecordType(20, 10);

        /// <summary>
        ///     <para>Program section (or sequencer) name </para>
        ///     <para>SEQ_NAME (C*n) </para>
        /// </summary>
        public string? Name { get; set; }
    }
}