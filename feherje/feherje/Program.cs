using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace feherje
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
        List<aminosav> aminosavak = new List<aminosav>();
        Dictionary<string, aminosav> aminosavak2 = new Dictionary<string,aminosav>();
        public feladat()
        {
            f1();
            f2();
            f3();
        }
        void f1()
        {
            string[] sorok = File.ReadAllLines("aminosav.txt");
            for (int i = 0; i < sorok.Length; i+=7)
            {
                string[] temp = {sorok[i],  sorok[i+1],
                                            sorok[i+ 2 ] ,
                                            sorok[i+ 3]  ,
                                            sorok[i+ 4]  ,
                                            sorok[i+ 5]  ,
                                            sorok[i+ 6] };
                aminosavak.Add(new aminosav(temp));
                aminosavak2.Add(sorok[i+1], new aminosav(temp));
            }
        }
        void f2()
        {

        }
        void f3()
        {
            aminosavak=aminosavak.OrderBy(e => e.molekulaTomeg()).ToList();

            StreamWriter ir = new StreamWriter("eredmeny.txt");
            for (int i = 0; i < aminosavak.Count; i++)
            {
                Console.WriteLine("{0} {1}",aminosavak[i].rövid,aminosavak[i].molekulaTomeg());
                ir.WriteLine("{0} {1}",aminosavak[i].rövid,aminosavak[i].molekulaTomeg());
                
            }
            ir.Close();
        }
        List<aminosav> bsa = new List<aminosav>();
        string bsaString = "";
        void f4()
        {
            Dictionary<string, int> stat = new Dictionary<string, int>();

            string[] sorok= File.ReadAllLines("bsa.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                bsa.Add(aminosavak2[sorok[i]]);
                bsaString += sorok[i];
            }
            stat.Add("C",0);
            stat.Add("H",0);
            stat.Add("O",0);
            stat.Add("N",0);
            stat.Add("S",0);
            
            for (int i = 0; i < bsa.Count; i++)
            {
                stat["C"] += bsa[i].C;
                stat["H"] +=bsa[i].H;
                stat["O"] +=bsa[i].O;
                stat["N"] +=bsa[i].N;
                stat["S"] +=bsa[i].S;

            }

            StreamWriter ir = new StreamWriter("eredmeny.txt", true);
            Console.WriteLine("C {0} H{1} O{2} N{3} S{4}",stat["C"], stat["C"], stat["C"], stat["C"], stat["S"]);
            ir.Close();
        }
    }
    class aminosav
    {
        public string rövid, betujel;
        public int C, H, O, N, S;
        public aminosav(string[] args)
        {
            rövid = args[0];
            betujel= args[1];
       //     Console.WriteLine(args[2]);
            C= Convert.ToInt32(args[2]);
            H= Convert.ToInt32(args[3]);
            O= Convert.ToInt32(args[4]);
            N= Convert.ToInt32(args[5]);
            S= Convert.ToInt32(args[6]);

        }

        public int molekulaTomeg()
        {
            return C * 12 + H + O * 16 + N * 14 + S * 32;
        }
    }

    /*
    1. Feladat:
    -File be olvasás 7 soronként
    2. Feladat:
    -Be helyettesités
    3. Feladat:
    -Use linq
    -Order by --> Lista kell újra (to list)
    -File ki íratás (képernyő + txt)
    4. Feladat:
    -Dictionarybe kell be olvasni az első fájlt 
    -Összegzés (5db)
    - i-1
    5. Feladat:
    -BSA egy stringbe be olvasni --> slpitelni "YWF"-nél és a darabokból a leghosszabbat meg keresni (maxmimum keresés)
    Első és utolsó amino savának sorszáma kell (index of(maximum leghosszabb darab))
    6. Feladat: 
    -Index of
    Ra vagy Rv keresése

    */
}
