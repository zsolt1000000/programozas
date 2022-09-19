using System;
using System.Collections.Generic;
using System.IO;

namespace jatszma5
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

        List<string> labdamenetLista = new List<string>();
        public feladat()
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
            f9();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("labdamenetek5.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                labdamenetLista.Add(sorok[i]);
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Labdamenetek száma: {0}",labdamenetLista.Count);
        }
        void f4() 
        {
            int db = 0;
            for (int i = 0; i < labdamenetLista.Count; i++)
            {
                if (labdamenetLista[i]=="A")
                {
                    db++;
                } 
            }
            Console.WriteLine("4. feladat: Az adogató játékos {0:0.0000000000000%}-ban nyerte meg a labdameneteket.",(Double)db/labdamenetLista.Count);
        }
        void f5() 
        {
            int max = 0;
            int db = 0;
            for (int i = 0; i < labdamenetLista.Count; i++)
            {
                if (labdamenetLista[i]=="A")
                {
                    db++;
                }
                else
                {
                    if (max<db)
                    {
                        max = db;
                    }
                    db = 0;
                }
            }
            Console.WriteLine("5. feladat: Leghosszabb sorozat: {0}",max);
        }
        void f6() 
        {
            
        }
        void f7() 
        {
            Játék próbaJáték = new Játék("Mahut","Isner","FAFAA");
            próbaJáték.Hozzáad("A");

            Console.WriteLine("7. feladat: A próba játék");
            Console.WriteLine("\t Állás: {0}",próbaJáték.allas);
            if (próbaJáték.Játékvége()==true)
            {
                Console.WriteLine("\t Befejezedődött a játék vége: igen");

            }
            else
            {
                Console.WriteLine("\t Befejezedődött a játék vége: nem");

            }
        }
        List<Játék> jatekok = new List<Játék>();
        void f8() 
        {

            Játék jatek = new Játék("Isner","Mahut","");
            jatek.Hozzáad(labdamenetLista[0]);
            for (int i =1; i < labdamenetLista.Count; i++)
            {
                jatek.Hozzáad(labdamenetLista[i]);
                if (jatek.Játékvége())
                {
                    jatekok.Add(jatek);
                    jatek=new Játék(jatek.fogado, jatek.adogato, "");

                }

            }


        }
        //a két játékos nyert  irjuk ki külön fájlba hogy melyik játékot 
        //Kell a játék sorszáma  Isler,Mahut és a játék végeredményével
        void f10() 
        {
            StreamWriter ir = new StreamWriter("Isner.txt");
            for (int i = 0; i < jatekok.Count; i++)
            {
                if (jatekok[i].nyertes()=="Isner")
                {
                    ir.WriteLine("{0} {1}", i + 1, jatekok[i].allas);
                }
            }
            ir.Close();

             ir = new StreamWriter("Mahut.txt");
            for (int i = 0; i < jatekok.Count; i++)
            {
                if (jatekok[i].nyertes() == "Mahut")
                {
                    ir.WriteLine("{0} {1}", i + 1, jatekok[i].allas);
                }
            }
            ir.Close();
        }
        void f9() 
        {
            int db = 0;
            for (int i = 0; i < jatekok.Count; i++)
            {
                if (jatekok[i].nyertes()=="Isner")
                {
                    db++;
                }
            }
            Console.WriteLine("9. feladat: az 5 játszma végeredménye:");
            Console.WriteLine("\t Mahut: {0}",jatekok.Count-db);
            Console.WriteLine("\t Isner: {0}",db);

        }
    }
    class Játék
    {
        public string allas;
        public string adogato, fogado;
        
        
        public Játék(string adogatoNev,string fogadoNev,string allas)
        {
            adogato = adogatoNev;
            fogado = fogadoNev;
            this.allas = allas;


        }
       
        public void Hozzáad(string eredmeny)
        {

            allas += eredmeny;

        }
        public string nyertes()
        {
            if (NyertLabdamenetekSzama("A")>NyertLabdamenetekSzama("F"))
            {
                return adogato;
            }
            else
            {
                return fogado;
            }
            
        }
        public int NyertLabdamenetekSzama(string jatekos)
        {
            int db = 0;
            for (int i = 0; i < allas.Length; i++)
            {
                if (allas[i]==jatekos[0])
                {
                    db++;
                }
            }

            return db;
        }
        public bool Játékvége()
        {


            int nyertAdogató;
            int nyertFogadó;
            int különbség;

            nyertAdogató = NyertLabdamenetekSzama("A");
            nyertFogadó = NyertLabdamenetekSzama("F");
            különbség = Math.Abs(nyertAdogató - nyertFogadó);

            return (nyertAdogató>=4 || nyertAdogató>=4)&&(különbség>=2);
        }
    }
}
/*
 
1. Feladat megoldási terv/tervek:


2. Feladat megoldási terv/tervek:
 

3. Feladat megoldási terv/tervek:

A lista elemszámát kell valószinűleg ki írni

4. Feladat megoldási terv/tervek:

Meg kell számolni majd a végén el kell osztani egymással
Az adogatok meg számolása százalék számítás (Legyen valós szám)

5. Feladat megoldási terv/tervek:

Egymás után következő A- közül a leghossazbbat kell meg keresni 

6. Feladat megoldási terv/tervek:

kell egy class játék
(String) 
3 mező kell 
kell egy publik játékos 
kell egy hozzáadó függvény fel tölti majd az állást
kell megint egy függvény -- hányat nyert -- paraméterbe át kell adni -- A vagy F betűk meg számolása


7. Feladat megoldási terv/tervek:

példányusítás
hozzá kell adni egy A-t ha az adogató nyer 
Használni kell a játék osztályt

8. Feladat megoldási terv/tervek:

Hozzon létre egy játékosztályt 
kell egy át meneti class 
és ha késsz akkor kell bele rakni

9. Feladat megoldási terv/tervek:

Utolsó listának az eredményét kell meg számolni 
 
 */
