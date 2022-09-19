using System;
using System.IO;
using System.Collections.Generic;

namespace NASA
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
        List<keres> log = new List<keres>();
        public feladat()
        {
            f4();
            f5();
            f6();
            f7();
            f8();
            f9();
        }
        void f4()
        {
            string[] sorok = File.ReadAllLines("NASAlog.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                log.Add(new keres(sorok[i]));
            }
        }
        void f5()
        {
            Console.WriteLine("5. feladat: Kérések száma: {0}",log.Count);
        }
        void f6()
        {
            int osszeg = 0;
            for (int i = 0; i < log.Count; i++)
            {
                osszeg += log[i].ByteMeret();
            }
            Console.WriteLine("6. feladat: Válaszok összes mérete: {0} byte",osszeg);
        }
        void f7()
        {

        }
        void f8()
        {
            double db = 0;
            for (int i = 0; i < log.Count; i++)
            {
                if (log[i].Domain())
                {
                    db++;
                }
            }
            Console.WriteLine("{0}",db);
        }
        void f9()
        {
            Dictionary<int, int> stat = new Dictionary<int, int>();
            for (int i = 0; i < log.Count; i++)
            {
                if (stat.ContainsKey(Convert.ToInt32(log[i].kod)))
                {
                    stat.Add(Convert.ToInt32(log[i].kod), 1);
                }
                else
                {
                    stat[Convert.ToInt32(log[i].kod)]++;
                }
                Console.WriteLine("9. feladat Statisztika:");
                foreach (var item in stat)
                {
                    Console.WriteLine("\t{0}: {1} db",item.Key,item.Value);
                }
            }
        }
    }
    class keres
    {
        public string cim, datum, kep, kod, meret;
        public bool Domain()
        {
            string[] szamok = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < szamok.Length; i++)
            {
                if (cim[cim.Length-1].ToString()==szamok[i])
                {
                    return false;
                }
            }
            return true;
        }
        public int ByteMeret()
        {

            if (meret == "-")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(meret);
            }
            
        }
        public keres(string sor )
        {
            string[] vag = sor.Split("*");
            cim = vag[0];
            datum = vag[1];
            kep = vag[2];
            //kod = vag[3];
            string[] vag2 = vag[3].Split(" ");
            kod = vag2[0];
            meret = vag2[1];
            //meret = vag[4];
        }
    }
}/*
  //1. Feladat 
  //2. Feladat 
  //3. Feladat 
  //4. Feladat 
  //5. Feladat 
  //6. Feladat 
  //7. Feladat 
  //8. Feladat 
összegzés tétel százalék számítás és double legyen
  //9. Feladat 
Dictionary
  
  
  */
