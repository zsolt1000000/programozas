using System;
using System.Collections.Generic;
using System.IO;

namespace futar2
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }
    class feladat
    {
        List<adatok> naplo = new List<adatok>();

        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
        }
        void f1()
        {
            string[] sorok = File.ReadAllLines("tavok.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                naplo.Add(new adatok(sorok[i]));
            }
        }
        void f2()
        {

            Console.WriteLine("2. feladat");
            int min = 8;
            for (int i = 0; i < naplo.Count; i++)
            {
                if (naplo[i].nap < min)
                {
                    min = naplo[i].nap;
                }
            }

            for (int i = 0; i < naplo.Count; i++)
            {
                if (naplo[i].nap == min && naplo[i].fuvar == 1)
                {
                    Console.WriteLine("A hét első fuvarja: {0} km volt", naplo[i].km);
                }
            }


        }
        void f3()
        {
            int max = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if (naplo[i].nap > max)
                {
                    max = naplo[i].nap;
                }
            }
            Console.WriteLine("3. feladat");

            int maxFuvar = 0;
            int maxKm = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if (naplo[i].nap == max)
                {
                    if (naplo[i].fuvar > maxFuvar)
                    {
                        maxFuvar = naplo[i].fuvar;
                        maxKm = naplo[i].km;
                    }

                }

            }
            Console.WriteLine("A heti utolsó fuvar {0} km volt.", maxKm);

        }
        Dictionary<int, int> stat = new Dictionary<int, int>();

        void f4()
        {
            for (int i = 0; i < naplo.Count; i++)
            {
                if (stat.ContainsKey(naplo[i].nap))
                {
                    stat[naplo[i].nap]++;
                }
                else
                {
                    stat.Add(naplo[i].nap, 1);
                }

            }
            Console.WriteLine("4. feladat:");
            for (int i = 1; i <=7; i++)
            {
                if (!stat.ContainsKey(i))
                {
                    Console.WriteLine("Ezen a napon nem dolgozott: {0}. nap", i);
                }
            }

        }
        void f5()
        {
            int maxErtek = 0;
            int maxNap =0;

            foreach (var item in stat)
            {
                if (item.Value>maxErtek)
                {
                     maxErtek=item.Value;
                    maxNap = item.Key;
                }
            }
            Console.WriteLine("5. feladat");
            Console.WriteLine("A {0}. napon volt a legtöbb fuvar {1}",maxNap,maxErtek);

        }
        void f6() 
        {
            Console.WriteLine("6. feladat");
            Dictionary<int, int> statKm = new Dictionary<int, int>();

            for (int i = 0; i < naplo.Count; i++)
            {
                if (statKm.ContainsKey(naplo[i].nap))
                {
                    statKm[naplo[i].nap] += naplo[i].km;
                }
                else
                {
                    statKm.Add(naplo[i].nap, naplo[i].km);
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                if (statKm.ContainsKey(i))
                {
                    Console.WriteLine("{0}. nap: {1} km",i,statKm[i]);
                }
                else
                {
                    Console.WriteLine("{0}. nap: {1} km", i, 0);

                }
            }
        }
        void f7()
        {
            Console.WriteLine("7. feladat");
            Console.Write("Kérek egy távot: ");
            int km = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} km {1} forintba kerül.",km,kmToFt(km));
        }
        int kmToFt(int km)
        {
            /*
             1 – 2 km 500 Ft
             3 – 5 km 700 Ft
             6 – 10 km 900 Ft
             11 – 20 km 1 400 Ft
             21 – 30 km 2 000 Ft
             */

            if (km < 2)
            {
                return 500;
            }
            else if (km < 6)
            {
                return 700;
            }
            else if (km < 11)
            {
                return 900;
            }
            else if (km < 21)
            {
                return 1400;
            }
            else
            {
                return 2000;
            }



        }
    
    void f8()
        {
            StreamWriter ir = new StreamWriter("dijazas.txt");

            for (int i = 0; i < naplo.Count; i++)
            {
                Console.WriteLine("{0}. nap {1}. út: {2} Ft",naplo[i].nap,naplo[i].fuvar,naplo[i].kmToFt());
            }



            ir.Close();

            int összeg = 0;
            int kmek = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                naplo[i].km = kmek;

                



                Console.WriteLine("A heti fizetése:{0}",összeg);

            }
        }
    }
    class adatok
    {
        public int nap, fuvar, km;

        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            nap = Convert.ToInt32(vag[0]);
            fuvar = Convert.ToInt32(vag[1]);
            km = Convert.ToInt32(vag[2]);
        }
       public  int kmToFt()
        {
            /*
             1 – 2 km 500 Ft
             3 – 5 km 700 Ft
             6 – 10 km 900 Ft
             11 – 20 km 1 400 Ft
             21 – 30 km 2 000 Ft
             */

            if (km < 2)
            {
                return 500;
            }
            else if (km < 6)
            {
                return 700;
            }
            else if (km < 11)
            {
                return 900;
            }
            else if (km < 21)
            {
                return 1400;
            }
            else
            {
                return 2000;
            }



        }
    }
    /*
     1. feladat: File beolvasás lista lértehozása
     2. feladat: Legkisebb nap --> legkisebb fuvar száma 
     Minimum keresés  legkisebb nap (1-es fuvarja)
     3. Feladat: nap maximum és az utolsó út  maximum
     4. Feladat: statisztika kell (dictionary) mikor nem dolgozott ha nulla a fuvar szám
     5. Feladat: megszámolás (hány fuvar) és maximum keresés  melyik a legnagyobb érték 
     6. Feladat: Összegzés
     7. Feladat: Valamilyen függvényt kellene meg adott kilométerből vissza adja az összeget (else,if)
     8. Feladat: 
     9. Feladat: összegzés 
      
     */
}
