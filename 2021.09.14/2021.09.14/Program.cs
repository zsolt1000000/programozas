using System;
using System.Collections.Generic;

namespace _2021._09._14
{
    class Program
    {
        static void Main(string[] args)
        {
            battle csata = new battle(5, 5);
            
           //sata.team(false);
           
            csata.fight();
          
        }
    }
    class battle
    {
        List<hero> heroes = new List<hero>();
        List<hero> villains = new List<hero>();
        public battle(int heroNumber, int villainNumber)
        {
            for (int i = 0; i < heroNumber; i++)
            {
                heroes.Add(new hero(true));
            }

            for (int i = 0; i < villainNumber; i++)
            {
                villains.Add(new hero(false));
            }
        }

        public void team(bool isGood)
        {
            List<hero> temp = new List<hero>();
            if (isGood)
            {
                temp = heroes;
            }
            else
            {
                temp = villains;
            }
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
        }
        Random rand = new Random();
        //indul a csata
        public void fight()
        {
            bool aliveHero = false;
            bool alivevillain = false;
            do
            {


                //hősök
                aliveHero = false;
                foreach (var item in heroes)
                {
                    aliveHero |= item.hp > 0;
                   
                }

                int heroIndex = -1;
                if (aliveHero)
                {
                    do
                    {
                        heroIndex = rand.Next(heroes.Count);
                    } while (heroes[heroIndex].hp <= 0);
                }

                //gonoszak
                alivevillain = false;
                foreach (var item in villains)
                {
                    alivevillain |= item.hp > 0;
                    
                }
                
                int villainIndex = -1;
                if (alivevillain)
                {
                    do
                    {
                        villainIndex = rand.Next(villains.Count);
                    } while (villains[villainIndex].hp <= 0);
                }
                if (alivevillain && aliveHero)
                {
                    Console.WriteLine(heroes[heroIndex]);
                    Console.WriteLine(villains[villainIndex]);

                    heroes[heroIndex].hp -= villains[villainIndex].power;
                    villains[villainIndex].hp -= heroes[heroIndex].power;

                }
                
            } 
            while (aliveHero && alivevillain);
            if (aliveHero)
            {
                Console.WriteLine("Hősök nyertek");
            }
            else if (alivevillain)
            {
                Console.WriteLine("Gonoszak nyertek");
            }
            else
            {
                Console.WriteLine("Döntetlen");    
            }
           

            

        }
    }
    class hero
    {
        public string name;
        public int hp;
        public int power;
        public bool isGood;

        public hero(bool isHero)
        {
            String[] knev = {"Sanyi","Zsolt","Kevin","Petya","Lajos","Steve","Haky","Lali", "Garfield","Thor","Hulk","Machinist"};
            String[] tulajdunsag = {"Sötét","Dark","Red","Hosszú","old","High","Boxos","Lakatos","Botox","Copperfinder","Sarjabb","Erős","Kicsi"};

            Random rand = new Random();
            int i = rand.Next(tulajdunsag.Length);
            name = tulajdunsag[i];
            name += " ";
            i = rand.Next(knev.Length);
            name += knev[i];

            // életerő
            hp = rand.Next(1, 100);

            //erő
            power = rand.Next(10, 50);

            //hűs fajtája
            //  isGood = rand.Next(2)== 0;
            isGood = isHero;
            
        }


        public override string ToString()
        {
            return name + " - hp:" + hp + " - power:" + power+" - " + (isGood ? "Hero" : "Villain");
        }


    }
}
