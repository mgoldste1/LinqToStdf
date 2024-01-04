// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.
using LinqToStdf.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToStdf {

    /// <summary>
    /// Abstract stdf record type
    /// </summary>
    public abstract class StdfRecord : IRecordContext {

        /// <summary>
        /// Returns the name of the record, which is set on each record.
        /// </summary>
        public virtual string FullName { get => "UNKNOWN"; }

        public string ShortRecName
        {
            get
            {
                return this.GetType().Name;
            }
        }
        /// <summary>
        /// The <see cref="RecordType"/> of the instance
        /// </summary>
        public abstract RecordType RecordType { get; }

        /// <summary>
        /// this allows you to group up on the record type without it bombing out. helpful for creating summaries of the contents in an stdf file
        /// </summary>
        /// <returns></returns>
        public RecordType GetRecordType_Safe()
        {
            try
            {
                return RecordType;
            }
            catch
            {
                if (this.GetType() == typeof(StartOfStreamRecord))
                    return new RecordType(254, 254);
                else if (this.GetType() == typeof(EndOfStreamRecord))
                    return new RecordType(254, 255);
                else
                    return new RecordType(255, 255);
            }
        }

        /// <summary>
        /// Reference to the "owning" StdfFile.
        /// </summary>
        public StdfFile StdfFile {
            get { return _StdfFile ?? throw new InvalidOperationException("StdfFile has not yet been set."); } set { _StdfFile = value; } }
        StdfFile? _StdfFile = null;

        /// <summary>
        /// Indicates whether this record should be considered for persisting to a file.
        /// </summary>
        public virtual bool IsWritable { get { return true; } }

        ulong _OffsetData;

        /// <summary>
        /// The mask used for the offset data. (we're reserving the 2 highest bits)
        /// </summary>
        static readonly ulong _OffsetMask = 0x3fffffffffffffff;

        /// <summary>
        /// The file/stream offset of this record's header
        /// </summary>
        public long Offset {
            get { return (long)(_OffsetData & _OffsetMask); }
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("value", "Offset must be >= 0");
                }
                if (value >= (long)_OffsetMask) {
                    throw new ArgumentOutOfRangeException("value", "The offset is to large to be stored in an StdfRecord.");
                }
                _OffsetData = (~_OffsetMask & _OffsetData) | (_OffsetMask & (ulong)value);
            }
        }

        /// <summary>
        /// The mask used for the synthesized bit
        /// </summary>
        static readonly ulong _SynthesizedMask = 0x8000000000000000;

        /// <summary>
        /// Indicates whether or not this record was synthesized
        /// </summary>
        public bool Synthesized {
            get { return (_SynthesizedMask & _OffsetData) != 0; }
            set { _OffsetData = value ? _OffsetData | _SynthesizedMask : _OffsetData & ~_SynthesizedMask; }
        }
    }
}
