﻿// https://github.com/marklio/LinqToStdf
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToStdf.Attributes
{

    /// <summary>
    /// Defines an STDF field whose "null" state is set by an external bitfield byte
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class FlaggedArrayFieldLayoutAttribute : ArrayFieldLayoutAttribute, IFlaggedFieldLayout
    {
        public FlaggedArrayFieldLayoutAttribute()
        {
            base.IsOptional = true;
            base.PersistMissingValue = true;
        }

        /// <summary>
        /// This indicates the bitfield byte used to determine if we have a value
        /// for this field
        /// </summary>
        public int FlagIndex { get; set; }
        /// <summary>
        /// This indicates the mask that is used on the bitfield to determine if we have a value.
        /// </summary>
        public byte FlagMask { get; set; }

    }
}

