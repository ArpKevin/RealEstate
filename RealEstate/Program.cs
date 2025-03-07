namespace RealEstate
{
    internal class Program
    {
        static List<Ad> ads = new List<Ad>();
        static void Main(string[] args)
        {
            ads = Ad.LoadFromCsv(@"..\..\..\src\realestates.csv");

            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {Math.Round(ads.Where(a => a.Floors == 0).Average(a => a.Area), 2)} m2");

            var mesevarSzelessegiFok = 47.4164220114023;
            var mesevarHosszusagiFok = 19.066342425796986;

            var legkozelebbiTehermentesIngatlan = ads.Where(a => a.FreeOfCharge).MinBy(t => DistanceTo(t.SzelessegiFok, t.HosszusagiFok, mesevarSzelessegiFok, mesevarHosszusagiFok));

            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine($"\tEladó neve     : {legkozelebbiTehermentesIngatlan.Seller.SellerName}");
            Console.WriteLine($"\tEladó telefonja: {legkozelebbiTehermentesIngatlan.Seller.SellerPhone}");
            Console.WriteLine($"\tAlapterület    : {legkozelebbiTehermentesIngatlan.Area}");
            Console.WriteLine($"\tSzobák száma   : {legkozelebbiTehermentesIngatlan.Rooms}");

            Console.ReadKey();
        }

        
        static double DistanceTo(double a1, double a2, double b1, double b2)
        {
            var x = Math.Abs(a1 - b1);
            var y = Math.Abs(a2 - b2);

            return Math.Sqrt(x * x + y * y);
        }
    }
}
