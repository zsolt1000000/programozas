using System;
using System.Collections.Generic;
using System.IO;

namespace Ultrabalaton
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat a = new feladat();
        }
    }
    class feladat
    {
        List<adatok> versenyzok = new List<adatok>();
        public feladat()
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("ub2017egyeni.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                versenyzok.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Egyéni indulok: {0} fő",versenyzok.Count);
        }
        void f4()
        {
            int darab= 0;
            
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].neme =="Noi" && versenyzok[i].tav ==100)
                {
                    darab++;
                }
            }
            Console.WriteLine("4. feladat:Célba érkező női sportolók: {0} fő", darab);
        }
        void f5()
        {
            string neve;
            Console.Write("5. feladat: Kérem a sportoló nevét:");
            neve = Console.ReadLine();
            //  Console.WriteLine("\tIndult egyéniben a sportoló? {0}"); Utasi Akos
            //Console.WriteLine("\tTeljesítette a teljes távot? {0}");
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].nev != neve)
                {
                    Console.Write("\tIndult egyéniben a sportoló?");
                    Console.Write(" Nem");


                    break;
                }
                else 
       
                {
                    Console.Write("\tIndult egyéniben a sportoló?");
                    Console.Write(" Igen");
                    break;
                }
                /*
                if (versenyzok[i].tav == 100)
                {
                    Console.WriteLine("\tTeljesítette a teljes távot?");
                    Console.Write(" Igen");
                }
                else if (false)
                {
                    Console.Write(" Nem");

                }*/



            }
        }
        void f6()
        {
            double időÓrában;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                Console.WriteLine(versenyzok[i].ido);
                
            }
        }
        void f7()         
        {
            Console.WriteLine("7. feladat: Átlagos idő: {0}");
        }
        void f8()
        {
            Console.WriteLine("8. feladat: Verseny győztesei");
            double FerfiIdo;
            double NoiIdo;
        }

    }
    class adatok
    {
        public string nev;
        public int szam;
        public string neme;
        public string ido;
        public int tav;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            nev = vag[0];
            szam =Convert.ToInt32( vag[1]);
            neme = vag[2];
            ido = vag[3];
            tav = Convert.ToInt32(vag[4]);
        }
    }
}
