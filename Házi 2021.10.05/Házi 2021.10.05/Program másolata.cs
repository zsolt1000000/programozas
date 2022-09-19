
using System;

namespace Házi_2021._10._05
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                hazi_feladat a = new hazi_feladat();
                Console.WriteLine("Kérek egy számot");
                a.szam1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kérek egy számot");
                a.szam2 = Convert.ToInt32(Console.ReadLine());

               // Console.WriteLine(a.szam1);
              //  Console.WriteLine(a.szam2);
                Console.WriteLine(a.osszead());
                Console.WriteLine(a.osszeszoroz());

            }
        }
        class hazi_feladat
        {
            public int szam1;
            public int szam2;

            public int osszead()
            {


                 int oszeg;
                oszeg = szam1 + szam2;

                return (oszeg);
            }
            public int osszeszoroz()
            {


                int szorzat;
                szorzat = szam1 * szam2;

                return (szorzat);
            }
        }
    }
}