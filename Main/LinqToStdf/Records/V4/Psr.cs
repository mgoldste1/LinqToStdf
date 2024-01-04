///////////////////////////////////////////////////////////////////////////////////////////////////
//The PSRs in my STDFs are barebones. Unsure how well this will work with fully fleshed out ones.//
// (hasn't thrown an error and it's processed 10k+ stdfs)                                        //
///////////////////////////////////////////////////////////////////////////////////////////////////
namespace LinqToStdf.Records.V4 {
    using Attributes;

    ///<summary> Pattern Sequence Record [1-90] (V4-2007)</summary>
    ///<remarks>
    ///     <para>Function:  <br> PSR record contains the information on the pattern profile for a specific executed scan test
    ///                           as part of the Test Identification information. In particular it implements the Test Pattern
    ///                           Map data object in the data model. It specifies how the patterns for that test were constructed.
    ///                           There will be a PSR record for each scan test in a test program. A PSR is referenced by the STR
    ///                           (Scan Test Record) using its PSR_INDX field</br></para>
    ///     <para>Frequency: <br> * Not In Spec</br></para>
    ///     <para>Location:  <br> Not In Spec</br></para></remarks>

    [FieldLayout(FieldIndex = 0, FieldType = typeof(byte), RecordProperty = "ContinuationFlag", NameInSpec = "CONT_FLG"),
     FieldLayout(FieldIndex = 1, FieldType = typeof(ushort), RecordProperty = "PsrRecordIndex", NameInSpec = "PSR_INDX"),
     StringFieldLayout(FieldIndex = 2, RecordProperty = "PsrName", NameInSpec = "PSR_NAM"),
     FieldLayout(FieldIndex = 3, FieldType = typeof(byte), RecordProperty = "OptionalFlags", MissingValue = (byte)0x00,  NameInSpec = "OPT_FLG"),
     FieldLayout(FieldIndex = 4, FieldType = typeof(ushort), RecordProperty = "TotalPatternFileCount", NameInSpec = "TOTP_CNT"),
     FieldLayout(FieldIndex = 5, FieldType = typeof(ushort) /*, NameInSpec = "LOCP_CNT"*/),
     ArrayFieldLayout(FieldIndex = 6, FieldType = typeof(ulong), ArrayLengthFieldIndex = 5, RecordProperty = "PatternBegin", NameInSpec = "PAT_BGN"),
     ArrayFieldLayout(FieldIndex = 7, FieldType = typeof(ulong), ArrayLengthFieldIndex = 5, RecordProperty = "PatternEnd", NameInSpec = "PAT_END"),
     ArrayFieldLayout(FieldIndex = 8, FieldType = typeof(string), ArrayLengthFieldIndex = 5, RecordProperty = "PatternFileNames", NameInSpec = "PAT_FILE"),
     FlaggedArrayFieldLayout(FieldIndex = 9,  FieldType = typeof(string), FlagIndex = 3, ArrayLengthFieldIndex = 5, IsOptional = true, FlagMask = (byte)0x01, RecordProperty = "PatternLabels", NameInSpec = "PAT_LBL"),
     FlaggedArrayFieldLayout(FieldIndex = 10, FieldType = typeof(string), FlagIndex = 3, ArrayLengthFieldIndex = 5, IsOptional = true, FlagMask = (byte)0x02, RecordProperty = "FileIdentifierCodes", NameInSpec = "FILE_UID"),
     FlaggedArrayFieldLayout(FieldIndex = 11, FieldType = typeof(string), FlagIndex = 3, ArrayLengthFieldIndex = 5, IsOptional = true, FlagMask = (byte)0x04, RecordProperty = "AtpgInformation", NameInSpec = "ATPG_DSC"),
     FlaggedArrayFieldLayout(FieldIndex = 12, FieldType = typeof(string), FlagIndex = 3, ArrayLengthFieldIndex = 5, IsOptional = true, FlagMask = (byte)0x08, RecordProperty = "PatternInSrcFileIds", NameInSpec = "SRC_ID")]
    public class Psr : StdfRecord
    {
        public override string FullName => "Pattern Sequence Record";
        public override RecordType RecordType => new RecordType(1, 90);

        /// <summary>
        ///     <br>Continuation PSR record exist; default 0</br> 
        ///     <br>CONT_FLG (B*1)</br></summary>
        /// <remarks>This flag is used to indicated existence of continuation PSR records. If it 
        ///          is set to 1 then it mean a continuation PSR exists.A 0 value indicated that this is the last
        ///          PSR record.</remarks>
        public byte ContinuationFlag { get; set; }

        /// <summary>
        ///     <br>PSR Record Index (used by STR records)</br>
        ///     <br>PSR_INDX (U*2)</br></summary>
        /// <remarks> This is a unique identifier for the set of PSRs that describe the patterns for a scan test.</remarks>
        public ushort PsrRecordIndex { get; set; }

        /// <summary>
        ///     <br>Symbolic name of PSR record</br>
        ///     <br>PSR_NAM (C*n)</br></summary>
        /// <remarks> It is a symbolic name of the test suite to which this PSR belongs. For
        ///           example with reference to figure 8, it would be stuck-at for the test_suite #1</remarks>
        public string? PsrName { get; set; }

        
        /// <summary>
        ///     <br>Contains PAT_LBL, FILE_UID, ATPG_DSC, and SRC_ID field missing flag bits 
        ///         and flag for start index for first cycle number.  Also 3 more bits without associated variables</br>
        ///     <br>OPT_FLG(B*1)</br></summary>
        /// <remarks> This flag is used to indicate the presence of optional fields. 
        ///           If the bit is set to 1 the corresponding optional field is considered missing.</remarks>

        public byte? OptionalFlags { get; set; }
        

        /// <summary>
        ///     <br>Count of total pattern file information sets in the complete PSR data set</br>
        ///     <br>TOTP_CNT</br></summary>
        /// <remarks>This field indicates the total number of pattern that make up a scan test
        ///          over all the PSRs.The description of all the patterns may not fit into a single PSR as
        ///          mention above. For continuation records this should be the same count as for the first
        ///          record (i.e.the final total)</remarks>
        public ushort TotalPatternFileCount { get; set; }

        //LOCP_CNT U*2 Count(k) of pattern file information sets in this record
        //This field indicates the total number of patterns that are described in the current PSR from a scan test.

        //////////////////////////////////////////////////////////////////////////////////////////
        // The next set of fields is repeated for each pattern that is contained in a scan test.//
        // Each of these fields is stored in its own array of size LOCAL_CNT.                   //
        //////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        ///     <br>Array of Cycle #’s patterns begins on</br>
        ///     <br>PAT_BGN</br></summary>
        /// <remarks>The cycle count the specified ATPG pattern begins on. The 1st cycle 
        ///          number is determined by the OPT_FLG (bit 4).</remarks>
        public ulong[]? PatternBegin { get; set; }

        /// <summary>
        ///     <br>Array of Cycle #’s patterns stops at</br>  
        ///     <br>PAT_END</br></summary>
        /// <remarks>The cycle count the specified ATPG pattern ends on.</remarks>
        public ulong[]? PatternEnd { get; set; }

        /// <summary>
        ///     <br>Array of Pattern File Names  </br> 
        ///     <br>PAT_FILE</br></summary>
        /// <remarks>The name of the ATPG file from which the current pattern was created.</remarks>
        public string[]? PatternFileNames { get; set; }

        /// <summary>
        ///     <br>Optional pattern symbolic name</br>
        ///     <br>PAT_LBL</br></summary>
        /// <remarks><br>OPT_FLG bit 0 = 1</br>
        ///          <br>This is a symbolic name of the pattern within a test suite. For
        ///              example, with reference to figure 8 it will be P1 for the pattern coming from file1.</br></remarks>
        public string[]? PatternLabels { get; set; }

        /// <summary>
        ///      <br>Optional array of file identifier code</br>
        ///      <br>FILE_UID</br></summary>
        /// <remarks><br>OPT_FLG bit 1 = 1</br>
        ///          <br>Unique character string that uniquely identifies the file. This
        ///              field is provided as a means to additionally uniquely identify the source file.The exact
        ///              mechanism to use this field is decided by the ATPG software, which will also provide
        ///              this piece of information in the source files during the translation process.</br></remarks>
        public string[]? FileIdentifierCodes { get; set; }

        /// <summary>
        ///      <br>Optional array of ATPG information</br>
        ///      <br>ATPG_DSC</br></summary>
        /// <remarks><br>OPT_FLG bit 2 = 1</br>
        ///          <br>This field intended to be used to store any ASCII data that can
        ///              identify the source tool, time of generation etc.</br></remarks>
        public string[]? AtpgInformation { get; set; }

        /// <summary>
        ///      <br>Optional array of PatternInSrcFileID</br>
        ///      <br>SRC_ID</br></summary>
        /// <remarks><br>OPT_FLG bit 3 = 1</br>
        ///          <br>The name of the specific PatternExec block in the source file. In
        ///              case there are multiple patterns being specified in the source file e.g.multiple
        ///              PatternExec blocks in STIL, this field specifies the one, which is the source of the pattern
        ///              in this PSR</br></remarks>
        public string[]? PatternInSrcFileIds { get; set; }


    }

}
