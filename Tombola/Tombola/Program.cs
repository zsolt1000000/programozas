using System;
using System.IO;

namespace Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            mix a = new mix();
            adatok adat = new adatok();




        }
    }
    class adatok{
    
    public adatok()
        {
           
           
        }
    }
    class mix
    {
        public mix()
        {
            int[] szamok = new int[100];
            Random rand = new Random();
            String[] szinek = { "zöld", "kék", "piros", "sárga", "lila", "barna", "fekete", "szürke" };
            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rand.Next(1, 100);
                
                Console.WriteLine(szinek[i] + " " + szamok[i]);

            }
     
          
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
