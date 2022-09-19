using System;
using System.IO;
using System.Collections.Generic;
namespace _2022._09._07_első_óra_13_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             első projekt

                kérjünk be neveket és írjuk ki egy szöveges fájlba (osztály név sor)
                az osztály név sor amit létrehoztunk töltsök be a fájlból tegyük fel van 20 tétel ki kell sorsolni hogy a diákok közül mindenki kapjun legalább egyett minden feladatot ki kell osztanni
             */

            string a = " ";
            /*   StreamWriter ir = new StreamWriter("nevek.txt");


               do
               {
                   Console.WriteLine("Kérem az osztály neveit szóközzel el választva");
                   a = Console.ReadLine();
                   //  Console.WriteLine(a);
                   ir.WriteLine(a);
               } while (a!="");



               ir.Close();*/


            int[,] szamok =new int[1,21];
            for (int i = 1; i < szamok.Length; i++)
            {
               // Console.WriteLine(i);
            }
            List<string> nevek = new List<string>();
            StreamReader rs = new StreamReader("nevek.txt");
          //  StreamReader rs = new StreamReader(fs);

            string s = rs.ReadLine();
            string[] sorok = File.ReadAllLines("nevek.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                nevek.Add(sorok[i]);
            }

            for (int i = 1; i < szamok.Length; i++)
            {
                Console.WriteLine(i+" "+ );
            }

            Random rand = new Random();
            
        }


    }

    
}
