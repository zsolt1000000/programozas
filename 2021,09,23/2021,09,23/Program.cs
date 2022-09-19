using System;
using System.Collections.Generic;

namespace _2021_09_23
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1)5.ös lottó névre hallgat
            2)1-90 szám nincs bent ismétlődés 
            3)ebből 5 szám jön ki
            4)2021-es év szimuláció minden szombaton van húzás
            5)Dátum - a számok
            6)kérjünk be 5 számot a felhasználotól ami nem ismétlődhet
            7)számoljuk ki hány találata volt
            */
            huzas a = new huzas();
            //   a.kiir();
            sorsolasok s = new sorsolasok();
            s.kiir();
            s.beker();

        }

        class sorsolasok
        {
            //hf be kérni 5 számot

            List<huzas> huzasok = new List<huzas>();
            int kezEv = 2021;
            int vegEv = 2021;
            public sorsolasok()
            {
                DateTime naptar = new DateTime(kezEv, 1, 1);
                // Console.WriteLine((int)naptar.DayOfWeek);
                while ((int)naptar.DayOfWeek != 6)
                {
                    naptar = naptar.AddDays(1);
                }
                //  Console.WriteLine(naptar.ToShortDateString());


                while (naptar.Year <= vegEv)
                {

                    huzasok.Add(new huzas());
                    huzasok[huzasok.Count - 1].datum = naptar;

                    //   Console.WriteLine(naptar.ToShortDateString());

                    naptar = naptar.AddDays(7);


                }


            }
            public int[] tippek = new int[5];
            public void beker()
            {
                for (int i = 1; i < tippek.Length; i++)
                {

                    Console.WriteLine("Kérekm az {0} számot 1-90 között", i);



                    try
                    {
                        tippek[i] = Convert.ToInt32(Console.ReadLine());
                        bool vanE = false;
                        for (int k = 0; k < i; k++)
                        {
                            
                            vanE |= tippek[k] == tippek[i];
                        }
                        if (vanE)
                        {
                            throw (new Exception("Dupla adat"));
                        }
                        if (tippek[i]>90 && )
                        {

                        }

                    }
                    catch (Exception)
                    {
                        i--;
                        Console.WriteLine("Hibás Adat");
                    }
                }
            }
            public void kiir()
            {

                foreach (var item in huzasok)
                {
                    Console.Write("{0}: ", item.datum.ToShortDateString());
                    for (int i = 0; i < item.szamok.Length; i++)
                    {
                        Console.Write(item.szamok[i]);

                        if (i != item.szamok.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();

                }


            }
        }
        class huzas
        {
           public int[] szamok = new int[5];
            Random rand = new Random();
            public DateTime datum = new DateTime();

            public huzas()
            {
                for (int i = 0; i < szamok.Length; i++)

                {

                    szamok[i] = rand.Next(1, 91);
                    bool vanE = false;
                    for (int k = 0; k < i; k++)
                    {
                        /*  if (szamok[k]==szamok[i])
                          {
                              vanE = true;
                          }*/
                        vanE |= szamok[k] == szamok[i];
                    }
                    if (vanE)
                    {
                        i--;
                    }


                }
            }
            public void kiir()
            {
                for (int i = 0; i < szamok.Length; i++)
                {
                    Console.WriteLine(szamok[i]);
                }
            }
        }

    }
}
