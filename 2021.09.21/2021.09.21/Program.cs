using System;

namespace _2021._09._21
{
    class Program
    {
        static void Main(string[] args)
        {

            bool[] borton = new bool [400];
            for (int i = 0; i < borton.Length; i++)
            {
                borton[i] = false;
            }
            //szolgák
            for (int szolga = 0; szolga < 400; szolga++)
            {
                for (int ajtoSzam = szolga; ajtoSzam < 400; ajtoSzam+=szolga+1)
                {
                    if (borton[ajtoSzam]==false)
                    {
                        borton[ajtoSzam] = true;
                    }
                    else 
                    {
                        borton[ajtoSzam] = false;
                    }
                 //   borton[ajtoSzam] = !borton[ajtoSzam];
                }
                Console.Clear();
                rajz(borton);

            }
            for (int i = 0; i < borton.Length; i++)
            {
                if (borton[i])
                {
                    Console.WriteLine("{0}. ajtó van nyitva",i+1);
                }

            }
          
            
            
        }
        static void rajz(bool[] borton)
        {
            for (int i = 0; i < borton.Length; i++)
            {


                if (borton[i])
                {
                    Console.Write("_");
                }
                else
                {
                    Console.Write("@");
                }
                if (i%40==39)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
