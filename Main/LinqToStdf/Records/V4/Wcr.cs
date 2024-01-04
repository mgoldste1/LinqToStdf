// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Wafer Configuration Record [2-30] </summary>
    ///<remarks>
    ///     <para>Function:  <br> Contains the configuration information for the wafers tested by the job plan.The
    ///                           WCR provides the dimensions and orientation information for all wafers and dice
    ///                           in the lot.This record is used only when testing at wafer probe time.</br></para>
    ///     <para>Frequency: <br> * Obligatory for Wafer sort</br>
    ///                      <br> * One per STDF file</br></para>
    ///     <para>Location:  <br> Anywhere in the data stream after the initial "FAR-(ATRs)-MIR-(RDR)-(SDRs)" sequence, and before the MRR.</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(float), IsOptional = true, MissingValue = (float)0, RecordProperty = "WaferSize", NameInSpec = "WAFR_SIZ"),
    FieldLayout(FieldIndex = 1, FieldType = typeof(float), IsOptional = true, MissingValue = (float)0, RecordProperty = "DieHeight", NameInSpec = "DIE_HT"),
    FieldLayout(FieldIndex = 2, FieldType = typeof(float), IsOptional = true, MissingValue = (float)0, RecordProperty = "DieWidth", NameInSpec = "DIE_WID"),
    FieldLayout(FieldIndex = 3, FieldType = typeof(byte), IsOptional = true, MissingValue = byte.MinValue, RecordProperty = "Units", NameInSpec = "WF_UNITS"),
    StringFieldLayout(FieldIndex = 4, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "Flat", NameInSpec = "WF_FLAT"),
    FieldLayout(FieldIndex = 5, FieldType = typeof(short), IsOptional = true, MissingValue = short.MinValue, RecordProperty = "CenterX", NameInSpec = "CENTER_X"),
    FieldLayout(FieldIndex = 6, FieldType = typeof(short), IsOptional = true, MissingValue = short.MinValue, RecordProperty = "CenterY", NameInSpec = "CENTER_Y"),
    StringFieldLayout(FieldIndex = 7, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "PositiveX", NameInSpec = "POS_X"),
    StringFieldLayout(FieldIndex = 8, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "PositiveY", NameInSpec = "POS_Y")]
    public class Wcr : StdfRecord
    {
        public override string FullName => "Wafer Configuration Record";
        public override RecordType RecordType => new RecordType(2, 30);

        /// <summary>
        ///     <br>Diameter of wafer in WF_UNITS</br>
        ///     <br>WAFR_SIZ ()</br>
        /// </summary>
        public float? WaferSize { get; set; }

        /// <summary>
        ///     <br>Height of die in WF_UNITS</br>
        ///     <br>DIE_HT ()</br>
        /// </summary>
        public float? DieHeight { get; set; }

        /// <summary>
        ///     <br>Width of die in WF_UNITS</br>
        ///     <br>DIE_WID ()</br>
        /// </summary>
        public float? DieWidth { get; set; }

        /// <summary>
        ///     <br>Units for wafer and die dimensions</br>
        ///     <br>WF_UNITS ()</br> </summary>
        /// <remarks>Known values are: 0 (unknown), 1 (in), 2 (cm), 3 (mm), 4 (mils)</remarks>
        public byte? Units { get; set; }

        /// <summary>
        ///     <br>Orientation of wafer flat</br>
        ///     <br>WF_FLAT ()</br></summary>
        /// <remarks>Known values are: U(p), D(own), L(eft), R(ight) and a space is unknown</remarks>
        public string? Flat { get; set; }

        /// <summary>
        ///     <br>X coordinate of center die on wafer</br>
        ///     <br>CENTER_X (I*2)</br></summary>
        /// <remarks>Use short.MinValue to indicate that the field is invalid</remarks>
        public short? CenterX { get; set; }

        /// <summary>
        ///     <br>Y coordinate of center die on wafer</br>
        ///     <br>CENTER_Y (I*2)</br></summary>
        /// <remarks>Use short.MinValue to indicate that the field is invalid</remarks>
        public short? CenterY { get; set; }
        /// <summary>
        ///     <br>Positive X direction of wafer</br>
        ///     <br>POS_X (C*1)</br></summary>
        /// <remarks>Known values are: L(eft), R(inght) and a space is unknown</remarks>
        public string? PositiveX { get; set; }

        /// <summary>
        ///     <br>Positive Y direction of wafer</br>
        ///     <br>POS_Y (C*1)</br></summary>
        /// <remarks>Known values are: U(p), D(own) and a space is unknown</remarks>
        public string? PositiveY { get; set; }
    }
}
