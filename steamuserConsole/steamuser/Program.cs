namespace steamuser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladatok feladatok = new Feladatok("steamUser.csv");
            feladatok.Feladat2();
            feladatok.Feladat3();
            feladatok.Feladat4();
            feladatok.Feladat5();
            feladatok.Feladat6();
        }
    }
}
