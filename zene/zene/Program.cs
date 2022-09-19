using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace zene
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
        List<adatok> radio = new List<adatok>();
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f4_2();
            f5();
            f6();
        }

        void f1()
        {
            string[] sorok = File.ReadAllLines("musor.txt");

            int ido1 = 0;
            int ido2 = 0;
            int ido3 = 0;
            for (int i = 1; i < sorok.Length; i++)
            {
                radio.Add(new adatok(sorok[i]));
                if (radio[radio.Count - 1].ado==1)
                {
                    radio[radio.Count - 1].kezdesiIdoMp=ido1;
                    ido1 += radio[radio.Count - 1].hosszMp();

                }
                if (radio[radio.Count - 1].ado == 2)
                {
                    radio[radio.Count - 1].kezdesiIdoMp = ido2;
                    ido2 += radio[radio.Count - 1].hosszMp();

                }
                if (radio[radio.Count - 1].ado == 3)
                {
                    radio[radio.Count - 1].kezdesiIdoMp = ido3;
                    ido3 += radio[radio.Count - 1].hosszMp();

                }
            }
        }
        void f2()
        {

            Dictionary<int, int> darab = new Dictionary<int, int>();
            darab.Add(1, 0);
            darab.Add(2, 0);
            darab.Add(3, 0);
            for (int i = 0; i < radio.Count; i++)
            {

                if (radio[i].ado==1)
                {
                    darab[1]++;
                }
                if (radio[i].ado ==2)
                {
                    darab[2]++;
                }
                if (radio[i].ado == 3)
                {
                    darab[3]++;
                }
                
            }
            Console.WriteLine("2. feladat");
            Console.WriteLine("A {0} adón {1} zene volt",1,darab[1]);
            Console.WriteLine("A {0} adón {1} zene volt",2,darab[2]);
            Console.WriteLine("A {0} adón {1} zene volt",3,darab[3]);

        }
        void f3()
        {
            int elso = -1;
            int utolso = -1;
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].ado==1)
                {
                    if (radio[i].eloado=="Eric Clapton")
                    {
                        if (elso==-1)
                        {
                            elso = radio[i].kezdesiIdoMp;
                        }
                     //   Console.WriteLine(radio[i].kezdesiIdoMp+ " "+ radio[i].cim);
                        utolso = radio[i].kezdesiIdoMp+radio[i].hosszMp();
                    }
                }
            }
            int ossz = utolso - elso;
            int ora = ossz /3600;
            int perc = (ossz % 3600) / 60;
            int mp = (ossz % 3600) %60;
            Console.WriteLine("3. Feladat");
            Console.WriteLine("Összesen {0} óra {1} perc {2} másodperc telt el a két szmá között",ora,perc,mp);
            

        }
        void f4()
        {
            int sorszam = -1;
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].zene=="Omega:Legenda")
                {
                    sorszam = i;
                    break;
                }
            }
            int s1 = -1;
            int s2 = -1;
            int s3 = -1;
            if (radio[sorszam].ado==1)
            {
                s1 = sorszam;
            }
            if (radio[sorszam].ado == 2)
            {
                s2 = sorszam;
            }
            if (radio[sorszam].ado == 3)
            {
                s3 = sorszam;
            }

            for (int i = sorszam-1 ; i >=0; i--)
            {
                if (s1>-1 && s2>-1 && s3>-1)
                {

                    break;
                }
                if (radio[i].ado==1)
                {
                    if (s1==-1)
                    {
                        s1 = i;
                    }
                }
                if (radio[i].ado == 2)
                {
                    if (s2 == -1)
                    {
                        s2 = i;
                    }
                }
                if (radio[i].ado == 3)
                {
                    if (s3 == -1)
                    {
                        s3 = i;
                    }
                }
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("Az Omega legenda a {0} adón szólt",radio[sorszam].ado);
            if (s1!=sorszam)
            {
                Console.WriteLine("A(z) {0} adón a {1} szólt.", 1, radio[s1].zene);

            }
            if (s2 != sorszam)
            {
                Console.WriteLine("A(z) {0} adón a {1} szólt.", 2, radio[s2].zene);

            }
            if (s3 != sorszam)
            {
                Console.WriteLine("A(z) {0} adón a {1} szólt.", 3, radio[s3].zene);

            }
        
        }
        void f4_2()
        {
            Dictionary<int, string> most = new Dictionary<int, string>();
            most.Add(1, "");
            most.Add(2, "");
            most.Add(3, "");
            int omegaDal = -1;
            for (int i = 0; i < radio.Count; i++)
            {
                most[radio[i].ado] = radio[i].zene;
                if (radio[i].zene=="Omega:Legenda")
                {
                    omegaDal = radio[i].ado;
                    break;
                }
            }
            Console.WriteLine("4. Feladat_2");
            Console.WriteLine("A {0} adón szólt az Omega",omegaDal);
            foreach (var item in most)
            {
                if (item.Value!="Omega:Legenda")
                {
                    Console.WriteLine("A(z) {0} adón a(z) {1} zene szólt",item.Key,item.Value);

                }
            }
        }
        void f5()
        {
            Console.WriteLine("5. feladat");
            Console.Write("Kérem a betüket: ");
            string be = Console.ReadLine();
            StreamWriter ir = new StreamWriter("keres.txt");
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].szovegRresz(be))
                {
                    Console.WriteLine(radio[i].zene);
                    ir.WriteLine(radio[i].zene);
                }
            }

            ir.Close();
        }
        void f6() 
        {
            int seged = 0;
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].ado==1)
                {
                    if (seged%3600==0)
                    {
                        seged += 3 * 60;
                    }
                    else
                    {
                        if (seged%3600+radio[i].hosszMp()>3600)
                        {
                            seged += 3600 - seged % 3600;
                            seged += 3 * 60;

                        }
                    }
                    seged += radio[i].hosszMp();
                }
            }
            int ora = seged / 3600;
            int perc = (seged % 3600) / 60;
            int mp = (seged % 3600) % 60;
            Console.WriteLine("6.Feladat");
            Console.WriteLine(seged);
            Console.WriteLine(ora,perc,mp);
        }
    }


    class adatok
    {

        public int ado, perc, mp;
        public string zene;
        public string eloado, cim;
        public int kezdesiIdoMp;
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ", 4);
            ado = Convert.ToInt32(vag[0]);
            perc = Convert.ToInt32(vag[1]);
            mp = Convert.ToInt32(vag[2]);
            zene = vag[3];
            eloado = zene.Split(":")[0];
            cim = zene.Split(":")[1];
        
        
        }
        public int hosszMp()
        {
            return perc * 60 + mp;
        }
    
        public bool szovegRresz(string resz)
        {
            string zene2 = zene.ToLower();
            zene2 = zene2.Replace(":", "");
            zene2 = zene2.Replace(" ", "");
            resz = resz.ToLower();

            return zene2.IndexOf(resz) > -1;
        }

    }
}
/*
    0.  
    1sort ki kell hagyni 
    1 sorban  van 4 adat
    int int int string
    Lehet lesz áltváltás
    sorba vannak
    1.  
    File beolvasás 
    adatok class
    Lista
    Ügyelni kell hogy szóköz lehet a szám címében 
    2.
    Dictionary statisztika
    3.
    meg keresni az elsőt és utolsót
    el tárolni 
    végéből ki vonni a kezdetett
    hozzá adni az időt be töltéskor (Mikor kezdödött a lejátszása)
    4.
    meg keressük az Omegát
    Visszafelé el indulva meg keresve a többit 
    Az első találat a másik két adóra 
    5. 
    Szöveg be kérése felhasználótól    
    szóközt kettöspontot ki törlése 
    Kis is nagybetű --> átalakítás kis betűsre
    Index of ha nem -1 akkor talált
    FILEBA írsás
    Tanács: Kerüljön be a vizsgálat az adatok classba
    6.
    
    
    
    
 
 */