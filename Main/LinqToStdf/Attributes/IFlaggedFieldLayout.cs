using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToStdf.Attributes
{
    public interface IFlaggedFieldLayout
    {
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
