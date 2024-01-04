using LinqToStdf;
using LinqToStdf.Records.V4;

//this one has a bunch of pmrs, some dtrs in the die area, 2 pir/prr combos, is multidut, and has some ptrs/mprs/ftrs 
StdfFile sf = new(@"C:\stdf\StdfFiles\Sample_STDF.stdf");

sf.Consume();

//making sure this goes to the v4 versions implementation
var t1 = sf.GetRecords().OfExactType("PIR").Select(o => ((Pir)o).GetChildRecords().ToList()).ToList();

//making sure this bombs out since i am using a multidut file here.
try
{
    var t2 = sf.GetRecords().OfExactType("PIR").Select(o => ((Pir)o).GetChildRecords_NoHeadSiteCheck().ToList()).ToList();
}catch(Exception ex)
{
    _ = ex.ToString();
}

//making sure this gets the pmrs
var t3 = sf.GetRecords().OfExactType<Mpr>().First().GetAllPmrs()!.Select(o=>o.PhysicalName).ToList();

//checking to make sure the die level stuff isnt in this collection
var t4 = sf.GetRecordsOutsideDieArea();
var t4_1 = t4.OfExactType<Mir>().First();

//checking to make sure it return 2 die groupings with the pir/prr and all the children. it should also use the v4 strat version of the get children 
var t5 = sf.GetDieGroupings(true);

// single dut with ptrs/mprs and 61 die
StdfFile sf2 = new(@"C:\stdf\StdfFiles\Sample2_STDF.stdf");

sf2.Consume();

//make sure it reads in the psrs.
var t6 = sf2.GetRecords().OfExactType<Psr>().ToList();


//making sure this gets the right file's records since now there are two loaded into memory and this is a static variable.
//the GUID should make it see its different than what is cached and reset the var.
var t7 = sf2.GetRecordsOutsideDieArea();
var t8 = sf.GetRecordsOutsideDieArea();

_ = 543;