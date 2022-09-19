
using System;
using System.Collections.Generic;
using System.IO;

namespace hianyzasok
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
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
        }

        List<egyNap> napló = new List<egyNap>();
        void f1()
        {
            List<hianyzo> temp = new List<hianyzo>();
            string[] sorok = File.ReadAllLines("naplo.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                if (sorok[i][0] == '#')
                {

                    if (temp.Count > 0)
                    {
                        napló[napló.Count - 1].hianyzok = temp;
                        temp = new List<hianyzo>();
                    }
                    napló.Add(new egyNap(sorok[i], new List<hianyzo>()));

                    /*  if (temp.Count>0)
                      {
                          napló.Add(new egyNap(sorok[i], temp));
                          temp = new List<hianyzo>();
                      }*/
                }
                else
                {
                    string[] vag = sorok[i].Split(" ");
                    temp.Add(new hianyzo(vag[0] + " " + vag[1], vag[2]));
                }
                napló[napló.Count - 1].hianyzok = temp;

            }
        }
        void f2()
        {
            Console.WriteLine("2. Feladat");
            int össz = 0;
            for (int i = 0; i < napló.Count; i++)
            {
                össz += napló[i].hianyzok.Count;
            }

            Console.WriteLine("A naplóban {0} bejegyzés volt",össz);
        }
        void f3()
        {
            int összIgazolt = 0;
            int összIgazolatlan = 0;
            for (int i = 0; i < napló.Count; i++)
            {
                összIgazolt += napló[i].igazolt();
                összIgazolatlan += napló[i].igazolatlan();

            }
            Console.WriteLine("3. Feladata");
            Console.WriteLine("Az igazolt hiányzások száma {0}, az igatolatlanoké {1} óra",összIgazolt,összIgazolatlan);
        }
        void f4()
        {
            /*
             * 
Függvény hetnapja(honap:egesz, nap:egesz): szöveg 
napnev[]:= ("vasarnap", "hetfo", "kedd", "szerda", "csutortok", 
"pentek", "szombat") 
napszam[]:= (0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335) 
napsorszam:= (napszam[honap-1]+nap) MOD 7 
hetnapja:= napnev[napsorszam] 
Függvény vége 

             */
        }
        public string hetnapja(int honap, int nap)
        {
            string[] napnev = { "vasárnap", "hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat" };
            int[] napszam = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return  napnev[napsorszam];
        }

        void f5()
        {
            Console.WriteLine("5. Feladat");
            Console.Write("A hónap sorszáma: ");
            int honap = Convert.ToInt32(Console.ReadLine());


            Console.Write("A nap sorszáma: ");
            int nap = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Azon a napon {0} volt.",hetnapja(honap,nap));
        }
        void f6()
        {
            Console.WriteLine("6. Feladat");

            Console.Write("A nap neve=");
            string nap = Console.ReadLine();
            Console.Write("Az óra sorszáma=");
            int óra = Convert.ToInt32(Console.ReadLine());
            int darab = 0;
            for (int i = 0; i < napló.Count; i++)
            {
                if (hetnapja(napló[i].honap,napló[i].nap)==nap)
                {
                    for (int k = 0; k < napló[i].hianyzok.Count; k++)
                    {
                     //   Console.WriteLine(  napló[i].hianyzok[k].hianyzas[óra - 1]);
                        if (napló[i].hianyzok[k].hianyzas[óra - 1]!='O')
                        {

                            darab++;

                        }
                    }
                }
            }
            Console.WriteLine("Ekkor összesen {0} óra hiányzás történt", darab);

        }
        void f7()
        {
            Console.WriteLine("7. Feladat");

            Dictionary<string, int> ossz = new Dictionary<string, int>();


            for (int i = 0; i < napló.Count; i++)
            {
                for (int k = 0; k < napló[i].hianyzok.Count; k++)
                {
                    hianyzo aktualis = napló[i].hianyzok[k];
                    if (ossz.ContainsKey(napló[i].hianyzok[k].nev))
                    {
                        ossz[napló[i].hianyzok[k].nev] += napló[i].hianyzok[k].igazolatlan() + napló[i].hianyzok[k].igazolt();
                    }

                    else
                    {
                        ossz.Add(aktualis.nev, aktualis.igazolatlan() + aktualis.igazolt());
                    }
                }
            }

            int max = 0;
            foreach (var item in ossz)
            {
                if (max<item.Value)
                {
                    max = item.Value;
                }
            }
            Console.Write("A legtöbett hiányzó tanulók: ");
            foreach (var item in ossz)
            {
                if (max==item.Value)
                {
                    Console.Write("{0} ",item.Key);
                }
            }


            Console.WriteLine();
        }

    }
    
}

    class hianyzo
    {

        public string nev;
        public string hianyzas;
        public hianyzo(string nev,string hianyzas)
        {
            this.nev = nev;
            this.hianyzas = hianyzas;
        }
        public int igazolt()
        {

            int db = 0;
            for (int i = 0; i < hianyzas.Length; i++)
            {
                if (hianyzas[i]=='X')
                {
                    db++;
                }
            }
            return db;
            
        }
        public int igazolatlan()
        {

            int db = 0;
            for (int i = 0; i < hianyzas.Length; i++)
            {
                if (hianyzas[i] == 'I')
                {
                    db++;
                }
            }
            return db;

        }

    }
    class egyNap
    {
        public int honap, nap;
       public List<hianyzo> hianyzok = new List<hianyzo>(); 
        public egyNap(string sor, List<hianyzo> h)
        {
            string[] vag = sor.Split(" ");
            honap = Convert.ToInt32(vag[1]);
            nap = Convert.ToInt32(vag[2]);
            hianyzok = h;
        }
        public int igazolt()
        {
            int össz = 0;
            for (int i = 0; i < hianyzok.Count; i++)
            {
                össz += hianyzok[i].igazolt();
            }
            return össz;
        }
        public int igazolatlan()
        {
            int össz = 0;
            for (int i = 0; i < hianyzok.Count; i++)
            {
                össz += hianyzok[i].igazolatlan();
            }
            return össz;
        }

    
}

/*
1. Feladat több soros be olvasás 
int int 
string string

Kell egy osztály amibe név és hiányzás van (string, string) neve legyen hianyzóú
Kell még egy osztály hónap nap lista a hiányzókkal (int, int,  list)


2. Feladat:

A belsü liszának az elemeit adjuk össze (egyszerű összegzés)

3. Feladat: 

A hiányzók classba meg kell számolni az "X" és az "I" betűket és a teljes listában összegzések

4. Feladat:

Feudo kód másolása

5. Feladat:

Kérjünk be egy dátumot -- Egy hónap nap két kölünböző be kérés 
és egy hét napja meg hívás

6. Feladat:

Két adatot kell be kérnünk (string, int)


7. Feladat:




 */

