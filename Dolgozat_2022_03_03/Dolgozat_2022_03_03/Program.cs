using System;
using System.Collections.Generic;
using System.IO;

namespace Dolgozat_2022_03_03
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
        void f1()
        {
            Console.WriteLine("1. Feladat");
        }

       public int padloHossz = -1;
        public int padloSzelesseg = -1;
        public void f2()
        {
            Console.WriteLine("2. Feladat");
            while (padloSzelesseg<5 || padloSzelesseg>100)
            {
                Console.WriteLine("Kérek egy szélességet 5 és 99 között: ");
                padloSzelesseg = Convert.ToInt32(Console.ReadLine());
            }
            while (padloHossz<5 ||padloHossz>100)
            {


                Console.WriteLine("Kérek egy hosszuságot 5 és 99 között: ");
                padloHossz = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine(padloHossz+" "+padloSzelesseg);
        }

        void f3()
        {

            Console.WriteLine("3. Feladat");
            int[,] padlo = new int[padloHossz, padloSzelesseg];
            Random rand = new Random();
            for (int i = 0; i < padlo.GetLength(0); i++)
            {
                for (int k = 0; k < padlo.GetLength(1); k++)
                {
                    padlo[i, k] = rand.Next(1, 26);
                }

            }
            Console.WriteLine("4. Feladat");
            StreamWriter ir = new StreamWriter("minecraft.txt");

            for (int i = 0; i < padlo.GetLength(0); i++)
            {
                for (int k = 0; k < padlo.GetLength(1); k++)
                {
                    ir.Write(padlo[i,k]);
                    ir.Write(" ");
                        
                }
                ir.WriteLine("");

            }
            ir.Close();
            Console.WriteLine("5. Feladat");
            Dictionary<int, int> szamok = new Dictionary<int, int>();
            
                szamok.Add(1, 0);
                szamok.Add(2, 0);
                szamok.Add(3, 0);
                szamok.Add(4, 0);
                szamok.Add(5, 0);
                szamok.Add(6, 0);
                szamok.Add(7, 0);
                szamok.Add(8, 0);
                szamok.Add(9, 0);
                szamok.Add(10, 0);
                szamok.Add(11, 0);
                szamok.Add(12, 0);
                szamok.Add(13, 0);
                szamok.Add(14, 0);
                szamok.Add(15, 0);
                szamok.Add(16, 0);
                szamok.Add(17, 0);
                szamok.Add(18, 0);
                szamok.Add(19, 0);
                szamok.Add(20, 0);
                szamok.Add(21, 0);
                szamok.Add(22, 0);
                szamok.Add(23, 0);
                szamok.Add(24, 0);
                szamok.Add(25, 0);

            for (int i = 0; i < 25; i++)
            {

            }

            Console.WriteLine("6. Feladat");
            StreamWriter anyag = new StreamWriter("anyagok.txt");
            
            for (int l = 0; l < padlo.GetLength(0); l++)
            {
                for (int q = 0; q < padlo.GetLength(1); q++)
                {

                }
            }




            Console.WriteLine("7. Feladat");

        }
        void f4()
        {

        }
        void f5()
        {
           
        }
        void f6()
        {

        }
        void f7()
        {

        }
    }
    class adatok
    {
       public int szelesseg = 0;
       public int hosszusag = 0;
        public int blokkok;

        
        public adatok() 
        {
            Random rand = new Random();
            szelesseg= rand.Next(5, 99);
            hosszusag= rand.Next(5, 99);
             
        }
        

    }
}
