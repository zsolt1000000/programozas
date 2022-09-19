using System;
using System.Collections.Generic;
using System.IO;

namespace Kutyák
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
        List<nevek> kutyaNevek = new List<nevek>();
        List<fajtak> kutyaFajta = new List<fajtak>();
        List<kutyak> kutyaLista = new List<kutyak>();

        public feladat()
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("KutyaNevek.csv");
            for (int i = 1; i < sorok.Length; i++)
            {
                kutyaNevek.Add(new nevek(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Kutya nevek száma: {0}", kutyaNevek.Count);

        }
        void f4()
        {
            string[] sorok = File.ReadAllLines("KutyaFajtak.csv");
            for (int i = 1; i < sorok.Length; i++)
            {
                kutyaFajta.Add(new fajtak(sorok[i]));
            }
        }
        void f5() 
        {
            string[] sorok = File.ReadAllLines("Kutyak.csv");
            for (int i = 1; i < sorok.Length; i++)
            {
                kutyaLista.Add(new kutyak(sorok[i]));
            }
            for (int i = 0; i < kutyaLista.Count; i++)
            {
                for (int k = 0; k < kutyaNevek.Count; k++)
                {
                    if (kutyaLista[i].nev_id==kutyaNevek[k].id)
                    {
                        kutyaLista[i].nev = kutyaNevek[k].nev;
                    }
                }
                for (int k = 0; k < kutyaFajta.Count; k++)
                {
                    if (kutyaLista[i].fajta_id == kutyaFajta[k].id)
                    {
                        kutyaLista[i].fajta = kutyaFajta[k].nev;
                    }
                }
            }
        }
        void f6() 
        {
            double eletkor=0;
            for (int i = 0; i < kutyaLista.Count; i++)
            {
                eletkor += kutyaLista[i].eletkor;
            }
            Console.WriteLine("6. feladat: Kutyák átlag életkora: {0:0.00}",Math.Round(eletkor/kutyaLista.Count,2));
        }
        void f7()
        {
            kutyak maximum = kutyaLista[0];
            for (int i = 0; i < kutyaLista.Count; i++)
            {
                if (kutyaLista[i].eletkor>maximum.eletkor)
                {
                    maximum = kutyaLista[i];
                }
            }

            Console.WriteLine("7. Feladat: Legidősebb kutya neve és fajtája: {0}, {1}",maximum.nev,maximum.fajta);
        }
    }
    class nevek
    {
        public string nev;
        public int id;
        public nevek(string sor)
        {
            string[] vag = sor.Split(";");

            nev = vag[1];
            id = Convert.ToInt32(vag[0]);
        }

    }
    class fajtak 
    {
        public string nev, eredeti;
        public int id;

        public fajtak(string sor)
        {
            string[] vag = sor.Split(";");
            id = Convert.ToInt32(vag[0]);
            nev = vag[1];
            eredeti = vag[2];
        }
    }
    class kutyak
    {
        public int id, fajta_id, nev_id, eletkor;
        public string orvosiVizsgalat;
        public string nev, fajta;
        public kutyak(string sor)
        {
            string[] vag = sor.Split(";");
            id = Convert.ToInt32(vag[0]);
            fajta_id = Convert.ToInt32(vag[1]);
            nev_id = Convert.ToInt32(vag[2]);
            eletkor = Convert.ToInt32(vag[3]);
            orvosiVizsgalat = vag[4];
        }
      
    }
}
