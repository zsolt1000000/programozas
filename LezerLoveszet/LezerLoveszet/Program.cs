using System;
using System.IO;
using System.Collections.Generic;

namespace LezerLoveszet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<JatekosLovese> lovesek = new List<JatekosLovese>();

            string[] sorok = File.ReadAllLines("lovesek.txt");
            JatekosLovese celtabla = new JatekosLovese("céltábla;" + sorok[0], 0,new double[2]);

            //celtabla.koordinata
            for (int i = 1; i < sorok.Length; i++)
            {
                lovesek.Add(new JatekosLovese(sorok[i], i,celtabla.koordinata));
            }
            Console.WriteLine("5. feladat: Lövések száma: {0} db",lovesek.Count);

            JatekosLovese nyertes = lovesek[0];
            for (int i = 1; i < lovesek.Count; i++)
            {
                if (lovesek[i].tavolsag()<nyertes.tavolsag())
                {
                    nyertes = lovesek[i];
                }                                              
            }
            Console.WriteLine("7. feladat: Legpontosabb lövés:");
            Console.WriteLine("\t"+nyertes);

            int db = 0;
            for (int i = 0; i < lovesek.Count; i++)
            {
                if (lovesek[i].pontszam==0)
                {
                    db++;
                }
            }
            Console.WriteLine("9. feladat: Nulla pontos lövések száma: {0} db", db);

            Dictionary<string, int> jatekosok = new Dictionary<string, int>();
            for (int i = 0; i < lovesek.Count; i++)
            {
                if (jatekosok.ContainsKey(lovesek[i].nev))
                {
                    jatekosok[lovesek[i].nev]++;       
                }
                else
                {
                    jatekosok.Add(lovesek[i].nev,-1);
                }
            }

            Console.WriteLine("10. feladat: játkosok száma: {0}",jatekosok.Count);
            Console.WriteLine("11. feladat: Lövések száma:");
            foreach (var item in jatekosok )
            {
                Console.WriteLine("\t"+"{0} - {1} db",item.Key,item.Value);
            }



            Dictionary<string,double> osszesPont = new Dictionary<string, double>();
            Console.WriteLine("12. feladat: Átlagpontszámok");
            foreach (var item in jatekosok)
            {
                osszesPont.Add(item.Key,0);
                for (int i = 0; i < lovesek.Count; i++)
                {
                    if (item.Key==lovesek[i].nev)
                    {
                        osszesPont[item.Key]+=lovesek[i].pontszam;
                    }
                }
                

            }
            foreach (var item in jatekosok)
            {
                Console.WriteLine("\t" + "{0} - {1}", item.Key, item.Value/jatekosok[item.Key]);
            }


        }
    }
    class JatekosLovese
    {
        public string nev;
        public double[] koordinata=new double[2];
        public int sorszam;
        double[] celtabla = new double[2];
        public double pontszam;
        
        public JatekosLovese(string sor, int loves,double[] cel)
        {
            string[] vag = sor.Split(";");
            nev = vag[0];
            koordinata[0] = Convert.ToDouble(vag[1]);
            koordinata[1] = Convert.ToDouble(vag[2]);

            sorszam = loves;
            celtabla = cel;

            pontszam = 10 - tavolsag();
            pontszam = Math.Round(pontszam, 2);

            if (pontszam<0)
            {
                pontszam = 0;
            }
            
           
            
        }
        public double tavolsag()
        {

            double dx = celtabla[0] - koordinata[0];
            double dy = celtabla[1] - koordinata[1];
            return Math.Sqrt(dx * dx + dy * dy);

        }
        public override string ToString()
        {
            return "" + sorszam + ".;" + nev + "; x=" + koordinata[0] + "; y=" + koordinata[1] +"; távolság:"+tavolsag();
        }

    }
}
