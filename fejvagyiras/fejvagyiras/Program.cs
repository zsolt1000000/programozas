using System;
using System.IO;

namespace fejvagyiras
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
        }

        Random rand = new Random();
        int fejDb = 0;
        int db = 0;
        public void f1()
        {
            int szam = rand.Next(2);
            Console.WriteLine("1. feladat");
            string szoveg = "A pénzfeldobás eredménye: ";
            if (szam==0)
            {
                szoveg += "F";
            }
            else
            {
                szoveg += "I";
            }
            Console.WriteLine(szoveg);
        }
        public void f2()
        {
            string szoveg=" ";
            string szo=" ";
            Console.WriteLine("2. feladat");
            Console.Write("Tippeljen! (F/I)= ");
            szo = Console.ReadLine();
           
            int szam = rand.Next(2);
           
            if (szam == 0)
            {
                szoveg = "F";
            }
            else
            {
                szoveg = "I";
            }
            Console.WriteLine("A tipp {0}, a dobás eredménye {1} volt.",szo ,szoveg);
            if (szoveg ==szo)
            {
                Console.WriteLine("Ön eltalálta!");
            }
            else
            {
                Console.WriteLine("Ön nem találta el");
            }







        }
        public void f3()
        {
            Console.WriteLine("3. feladat");
           
           
            StreamReader olvas = new StreamReader("kiserlet.txt");

            while (!olvas.EndOfStream)
            {
               string be = olvas.ReadLine();
                db++;
                if (be=="F")
                {
                    fejDb++;
                }

            }

            olvas.Close();
            Console.WriteLine("A kisérlet {0} dobásból állt.", db);
        }
        public void f4()
        {
            Console.WriteLine("4. feladat");
            Console.WriteLine("A kisérlet során a fej relatív gyakorisága {0:0.00%} volt.",(double)fejDb/db);
        }
        public void f5()
        {
            Console.WriteLine("5 feladat");
            StreamReader olvas = new StreamReader("kiserlet.txt");
            int db = 0;
            string seged = "";
            while (!olvas.EndOfStream)
            {
                string be = olvas.ReadLine();
                if (be == "F")
                {
                    seged += be;
                }
                else
                {
                    if (seged =="FF")
                    {
                        db++;
                    }
                    seged = "";
                }
            }
            if (seged == "FF")
            {
                db++;
            }
            seged = "";
            olvas.Close();
            Console.WriteLine("A kisérlet során {0} alkalommal dobtak pontosan két fejet egymás után.",db);
        }
        public void f6()
        {
            int sorszam = 1;
            string seged = "";
            int maxHossz = -1;
            int maxSorszam = -1;
            StreamReader olvas = new StreamReader("kiserlet.txt");
            while (!olvas.EndOfStream)
            {
                string be =olvas.ReadLine();
                if (be =="F")
                {
                    seged += be;
                }
                else
                {
                    if (seged.Length>maxHossz)
                    {
                        maxHossz = seged.Length;
                        maxSorszam = sorszam - maxHossz;
                    }

                    seged="";
                }
                sorszam++;
            }
            if (seged.Length > maxHossz)
            {
                maxHossz = seged.Length;
                maxSorszam = sorszam - maxHossz;
            }
            olvas.Close();
            Console.WriteLine("6. feladat");

            Console.WriteLine("A leghosszabb tisztafej sorozat {0} tagból áll, kezdete a(z) {1}. dobás",maxHossz,maxSorszam);
        }
    }
}
