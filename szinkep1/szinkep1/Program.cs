using System;
using System.Collections.Generic;
using System.IO;

namespace szinkep1
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
            //f2();
            f3();
            f4();
            f5();
            f6();
            f7();
        }

        adatok[,] kep = new adatok[50,50];
        void f1()
        {
            string[] sorok = File.ReadAllLines("kep.txt");
            int index = 0;
            for (int i = 0; i < kep.GetLength(0); i++)
            {


                for (int k = 0; k < kep.GetLength(1); k++)
                {
                    kep[i, k] = new adatok(sorok[index]);
                    index++;
                }
            }
        }
        void f2()
        {
            Console.WriteLine("2. Feladat");
            Console.WriteLine("Kérek egy RGB kódot");
            string kod = Console.ReadLine();
            adatok bekert = new adatok(kod);
            bool vanE = false;


            for (int i = 0; i < kep.GetLength(0); i++)
            {
                for (int k = 0; k < kep.GetLength(1); k++)
                {
                    if (kep[i,k].egyenlo(bekert))
                    {
                        vanE = true;
                    }
                }
            }

            if (vanE)
            {
                Console.WriteLine("Van iylen szín kód");
            }
            else
            {
                Console.WriteLine("Nincs ilyen szín"); 
            }
        
        
        }
        void f3()
        {
            Console.WriteLine("3. Feladat");
            int oszlopba = 0;
            int sorban = 0;
            for (int i = 0; i < kep.GetLength(1); i++)
            {
                if (kep[34,i].egyenlo(kep[34,7]))
                {
                    sorban++;
                }
            }
            for (int i = 0; i < kep.GetLength(0); i++)
            {
                if (kep[i,7].egyenlo(kep[34,7]))
                {
                    oszlopba++;
                }
            }

            Console.WriteLine("Sorban: {0} Oszlopban: {1}",sorban,oszlopba);
        }
        void f4()
        {
            Dictionary<string, int> statisztika = new Dictionary<string, int>();
            for (int i = 0; i < kep.GetLength(0); i++)
            {
                for (int k = 0; k < kep.GetLength(1); k++)
                {
                    if (kep[i,k].egyenlo(new adatok("255 0 0")))
                    {
                        if (statisztika.ContainsKey("vörös"))
                        {
                            statisztika["vörös"]++;
                        }
                        else
                        {
                            statisztika.Add("vörös",1);
                        }
                    }
                    if (kep[i, k].egyenlo(new adatok("0 255 0")))
                    {
                        if (statisztika.ContainsKey("zöld"))
                        {
                            statisztika["zöld"]++;
                        }
                        else
                        {
                            statisztika.Add("zöld", 1);
                        }
                    }
                    if (kep[i, k].egyenlo(new adatok("0 0 255")))
                    {
                        if (statisztika.ContainsKey("kek"))
                        {
                            statisztika["kek"]++;
                        }
                        else
                        {
                            statisztika.Add("kek", 1);
                        }
                    }
                }
            }

            Console.WriteLine(statisztika["vörös"]);
            Console.WriteLine(statisztika["zöld"]);
            Console.WriteLine(statisztika["kek"]);
            if (statisztika["vörös"]>=statisztika["zöld"] && statisztika["vörös"]>=statisztika["kek"])
            {
                Console.WriteLine("A vörös szín: {0}",statisztika["vörös"]);

            }

           else if (statisztika["zöld"] >= statisztika["vörös"] && statisztika["zöld"] >= statisztika["kek"])
            {
                Console.WriteLine("A zöld szín: {0}", statisztika["zöld"]);

            }
            else
            {
                Console.WriteLine("A kék szín: {0}", statisztika["kek"]);


            }

        }
        void f5()
        {

            for (int i = 0; i < kep.GetLength(0); i++)
            {

                kep[i, 0]  = new adatok("0 0 0");
                kep[i, 1]  = new adatok("0 0 0");
                kep[i, 2]  = new adatok("0 0 0");
                kep[i, 47] = new adatok("0 0 0");
                kep[i, 48] = new adatok("0 0 0");
                kep[i, 49] = new adatok("0 0 0");

            }
            for (int i = 0; i < kep.GetLength(1); i++)
            {

                kep[0, i] = new adatok("0 0 0");
                kep[1, i] = new adatok("0 0 0");
                kep[2, i] = new adatok("0 0 0");
                kep[47,i] = new adatok("0 0 0");
                kep[48,i] = new adatok("0 0 0");
                kep[49,i] = new adatok("0 0 0");

            }
        }
        void f6()
        {
            StreamWriter ir = new StreamWriter("kertes.txt");
            for (int i = 0; i < kep.GetLength(0); i++)
            {
                for (int k = 0; k < kep.GetLength(1); k++)
                {
                    ir.WriteLine("{0} {1} {2}", kep[i, k].red, kep[i, k].green, kep[i, k].blue);

                }

            }
            

                ir.Close();
        }
        void f7()
        {
            int[] kezdes = { -1, -1 };
            int[] vegzes = { -1, -1 };
            for (int i = 0; i < kep.GetLength(0); i++)
            {
                for (int k = 0; k < kep.GetLength(1); k++)
                {
                    if (kep[i,k].egyenlo(new adatok("255 255 0")))
                    {
                        if (kezdes[0]==-1)
                        {
                            kezdes[0] = i;
                            kezdes[1] = k;
                        }
                        vegzes[0] = i;
                        vegzes[1] = k;
                    }
                }
            }

            Console.WriteLine("7. Feladat");
            Console.WriteLine("kezd: {0} {1}",kezdes[0],kezdes[1]);
            Console.WriteLine("végzés: {0} {1}",vegzes[0],vegzes[1]);
            int T = (vegzes[0] - kezdes[0]) * (vegzes[1] - kezdes[1]);
            Console.WriteLine("Képponotok száma: {0}",T);



        }

    }
    class adatok
    {
        public int red, green, blue;
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            red = Convert.ToInt32(vag[0]);
            green = Convert.ToInt32(vag[1]);
            blue = Convert.ToInt32(vag[2]);
        }
        public bool egyenlo(adatok masik)
        {
            return red == masik.red && green == masik.green && blue == masik.blue;
        }
    }
    /*
    1 be olvasás (Mi a megfelelő adat szerkezet)
    2 be kérünk egy szüveget
    van-e
    3. 2 megszámolás 
    4. statitsztika
    5.Kivűlre vagy a képen belül? 
    6. Fileba írás  adatok class olyan fügvény ami szokozzel elvalasztja
    7.A legelső találat a bal feslő a leg utolsó találat a jobb alsó

     
     
     */

}
