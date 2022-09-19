using System;
using System.Collections.Generic;
using System.IO;

namespace szokereso
{
    class Program
    {
        static void Main(string[] args)
        {
            feladatok f = new feladatok();
        }


    }
    class feladatok
        
    {
        List<adatok> szavak = new List<adatok>();
        public feladatok()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
        }
        public void f1()
        {
            string[] sor = File.ReadAllLines("szavak.txt");
            for (int i = 0; i < sor.Length; i++)
            {
                szavak.Add(new adatok(sor[i]));
            }

            Console.WriteLine("1. feladat - Szavak száma: {0} db",szavak.Count);

        }
        int max = 0;
        public void f2()
        {
            
            for (int i = 0; i < szavak.Count; i++)
            {
                if (szavak[i].szo.Length>max)
                {
                    max = szavak[i].szo.Length;
                }
                
            }
            Console.WriteLine("2. feladat - leghosszabb szó hossza: {0} db karakter",max);
        }
        public void f3()
        {
            Console.WriteLine("3. feladat - Leghosszab szó/szvaka:");

            for (int i = 0; i < szavak.Count; i++)
            {
                if (szavak[i].szo.Length==max)
                {
                    Console.WriteLine("\t{0}",szavak[i].szo);
               //     Console.WriteLine("\t{0}",szavak[i].szo);
                }
            }
           
          
        }
        string[,] matrix = new string[16, 16];
        public void f4()
        {
            int[,] irany = new int[9, 2]                { 
                                            { 0     , 0 },
                                            { 1     , 0 }, 
                                            { 1     ,-1  },
                                            {0      ,-1 },
                                            { -1    , -1 }, 
                                            { -1    , 0 }, 
                                            { -1    , 1 }, 
                                            { 0     , 1 }, 
                                            { 1     , 1 }
                                                        };

            for (int i = 0; i < szavak.Count; i++)
            {
                int x = szavak[i].oszlop;
                int y = szavak[i].sor;
                for (int k = 0; k < szavak[i].szo.Length; k++)
                {
                    matrix[x, y] = szavak[i].szo[k].ToString();
                    x += irany[szavak[i].irany,0];
                    y += irany[szavak[i].irany, 1];
                }
            }

            
        }
        public void f5()
        {
            Console.WriteLine("5. feladat  - Szavak kiírása");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i,k]==null)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(matrix[i, k]);
                    }
                  
                }
                Console.WriteLine();
            }
        }
    }
    class adatok
    {
      public  string szo;
        public int sor, oszlop;
        public int irany;

        public adatok(string sor)
        {

            

            string[] vag = sor.Split("*");
            szo = vag[0];
            this.sor = Convert.ToInt32(vag[1]);
            this.oszlop = Convert.ToInt32(vag[2]);
            irany = Convert.ToInt32(vag[3]);
        }
      
    }
}
