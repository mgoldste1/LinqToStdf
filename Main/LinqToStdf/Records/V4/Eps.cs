// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.
namespace LinqToStdf.Records.V4
{
    ///<summary> End Program Section Record [20-20] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Marks the end of the current program section(or sequencer) in the job plan.</br></para>
    ///     <para>Frequency: <br> * Optional </br>
    ///                      <br> * On each exit from the program segment</br></para>
    ///     <para>Location:  <br> Following the corresponding BPS and before the PRR in the data stream.</br></para></remarks>
    public class Eps : StdfRecord
    {
        public override string FullName => "End Program Section Record";
        public override RecordType RecordType => new RecordType(20, 20);
    }
}
