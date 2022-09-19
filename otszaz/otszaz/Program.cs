using System;
using System.Collections.Generic;
using System.IO;

namespace otszaz
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
        List<string> kosar = new List<string>();
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
            string[] sorok = File.ReadAllLines("penztar.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                kosar.Add(sorok[i]);
            }
        }
        void f2()
        {
            int f = 0;
            for (int i = 0; i < kosar.Count; i++)
            {
                if (kosar[i]=="F")
                {
                    f++;
                }
            }
            Console.WriteLine("2. Feladat");
            Console.WriteLine("A fizetések száma: {0}",f);
        }
        void f3()
        {
            int index = 0;
            Console.WriteLine("3. Feladat");
            for (int i = 0; i < kosar.Count; i++)
            {
                if (kosar[i]=="F")
                {
                    index = i;
                    break;
                }
            }
            Console.WriteLine("Az első vásárló {0} darab árucikket vásárolt.",index);
        }
        string árucikk = "";
        int sorszam = 0;
        int db = 0;

        void f4()
        {

            Console.Write("Adja meg egy vásárlás sorszámát! ");
             sorszam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg egy árucikk nevét! ");
             árucikk = Console.ReadLine();
            Console.Write("Adja meg a vásárolt darabszámot! ");
             db = Convert.ToInt32(Console.ReadLine()); 
        }
        void f5()
        {
            int első = 0;
            int utolsó = 0;
            for (int i = 0; i < kosar.IndexOf(árucikk); i++)
            {
                

                if (kosar[i]=="F")
                {
                    első++;
                }
                
            }
            for (int i = 0; i < kosar.LastIndexOf(árucikk); i++)
            {


                if (kosar[i] == "F")
                {
                    utolsó++;
                }

            }
            int db = 0;
            int temp =0;
            for (int i = 0;  i< kosar.Count; i++)
            {
                if (kosar[i] == árucikk)
                {
                    temp++;
                }
                if (kosar[i]=="F")
                {
                    if (temp>0)
                    {
                        db++;
                    }
                    temp = 0;

                }
            }
            Console.WriteLine("5. Feladat");
            Console.WriteLine("Az első vásárlás sorszáma: {0}",első+1);
            Console.WriteLine("Az utolsó vásárlás sorszáma: {0}",utolsó+1);
            Console.WriteLine("{0} vásárlás során vettek belőle.",db);
        }
        int ertek(int db)
        {
            if (db ==1)
            {
                return 500;

            }
            else
            {
                return (db - 2) * 400 + 950;
            }
        }
        void f6()
        {
            Console.WriteLine("6. Feladat");
            Console.WriteLine("{0}  darab vételekor fizetendő: {1} ", db,ertek(db));
        }
        void f7()
        {
            int index = 0;
            int elozoIndex = 0;
            int srsz = 0;
            for (int i = 0; i < kosar.Count; i++)
            {
                if (kosar[i] == "F")
                {
                    elozoIndex = i;
                    srsz++;

                    if (srsz==sorszam)
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        elozoIndex = i;
                    }
                }
            }
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = elozoIndex+1; i < index; i++)
            {
                if (!stat.ContainsKey(kosar[i]))
                {
                    stat.Add(kosar[i], 1);
                }
                else
                {
                    stat[kosar[i]]+=1;
                }
            }
            Console.WriteLine("7. Feladat");
            foreach (var item in stat)
            {
                Console.WriteLine("{0} {1}",item.Value,item.Key);
            }
        }
        void f8()
        {

            Dictionary<string, int> stat = new Dictionary<string, int>();

            int osszeg = 0;
            List<int> árak = new List<int>();
            
            for (int i = 0; i < kosar.Count; i++)
            {
                if (kosar[i]=="F")
                {
                    foreach (var item in stat)
                    {
                        osszeg += ertek(item.Value);
                    }
                    árak.Add(osszeg);

                    stat.Clear();
                    osszeg = 0;
                }
                else
                {
                    if (stat.ContainsKey(kosar[i]))
                    {
                        stat[kosar[i]]++;
                    }
                    else
                    {
                        stat.Add(kosar[i], 1);
                    }
                }
            }
            StreamWriter ir = new StreamWriter("osszeg.txt");

            for (int i = 0; i < árak.Count; i++)
            {
                ir.WriteLine("{0}: {1}",i+1,árak[i]);
            }


            ir.Close();

        }
    
    }
    class adatok
    {
        public adatok()
        {

        }
    }

    /*
     1. Feladat: 

    String tipusó lista beolvasás

     2. Feladat: 
    Meg kell számolni az F-ekete
     3. Feladat: 
    Az első F-ig megy meg kell keresni pl ciklus 
    Vagy az Index Of-fal
     4. Feladat: 
    3db be kérés 
    szám string szám
     5. Feladat: 
     A. Meg nézzük hányadik sorban van elöszőr Megsámoló ciklúst addig futattjuk ahol van 
        Meg keressük a legutolsó vásárlást (utolsó elem keresés)
        A vásárlás sorszáma db+1
     B. 
    KÉt segéd változó 
     6. Feladat: 
    kell egy függvény érték néven
      (X-2)*400+450+500
     7. Feladat: 

    Dictionary -- Statisztika  (string - érték)
    
    pl: 
    kezdete     61. "F" vége
    vége        62. "F" vége
    Meg kell keresni hol van a 62 "F" -1 
    Meg kell keresni a bekért szám -1 "F"-et  és a szám "F"-et 
    for ciklus az n-1. sorszámátol az n. sorszámáig megy 
    Ezeken kell a statisztika  :D 
    Néma csend egész órán

     8. Feladat: 



    itt kell használni az ertek nevü függvényt
    File készítés
    Statisztika kell itt is ugyan ugy (string int)
    Minden Fizetést kell meg számolni (összegezni)

    F-ig statisztika a darabszámokról F esetén a statisztika át futattása az ertek függvényen (6. Ffeladata)-
    eredmények összegzése Dictonary nullázása és Filbe kell írni ezt az összegett 
    sorszám  (segéd változó) kell számolni az F-eket 

     */
}
