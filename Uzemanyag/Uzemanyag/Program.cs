using System;
using System.Collections.Generic;
using System.IO;

namespace Uzemanyag
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
            f8();
            f9();
            f10();
        }
        void f1()
        {

        }
        List<adatok> valtozasok = new List<adatok>(); 
        void f2()
        {
            string[] sorok = File.ReadAllLines("uzemanyag.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                valtozasok.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Változások száma: {0}",valtozasok.Count);
        }
        int min = 999999999;

        void f4()
        {
            min =999999999;
            for (int i = 0; i < valtozasok.Count; i++)
            {
                if (min>valtozasok[i].kulonbseg())
                {
                    min = valtozasok[i].kulonbseg();
                }
            }



            Console.WriteLine("4. feladat: A legkisebb különbség: {0}",min);
        }
        void f5()
        {
            int db = 0;
            for (int i = 0; i <valtozasok.Count ; i++)
            {
                if (min==valtozasok[i].kulonbseg())
                {
                    db++;
                }
            }
            Console.WriteLine("5. feladat: A legkisebb különbség előfordulás: {0}",db);
        }
        void f6()
        {

            bool seged=false;
            for (int i = 0; i < valtozasok.Count; i++)
            {
                if (valtozasok[i].szokoNap())
                {
                    Console.WriteLine("6. feladat: Volt változás szökőnapon");
                    seged = true;

                    break;
                }
               
            }
            if (seged==false)
            {
                Console.WriteLine("6. feladat: Nem volt változás szökőnapon");

            }


        }
        void f7()
        {
            StreamWriter ir = new StreamWriter("euro.txt");
            for (int i = 0; i < valtozasok.Count; i++)
            {
                ir.WriteLine("{0};{1:0.00};{2:0.00}",valtozasok[i].datum, valtozasok[i].benzinEuro(), valtozasok[i].dizelEuro());
            }

            ir.Close();
        }
        int ev = 0;

        void f8()
        {

               
            do
            {
                Console.Write("8. feladat: Kérem adja meg az évszámot [2011..2016]: ");
                 ev = Convert.ToInt32(Console.ReadLine());
            } while (!(2011<=ev && ev<=2016) );
            
            

            

        }
        int napokSzama(string datum1, string datum2)
        {
            int[] napokSzama = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            adatok temp = new adatok(datum1.Substring(0, 4)+".02.24;0;0");
            // if (Convert.ToInt32(datum1.Substring(0,4))%4==0)
            if (temp.szokoNap())
            {
                napokSzama[1] = 29;
            }
            if (datum1.Substring(5,2)== datum2.Substring(5, 2))
            {
                return Convert.ToInt32(datum2.Substring(8, 2)) - Convert.ToInt32(datum1.Substring(8, 2));
            }
            else
            {
                return napokSzama[Convert.ToInt32(datum1.Substring(5, 2)) - 1]
                    - 
                    Convert.ToInt32(datum2.Substring(8, 2))
                    +
                    Convert.ToInt32(datum1.Substring(8, 2));
            }

        }
        void f9()
        {

        }
        void f10()
        {


            int max =0;
            for (int i = 1; i < valtozasok.Count; i++)
            {
                if (ev==Convert.ToInt32(valtozasok[i].datum.Split(".")[0]))
                {
                    if (max< napokSzama(valtozasok[i - 1].datum, valtozasok[i].datum))
                    {
                        //Console.WriteLine(napokSzama(valtozasok[i-1].datum,valtozasok[i].datum));
                        max = napokSzama(valtozasok[i - 1].datum, valtozasok[i].datum);
                    }
                }

            }
            
            Console.WriteLine("10. feladat: {0} évben a leghosszabb időszak {1} nap volt",ev,max);
        }
    }
    class adatok
    {
        public string datum = "";
        public int benzin, dizel;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            datum = vag[0];
            benzin = Convert.ToInt32(vag[1]);
            dizel = Convert.ToInt32(vag[2]);
        }
        public int kulonbseg()
        {
            int k = Math.Abs(benzin - dizel);
            return k;
        }

        public double benzinEuro()
        {
            return benzin / 307.7;
        }
        public double dizelEuro()
        {
            return dizel / 307.7;
        }
        public bool szokoNap()
        {
            string[] vag = datum.Split(".");
            if (Convert.ToInt32(vag[0])%4==0)
            {
                if (vag[1]=="02")
                {
                    if (vag[2]=="24")
                    {
                        return true;
                        
                    }
                }
            }
            
            
                return false;
            
            
        }
    }
}
/*
1. Feladat
    3 adat lesz az adatok klasszban 
    soronként egy adat 
    adatok típuso lista
2. Feladat    
3. Feladat
    Ahány lista elem van
4. Feladat
    Kívonás kettőt egymásból
5. Feladat
    meg kell számolni hányszor fordul elő   
6. Feladat
    Ha az év szökő év (4 el osztható maradék nélkük)
7. Feladat
    stream writer
    adatok klassz ki egészítése
    
8. Feladat
    Be kérés
    While ciklusos

9. Feladat
    
10. Feladat
    
 */