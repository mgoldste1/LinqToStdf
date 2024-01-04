// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;
    /// <summary> File Attributes Record [0-10] </summary>
    /// <remarks>
    ///     <para>Function:  <br> Contains the information necessary to determine how to decode the STDF data contained in the file.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>
    ///                      <br> * One per datastream</br></para>
    ///     <para>Location:  <br> First record of the STDF file</br></para></remarks>
    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), RecordProperty = "CpuType", NameInSpec = "CPU_TYPE"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(byte), MissingValue = (byte)4, RecordProperty = "StdfVersion", NameInSpec = "STDF_VER")]
    public class Far : StdfRecord
    {
        public override string FullName => "File Attribute Record";
        public override RecordType RecordType => new RecordType(0, 10);

        /// <summary> 
        ///     <para>CPU type that wrote this file</para>
        ///     <para>CPU_TYPE (U*1)</para></summary>
        /// <remarks>Indicates which type of CPU wrote this STDF file. This information is useful for
        ///          determining the CPU-dependent data representation of the integer and floating point
        ///          0 = DEC PDP-11 and VAX processors. F and D floating point formats
        ///          will be used. G and H floating point formats will not be used.
        ///          1 = Sun 1, 2, 3, and 4 computers.
        ///          2 = Sun 386i computers, and IBM PC, IBM PC-AT, and IBM PC-XT computers.
        ///          3-127 = Reserved for future use by Teradyne.
        ///          128-255 = Reserved for use by customers.
        ///          A code defined here may also be valid for other CPU types whose data formats are fully
        ///          compatible with that of the type listed here. Before using one of these codes for a CPU
        ///          type not listed here, please check with the Teradyne hotline, which can provide
        ///          information on CPU compatibility.</remarks>
        public byte CpuType { get; set; }

        /// <summary>
        ///      <para>STDF version number</para>
        ///      <para>STDF_VER (U*1)</para></summary>
        /// <remarks>Identifies the version number of the STDF specification used in generating the data.
        ///          This allows data analysis programs to handle STDF specification enhancements.</remarks>
        public byte StdfVersion { get; set; }
    }
}
