using System;

namespace Házi
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Kérek egy nevet");
             string nev = Console.ReadLine();
             Console.WriteLine("Szia {0}", nev);
             for (int i = nev.Length -1; i >=0; i--)
             {
                 Console.Write(nev[i]);
             }*/
            //1. Feladat Rendszám generálása
            //2. Feladat legyen függvénnyel meg oldva
            //3. Feladat pár szabályt tarstunk be legye a magyar szabályoknak megfelelő

            for (int i = 0; i < 3; i++)
            {
                Random rnd = new Random();
                char randomChar = (char)rnd.Next('a', 'z');
                Console.Write( randomChar);
            }
            Console.Write("-");
            for (int i = 0; i < 3; i++)
            {
                Random rnds = new Random();
                char randomChars = (char)rnds.Next('0', '9');
                Console.Write(randomChars);
            }

            Console.WriteLine(" ");

            Console.WriteLine(rendszam());
        }
        static string rendszam()
        {
            string rsz = "";
            String[] betuk = { "W", "E", "R", "T", "Z", "U", "I", "O", "P", "A", };
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                                
                
                int index = rand.Next(betuk.Length);
                if (i == 0)
                {

                }
                rsz +=((betuk[index]));
            }
            String[] szamok = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            rsz += ("-");
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(szamok.Length);
                rsz += ((szamok[index]));
            }
            return rsz;
        }
    }
}
