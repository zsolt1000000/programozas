using System;
using System.IO;
using System.Collections.Generic;

namespace footgolf
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
        List<adatok> Versenyzok = new List<adatok>();
        public feladat()
        {
            f2();
            f3();
            f4();
            f6();
            f7();
            f8();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("fob2016.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                Versenyzok.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3.Feladat: Versenyzők száma: {0}", Versenyzok.Count);
        }
        void f4()
        {
            double db = 0;
            for (int i = 0; i < Versenyzok.Count; i++)
            {
                if (Versenyzok[i].kategoria == "Noi")
                {
                    db++;
                }
            }
            Console.WriteLine("4.Feladat: A női versenyzők aránya: {0:0.00%}", db / Versenyzok.Count);
        }
        void f6()
        {
            Console.WriteLine("6.Feladat: A bajnok női versemyző");

            int max = 0;
            int index = 0;
            for (int i = 0; i < Versenyzok.Count; i++)
            {

                if (Versenyzok[i].kategoria=="Noi"&& max < Versenyzok [i].pontszam())
                {
                    max = Versenyzok[i].pontszam();
                    index = i;
                }
                

            }
            Console.WriteLine("\tNév:{0}",Versenyzok[index].nev);
            Console.WriteLine("\tEgyesület: {0}", Versenyzok[index].egyesulet);
            Console.WriteLine("\tÖsszpont: {0}", Versenyzok[index].pontszam());
        }
        void f7()
        {
            StreamWriter ir = new StreamWriter("osszpontFF.tx");
            for (int i = 0; i < Versenyzok.Count; i++)
            {
                if (Versenyzok[i].kategoria=="Felnott ferfi")
                {
                    ir.WriteLine("{0};{1}", Versenyzok[i].nev, Versenyzok[i].pontszam());
                }

            }

            ir.Close();
        }
        void f8()
        {
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < Versenyzok.Count; i++)
            {
                if (stat.ContainsKey(Versenyzok[i].egyesulet))
                {

                    stat[Versenyzok[i].egyesulet]++;
                }
                else
                {
                    stat.Add(Versenyzok[i].egyesulet, 1);
                }
            }


            Console.WriteLine("8. Feladat: Egyesület statisztika");
            foreach (var item in stat)
            {
                if (item.Key!="n.a."&& item.Value>2)
                {
                    Console.WriteLine("\t{0} - {1} - fő",item.Key, item.Value);
                }
            }

        }

    }
    class adatok
    {
        public string nev, kategoria, egyesulet;
        public int[] pontok = new int[8];
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            nev = vag[0];
            kategoria = vag[1];
            egyesulet = vag[2];
            for (int i = 0; i < pontok.Length; i++)
            {
                pontok[i] = Convert.ToInt32(vag[i + 3]);
            }
        }
        public int pontszam()
        {
            int min1 = -1;
            int min2 = -1;

            int osszeg = 0;
            for (int i = 0; i < pontok.Length; i++)
            {
                osszeg += pontok[i];
                if (pontok[i] <= min1)
                {
                    min2 = min1;
                    min1 = pontok[i];
                }
                else if (pontok[i] < min2)
                {
                    min2 = pontok[i];
                }
            }
            osszeg -= min1;
            osszeg -= min2;
            if (min1 > 0)
            {
                osszeg += 10;
            }
            if (min2 > 0)
            {
                osszeg += 10;
            }
            return osszeg;
        }
    }
}
