// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Pin List Record [1-63] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Defines the current display radix and operating mode for a pin or pin group.</br></para>
    ///     <para>Frequency: <br> * Optional</br>
    ///                      <br> * One or more whenever the usage of a pin or pin group changes in the test program.</br></para>
    ///     <para>Location:  <br> After all the PMRs and PGRs whose PMR index values and pin group index values are
    ///                           listed in the GRP_INDX array of this record; and before the first FTR that references pins
    ///                           or pin groups whose modes are defined in this record.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(ushort), NameInSpec = ""),
    ArrayFieldLayout(FieldIndex = 1, FieldType = typeof(ushort), ArrayLengthFieldIndex = 0, RecordProperty = "GroupIndexes", NameInSpec = "GRP_CNT"),
    ArrayFieldLayout(FieldIndex = 2, FieldType = typeof(ushort), IsOptional = true, MissingValue = ushort.MinValue, ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "GroupModes", NameInSpec = "GRP_MODE"),
    ArrayFieldLayout(FieldIndex = 3, FieldType = typeof(byte), IsOptional = true, MissingValue = byte.MinValue, ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "GroupRadixes", NameInSpec = "GRP_RADX"),
    ArrayFieldLayout(FieldIndex = 4, FieldType = typeof(string), IsOptional = true, MissingValue = "", ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "ProgramStatesRight", NameInSpec = "PGM_CHAR"),
    ArrayFieldLayout(FieldIndex = 5, FieldType = typeof(string), IsOptional = true, MissingValue = "", ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "ReturnStatesRight", NameInSpec = "RTN_CHAR"),
    ArrayFieldLayout(FieldIndex = 6, FieldType = typeof(string), IsOptional = true, MissingValue = "", ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "ProgramStatesLeft", NameInSpec = "PGM_CHAL"),
    ArrayFieldLayout(FieldIndex = 7, FieldType = typeof(string), IsOptional = true, MissingValue = "", ArrayLengthFieldIndex = 0, AllowTruncation = true, RecordProperty = "ReturnStatesLeft", NameInSpec = "RTN_CHAL")]
    public class Plr : StdfRecord
    {
        public override string FullName => "Pin List Record";
        public override RecordType RecordType => new RecordType(1, 63);

        //GRP_CNT U*2 Count (k) of pins or pin groups
        //GRP_CNT defines the number of pins or pin groups whose radix and mode are being
        //        defined.Therefore, it defines the size of each of the arrays that follow in the record.
        //GRP_CNT must be greater than zero

        /// <summary>
        ///     <br>Array of pin or pin group indexes</br>
        ///     <br>GRP_INDX (kxU*2)</br>
        /// </summary>
        public ushort[]? GroupIndexes { get; set; }

        /// <summary>
        ///     <br>Operating mode of pin group</br>
        ///     <br>GRP_MODE (kxU*2)</br></summary>
        /// <remarks><br>The following are valid values for the pin group mode:</br>
        ///          <br> 00 = Unknown</br>
        ///          <br> 10 = Normal</br>
        ///          <br> 20 = SCIO(Same Cycle I/O)</br>
        ///          <br> 21 = SCIO Midband</br>
        ///          <br> 22 = SCIO Valid</br>
        ///          <br> 23 = SCIO Window Sustain</br>
        ///          <br> 30 = Dual drive(two drive bits per cycle)</br>
        ///          <br> 31 = Dual drive Midband</br>
        ///          <br> 32 = Dual drive Valid</br>
        ///          <br> 33 = Dual drive Window Sustain</br>
        ///     <para>Unused pin group modes in the range of 1 through 32,767 are reserved for future use.
        ///           Pin group modes 32,768 through 65,535 are available for customer use.</para></remarks>
        public ushort[]? GroupModes { get; set; }

        /// <summary>
        ///     <br>Display radix of pin group</br>
        ///     <br>GRP_RADX (kxU*1)</br></summary>
        /// <remarks><br> The following are valid values for the pin group display radix:</br>
        ///          <br> 0 = Use display program default</br>
        ///          <br> 2 = Display in Binary</br>
        ///          <br> 8 = Display in Octal</br>
        ///          <br> 10 = Display in Decimal</br>
        ///          <br> 16 = Display in Hexadecimal</br>
        ///          <br> 20 = Display as symbolic</br></remarks>
        public byte[]? GroupRadixes { get; set; }

        /// <summary>
        ///     <br> Program state encoding characters</br>
        ///     <br> PGM_CHAR (kxC*n)</br></summary>
        /// <remarks>These ASCII characters are used to display the programmed state in the FTR or MPR.
        ///          Use of these character arrays makes it possible to store tester-dependent display
        ///          representations in a tester-independent format.If a single character is used to
        ///          represent each programmed state, then only the PGM_CHAR array need be used. If two
        ///          characters represent each state, then the first (left) character is stored in PGM_CHAL
        ///          and the second (right) character is stored in PGM_CHAR.</remarks>
        public string[]? ProgramStatesRight { get; set; }

        /// <summary>
        ///     <br> Return state encoding characters</br>
        ///     <br> RTN_CHAR (kxC*n)</br></summary>
        /// <remarks>These ASCII characters are used to display the returned state in the FTR or MPR. Use
        ///          of these character arrays makes it possible to store tester-dependent display
        ///          representations in a tester-independent format.If a single character is used to
        ///          represent each returned state, then only the RTN_CHAR array need be used. If two
        ///          characters represent each state, then the first (left) character is stored in RTN_CHAL
        ///          and the second (right) character is stored in RTN_CHAR.</remarks>
        public string[]? ReturnStatesRight { get; set; }

        /// <summary>
        ///     <br> Program state encoding characters</br>
        ///     <br> PGM_CHAL (kxC*n)</br></summary>
        /// <remarks>These ASCII characters are used to display the programmed state in the FTR or MPR.
        ///          Use of these character arrays makes it possible to store tester-dependent display
        ///          representations in a tester-independent format.If a single character is used to
        ///          represent each programmed state, then only the PGM_CHAR array need be used. If two
        ///          characters represent each state, then the first (left) character is stored in PGM_CHAL
        ///          and the second (right) character is stored in PGM_CHAR.</remarks>
        public string[]? ProgramStatesLeft { get; set; }

        /// <summary>
        ///     <br> Return state encoding characters</br>
        ///     <br> RTN_CHAL (kxC*n)</br></summary>
        /// <remarks>These ASCII characters are used to display the returned state in the FTR or MPR. Use
        ///          of these character arrays makes it possible to store tester-dependent display
        ///          representations in a tester-independent format.If a single character is used to
        ///          represent each returned state, then only the RTN_CHAR array need be used. If two
        ///          characters represent each state, then the first (left) character is stored in RTN_CHAL
        ///          and the second (right) character is stored in RTN_CHAR.</remarks>
        public string[]? ReturnStatesLeft { get; set; }

        internal static Plr ConvertToPlr(UnknownRecord unknownRecord)
        {
            Plr plr = new Plr();
            using (BinaryReader reader = new BinaryReader(new MemoryStream(unknownRecord.Content), unknownRecord.Endian, true))
            {
                // Group count and list of group indexes are required
                ushort groupCount = reader.ReadUInt16();
                plr.GroupIndexes = reader.ReadUInt16Array(groupCount, true);

                // Latter arrays are optional, and may be truncated
                if (!reader.AtEndOfStream)
                {
                    ushort[] groupModes = reader.ReadUInt16Array(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((groupModes != null) && (groupModes.Length < groupCount))
                    {
                        int i = groupModes.Length;
                        Array.Resize<ushort>(ref groupModes, groupCount);
                        for (; i < groupModes.Length; i++)
                            groupModes[i] = ushort.MinValue;
                    }
                    plr.GroupModes = groupModes;
                }
                if (!reader.AtEndOfStream)
                {
                    byte[] groupRadixes = reader.ReadByteArray(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((groupRadixes != null) && (groupRadixes.Length < groupCount))
                    {
                        int i = groupRadixes.Length;
                        Array.Resize<byte>(ref groupRadixes, groupCount);
                        for (; i < groupRadixes.Length; i++)
                            groupRadixes[i] = byte.MinValue;
                    }
                    plr.GroupRadixes = groupRadixes;
                }
                if (!reader.AtEndOfStream)
                {
                    string[] programStatesRight = reader.ReadStringArray(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((programStatesRight != null) && (programStatesRight.Length < groupCount))
                    {
                        int i = programStatesRight.Length;
                        Array.Resize<string>(ref programStatesRight, groupCount);
                        for (; i < programStatesRight.Length; i++)
                            programStatesRight[i] = "";
                    }
                    plr.ProgramStatesRight = programStatesRight;
                }
                if (!reader.AtEndOfStream)
                {
                    string[] returnStatesRight = reader.ReadStringArray(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((returnStatesRight != null) && (returnStatesRight.Length < groupCount))
                    {
                        int i = returnStatesRight.Length;
                        Array.Resize<string>(ref returnStatesRight, groupCount);
                        for (; i < returnStatesRight.Length; i++)
                            returnStatesRight[i] = "";
                    }
                    plr.ReturnStatesRight = returnStatesRight;
                }
                if (!reader.AtEndOfStream)
                {
                    string[] programStatesLeft = reader.ReadStringArray(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((programStatesLeft != null) && (programStatesLeft.Length < groupCount))
                    {
                        int i = programStatesLeft.Length;
                        Array.Resize<string>(ref programStatesLeft, groupCount);
                        for (; i < programStatesLeft.Length; i++)
                            programStatesLeft[i] = "";
                    }
                    plr.ProgramStatesLeft = programStatesLeft;
                }
                if (!reader.AtEndOfStream)
                {
                    string[] returnStatesLeft = reader.ReadStringArray(groupCount, false);
                    // Expand a truncated array, filling with missing value
                    if ((returnStatesLeft != null) && (returnStatesLeft.Length < groupCount))
                    {
                        int i = returnStatesLeft.Length;
                        Array.Resize<string>(ref returnStatesLeft, groupCount);
                        for (; i < returnStatesLeft.Length; i++)
                            returnStatesLeft[i] = "";
                    }
                    plr.ReturnStatesLeft = returnStatesLeft;
                }
            }
            return plr;
        }

        internal static UnknownRecord ConvertFromPlr(StdfRecord record, Endian endian)
        {
            Plr plr = (Plr)record;
            using (MemoryStream stream = new MemoryStream())
            {
                // Writing the PLR backwards
                BinaryWriter writer = new BinaryWriter(stream, endian, true);

                // Get GroupIndexes length, which must be consistent with all other arrays, except for the last one present, which may be truncated
                if (plr.GroupIndexes == null)
                    throw new InvalidOperationException(String.Format(Resources.NonNullableField, 1, typeof(Plr)));

                int groupCount = plr.GroupIndexes.Length;
                if (groupCount > UInt16.MaxValue)
                    throw new InvalidOperationException(String.Format(Resources.ArrayTooLong, UInt16.MaxValue, 1, typeof(Plr)));

                bool fieldsWritten = false;

                // Field 7: ReturnStatesLeft
                if (plr.ReturnStatesLeft != null)
                {
                    // Check for larger group length (writing has definitely not occurred yet)
                    if (plr.ProgramStatesLeft.Length > groupCount)
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 7));
                    // Write the field
                    writer.WriteStringArray(plr.ReturnStatesLeft);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    string[] arr = new string[groupCount];
                    Array.ForEach<string>(arr, delegate (string a) { a = ""; });
                    writer.WriteStringArray(arr);
                }

                // Field 6: ProgramStatesLeft
                if (plr.ProgramStatesLeft != null)
                {
                    // Check for larger, or not equal group length ifwriting has occurred
                    if ((plr.ProgramStatesLeft.Length > groupCount) || (fieldsWritten && (plr.ProgramStatesLeft.Length != groupCount)))
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 6));
                    // Write the field
                    writer.WriteStringArray(plr.ProgramStatesLeft);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    string[] arr = new string[groupCount];
                    Array.ForEach<string>(arr, delegate (string a) { a = ""; });
                    writer.WriteStringArray(arr);
                }

                // Field 5: ReturnStatesRight
                if (plr.ReturnStatesRight != null)
                {
                    // Check for larger, or not equal group length ifwriting has occurred
                    if ((plr.ReturnStatesRight.Length > groupCount) || (fieldsWritten && (plr.ReturnStatesRight.Length != groupCount)))
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 5));
                    // Write the field
                    writer.WriteStringArray(plr.ReturnStatesRight);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    string[] arr = new string[groupCount];
                    Array.ForEach<string>(arr, delegate (string a) { a = ""; });
                    writer.WriteStringArray(arr);
                }

                // Field 4: ProgramStatesRight
                if (plr.ProgramStatesRight != null)
                {
                    // Check for larger, or not equal group length ifwriting has occurred
                    if ((plr.ProgramStatesRight.Length > groupCount) || (fieldsWritten && (plr.ProgramStatesRight.Length != groupCount)))
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 4));
                    // Write the field
                    writer.WriteStringArray(plr.ProgramStatesRight);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    string[] arr = new string[groupCount];
                    Array.ForEach<string>(arr, delegate (string a) { a = ""; });
                    writer.WriteStringArray(arr);
                }

                // Field 3: GroupRadixes
                if (plr.GroupRadixes != null)
                {
                    // Check for larger, or not equal group length ifwriting has occurred
                    if ((plr.GroupRadixes.Length > groupCount) || (fieldsWritten && (plr.GroupRadixes.Length != groupCount)))
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 3));
                    // Write the field
                    writer.WriteByteArray(plr.GroupRadixes);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    byte[] arr = new byte[groupCount];
                    Array.ForEach<byte>(arr, delegate (byte a) { a = Byte.MinValue; });
                    writer.WriteByteArray(arr);
                }

                // Field 2: GroupModes
                if (plr.GroupModes != null)
                {
                    // Check for larger, or not equal group length ifwriting has occurred
                    if ((plr.GroupModes.Length > groupCount) || (fieldsWritten && (plr.GroupModes.Length != groupCount)))
                        throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 2));
                    // Write the field
                    writer.WriteUInt16Array(plr.GroupModes);
                    fieldsWritten = true;
                }
                else if (fieldsWritten)
                {
                    // Fill an array of missing values and write
                    ushort[] arr = new ushort[groupCount];
                    Array.ForEach<ushort>(arr, delegate (ushort a) { a = UInt16.MinValue; });
                    writer.WriteUInt16Array(arr);
                }

                // Field 1: GroupIndexes
                // Check for larger, or not equal group length ifwriting has occurred
                if ((plr.GroupIndexes.Length > groupCount) || (fieldsWritten && (plr.GroupIndexes.Length != groupCount)))
                    throw new InvalidOperationException(String.Format(Resources.SharedLengthViolation, 1));
                // Write the field
                writer.WriteUInt16Array(plr.GroupIndexes);
                fieldsWritten = true;

                // Field 0: Group Count
                writer.WriteUInt16((ushort)groupCount);

                // Reverse bytes in stream
                long length = stream.Length;
                if (length > UInt16.MaxValue)
                    throw new InvalidOperationException(Resources.RecordTooLong);
                byte[] sa = stream.ToArray();
                Array.Reverse(sa, 0, (int)length);

                return new UnknownRecord(plr.RecordType, sa, endian);
            }
        }
    }
}
