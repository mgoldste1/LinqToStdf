namespace LinqToStdf.Records.V4
{
    using Attributes;
    using System.Collections;

    ///<summary> Version Update Record [0-30] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Version update Record is used to identify the updates over version V4.
    ///                           Presence of this record indicates that the file may contain records defined by the new standard.</br></para>
    ///     <para>Frequency: <br> * One for each extension to STDF V4 used.</br></para>
    ///     <para>Location:  <br> Just before the MIR</br></para>
    ///     <para>Note:      <br> This is the V93K version of a VUR record. V93K tools make VUR records that are an array of strings. 
    ///                           THIS DOES NOT FOLLOW THE SPEC.</br></para></remarks>

    //these field layouts wont actually be used since we have a custom converter. they are only here for reference.
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


        /// <summary>
        /// If true, it will write the record as an array of strings like V93K testers do.
        /// If false, it will follow the spec and write a single string.
        /// </summary>
        /// <remarks>this can't be public because it makes the unit tests fail.
        ///          we have to use a method to set the var if we want to change the format</remarks>
        private bool? _IsArray { get; set; }
        
        public void SetIsArrayFlag(bool? value) => _IsArray = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unknownRecord"></param>
        /// <returns></returns>
        /// <remarks>Standard parsing doesnt always work since VURs can be in multiple formats. 
        ///          V93K tools write their Vur records as an array of strings, but the spec says it's just a single string.
        ///          I've encountered STDFs that are just a string as well so a custom parser is required.
        /// </remarks>
        internal static Vur ConvertToVur(UnknownRecord unknownRecord)
        {
            //probably should add a flag so it defaults to either an array or a string...
            //if the payload is a 1 0 and you read that in as a string array, it means 1 string in the array but the array is empty.
            //now if you read the 1 0 in as a string, it's a 1 character long string holding a zero (not an ascii zero, just a zero)...
            //i think the string reader will bomb out in this case because it isnt a valid character,
            //but there are probably other potential edge cases where it could switch the format from an array to a string or vice versa.
            Vur vur = new Vur();
            using (BinaryReader reader = new BinaryReader(new MemoryStream(unknownRecord.Content), unknownRecord.Endian, true))
            {
                try
                {
                    byte potentialArraySize = reader.ReadByte();
                    //reader.Reset();
                    if (potentialArraySize > 0)
                    {
                        var strArray = reader.ReadStringArray(potentialArraySize);
                        //chances are if this isn't a string array, an exception was thrown
                        //at the line above and we go straight to the catch block.
                        //if reading the data in the format of an array did not read all of the data, go to the catch block.
                        if (!reader.AtEndOfStream)
                            throw new Exception("Failed to parse VUR Record (Array Area)");

                        vur._IsArray = true;
                        vur.UpdateVersionName = strArray;
                    }
                    else
                    {
                        //if the first byte was 0, that means it's impossible to know if IsArray should be true or false.
                        //if someone gives UpdateVersionName a single value, it will be written as a single string
                        //unless they update the IsArray variable to true. in that case it gets written as 1 value in a list of strings.
                        vur._IsArray = false;
                        vur.UpdateVersionName = null;
                    }
                    return vur;

                }
                catch (Exception ex)
                {
                    //parsing it as an array did not work. try just reading it as 1 string.
                    reader.Reset();
                    string str = reader.ReadString();
                    if (!reader.AtEndOfStream)
                        throw new Exception("Failed to parse VUR Record", ex);

                    vur._IsArray = false;
                    if (str.Length > 0)
                        vur.UpdateVersionName = new string[1] { str };
                    return vur;
                }
            }
        }


        internal static UnknownRecord ConvertFromVur(StdfRecord record, Endian endian)
        {
            Vur vur = (Vur)record;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(stream, endian, false);
                //if the is array variable is true or the updateversion name has a length greater than 1, write it as a string array.
                if (vur._IsArray.HasValue && vur._IsArray.Value)
                {
                    //we read this in as the non-compliant vur format, so write it back out the same way.
                    writer.WriteStringArray(vur.UpdateVersionName);
                }
                else if (vur.UpdateVersionName != null && vur.UpdateVersionName.Length > 1)
                {
                    //assume the variable was editted by the dev because it wasn't read in as an array, but it now contains more than 1 item.
                    writer.WriteStringArray(vur.UpdateVersionName);
                }
                else
                {
                    //it's not an array.
                    //the else if block above will trigger if the length of the array is greater than 1 so checking if it's zero is enough.
                    if (vur.UpdateVersionName == null || vur.UpdateVersionName.Length == 0)
                        writer.WriteString(null);
                    else
                        writer.WriteString(vur.UpdateVersionName[0]);
                }
                return new UnknownRecord(vur.RecordType, stream.ToArray(), endian);
            }
        }
    }
}
