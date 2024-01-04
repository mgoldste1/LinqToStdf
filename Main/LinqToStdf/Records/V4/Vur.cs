namespace LinqToStdf.Records.V4 {
    using Attributes;

    ///<summary> Version Update Record [0-30] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Version update Record is used to identify the updates over version V4.
    ///                           Presence of this record indicates that the file may contain records defined by the new standard.</br></para>
    ///     <para>Frequency: <br> * One for each extension to STDF V4 used.</br></para>
    ///     <para>Location:  <br> Just before the MIR</br></para>
    ///     <para>Note:      <br>Spec says this is just a string, but it seems to be an array of strings.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte)), //upd_cnt is the name of it in a third party program
     ArrayFieldLayout(FieldIndex = 1, FieldType = typeof(string), ArrayLengthFieldIndex = 0, RecordProperty = "UpdateVersionName", NameInSpec = "UPD_NAM")]
    public class Vur : StdfRecord
    {
        public override string FullName => "Version Update Record";
        public override RecordType RecordType => new RecordType(0, 30);


        /// <summary>
        ///     <br>Update Version Name</br>
        ///     <br>UPD_NAM (C*n)</br></summary>
        /// <remarks> This field will contain the version update name. For example the new
        ///           standard name will be stored as “V4–2007” string in the UPD_NAM field.</remarks>
        public string[]? UpdateVersionName { get; set; }
    }
}




