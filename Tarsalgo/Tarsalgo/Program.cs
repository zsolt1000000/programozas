using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tarsalgo
{
    class Program
    {
        static void Main(string[] args)
        {

            feladat f = new feladat();
        }



        class feladat
        {
            List<adatok> naplo = new List<adatok>();
            public feladat()
            {
                f1();
                f2();
                f3();
                f4();
                f5();
                f6();
            }

            void f1()
            {
                string[] sorok = File.ReadAllLines("ajto.txt");
                for (int i = 0; i < sorok.Length; i++)
                {
                    naplo.Add(new adatok(sorok[i]));
                }
            }
            void f2()
            {
                Console.WriteLine("2. feladat");


                Console.WriteLine("Az első belépő: {0}", naplo[0].azonosito);

                int utolso = -1;
                for (int i = naplo.Count - 1; i >= 0; i--)
                {
                    if (naplo[i].athaladas == "ki")
                    {
                        utolso = naplo[i].azonosito;
                        break;
                    }
                }
                Console.WriteLine("Az utolsó kilépő: {0}", utolso);




            }
            Dictionary<int, int> darab = new Dictionary<int, int>();
            void f3()
            {
                
                for (int i = 0; i < naplo.Count; i++)
                {
                    // hiba el kerülése
                  /* if (darab.ContainsKey(naplo[i].azonosito))
                    {
                        darab[naplo[i].azonosito]++;
                    }
                    else
                    {
                        darab.Add(naplo[i].azonosito, 1);
                    }*/

                    // hiba kezelése
                     try
                     {
                         darab[naplo[i].azonosito]++;

                     }
                     catch (Exception)
                     {

                         darab.Add(naplo[i].azonosito, 1);
                     }


                }
                /*darab = darab.OrderBy(e => e.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
                foreach (var item in darab)
                {
                    Console.WriteLine("{0} {1}",item.Key,item.Value);
                }*/
                StreamWriter ir = new StreamWriter("athaladas.txt");
                for (int i = 1; i < 101; i++)
                {
                    if (darab.ContainsKey(i))
                    {
                        ir.WriteLine("{0} {1}", i, darab[i]);

                    }
                }
                ir.Close();
            }
            void f4()
            {
                Console.WriteLine("4.feladat");
                Console.Write("A végén a társalgóban voltak:");

                for (int i = 1; i < 101; i++)
                {

                    if (darab.ContainsKey(i))
                    {
                        if (darab[i]%2==1)
                        {

                            Console.Write(" {0} ",i);
                        }

                    }
                }
            }
            void f5()
            {
                //megszámoolás
                //maximum keresés
                int db = 0;
                int max = 0;
                int maxIndex = 0;
                for (int i = 0; i < naplo.Count; i++)
                {
                    if (naplo[i].athaladas=="ki")
                    {
                        db--;
                    }
                    else
                    {
                        db++;
                    }
                    if (db>max)
                    {
                        max = db;
                        maxIndex = i;
                    }
                    
                }
                Console.WriteLine(" ");
                Console.WriteLine("5. feladat");
                Console.WriteLine("{0}:{1}-kor voltak a legtöbben a társalgóban.", naplo[maxIndex].ora, naplo[maxIndex].perc);

            }
            void f6()
            {

            }
        }
        

    }
    class adatok
    {
        public int ora, perc;
        public int azonosito;
        public string athaladas;
        
        public adatok (string sor)
        {

            string[] vag = sor.Split(" ");
            ora = Convert.ToInt32(vag[0]);
            perc = Convert.ToInt32(vag[1]);
            azonosito = Convert.ToInt32(vag[2]);
            athaladas = vag[3];
        }

    }
}
