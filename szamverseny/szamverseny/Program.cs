using System;
using System.IO;
using System.Collections.Generic;

namespace szamverseny
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
        List<adatok> test = new List<adatok>();
        void f1()
        {
            string[] sorok = File.ReadAllLines("felszam.txt");
            for (int i = 0; i < sorok.Length; i += 2)
            {
                test.Add(new adatok(sorok[i], sorok[i + 1]));

            }

        }
        void f2()
        {
            Console.WriteLine("Az adat fáljban {0} kérdés van",test.Count);
        }
        void f3()
        {


            int matek =0;
            int pont1 = 0;
            int pont2 = 0;
            int pont3 = 0;

            for (int i = 0; i < test.Count; i++)
            {
                if (test[i].tantargy=="matematika")
                {
                    matek++;
                }
                if (test[i].tantargy == "matematika" && test[i].szam2==1)
                {
                    pont1++; 
                }
                else if (test[i].tantargy == "matematika" && test[i].szam2==2)
                {
                    pont2++;
                }
                else if (test[i].tantargy == "matematika" && test[i].szam2==3)
                {
                    pont3++;
                }
                

                


            }
            Console.WriteLine("Az adatfájlban {0} matematikai feladat van, 1 pontot er {1} feladat, 2 pontott er {2} feladat, 4 pontot er {3} feladat", matek, pont1,pont2,pont3);


        }
        void f4()
        {

            int legkisebb = 0;
            int legnagyobb = 0;
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i].szam1>=legnagyobb)
                {
                    legnagyobb= test[i].szam1;
                }

                if (test[i].szam1<=legnagyobb)
                {
                    legkisebb = test[i].szam1;
                }
            
            }

            Console.WriteLine("A legkisebb szám: {0}",legkisebb);
            Console.WriteLine("A legnagyobb szám: {0}",legnagyobb);
        }
        void f5()
        {
            string temakor1 = " ";
            string temakor2 = " ";
            string temakor3 = " ";
            string temakor4 = " ";
            string temakor5 = " ";
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i].tantargy==temakor1)
                {
                    if (test[i].tantargy == temakor2)
                    {
                        if (test[i].tantargy == temakor3)
                        {
                            if (test[i].tantargy == temakor4)
                            {
                                if (test[i].tantargy == temakor5)
                                {

                                }
                                else
                                {
                                    temakor5 = test[i].tantargy;

                                }
                            }
                            else
                            {
                                temakor4 = test[i].tantargy;

                            }
                        }
                        else
                        {
                            temakor3 = test[i].tantargy;
                        }
                    }
                    else
                    {
                        temakor2 = test[i].tantargy;

                    }
                }
                else
                {
                    temakor1 = test[i].tantargy;
                }

            }
-
        }
        void f6() 
        {
            Console.Write("Milyen temakorben szeretne kerdest kapni? ");
            string temakor = Console.ReadLine();
            int valasz;
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i].tantargy==temakor)
                {
                    Console.Write(test[i].kerdes);
                     valasz =Convert.ToInt32( Console.ReadLine());
                    if (test[i].szam1==valasz)
                    {
                        Console.WriteLine("A valasz {0} pontot er",test[i].szam2);
                        Console.WriteLine("A helyes váalsz: {0}", test[i].szam1);

                        break;
                    }
                    else
                    {
                        Console.Write("A valasz 0 pontot er");
                        Console.WriteLine(" ");
                        Console.WriteLine("A helyes váalsz: {0}",test[i].szam1);
                        break;
                        
                    }
                }

             
                
            }
        }
        void f7()
        {

        }

    }
    class adatok
    {
        public string kerdes;
        public int szam1, szam2;
        public string tantargy;
        
        public adatok(string sor1 ,string sor2)
        {
            kerdes = sor1;
            
            string[] vag = sor2.Split(" ");
            szam1 = Convert.ToInt32(vag[0]);
            szam2 = Convert.ToInt32(vag[1]);
            tantargy = vag[2];
        }
    }


}
