using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FIFAvilágranglísta
{
    class Program
    {
        static void Main(string[] args)
        {

            feladt f = new feladt();

        }
    }
    class feladt
    {
        List<adatok> fifa = new List<adatok>();
        public feladt()
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
            string[] sorok = File.ReadAllLines("fifa.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                fifa.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: A világranglistán {0} csapat szerepel", fifa.Count);
        }

        void f4()
        {
            double seged = 0;
            for (int i = 0; i < fifa.Count; i++)
            {
                seged += fifa[i].Pontszam;
            }
            double seged2 = seged / fifa.Count;

            Console.WriteLine("4. feladat: A csapatok átlagos pontszáma: {0:0.00} pont",seged2);
        }
        void f5()
        {
            Console.WriteLine("5. feladat: A legtöbbet javító csapat:");
            int seged = 0;
            for (int i = 0; i < fifa.Count; i++)
            {
                if (seged>fifa[i].Valtozas)
                {
                    seged = i;
                }
            }
            Console.WriteLine("\tHelyezés: {0}",fifa[seged].Helyezes);
            Console.WriteLine("\tCsapat: {0}", fifa[seged].Csapat);
            Console.WriteLine("\tPontszam: {0}",fifa[seged].Pontszam);
        }
        void f6()
        {
            bool seged = false;
            for (int i = 0; i < fifa.Count; i++)
            {
                if (fifa[i].Csapat=="Magyarország")
                {
                    seged = true;
                }
            }
            if (seged)
            {
                Console.WriteLine("6. feladat: A csapatok között volt Magyarország");
            }
            else
            {
                Console.WriteLine("6. feladat: A csapatok között nem volt Magyarország");
            }
        }
        void f7()
        {
            Dictionary<int, int> stat = new Dictionary<int, int>();
            for (int i = 0; i < fifa.Count; i++)
            {
                if (stat.ContainsKey(fifa[i].Valtozas))
                {
                    stat[fifa[i].Valtozas]++;
                }
                else
                {
                    stat.Add(fifa[i].Valtozas, 1);
                }
            }
            foreach (var item in stat)
            {
                if (item.Value>1)
                {
                    Console.WriteLine("{0} {1}",item.Value,item.Key);
                }

            }
        }
        void f8()
        {
            Console.WriteLine("8. feladat");
            double seged = 0;
            for (int i = 0; i < fifa.Count; i++)
            {
                seged += fifa[i].Pontszam;
            }
            double seged2 = seged / fifa.Count;
            StreamWriter ir = new StreamWriter("elteres.txt");
            
            ir.Close();
        }
        
    }
    class adatok
    {
        public string Csapat;
        public int Helyezes, Valtozas, Pontszam;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            Csapat = vag[0];
            Helyezes = Convert.ToInt32(vag[1]);
            Valtozas = Convert.ToInt32(vag[2]);
            Pontszam= Convert.ToInt32(vag[3]);
        }
    }
}
