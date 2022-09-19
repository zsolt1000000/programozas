using System;
using System.IO;
using System.Collections.Generic;

namespace valasztas
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
        List<adatok> szavazatokOsszes = new List<adatok>();
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
            string[] sorok = File.ReadAllLines("szavazatok.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                szavazatokOsszes.Add(new adatok(sorok[i]));
            }
        }
        void f2()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine("A helyhatósági választáson {0} képviselőjelölt indult", szavazatokOsszes.Count);
        }
        void f3()
        {
            Console.WriteLine("3. Feladat");
            Console.Write("Kérem az egyik képviselő vezeték nevét: ");
            string vez = Console.ReadLine();
            Console.Write("Kérem a képviselő keresztnevét is: ");
            string kere = Console.ReadLine();
            bool seged = false;
            int szamSeged = 0;

            for (int i = 0; i < szavazatokOsszes.Count; i++)
            {
                if (vez == szavazatokOsszes[i].vezetek)
                {
                    if (kere == szavazatokOsszes[i].utonev)
                    {
                        //  Console.WriteLine("A(z) {0} {1} nevű képviselő {3} db szavazatot kapott", vez, kere, szavazatokOsszes[i].szavazat);
                        seged = true;
                        szamSeged = szavazatokOsszes[i].szavazat;
                    }

                }
            }
            if (seged == true)
            {
                Console.WriteLine("A(z) {0} {1} nevű képviselő {3} db szavazatot kapott", vez, kere, szamSeged);

            }
            else
            {
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");

            }
        }
        int lakok = 12345;
        double egySzazalek = 12345 / 100;
        void f4()
        {
             lakok = 12345;
             egySzazalek = 12345 / 100;
            Console.WriteLine(egySzazalek);
            int szavazatok = 0;
            Console.WriteLine("4. Feladat");
            for (int i = 0; i < szavazatokOsszes.Count; i++)
            {
                szavazatok += szavazatokOsszes[i].szavazat;
            }
            double szazalek = szavazatok / egySzazalek;
            Console.WriteLine("A választáson {0} állampolgár, a jogusoltak {1:0.00}%-a vett részt.",szavazatok,szazalek);
        }
        void f5()
        {

        }
        void f6()
        {

        }
        void f7()
        {

            StreamWriter ir = new StreamWriter("kepviselok.txt");
            for (int i = 0; i < szavazatokOsszes.Count; i++)
            {
                ir.WriteLine("{0} {1} {2} {3}", szavazatokOsszes[i].valasztokerulet, szavazatokOsszes[i].vezetek, szavazatokOsszes[i].utonev, szavazatokOsszes[i].part);
            }
            
            ir.Close();
        }
    }
    class adatok
    {
        public int valasztokerulet, szavazat;
        public string vezetek, utonev, part;
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            valasztokerulet = Convert.ToInt32(vag[0]);
            szavazat = Convert.ToInt32(vag[1]);
            vezetek = vag[2];
            utonev = vag[3];
            part= vag[4];

        }
    }
}
