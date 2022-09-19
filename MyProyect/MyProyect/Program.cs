using System;

namespace MyProyect
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. Karakter összee rakás
            2. erő hozzá adás 
            3. Harc
            4. páncél hozzá adás
            5. csata elején exrta sebzés vagy páncél
            */
            hosok a = new hosok();
            
        }

    }


    class hosok
    {
        public  hosok()
        {
            nevek();
        }
        Random rand = new Random();
        string[] nev1= {"Hegdűs","Nagy","Szép","Szörős","Kicsi","James", "Erős","Király","Herceg","Lovag"};
        string[] nev2= { "Matyi", "Jolly", "Suzy", "Anett", "Bond", "Medve", "Sándor", "O'nill", "Samanta", "Lajcsi", "Elemér" };
        string[] egesznev= { "", "", "", "", "", "", "", "", "", "" };
        public void nevek()
        {
            for (int i = 0; i < 10; i++)
            {
                rand = new Random(nev1.Length + nev2.Length);
                rand = egesznev[nev1[i]+nev2[i]];
                Console.WriteLine(egesznev);
            }
        }

    }
}
