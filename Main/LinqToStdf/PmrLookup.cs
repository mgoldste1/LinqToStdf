
using LinqToStdf.Records.V4;

namespace LinqToStdf
{
    /// <summary>
    /// this allows you to lookup pmrs by their index (pmr_indx variable in spec) quickly and easily.
    /// </summary>
    public class PmrLookup
    {
        readonly Dictionary<ushort, Pmr> pmrs;
        private static readonly object @lock = new();

        internal PmrLookup(StdfFile f)
        {
            if (pmrs == null)
                lock (@lock)
                    pmrs ??= f.GetRecords().OfExactType<Pmr>().ToDictionary(k => k.PinIndex, v => v);
        }
        public Pmr Get(ushort pinIndex)
        {
            return pmrs[pinIndex];
        }
        public Pmr Get(string pinIndex)
        {
            if (ushort.TryParse(pinIndex, out ushort output))
                return pmrs[output];
            else
                throw new Exception("Input could not be transformed into a ushort");
        }

        public Pmr Get(int pinIndex)
        {
            return Get("" + pinIndex);
        }
        public Pmr Get(object pinIndex)
        {
            if (pinIndex == null) throw new Exception("Null put into PMR.Get");
            if (pinIndex is string pStr)
                return Get(pStr);
            else if (pinIndex is ushort pi)
                return Get(pi);
            else if (pinIndex.GetType().IsPrimitive)
                return Get(Convert.ToUInt16(pinIndex));
            else
                throw new Exception("Input object was not a primitive type or string, so we can't figure out what kind of object you inputted");
        }
        public List<Pmr> GetAll(ushort[]? pinIndexes)
        {
            List<Pmr> pmrs = new List<Pmr>();
            if (pinIndexes == null)
                return pmrs;

            foreach (var p in pinIndexes)
                pmrs.Add(Get(p));
            return pmrs;
        }
    }
}
