using System;
using System.IO;

namespace _2022._02._14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

kérjünk be 2db számot
legyen 50 és 100 közötti  (egész szám, 99 a legnagyobb )
kell egy ekkora tömb (2 dimenziós) fel kell tölteni véletlen számokkal 0-100-ig (99 a legnagyobb)
írassuk ki fájlba a tömböt 
keresd meg a leggyakoribb számot melyik sorban van
*/
            int szam1 = -1;

            while (szam1<50||szam1>100)
            {
                Console.Write("Kérek egy számot (50 és 100 közötti): ");
                szam1 = Convert.ToInt32(Console.ReadLine());
            }

            int szam2 = -1;

            while (szam2 < 50 || szam2 > 100)
            {
                Console.Write("Kérek még egy számot (50 és 100 közötti): ");
                szam2 = Convert.ToInt32(Console.ReadLine());
            }
            Random rand = new Random();
           

            int[,] randomok = new int[szam1, szam2];
            for (int i = 0; i < randomok.GetLength(0); i++)
            {
                for (int k = 0; k < randomok.GetLength(1) ; k++)
                {
                    randomok[i, k] = rand.Next(0, 100);
                }

            }
            StreamWriter ir = new StreamWriter("szamok.txt");

            for (int i = 0; i < randomok.GetLength(0); i++)
            {
                for (int k = 0; k < randomok.GetLength(1); k++)
                {
                    ir.Write(randomok[i,k]);
                    ir.Write(";");
                }
                ir.WriteLine();
            }

            ir.Close();

        }
    }
}
