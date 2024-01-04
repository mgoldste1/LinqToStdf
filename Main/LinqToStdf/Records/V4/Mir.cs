// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace LinqToStdf.Records.V4
{
    using Attributes;

    ///<summary> Master Information Record [1-10] </summary>
    ///<remarks>
    ///     <para>Function:  <br> The MIR and the MRR(Master Results Record) contain all the global information that
    ///                           is to be stored for a tested lot of parts.Each data stream must have exactly one MIR,
    ///                           immediately after the FAR(and the ATRs, if they are used). This will allow any data
    ///                           reporting or analysis programs access to this information in the shortest possible
    ///                           amount of time.</br></para>
    ///     <para>Frequency: <br> * Obligatory</br>  
    ///                      <br> * One per data stream.</br></para>
    ///     <para>Location:  <br> Immediately after the File Attributes Record (FAR) and the Audit Trail Records (ATR),
    ///                           if ATRs are used.</br></para></remarks>

    [TimeFieldLayout(FieldIndex = 0, RecordProperty = "SetupTime", NameInSpec = "SETUP_T"),
     TimeFieldLayout(FieldIndex = 1, RecordProperty = "StartTime", NameInSpec = "START_T"),
     FieldLayout(FieldIndex = 2, FieldType = typeof(byte), RecordProperty = "StationNumber", NameInSpec = "STAT_NUM"),
     StringFieldLayout(FieldIndex = 3, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "ModeCode", NameInSpec = "MODE_COD"),
     StringFieldLayout(FieldIndex = 4, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "RetestCode", NameInSpec = "RTST_COD"),
     StringFieldLayout(FieldIndex = 5, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "ProtectionCode", NameInSpec = "PROT_COD"),
     FieldLayout(FieldIndex = 6, IsOptional = true, FieldType = typeof(ushort), MissingValue = ushort.MaxValue, RecordProperty = "BurnInTime", NameInSpec = "BURN_TIM"),
     StringFieldLayout(FieldIndex = 7, IsOptional = true, Length = 1, MissingValue = " ", RecordProperty = "CommandModeCode", NameInSpec = "CMOD_COD"),
     StringFieldLayout(FieldIndex = 8, IsOptional = true, RecordProperty = "LotId", NameInSpec = "LOT_ID"),
     StringFieldLayout(FieldIndex = 9, IsOptional = true, RecordProperty = "PartType", NameInSpec = "PART_TYP"),
     StringFieldLayout(FieldIndex = 10, IsOptional = true, RecordProperty = "NodeName", NameInSpec = "NODE_NAM"),
     StringFieldLayout(FieldIndex = 11, IsOptional = true, RecordProperty = "TesterType", NameInSpec = "TSTR_TYP"),
     StringFieldLayout(FieldIndex = 12, IsOptional = true, RecordProperty = "JobName", NameInSpec = "JOB_NAM"),
     StringFieldLayout(FieldIndex = 13, IsOptional = true, RecordProperty = "JobRevision", NameInSpec = "JOB_REV"),
     StringFieldLayout(FieldIndex = 14, IsOptional = true, RecordProperty = "SublotId", NameInSpec = "SBLOT_ID"),
     StringFieldLayout(FieldIndex = 15, IsOptional = true, RecordProperty = "OperatorName", NameInSpec = "OPER_NAM"),
     StringFieldLayout(FieldIndex = 16, IsOptional = true, RecordProperty = "ExecType", NameInSpec = "EXEC_TYP"),
     StringFieldLayout(FieldIndex = 17, IsOptional = true, RecordProperty = "ExecVersion", NameInSpec = "EXEC_VER"),
     StringFieldLayout(FieldIndex = 18, IsOptional = true, RecordProperty = "TestCode", NameInSpec = "TEST_COD"),
     StringFieldLayout(FieldIndex = 19, IsOptional = true, RecordProperty = "TestTemperature", NameInSpec = "TST_TEMP"),
     StringFieldLayout(FieldIndex = 20, IsOptional = true, RecordProperty = "UserText", NameInSpec = "USER_TXT"),
     StringFieldLayout(FieldIndex = 21, IsOptional = true, RecordProperty = "AuxiliaryFile", NameInSpec = "AUX_FILE"),
     StringFieldLayout(FieldIndex = 22, IsOptional = true, RecordProperty = "PackageType", NameInSpec = "PKG_TYP"),
     StringFieldLayout(FieldIndex = 23, IsOptional = true, RecordProperty = "FamilyId", NameInSpec = "FAMLY_ID"),
     StringFieldLayout(FieldIndex = 24, IsOptional = true, RecordProperty = "DateCode", NameInSpec = "DATE_COD"),
     StringFieldLayout(FieldIndex = 25, IsOptional = true, RecordProperty = "FacilityId", NameInSpec = "FACIL_ID"),
     StringFieldLayout(FieldIndex = 26, IsOptional = true, RecordProperty = "FloorId", NameInSpec = "FLOOR_ID"),
     StringFieldLayout(FieldIndex = 27, IsOptional = true, RecordProperty = "ProcessId", NameInSpec = "PROC_ID"),
     StringFieldLayout(FieldIndex = 28, IsOptional = true, RecordProperty = "OperationFrequency", NameInSpec = "OPER_FRQ"),
     StringFieldLayout(FieldIndex = 29, IsOptional = true, RecordProperty = "SpecificationName", NameInSpec = "SPEC_NAM"),
     StringFieldLayout(FieldIndex = 30, IsOptional = true, RecordProperty = "SpecificationVersion", NameInSpec = "SPEC_VER"),
     StringFieldLayout(FieldIndex = 31, IsOptional = true, RecordProperty = "FlowId", NameInSpec = "FLOW_ID"),
     StringFieldLayout(FieldIndex = 32, IsOptional = true, RecordProperty = "SetupId", NameInSpec = "SETUP_ID"),
     StringFieldLayout(FieldIndex = 33, IsOptional = true, RecordProperty = "DesignRevision", NameInSpec = "DSGN_REV"),
     StringFieldLayout(FieldIndex = 34, IsOptional = true, RecordProperty = "EngineeringId", NameInSpec = "ENG_ID"),
     StringFieldLayout(FieldIndex = 35, IsOptional = true, RecordProperty = "RomCode", NameInSpec = "ROM_COD"),
     StringFieldLayout(FieldIndex = 36, IsOptional = true, RecordProperty = "SerialNumber", NameInSpec = "SERL_NUM"),
     StringFieldLayout(FieldIndex = 37, IsOptional = true, RecordProperty = "SupervisorName", NameInSpec = "SUPR_NAM")]
    public class Mir : StdfRecord
    {
        public override string FullName => "Master Information Record";
        public override RecordType RecordType => new RecordType(1, 10);

        /// <summary>
        ///     <br>Date and time of job setup</br>
        ///     <br>SETUP_T (U*4)</br>
        /// </summary>
        public DateTime? SetupTime { get; set; }

        /// <summary>
        ///     <br>Date and time first part tested</br>
        ///     <br>START_T (U*4)</br>
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     <br>Tester station number</br>
        ///     <br>STAT_NUM (U*1)</br>
        /// </summary>
        public byte StationNumber { get; set; }

        /// <summary>
        ///     <br>Test mode code (e.g. prod, dev) </br>
        ///     <br>MODE_COD (C*1)</br></summary>
        /// <remarks><para>Indicates the station mode under which the parts were tested. Currently defined
        ///                values for the MODE_COD field are: 
        ///                <br>A = AEL (Automatic Edge Lock) mode</br>
        ///                <br>C = Checker mode</br>
        ///                <br>D = Development / Debug test mode</br>
        ///                <br>E = Engineering mode (same as Development mode)</br>
        ///                <br>M = Maintenance mode</br>
        ///                <br>P = Production test mode</br>
        ///                <br>Q = Quality Control</br></para>
        ///          <para>All other alphabetic codes are reserved for future use by Teradyne. The characters 0 -
        ///                9 are available for customer use.</para></remarks>
        public string? ModeCode { get; set; }

        /// <summary>
        ///     <br>Lot retest code</br>
        ///     <br>RTST_COD (C*1)</br></summary>
        /// <remarks><para>Indicates whether the lot of parts has been previously tested under the same test
        ///                conditions. Suggested values are:
        ///                <br>Y = Lot was previously tested.</br>
        ///                <br>N = Lot has not been previously tested.</br>
        ///                <br>space = Not known if lot has been previously tested.</br>
        ///                <br>0 - 9 = Number of times lot has previously been tested.</br></para></remarks>
        public string? RetestCode { get; set; }

        /// <summary>
        ///     <br>Data protection code </br>
        ///     <br>PROT_COD (C*1) </br> </summary>
        /// <remarks>User-defined field indicating the protection desired for the test data being stored. Valid
        ///          values are the ASCII characters 0 - 9 and A - Z. A space in this field indicates a missing
        ///          value (default protection).</remarks>
        public string? ProtectionCode { get; set; }

        /// <summary>
        ///     <br>Burn-in time (in minutes)</br>
        ///     <br>BURN_TIM (U*2)</br>
        /// </summary>
        public ushort? BurnInTime { get; set; }

        /// <summary>
        ///     <br>Command mode code </br>
        ///     <br>CMOD_COD (C*1) </br></summary>
        /// <remarks>Indicates the command mode of the tester during testing of the parts. The user or the
        ///          tester executive software defines command mode values. Valid values are the ASCII
        ///          characters 0 - 9 and A - Z. A space indicates a missing value.</remarks>
        public string? CommandModeCode { get; set; }

        /// <summary>
        ///     <br>Lot ID (customer specified)</br>
        ///     <br>LOT_ID (C*n)</br>
        /// </summary>
        public string? LotId { get; set; }

        /// <summary>
        ///     <br>Part Type (or product ID)</br>
        ///     <br>PART_TYP (C*n)</br>
        /// </summary>
        public string? PartType { get; set; }

        /// <summary>
        ///     <br>Name of node that generated data</br>
        ///     <br>NODE_NAM (C*n)</br>
        /// </summary>
        public string? NodeName { get; set; }

        /// <summary>
        ///     <br>Tester type</br>
        ///     <br>TSTR_TYP (C*n)</br>
        /// </summary>
        public string? TesterType { get; set; }

        /// <summary>
        ///     <br>Job name (test program name)</br>
        ///     <br>JOB_NAM (C*n)</br>
        /// </summary>
        public string? JobName { get; set; }

        /// <summary>
        ///     <br>Job (test program) revision number</br>
        ///     <br>JOB_REV (C*n)</br>
        /// </summary>
        public string? JobRevision { get; set; }

        /// <summary>
        ///     <br>Sublot ID</br>
        ///     <br>SBLOT_ID (C*n)</br>
        /// </summary>
        public string? SublotId { get; set; }

        /// <summary>
        ///     <br>Operator name or ID (at setup time)</br>
        ///     <br>OPER_NAM (C*n)</br>
        /// </summary>
        public string? OperatorName { get; set; }

        /// <summary>
        ///     <br>Tester executive software type</br>
        ///     <br>EXEC_TYP (C*n)</br>
        /// </summary>
        public string? ExecType { get; set; }

        /// <summary>
        ///     <br>Tester exec software version number</br>
        ///     <br>EXEC_VER (C*n)</br>
        /// </summary>
        public string? ExecVersion { get; set; }

        /// <summary>
        ///     <br>Test phase or step code</br>
        ///     <br>TEST_COD (C*n)</br></summary>
        /// <remarks>A user-defined field specifying the phase or step in the device testing process.</remarks>
        public string? TestCode { get; set; }

        /// <summary>
        ///     <br>Test temperature</br>
        ///     <br>TST_TEMP (C*n)</br></summary>
        /// <remarks>The test temperature is an ASCII string. Therefore, it can be stored as degrees Celsius,
        ///          Fahrenheit, Kelvin or whatever. It can also be expressed in terms like HOT, ROOM, and
        ///          COLD if that is preferred.</remarks>
        public string? TestTemperature { get; set; }

        /// <summary>
        ///     <br>Generic user text</br>
        ///     <br>USER_TXT (C*n)</br>
        /// </summary>
        public string? UserText { get; set; }

        /// <summary>
        ///     <br>Name of auxiliary data file</br>
        ///     <br>AUX_FILE (C*n)</br>
        /// </summary>
        public string? AuxiliaryFile { get; set; }

        /// <summary>
        ///     <br>Package type</br>
        ///     <br>PKG_TYP (C*n)</br>
        /// </summary>
        public string? PackageType { get; set; }

        /// <summary>
        ///     <br>Product family ID</br>
        ///     <br>FAMLY_ID (C*n)</br>
        /// </summary>
        public string? FamilyId { get; set; }

        /// <summary>
        ///     <br>Date code</br>
        ///     <br>DATE_COD (C*n)</br>
        /// </summary>
        public string? DateCode { get; set; }

        /// <summary>
        ///     <br>Test facility ID</br>
        ///     <br>FACIL_ID (C*n)</br>
        /// </summary>
        public string? FacilityId { get; set; }

        /// <summary>
        ///     <br>Test floor ID</br>
        ///     <br>FLOOR_ID (C*n)</br>
        /// </summary>
        public string? FloorId { get; set; }

        /// <summary>
        ///     <br>Fabrication process ID</br>
        ///     <br>PROC_ID (C*n)</br>
        /// </summary>
        public string? ProcessId { get; set; }

        /// <summary>
        ///     <br>Operation frequency or step</br>
        ///     <br>OPER_FRQ (C*n)</br>
        /// </summary>
        public string? OperationFrequency { get; set; }

        /// <summary>
        ///     <br>Test specification name</br>
        ///     <br>SPEC_NAM (C*n)</br>
        /// </summary>
        public string? SpecificationName { get; set; }

        /// <summary>
        ///     <br>Test specification version number</br>
        ///     <br>SPEC_VER (C*n)</br>
        /// </summary>
        public string? SpecificationVersion { get; set; }

        /// <summary>
        ///     <br>Test flow ID</br>
        ///     <br>FLOW_ID (C*n)</br>
        /// </summary>
        public string? FlowId { get; set; }

        /// <summary>
        ///     <br>Test setup ID</br>
        ///     <br>SETUP_ID (C*n)</br>
        /// </summary>
        public string? SetupId { get; set; }

        /// <summary>
        ///     <br>Device design revision</br>
        ///     <br>DSGN_REV (C*n)</br>
        /// </summary>
        public string? DesignRevision { get; set; }

        /// <summary>
        ///     <br>Engineering lot ID</br>
        ///     <br>ENG_ID (C*n)</br>
        /// </summary>
        public string? EngineeringId { get; set; }

        /// <summary>
        ///     <br>ROM code ID</br>
        ///     <br>ROM_COD (C*n)</br>
        /// </summary>
        public string? RomCode { get; set; }

        /// <summary>
        ///     <br>Tester serial number</br>
        ///     <br>SERL_NUM (C*n)</br>
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        ///     <br>Supervisor name or ID</br>
        ///     <br>SUPR_NAM (C*n)</br>
        /// </summary>
        public string? SupervisorName { get; set; }
    }
}