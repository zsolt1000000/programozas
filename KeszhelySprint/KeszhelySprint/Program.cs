using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KeszhelySprint
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
        List<adatok> adatokLista = new List<adatok>();
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
        void f7()
        {

        }
        void f6()
        {
            int seged1 = 0;
            int index = 0;
            int seged2 = 0;
            string nev = "";
            for (int i = 0; i < adatokLista.Count; i++)
            {
                if (!adatokLista[i].ferfi)
                {
                    if (adatokLista[index].osszido()>adatokLista[i].osszido())
                    {
                        index = i;
                    }
                }
               

                
            }
            Console.WriteLine("6. Feladat: A legjobb időt {0} futotta",adatokLista[index].nev);
        }
        void f5()
        {
            string kat;
            Console.Write("5 Feladat: Kérek egy kategóriát: ");
            kat = Console.ReadLine();
            string seged=" ";
            for (int i = 0; i < adatokLista.Count; i++)
            {
                if (kat==adatokLista[i].kategoria)
                {
                    seged +=Convert.ToString( adatokLista[i].rajtszam);
                    seged += " ";
                }
                



            }
            if (seged!=" ")
            {
                Console.WriteLine("Rajtszám(ok): {0}", seged);
            }
            else
            {
                Console.WriteLine("Rajtszám(ok): Nincs ilyen kategória!");
            }
           
        }
        void f4()
        {
            double ossz=0;
            foreach (var item in adatokLista)
            {
                ossz += 2014 - item.szuldatom;
            }
            Console.WriteLine("4. Feladat: Átlagéletkor: {0:0.0} év.",ossz/adatokLista.Count);
        }
        void f3()
        {
            int darab = 0;
            for (int i = 0; i < adatokLista.Count; i++)
            {
                if (adatokLista[i].kategoria=="elit junior")
                {
                    darab++;
                }
            }
            Console.WriteLine("3. Feladat: Versenyzők száma az \"elit Junior\" kategóriában: {0} fő",darab);

        }
        void f2()
        {
            Console.WriteLine("2. Feladat: A versenyt {0} versenyző fejezte be",adatokLista.Count);
        }
        void f1()
        {
            string[] sorok = File.ReadAllLines("Eredmenyek.txt",encoding:System.Text.Encoding.UTF8);
            for (int i = 0; i < sorok.Length; i++)
            {
                adatokLista.Add(new adatok(sorok[i])); 
            }
        }
    }
    class adatok
    {
        public string nev, kategoria, uszas, depo1, kerekpar, depo2, futas;
        public int szuldatom,rajtszam;
        public bool ferfi = true;
        
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");

            nev = vag[0];
            szuldatom = Convert.ToInt32(vag[1]);
            rajtszam = Convert.ToInt32(vag[2]);
            ferfi =vag[3]=="f";
            kategoria = vag[4];
            uszas = vag[5];
            depo1 = vag[6];
            kerekpar = vag[7];
            depo2 = vag[8];
            futas = vag[9];

        }
        int mp (string ido)
        {
            //"00:12:04"
            string[]vag = ido.Split(":");
            /*
             * "00"
             * "12"
             * "04"
             */

            return Convert.ToInt32(vag[0])*60*60+Convert.ToInt32(vag[1])*60+Convert.ToInt32(vag[2])*1;
                                }
        public int osszido()
        {
            return mp(uszas) + mp(depo1) + mp(futas) + mp(depo2) + mp(kerekpar);
        }
    }
}
