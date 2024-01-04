// (c) Copyright Mark Miller.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.
using LinqToStdf.Records.V4;
using System.Linq.Expressions;
using System.Reflection;

namespace LinqToStdf {

    /// <summary>
    /// Provides convenient shortcuts to query the structure of STDF as extension methods.
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// Returns only records of an exact type
        /// </summary>
        /// <typeparam name="TRecord"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TRecord> OfExactType<TRecord>(this IEnumerable<StdfRecord> source) where TRecord : StdfRecord {
            foreach (var r in source) {
                if (r.GetType() == typeof(TRecord)) yield return (TRecord)r;
            }
        }
        /// <summary>
        /// Returns only records of an exact type
        /// </summary>
        /// <typeparam name="TRecord"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<StdfRecord> OfExactType(this IEnumerable<StdfRecord> source, string className)
        {
            Type type = Type.GetType("LinqToStdf.Records.V4." + className, true, true) ?? throw new Exception("Failed to find type of " + "LinqToStdf.Records.V4." + className);

            foreach (var r in source)
            {
                if (r.GetType() == type) yield return r;
            }
        }

        /// <summary>
        /// Returns only records of an exact type
        /// </summary>
        /// <typeparam name="TRecord"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<TRecord> OfExactType<TRecord>(this IQueryable<StdfRecord> source) where TRecord : StdfRecord
        {
            return source.Provider.CreateQuery<TRecord>(
                Expression.Call(
                    ((MethodInfo)(MethodBase.GetCurrentMethod() ?? throw new InvalidOperationException("Couldn't get current method."))).MakeGenericMethod(typeof(TRecord)),
                    source.Expression));
        }
        /// <summary>
        /// Returns only records of an exact type
        /// </summary>
        /// <typeparam name="TRecord"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<StdfRecord> OfExactType<StdfRecord>(this IQueryable<StdfRecord> queryable, string className)
        {
            Type runtimeType = Type.GetType("LinqToStdf.Records.V4." + className, true, true) ?? throw new Exception("Failed to find type of " + "LinqToStdf.Records.V4." + className);
            var method = typeof(Queryable).GetMethod(nameof(Queryable.OfType));
            var generic = method.MakeGenericMethod(new[] { runtimeType });
            return (IQueryable<StdfRecord>)generic.Invoke(null, new[] { queryable });
        }

        #region extending IRecordContext

        /// <summary>
        /// Gets the <see cref="Mir"/> for the record context.
        /// </summary>
        public static Mir? GetMir(this IRecordContext record) {
            return (from mir in record.StdfFile.GetRecords().OfExactType<Mir>()
                    select mir).FirstOrDefault();
        }

        /// <summary>
        /// Gets the <see cref="Mrr"/> for the record context.
        /// </summary>
        public static Mrr? GetMrr(this IRecordContext record) {
            return (from mrr in record.StdfFile.GetRecords().OfExactType<Mrr>()
                    select mrr).FirstOrDefault();
        }

        /// <summary>
        /// Gets the <see cref="Pcr">Pcrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Pcr> GetPcrs(this IRecordContext record) {
            return record.StdfFile.GetRecords().OfExactType<Pcr>();
        }

        /// <summary>
        /// Gets the <see cref="Pcr">Pcrs</see> for the record context
        /// with the given head and site.
        /// </summary>
        public static IEnumerable<Pcr> GetPcrs(this IRecordContext record, byte headNumber, byte siteNumber) {
            return from r in record.StdfFile.GetRecords().OfExactType<Pcr>()
                   where r.HeadNumber == headNumber && r.SiteNumber == siteNumber
                   select r;
        }

        /// <summary>
        /// Gets the summary (head 255) <see cref="Pcr"/> for the record context.
        /// </summary>
        public static Pcr? GetSummaryPcr(this IRecordContext record) {
            return (from r in record.StdfFile.GetRecords().OfExactType<Pcr>()
                    where r.HeadNumber == 255
                    select r).FirstOrDefault();
        }

        /// <summary>
        /// Gets the <see cref="Hbr">Hbrs</see> for the record context.
        /// </summary>
        /// <param name="record">The record context</param>
        /// <returns>All the <see cref="Hbr">Hbrs</see>.</returns>
        public static IEnumerable<Hbr> GetHbrs(this IRecordContext record) {
            return record.StdfFile.GetRecords().OfExactType<Hbr>();
        }

        /// <summary>
        /// Gets the <see cref="Hbr">Hbrs</see> for the record context
        /// with the given head and site.
        /// </summary>
        public static IEnumerable<Hbr> GetHbrs(this IRecordContext record, byte headNumber, byte siteNumber) {
            return GetBinRecords<Hbr>(record, headNumber, siteNumber);
        }

        /// <summary>
        /// Gets the summary (head 255) <see cref="Hbr">Hbrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Hbr> GetSummaryHbrs(this IRecordContext record) {
            return from r in record.StdfFile.GetRecords().OfExactType<Hbr>()
                   where r.HeadNumber == 255
                   select r;
        }

        /// <summary>
        /// Gets the <see cref="Sbr">Sbrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Sbr> GetSbrs(this IRecordContext record) {
            return record.StdfFile.GetRecords().OfExactType<Sbr>();
        }

        /// <summary>
        /// Gets the <see cref="Sbr">Sbrs</see> for the record context
        /// with the given head and site.
        /// </summary>
        public static IEnumerable<Sbr> GetSbrs(this IRecordContext record, byte headNumber, byte siteNumber) {
            return GetBinRecords<Sbr>(record, headNumber, siteNumber);
        }

        /// <summary>
        /// Gets the summary (head 255) <see cref="Sbr">Sbrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Sbr> GetSummarySbrs(this IRecordContext record) {
            return from r in record.StdfFile.GetRecords().OfExactType<Sbr>()
                   where r.HeadNumber == 255
                   select r;
        }

        /// <summary>
        /// Gets the <see cref="Tsr">Tsrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Tsr> GetTsrs(this IRecordContext record) {
            return record.StdfFile.GetRecords().OfExactType<Tsr>();
        }

        /// <summary>
        /// Gets the <see cref="Tsr">Tsrs</see> for the record context
        /// with the given head and site.
        /// </summary>
        public static IEnumerable<Tsr> GetTsrs(this IRecordContext record, byte headNumber, byte siteNumber) {
            return from r in record.StdfFile.GetRecords().OfExactType<Tsr>()
                   where r.HeadNumber == headNumber && r.SiteNumber == siteNumber
                   select r;
        }

        /// <summary>
        /// Gets the summary (head 255) <see cref="Tsr">Tsrs</see> for the record context.
        /// </summary>
        public static IEnumerable<Tsr> GetSummaryTsrs(IRecordContext record) {
            return from r in record.StdfFile.GetRecords().OfExactType<Tsr>()
                   where r.HeadNumber == 255
                   select r;
        }

        #region Helpers

        static IEnumerable<T> GetBinRecords<T>(IRecordContext record, byte head, byte site) where T : BinSummaryRecord {
            return from r in record.StdfFile.GetRecords().OfExactType<T>()
                   where r.HeadNumber == head && r.SiteNumber == site
                   select r;
        }

        #endregion

        #endregion

        #region extending StdfRecord

        /// <summary>
        /// returns records that occur before the given record
        /// </summary>
        /// <param name="record">The "marker" record</param>
        /// <returns>All the records before the marker record</returns>
        static public IEnumerable<StdfRecord> Before(this StdfRecord record) {
            return record.StdfFile.GetRecords().TakeWhile(r => r.Offset < record.Offset);
        }

        /// <summary>
        /// Returns the records that occur after the given record
        /// </summary>
        /// <param name="record">The "marker" record</param>
        /// <returns>All the records after the marker record</returns>
        static public IEnumerable<StdfRecord> After(this StdfRecord record) {
            return record.StdfFile.GetRecords().SkipWhile(r => r.Offset <= record.Offset);
        }

        #endregion

        #region Extending Wrr

        /// <summary>
        /// Gets the <see cref="Prr">Prrs</see> for this wafer.
        /// </summary>
        static public IEnumerable<Prr> GetPrrs(this Wrr wrr) {
            return from prr in wrr.StdfFile.GetRecords().OfExactType<Prr>()
                   where prr.HeadNumber == wrr.HeadNumber
                   select prr;
        }

        #endregion

        #region extending IHeadIndexable

        /// <summary>
        /// Gets the <see cref="Wir"/> for the current head
        /// </summary>
        public static Wir? GetWir(this IHeadIndexable record) {
            return (from wir in record.StdfFile.GetRecords().OfExactType<Wir>()
                    where wir.HeadNumber == record.HeadNumber
                    select wir).FirstOrDefault();
        }

        /// <summary>
        /// Gets the <see cref="Wrr"/> for the current head
        /// </summary>
        public static Wrr? GetWrr(this IHeadIndexable record) {
            return (from wrr in record.StdfFile.GetRecords().OfExactType<Wrr>()
                    where wrr.HeadNumber == record.HeadNumber
                    select wrr).FirstOrDefault();
        }

        #endregion

        #region extending IHeadSiteIndexable

        /// <summary>
        /// Gets the current Prr associated with the head/site
        /// </summary>
        public static Prr? GetPrr(this IHeadSiteIndexable record) {
            return (from prr in record.StdfFile.GetRecords().OfExactType<Prr>()
                    where prr.HeadNumber == record.HeadNumber && prr.SiteNumber == record.SiteNumber
                    select prr).FirstOrDefault();
        }

        /// <summary>
        /// Gets the current Pir associated with the head/site
        /// </summary>
        public static Pir? GetPir(this IHeadSiteIndexable record) {
            return (from pir in record.StdfFile.GetRecords().OfExactType<Pir>()
                    where pir.HeadNumber == record.HeadNumber && pir.SiteNumber == record.SiteNumber
                    select pir).FirstOrDefault();
        }

        #endregion

        #region PMRLookups

        public static List<Pmr>? GetAllPmrs(this Mpr mpr)
        {
            return mpr.StdfFile.PmrLookup.GetAll(mpr.PinIndexes);
        }
        //untested. i don't have FTRs with pmr info
        //public static List<Pmr>? GetAllPmrs(this Ftr ftr)
        //{
        //    return ftr.StdfFile.PmrLookup.GetAll(ftr.ReturnIndexes);
        //}
        #endregion
        #region extending PIR/PRR

        public static Prr? GetMatchingPrr(this Pir pir) {
            return pir.After()
                .OfExactType<Prr>()
                .Where(r => r.HeadNumber == pir.HeadNumber && r.SiteNumber == pir.SiteNumber)
                .FirstOrDefault();
        }

        public static Pir? GetMatchingPir(this Prr prr) {
            return prr.Before()
                .OfExactType<Pir>()
                .Where(r => r.HeadNumber == prr.HeadNumber && r.SiteNumber == prr.SiteNumber)
                .LastOrDefault();
        }

        /// <summary>
        /// Gets the records associated with this pir
        /// </summary>
        /// <param name="pir">The <see cref="Pir"/> representing the part</param>
        /// <returns>The records associated with the part (between the <see cref="Pir"/>
        /// and <see cref="Prr"/> and sharing the same head/site information.</returns>
        public static IEnumerable<StdfRecord> GetChildRecords(this Pir pir) {
            return pir.After()
                .OfType<IHeadSiteIndexable>()
                .Where(r => r.HeadNumber == pir.HeadNumber && r.SiteNumber == pir.SiteNumber)
                .TakeWhile(r => r.GetType() != typeof(Prr))
                .Cast<StdfRecord>();
        }

        /// <summary>
        /// Gets the records associated with this pir but don't check head site combo. make sure it isnt multidut first...
        /// </summary>
        /// <param name="pir">The <see cref="Pir"/> representing the part</param>
        /// <returns>The records associated with the part (between the <see cref="Pir"/>
        /// and <see cref="Prr"/> </returns>
        public static IEnumerable<StdfRecord> GetChildRecords_NoHeadSiteCheck(this Pir pir)
        {
            if (pir.StdfFile.IsMultiDut) throw new Exception("Multidut file. Don't use this.");
            return pir.After()
                .TakeWhile(r => r.GetType() != typeof(Prr))
                .Cast<StdfRecord>();
        }
        /// <summary>
        /// Gets the records associated with this prr
        /// </summary>
        /// <param name="prr">The <see cref="Prr"/> representing the part</param>
        /// <returns>The records associated with the part (between the <see cref="Pir"/>
        /// and <see cref="Prr"/> and sharing the same head/site information.</returns>
        public static IEnumerable<StdfRecord> GetChildRecords(this Prr prr) {
            return prr.GetMatchingPir()?.GetChildRecords() ?? throw new InvalidOperationException("Couldn't find matching Pir");
        }

        #endregion

        /// <summary>
        /// Combines two uint?'s with the sematics desirable
        /// for record summarizing.
        /// </summary>
        /// <param name="first">The first nullable uint</param>
        /// <param name="second">The second nullable uint</param>
        /// <returns>The addition of first and second where null is treated as 0.</returns>
        public static uint? Combine(this uint? first, uint? second) {
            if (first == null && second == null) return null;
            else if (first == null) return second;
            else if (second == null) return first;
            else return first + second;
        }

        /// <summary>
        /// Chains 2 <see cref="RecordFilter"/>s together
        /// </summary>
        /// <param name="first">The first filter</param>
        /// <param name="other">The filter to chain to the first</param>
        public static RecordFilter Chain(this RecordFilter first, RecordFilter other) {
            return (input) => other(first(input));
        }

        /// <summary>
        /// Chains 2 <see cref="SeekAlgorithm"/>s together
        /// </summary>
        /// <param name="first">The first algorithm</param>
        /// <param name="other">The algorithm to chain to the first</param>
        public static SeekAlgorithm Chain(this SeekAlgorithm first, SeekAlgorithm other) {
            return (input, endian, callback) => other(first(input, endian, callback), endian, callback);
        }

        public static MethodInfo GetMethodOrFail(this Type type, string methodName) => type.GetMethod(methodName) ?? throw new InvalidOperationException($"Could not get method {methodName} on type {type}");
        public static MethodInfo GetMethodOrFail(this Type type, string methodName, params Type[] parameters) => type.GetMethod(methodName, parameters) ?? throw new InvalidOperationException($"Could not get method {methodName} on type {type}");


        public class DieGroup
        {
            public Pir? pir;
            public Prr? prr;
            public List<StdfRecord>? children;
        }
        public static List<DieGroup> GetDieGroupings(this StdfFile sFile, bool IncludeGenericRecordsIfSingleDut, bool removePirFromChildren = true)
        {
            if (sFile.GetRecords().OfExactType<Wir>().Count() > 1)
                throw new Exception("This method only works if there is only 1 wafer in the file.");
            List<DieGroup> data;
            if (sFile.IsMultiDut || !IncludeGenericRecordsIfSingleDut)
            {
                data = sFile.GetRecords().OfExactType<Pir>()
                                   .Select(o => new DieGroup
                                   {
                                       pir = o,
                                       children = o.GetChildRecords().ToList(),
                                       prr = o.GetMatchingPrr()
                                   })
                                   .ToList();
            }
            else
            {
                data = sFile.GetRecords().OfExactType<Pir>()
                                         .Select(o => new DieGroup
                                         {
                                             pir = o,
                                             children = o.GetChildRecords_NoHeadSiteCheck().ToList(),
                                             prr = o.GetMatchingPrr()
                                         })
                                         .ToList();
            }
            //get children uses after and after includes the current record.
            //since we have the pir in a separate variable we can remove the pir in the children
            if (removePirFromChildren)
                foreach (var grp in data!)
                    if (grp.children != null && grp.children.Count > 0 && grp.children.First().GetType() == typeof(Pir))
                        grp.children.RemoveAt(0);

            //do a quick check to make sure no other pirs are in the grp. if there are then this stdf file is all sorts of wrong.
            if (data.Any(grp => grp.children != null && grp.children.Any(c => c.GetType() == typeof(Pir))))
                throw new Exception("Pirs of the same head/site found within another grouping. " +
                                    "This means between 1 Pir and its associated Prr, we found another Pir with the same head/site.");

            return data;
        }
        private static List<StdfRecord>? RecsOutsideDieArea;
        private static string? SFileGUID = null;
        public static List<StdfRecord> GetRecordsOutsideDieArea(this StdfFile sFile)
        {
            //this var needs to reset between stdf file objects.
            if (SFileGUID != null && sFile.GUID != SFileGUID)
                RecsOutsideDieArea = null;
            if (RecsOutsideDieArea == null)
            {
                SFileGUID = sFile.GUID;
                Pir? FirstPir = sFile.GetRecords().OfExactType<Pir>().FirstOrDefault();
                Prr? LastPrr = sFile.GetRecords().OfExactType<Prr>().LastOrDefault();
                if (FirstPir == null || LastPrr == null)
                    throw new Exception("Stdf file is missing Pir and/or Prr records");

                RecsOutsideDieArea = sFile.GetRecords().Where(o => o.Offset < FirstPir.Offset || o.Offset > LastPrr.Offset).ToList();
            }
            return RecsOutsideDieArea;
        }

        public static void ToSTDF(this IEnumerable<StdfRecord> source, string outputLocation)
        {
            StdfFileWriter stdfFileWriter = new(outputLocation);
            stdfFileWriter.WriteRecords(source);
            stdfFileWriter.Dispose();
        }

    }
}
