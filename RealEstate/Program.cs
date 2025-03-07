namespace RealEstate
{
    internal class Program
    {
        static List<Ad> ads = new List<Ad>();
        static void Main(string[] args)
        {
            ads = Ad.LoadFromCsv(@"..\..\..\src\realestates.csv");

            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {Math.Round(ads.Where(a => a.Floors == 0).Average(a => a.Area), 2)} m2");



            Console.ReadKey();
        }

        
        //static double DistanceTo(double a1, double a2, double b1, double b2)
        //{

        //}
    }
}
