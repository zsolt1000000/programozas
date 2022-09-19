using System;
using System.Collections.Generic;
using System.IO;

namespace robot
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat a = new feladat();

        }
    }
    class feladat
    {
        List<adatok> kodok = new List<adatok>();
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
            f6();
        }
        public void f1() 
        {
            string[] sorok = File.ReadAllLines("progs.txt");
            for (int i = 0; i < sorok.Length; i++)
            {

                kodok.Add(new adatok(sorok[i]));

            }
        }
        public void f2()
        {
            Console.WriteLine("2. Feladat: Tanulók száma: {0} fő",kodok.Count);
        }
        public void f3()
        {
            int db = 0;
            for (int i = 0; i < kodok.Count; i++)
            {
                if (!kodok[i].helyes)
                {
                    db++;
                }
            }
            Console.WriteLine("3. Feladat: Helytelen kódsorozatok száma {0}",db);
        }
        public void f4()
        {
            StreamWriter ir = new StreamWriter("ivsz.txt");
            foreach (adatok item in kodok)
            {
                if (item.helyes)
                {
                    ir.WriteLine("{0} {1}", item.nev, item.iranyValtasDarab);
                }
            }
            ir.Close();
        }
        public void f5()
        {
            double max=0;
            string nev = "";
            foreach (adatok item in kodok)
            {
                if (max<item.tavolsag)
                {
                    max = item.tavolsag;
                    nev = item.nev;

                }
            }

            Console.WriteLine("5. Feladat: Legtávolabbra jutó robot vezérlését készítette: {0}",nev);

        }
        public void f6()
        {
            int y = 15;
            int x = 60;
            string kod = kodok[0].kod;
            string kep = "|";
            Console.WriteLine(kod);
            ConsoleColor elozo = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            Console.Write(kep);

            Console.ForegroundColor = elozo;
            for (int i = 0; i < kod.Length; i++)
            {
                switch (kod[i])
                {
                    case 'E': y++; break;
                    case 'H': y--; break;
                    case 'J': x++; break;
                    case 'B': y--; break;

                }
                if (i==kod.Length-1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                Console.SetCursorPosition(x, y);
                Console.Write(kep); Console.ForegroundColor = elozo;

            }
        }
    }
    class adatok
    {
        public string nev;
        public string kod;
        public bool helyes;
        public  adatok (string sor)
        {
            
            string[] vag = sor.Split(" ");
            nev = vag[0];
            kod = vag[1];
            kodCheck();
        }
        void kodCheck()
        {
            helyes = true;

            string betuk = "EJBH";
            for (int i = 0; i < kod.Length; i++)
            {
                if (!betuk.Contains(kod[i]))
                {
                    helyes = false;
                    break;
                }


            }
        }
        public int iranyValtasDarab
        {
            get
            {
                int db = 0;
                for (int i = 0; i < kod.Length-1; i++)
                {
                    if (kod[i]!=kod[i+1])
                    {
                        db++;
                    }
                }
                return db;
            }



        }
        public double tavolsag
        {
            get
            {
                int y = 0;
                int x = 0;

                for (int i = 0; i < kod.Length; i++)
                {
                    switch (kod[i])
                    {
                        case 'E': y++; break;
                        case 'H': y--; break;
                        case 'J': x++; break;
                        case 'B': y--; break;

                   }
                }
                return Math.Sqrt(x * x + y * y);
            }
        }
    }
}
