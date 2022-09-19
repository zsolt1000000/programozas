using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace txt2srt
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
        List<IdozitettFelirat> szovegeg = new List<IdozitettFelirat>();

        public feladat()
        {
            f4();
            f5();
            f6();
            f8();
            f9();
        }
        void f4()
        {
            string[] sorok = File.ReadAllLines("feliratok.txt");
            for (int i = 0; i < sorok.Length; i+=2)
            {
                szovegeg.Add(new IdozitettFelirat(sorok[i], sorok[i + 1]));
            }
        }
        void f5()
        {
            Console.WriteLine("5. feladat - Feliratok száma: {0}", szovegeg.Count);
            
        }
        void f6()
        {
            int maxIndex = 0;
            for (int i = 0; i < szovegeg.Count; i++)
            {
                if (szovegeg[i].szavakSzama()>szovegeg[maxIndex].szavakSzama())
                {
                    maxIndex = i;
                }
            }
            Console.WriteLine("7. feladat - A legtöbb szóból álló felirat: \n {0}",szovegeg[maxIndex].felirat);
        }
        void f8()
        {

        }
        void f9()
        {
            
                StreamWriter ir = new StreamWriter("felirat.src");

                for (int i = 0; i < szovegeg.Count; i++)
                {
                    ir.WriteLine(i + 1);
                    ir.WriteLine(szovegeg[i].StrtIdozitets());
                    ir.WriteLine(szovegeg[i].felirat);
                    ir.WriteLine();
                }




                ir.Close();
            
        }
    }
class IdozitettFelirat
    {
        public string felirat, idozites;
        public IdozitettFelirat(string sor, string sor2)
        {
            idozites = sor;
            felirat = sor2;
        }
        public int szavakSzama()
        {
            return felirat.Split(" ").Length;
        }


        public string StrtIdozitets()
        {
            string[] vag = idozites.Split(" - ");
            return idoKonvert(vag[0]+ " -->"+idoKonvert(vag[1]));
        }

        string idoKonvert(string regi)
        {
            //65:02
            string[] vag = regi.Split(":");
            int perc = Convert.ToInt32(vag[0]);
            int ora = perc / 60;
            string uj = "";
            if (ora <10)
            {
                uj += "0";
            }
            uj += ora;
            uj += ":";
            if (perc%60<10)
            {
                uj += 0;
            }
            uj += perc%60;
            uj += ":";
            uj += vag[1];
            return uj;
            //return (Convert.ToInt32(vag[]/60<10?"0":"")

        }
    }
}
/*
 
 7. feladat 
Maximum keresés 
Felírat kell ki íratni + minta 
maximum index

8. feladat


 
*/

