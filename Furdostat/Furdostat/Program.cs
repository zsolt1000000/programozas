using System;
using System.Collections.Generic;
using System.IO;

namespace Furdostat
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

        List<adatok> stat = new List<adatok>();
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
            Console.WriteLine("1. Feladat");

            string[] sorok = File.ReadAllLines("furdoadat.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                stat.Add(new adatok(sorok[i]));
            }
        }
        void f2()
        {
            Console.WriteLine("2. Feladat");
            
                Console.WriteLine("Az első vendég {0}:{1}:{2}-kor lépett ki az öltözőből.",stat[0].ora,stat[0].perc,stat[0].masodperc);

            int utolsoIndex = 0;
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i].irany==1)
                {
                    utolsoIndex = i;
                }

            }
            Console.WriteLine("Az utolsó vendég {0}:{1}:{2}-kor lépett ki az öltözőből.", stat[utolsoIndex].ora, stat[utolsoIndex].perc, stat[utolsoIndex].masodperc);

        }
        void f3() 
        {
            Dictionary<int, int> stat = new Dictionary<int, int>();
            for (int i = 0; i < stat.Count; i++)
            {
                if (!stat.ContainsKey(this.stat[i].vendeg))
                {
                    stat.Add(this.stat[i].vendeg, 1);
                }
                else
                {
                    stat[this.stat[i].vendeg]++;
                }
                int db = 0;
                foreach (var item in stat)
                {
                    if (item.Value==4)
                    {
                        db++;
                    }
                }
            }
        }
        void f4()
        {
            Console.WriteLine("4. Feladat: ");
            int startIndex = 0;
            int maxIdo = 0;
            int maxVendeg = 0;
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i].reszleg==0 && stat[i].irany==1)
                {
                    startIndex = i;
                }
                if (stat[i].reszleg == 0 && stat[i].irany == 0)
                {
                    //    startIndex = i;
                    if (stat[i].mp() - stat[startIndex].mp()>maxIdo)
                    {
                        maxIdo = stat[i].mp() - stat[startIndex].mp();
                        maxVendeg = stat[i].vendeg;
                    }
                }
            }

            Console.WriteLine("A legtöbb idpt eltöltő vendég: ");
            Console.WriteLine("{0}. vendég {1}:{2}:{3}",maxVendeg,maxIdo/3600,(maxIdo%3600)/60,maxIdo%60);
        }
        void f5()
        {
            Dictionary<int, int> statisztika = new Dictionary<int, int>();
            statisztika.Add(1, 0);
            statisztika.Add(2, 0);
            statisztika.Add(3, 0);
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i].reszleg == 0 &&stat[i].irany==1)
                {
                    if (stat[i].ora<9)
                    {
                        statisztika[1]++;
                    }
                    else if (stat[i].ora<16)
                    {
                        statisztika[2]++;
                    }
                    else
                    {
                        statisztika[3]++;
                    }
                }
            }
            Console.WriteLine("5. Feladat:");
            Console.WriteLine("6 - 9 óra között {0} vendég",statisztika[1]);
            Console.WriteLine("9 - 16 óra között {0} vendég", statisztika[2]);
            Console.WriteLine("16 - 20 óra között {0} vendég", statisztika[3]);
        }
        void f6()
        {

            Console.WriteLine("6. Feladat");
            StreamWriter ir = new StreamWriter("szauna.txt");

            Dictionary<int, int> statisztika = new Dictionary<int, int>();

            
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i].reszleg == 2 && stat[i].irany == 0)
                {
                    int ido = stat[i + 1].mp() - stat[i].mp();
                    if (!statisztika.ContainsKey(stat[i].vendeg))
                    {
                        statisztika.Add(stat[i].vendeg,ido);
                    }
                    else
                    {
                        statisztika[stat[i].vendeg] += ido;
                    }
                }

            }
            foreach (var item in statisztika)
            {
                ir.WriteLine("{0} {1}", item.Key,TimeSpan.FromSeconds(item.Value));
            }
            ir.Close();
        }
        void f7()
        {

            Dictionary<int, int> stat = new Dictionary<int, int>();
            stat.Add(0, 0);
            stat.Add(1, 0);
            stat.Add(2, 0);
            stat.Add(3, 0);
            stat.Add(4, 0);

            bool[] helyseg = { false, false, false, false, false }; 

            for (int i = 0; i < this.stat.Count; i++)
            {
                if (this.stat[i].irany == 1)
                {
                    if (this.stat[i].reszleg==0)
                    {
                        helyseg = new bool[]{ false, false, false, false, false };
                    }
                    if (helyseg[this.stat[i].reszleg])
                    {

                    }
                    else
                    {
                        stat[this.stat[i].reszleg]++;
                        helyseg[this.stat[i].reszleg] = true;
                    }
                    
                }
            }

            Console.WriteLine("7. Feladat");
            Console.WriteLine("Uszoda: {0}",stat[1]);
            Console.WriteLine("Szaunák: {0}",stat[2]);
            Console.WriteLine("Gyógyvízes medencék: {0}",stat
                [3]);
            Console.WriteLine("Strand: {0}",stat[4]);
        }
    }
    class adatok
    {
        public int vendeg, reszleg, irany, ora, perc, masodperc;
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            vendeg = Convert.ToInt32(vag[0]);
            reszleg = Convert.ToInt32(vag[1]);
            irany = Convert.ToInt32(vag[2]);
            ora = Convert.ToInt32(vag[3]);
            perc= Convert.ToInt32(vag[4]);
            masodperc= Convert.ToInt32(vag[5]);
//            vendeg = Convert.ToInt32(vag[6]);
                
        }
        public int mp()
        {

            return ora *3600 + perc * 60;
            //return 5;
        }
    }
}
/*
 


 1. Feladat:

File be olvasás 
int
int 
bool / int
int - int -int (idő)
Valószínőleg

Lehet variálni a lista szerkezetével

 2. Feladat:

Mnimum és maximum 
első és utolsó ember meg keresése 

 3. Feladat:

Meg kell számolni hányszór szerepel a megfelelő ember 
statisztika
meg kell számolni hánya a 3 értékő

 4. Feladat:

Kimenésből ki vonjuk a bemenést
Fel írjuk az ember azonosítóját 
    
Az első és utolsó 0 meg keresése egy embernél 
utolsóból - első idő (ebből maximum keresés)


 5. Feladat:


Az öltözésből való kilépést kell meg keresni és megszámolni az óra csoportot (3 csoport van)

 6. Feladat:

statisztika a szauna terem használatáról 
Kilépés - belépés összege 

 7. Feladat:



 
 
 
 
 */