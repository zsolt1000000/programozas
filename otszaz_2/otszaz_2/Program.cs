using System;
using System.IO;
using System.Collections.Generic;

namespace otszaz_2
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
        List<string> szatyor = new List<string>();
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
            ertek();
            f6();
            f7();
            f8();
        }
        void f1()
        {

            string[] sor = File.ReadAllLines("penztar.txt");
            for (int i = 0; i < sor.Length; i++)
            {
                szatyor.Add (sor[i]);
            }
        }
        void f2()
        {
            int seged = 0;
            for (int i = 0; i < szatyor.Count; i++)
            {

                if (szatyor[i]=="F")
                {
                    seged++;
                }
            }
            Console.WriteLine("2. feladat");
            Console.WriteLine("A fizetések száma: {0}",seged);
        }
        void f3()
        {
            int seged = 0;
            Console.WriteLine("3. feladat");
            for (int i = 0; i < szatyor.Count; i++)
            {
                if (szatyor[i]=="F")
                {
                    seged = i;
                    break;
                }
            }
            Console.WriteLine("Az első vásárló {0} darab árucikket vásárolt",seged);
        }
        int sorszam = 0;
        string arucikk = "";
        int db = 0;
        void f4()
        {
            Console.WriteLine("4. feladat");
            
            Console.Write("Adja meg a vásárlás sorszámát! ");
            sorszam = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Adja meg egy árucikk nevét! ");
            arucikk = Console.ReadLine();
            
            Console.Write("Adja meg a vásárolt darabszámot! ");
            db = Convert.ToInt32(Console.ReadLine());
        }
        void f5()
        {
            Console.WriteLine("5. feladat");
            int elso = 0;
            int utolso = 0;
            int osszes = 0;
            for (int i = 0; i < szatyor.Count; i++)
            {

                utolso = szatyor.LastIndexOf(arucikk);

                elso = szatyor.IndexOf(arucikk);
                
               

                
               
                    if (szatyor[i]==arucikk)
                    {
                        osszes++;
                    }
                
            
              
            }
            Console.WriteLine("Az első vásárlás sorszáma: {0}",elso);
            Console.WriteLine("Az utolsó vásárlás sorszáma: {0}",utolso);
            Console.WriteLine("{0} vásárlás során vettek belőle",osszes);
        }
        void f6()
        {
            Console.WriteLine("6. feladat");
            Console.WriteLine("{0} darab vételkor fizetendő: {1}",db,ertek()) ;
        }
        void f7()
        {
            Console.WriteLine("7. feladat");
            for (int i = 0; i < szatyor.Count; i++)
            {

            }
        }
        void f8()
        {
            StreamWriter ir = new StreamWriter("osszeg.txt");
            int elso = 0;
            int utolso = 0;
            int seged = 1;
            //ir.WriteLine("maci");
            for (int i = 0; i < szatyor.Count; i++)
            {
                if (szatyor[i]=="F")
                {
                    elso = i;
                }


                if (szatyor[i]=="F")
                {
                    ir.WriteLine("{0}: {1}",seged++,ertek());
                }
            }
            ir.Close();
        }
        int ertek ()
        {

            if (db==1)
            {
                return db * 500;

            }
            else if (db==2)
            {
                return 500 + 450;
            }
            else
            {
                return 500 + 450 + ((db - 2) * 400);
            }
        }
    
    
    }
    class adatok
    {
        public adatok()
        {

        }
    }


}
