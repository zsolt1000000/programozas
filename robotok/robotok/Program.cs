using System;
using System.Collections.Generic;
using System.IO;

namespace robotok
{
    class Program
    {
        static void Main(string[] args)
        {
            //minden lepes utan pitagorasz tetel ebbol max kereses, ertek, sorszam
            //fuggveny
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
            //visszaAlakit("2N3DK9E");
            f6();
            
        }
        List<adatok> programok = new List<adatok>();
        void f3()
        {
            for (int i = 0; i < programok.Count; i++)
            {
                if (programok[i].energiaIgeny()<=100)
                {
                    Console.WriteLine("{0} {1}",i+1, programok[i].program);
                }

            }
        }
        void f2()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine("Kérek egy sorszámot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            if (programok[szam - 1].egyszerusitheto())
            {
                Console.WriteLine("Egyszerüsíthető");
            }
            else
            {
                Console.WriteLine("Nem egyszerüsíthető");
            }
            int[] t = programok[szam - 1].visszaUt();
            Console.WriteLine("{0} lépést kell tenni az ED, {1} lépést a KN tengely mentén.", t[0], t[1]);
        }
        void f1()
        {
            string[] sorok = File.ReadAllLines("program.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                programok.Add(new adatok(sorok[i]));
            }
        }
        void f4()
        {
            StreamWriter ir = new StreamWriter("ujprog.txt");


            for (int i = 0; i < programok.Count; i++)
            {

                ir.WriteLine(programok[i].tomorit());
            }


            ir.Close();
        }
        string visszaAlakit (string program)
        {
            String szam = "";
            string vissza = "";
            for (int i = 0; i < program.Length; i++)
            {
                if (program[i] == 'N' || program[i] == 'E' || program[i] == 'K' || program[i] == 'D')
                {

                    Console.WriteLine(program[i]);
                    Console.WriteLine(szam);
                    if (szam=="")
                    {
                        szam = "1";
                    }
                    for (int k = 0; k <Convert.ToInt32(szam); k++)
                    {
                        vissza += program[i];
                    }
                    szam = "";
                }
                else
                {
                    szam += program[i];
                }
            }

            return vissza;

        }
        void f6()
        {

        }
        void f5() {
            Console.WriteLine("Kérek egy újfajta utasítás sort");
            string program = Console.ReadLine();
            Console.WriteLine("Régi kód {0}",visszaAlakit(program));
        
        }
    }
        
    }
    class adatok
    {
        public string program;

        public adatok(string sor)
        {
            program = sor;
        }
        public double[] tavolsag()
        {
            int x = 0, y = 0;
            double maxTav = 0;
            double lepes = 0;
            for (int i = 0; i < program.Length; i++)
            {
                if (program[i] == 'K')
                {
                    x++;
                }
                if (program[i] == 'N')
                {
                    x--;
                }
                if (program[i] == 'E')
                {
                    y++;
                }
                if (program[i] == 'D')
                {
                    y--;
                }
                double akTav = Math.Sqrt(x * x + y * y);
                if (akTav > maxTav)
                {
                    maxTav = akTav;
                    lepes = i;
                }
               
            }
            double[] t = new double[2];
            t[0] = maxTav;
            t[1] = lepes;
            return t;
        }


        public string tomorit()
        {
            int darab = 1;
            string ujKod = "";
            char betu = program[0];
            for (int i = 1; i < program.Length; i++)
            {
                if (program[i]==program[i-1])
                {
                    darab++;
                }
                else
                {
                    if (darab<=1)
                    {
                        ujKod +=program[i - 1].ToString();
                    }
                    else
                    {
                        ujKod += darab + program[i - 1].ToString();

                    }
                    darab = 1;
                }

            }
            if (darab <= 1)
            {
                ujKod += program[program.Length- 1].ToString();
            }
            else
            {
                ujKod += darab + program[program.Length- 1].ToString();

            }
            return ujKod;
        }
        public int[] visszaUt()
        {
            Dictionary<char, int> stat = new Dictionary<char, int>();
            stat.Add('D', 0);
            stat.Add('E', 0);
            stat.Add('K', 0);
            stat.Add('N', 0);

            for (int i = 0; i < program.Length; i++)
            {
                stat[program[i]]++;
            }
            int[] vissza = new int[2];
            vissza[0] = Math.Abs(stat['E'] - stat['D']);
            vissza[1] = Math.Abs(stat['K'] - stat['N']);

            return vissza;
        }
        public bool egyszerusitheto()
        {
            for (int i = 0; i < program.Length - 1; i++)
            {
                if (program.Substring(i, 2) == "ED")
                {
                    return true;
                }
                if (program.Substring(i, 2) == "DE")
                {
                    return true;
                }
                if (program.Substring(i, 2) == "NK")
                {
                    return true;
                }
                if (program.Substring(i, 2) == "KN")
                {
                    return true;
                }
            }
            return false;
        }

        public int energiaIgeny()
        {

            int osszeg = 2+1;
            for (int i = 1; i < program.Length; i++)
            {
                if (program[i]!=program[i-1])
                {
                    osszeg += 1+2;
                }
                else
                {
                    osszeg++;
                }
            }
            return osszeg;
        }
    }

/*
 programok [szam -1].tavolsag()[1], programok[szam-1].tavolsag()[0]*/