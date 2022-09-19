using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace helyjegy
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
        List<adatok> jegyek = new List<adatok>();
        public feladat()
        {
         
            f1();
            f2();
            f3();
            f4();
        }
        int utHossz, kmDij;
        void f1()
        {
            string[] sorok = File.ReadAllLines("eladott.txt");
            string[] vag = sorok[0].Split(" ");
            utHossz = Convert.ToInt32(vag[1]);
            kmDij = Convert.ToInt32(vag[2]);
            for (int i = 1; i < sorok.Length; i++)
            {
                jegyek.Add(new adatok(sorok[i],kmDij));
            }
        }
        void f2()
        {

            Console.WriteLine("A legutolsó jegyvásárló ülése: {0}, az általa utazott távolság {1}", jegyek[jegyek.Count - 1].ules, jegyek[jegyek.Count - 1].hossz());
        }
        void f3()
        {
            int seged = 0;
            Console.WriteLine("3. feladat: ");    
            for (int i = 0; i < jegyek.Count; i++)
            {
                if (utHossz==jegyek[i].hossz())
                {
                    seged++;
                    Console.Write("{0} ",i+1);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("összesen {0} darab ember utazta végig",seged);
        }
        void f4()
        {
            int bevétel=0;
            /*for (int i = 0; i < jegyek.Count; i++)
            {
                bevétel += kmDij * jegyek[i].hossz();
            }
            Console.WriteLine("{0} ft a bevétel",bevétel);*/
        }
    }
    
    class adatok
    {
        public int ules, felKm, leKm,kmDij;
        public int ar()
        {
            int temp = hossz() / 10;
            if (hossz()%10>0)
            {
                temp++;
            }
            int forint = temp * kmDij;
            return (int)(Math.Round(forint / 0.5)*5)
        }
        public adatok(string sor,int kmDij)
        {
            string[] vag = sor.Split(" ");
            ules = Convert.ToInt32(vag[0]);
            felKm = Convert.ToInt32(vag[1]);
            leKm = Convert.ToInt32(vag[2]);
            this.kmDij = kmDij;
        }
        public int hossz()
        {
            return leKm - felKm;
        }
    }
}
/*
1. Feladat:
Beolvasás
1. sortól kell kezdeni (van fejléc)
fel kell dolgoni
 kerekítés --> 10db if vagy egy switch case vagy egy round matematikai függvény 

2. Feladat
Utolsó keresés 
leszállás - a felszállás (be építjük az adatok klaszba)
 
3. Feladat
0-km-nél szállt fel és leszál n-értékbe az utazta végig

4. Feladat
adatok klasszba be építeni
 
kerekéteni kell felfelé majd be kell szorzoni az egység árral majd kerekitjük 0-ra vagy  5-re
Össze kell adni a számokat
5. Feladat
Meg kerresük hol volt az utolsó állomás
meg számoljuk 

6. Feladat
statisztika a felszállás és leszállás kilóméter megszámolása (hányszor volt)
7. Feladat
fájlba írás 
kell egy tömb ahol van 48 elem de lehet dictionari is 
*/
