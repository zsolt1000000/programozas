using System;
using System.Collections.Generic;
using System.IO;

namespace tombula_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            tombolaJegy b = new tombolaJegy();
            nyeres c = new nyeres("lakóautó");
            sorsolas a = new sorsolas();

            Console.WriteLine(a);
            //Console.WriteLine(c);
            // Console.WriteLine(b);

            StreamWriter ir = new StreamWriter("eredmenyek.txt");

            ir.WriteLine(a);
            ir.Close();
        }
    }

    class tombolaJegy 
    {
        public int szam;
        public string szin;
        Random rand = new Random();
        public tombolaJegy()
        {
            szam = rand.Next(1, 101);
            string[] szinek = { "kék", "zöld", "piros", "sárga", "fekete", "szürke", "lime", "magenta" };

            int szinIndex = rand.Next(szinek.Length);
            szin = szinek[szinIndex];
        }

        public bool azonos (tombolaJegy masik)
        {
            return szin == masik.szin && szam == masik.szam;
        }
        public override string ToString()
        {
            return szin +" - "+ szam;
        }

    }
    class nyeres
    {
        public string nyeremeny;
        public tombolaJegy jegy;
        public nyeres(string nyeremeny)
        {
            this.nyeremeny = nyeremeny;
            jegy = new tombolaJegy();
        }
        public override string ToString()
        {
            return nyeremeny+" - " + jegy.ToString();

        }
    }
    class sorsolas
    {
        List<nyeres> nyertesek = new List<nyeres>();
        public sorsolas()
        {
            string[] sorok = File.ReadAllLines("ajandek.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                nyeres temp = new nyeres(sorok[i]);
                bool van = false;
                for (int k = 0; k < nyertesek.Count; k++)
                {
                    if (nyertesek[k].jegy.azonos(temp.jegy))
                    {
                        van = true;
                        break;
                    }
                    //nyertesek.Add();
                }
                if (!van)
                {
                    nyertesek.Add(temp);

                }
                else
                {
                    i--; //utolsó kör sztornó
                }



            }
        }
        public override string ToString()
        {
            string vissza = "";
            for (int i = 0; i < nyertesek.Count; i++)
            {
                vissza += nyertesek[i] + "\n";
            }
            return vissza;

        }
    }
}
