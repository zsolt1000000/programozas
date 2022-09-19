using System;
using System.Collections.Generic;
using System.IO;

namespace telefon
{
    class Program
    {
        static void Main(string[] args)
        {

            feladat f = new feladat();

        }
        static int mpbe(int o, int p, int mp)
        {
            return o * 60 * 60 + p * 60 + mp;
        }
        class feladat
        {
            int mpbe(int o, int p, int mp)
            {
                return o * 60 * 60 + p * 60 + mp;
            }
            List<adatok> hivasok = new List<adatok>();
            public feladat()
            {
                f2();
                f3();
                f4();
                f5();
                f6();
            }
            void f2()
            {
                string[] sorok = File.ReadAllLines("hivas.txt");
                for (int i = 0; i < sorok.Length; i++)
                {
                    hivasok.Add(new adatok(sorok[i]));
                }
            }
            Dictionary<int, int> stat = new Dictionary<int, int>();
            void f3()
            {
                for (int i = 0; i < hivasok.Count; i++)
                {
                    if (stat.ContainsKey(hivasok[i].Kora))
                    {
                        stat[hivasok[i].Kora]++;
                    }
                    else
                    {
                        stat.Add(hivasok[i].Kora ,1);
                    }
                }
                Console.WriteLine("3. Feladat:");
                
                foreach (var item in stat)
                {
                    Console.WriteLine("{0} óra {1} hívás",item.Key,item.Value);

                }

            }
            void f4()
            {
                    int maxIndex = 0;
                    for (int i = 0; i < hivasok.Count; i++)
                    {
                        if (hivasok[i].hivasHossz()>hivasok[maxIndex].hivasHossz())
                        {
                            maxIndex = i;
                        }
                   
                    }

                Console.WriteLine("4. Feladat");
                Console.WriteLine("A leghosszabb ideig vonalban levo hivo {0}. sorban szerepel, a hivas hossza: {1} másodperc",maxIndex+1,hivasok[maxIndex].hivasHossz());


            }
            void f5()
            {
                int mpbe(int o, int p, int mp)
                {
                    return o * 60 * 60 + p * 60 + mp;
                }
                int hivoSorszam = 0;



                Console.WriteLine("5. Feladat");
                string ido;
                int ora;

                do
                {


                    Console.Write(" Adjon meg egy idopontot!(ora perc masodperc (8:00:00-12:00:00) ");
                    ido = Console.ReadLine();
                    ora = Convert.ToInt32(ido.Split(":")[0]);
                }
                while (!(ora >= 8 && ora < 12));

                
                     int mpBekert = mpbe(Convert.ToInt32(ido.Split(":")[0]),
                                         Convert.ToInt32(ido.Split(":")[1]),
                                         Convert.ToInt32(ido.Split(":")[2]));
                
                
                int utolso = 0;
                for (int i = 0; i < hivasok.Count; i++)
                {
                    if (hivasok[i].mpbeK() <mpBekert)
                    {
                        utolso = i;
                    }
                    else
                    {
                        break;
                    }

                }
                int db = 0;
                for (int i = 0; i < utolso; i++)
                {
                    if (hivasok[i].mpbeV() < mpBekert)
                    {
                        db++;
                    }

                }
                Console.WriteLine("A varakozok szama: {0} a beszelo a {1}.hivo.;",utolso-db,db+1);

            }
            void f6()
            {
                Console.WriteLine("6. Feladat");
                int utolsoElotti = 0;

                for (int i = 0; i < hivasok.Count; i++)
                {
                    if (hivasok[i].mpbeV()<mpbe(12,0,0))
                    {
                        utolsoElotti = i;
                    }
                }

            }
        }
    }
    

    class adatok
    {
      public  int Kora, Kperc, Kmp;
      public  int Vora, Vperc, Vmp;
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            Kora = Convert.ToInt32(vag[0]);
            Kperc = Convert.ToInt32(vag[1]);
            Kmp = Convert.ToInt32(vag[2]);
            Vora = Convert.ToInt32(vag[3]);
            Vperc = Convert.ToInt32(vag[4]);
            Vmp = Convert.ToInt32(vag[5]);

        }

        public int hivasHossz()
        {
            return Math.Abs(mpbeV() - mpbeK());
        }
        public int mpbeK()
        {
            return Kora * 60 * 60 + Kperc * 60 + Kmp;
        }

      public   int mpbeV()
        {
            return Vora * 60 * 60 + Vperc * 60 + Vmp;
        }

    }
    /*
    1. Feladat: Egy függvényt kell létrehozni, Szorozni kell
    2. Feladat: Fájl beolvasása adatok class rétrehozása forrás adat beolvasása 
    3. Feladat: Dictionary
    4. Feladat: Ki kell írni a leghosszabb hívás sorszámát (maximum keresés) sorszámát kell el tárolni (Index)
    5. Feladat: Megszámolás kell majd --> hányan vártak és hányadik hívóval beszélt --> ha nem volt "Nem volt beszélő"
    6. Feladat: Megszámolás 
    7. Feladat: Létre kell hozni egy txt fájlt --> 
    
     
    */
}
