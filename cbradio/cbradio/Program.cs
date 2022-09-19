using System;
using System.IO;
using System.Collections.Generic;

namespace cbradio
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
        List<adatok> forgalom = new List<adatok>();
        public feladat()
        {
            f2();
            f3();
            f4();
            f5();
            f7();
            f8();
            f9();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("cb.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                forgalom.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Bejegyzések száma {0} db", forgalom.Count);
        }
        void f4()
        {
            bool seged = false;
            for (int i = 0; i < forgalom.Count; i++)
            {
                if (forgalom[i].AdasDb == 4)
                {
                    //Console.WriteLine("4. feladat: Volt négy adást indító sofőr");
                    seged = true;
                }


            }
            if (seged == true)
            {
                Console.WriteLine("4. feladat: Volt négy adást indító sofőr");

            }
            else
            {
                Console.WriteLine("4. feladat: Nem volt négy adást indító sofőr");

            }
        }
        Dictionary<string, int> soforok = new Dictionary<string, int>();
        void f5()
        {
            for (int i = 0; i < forgalom.Count; i++)
            {
                if (soforok.ContainsKey(forgalom[i].nev))
                {
                    soforok[forgalom[i].nev] += forgalom[i].AdasDb;
                }
                else
                {
                    soforok.Add(forgalom[i].nev, forgalom[i].AdasDb);
                }
            }
            Console.Write("5. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine();
            if (soforok.ContainsKey(nev))
            {
                Console.WriteLine("\t{0} {1}x használta a CB rádiót.", nev, soforok[nev]);
            }
            else
            {
                Console.WriteLine("\t Nincs ilyen nevű sofőr ");

            }
        }
        void f7()
        {
            StreamWriter ir = new StreamWriter("cb2.txt");

            ir.WriteLine("Kezdes;Nev;AdasDb");
            for (int i = 0; i < forgalom.Count; i++)
            {
                ir.WriteLine("{0};{1};{2}",forgalom[i].AtszamolPercre(),forgalom[i].nev,forgalom[i].AdasDb);
            }

            ir.Close();

        }
        void f8()
        {
           
            Console.WriteLine("8. feladat: Sofőrok száma: {0} fő",soforok.Count);


        }
        void f9()
        {
            int max = 0;
            string nev = "";
            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            foreach (var item in soforok)
            {
                if (max<item.Value)
                {
                    nev = item.Key;
                    max = item.Value;
                }
            }
            Console.WriteLine("\tNév: {0}",nev);
            Console.WriteLine("\tAdások száma: {0} alkalom",max);
        }
    }
    class adatok
    {
        public int Ora, Perc, AdasDb;
        public string nev;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            Ora = Convert.ToInt32(vag[0]);
            Perc = Convert.ToInt32(vag[1]);
            AdasDb = Convert.ToInt32(vag[2]);
            nev = vag[3];
        }
        public int AtszamolPercre()
        {
            return Ora * 60 + Perc;
        }
    }

    /*
    1. Feladat:
    be olvasás 
    3 szám 1 név (int ,int, int , string)
    van fejléc
    2. Feladat:
    3. Feladat:
    Lista ki íratása
    4. Feladat
    Megszámolás kell --> és ha az értéke 4 akkor áljunk meg
    5. Feladat
    meg számolást kell csinálni
    ha nulla  a darabszáma akkor nem szerepel benne
    6. Feladat
    Meg kell csinlni valahova valószinűleg adatij class
    7. Feladat:
    8. Feladat:
    Dictionary
    9. Feladat:
    Maximum keresés
    a dictionaryba
     
     
     
    */
}
