using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Program
    {
        private static bool Lekeres(elemek[] elem,string bekert,int i)
        {
            bool retur = false;
            for (int j = 0; j < i; j++)
            {
                if (elem[j].Vegyjel.ToLower() == bekert.ToLower())
                {
                    Kiir(elem[j]);
                    retur = true;
                }
            }
            return retur;
        }
        private static bool MegVizsgal(string bekert)
        {
            
            bool ellenor = true;
            if (bekert.Length != 2) { ellenor = false; } 

            string[] szam =  { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < szam.Length; i++)
            {
                if (bekert.Contains(szam[i]))
                { ellenor = false; }
            }
            return ellenor;
        }

        private static void Kiir(elemek elem)
        {
            Console.WriteLine("6.Feladat: Keresés\n \tAz elem vegyjele:" +
                                elem.Vegyjel + "\n\t Az elem neve: " + elem.Nev + "\n\t Rendszáma: " +
                                elem.Rendszama + "\n\t Felfedezés éve: " + elem.Ev + "\n\t Felfedezö neve:" +
                                elem.Felfedezö
                                );
        }

        private static void Statisztika(elemek[] elem,int i)
        {
            Dictionary<int, int> statiszt = new Dictionary<int, int>();

            for (int j = 0; j < i; j++)
            {
                if (statiszt.ContainsKey(elem[j].Ev))
                {
                    statiszt[elem[j].Ev]++;
                }
                else 
                {
                    statiszt.Add(elem[j].Ev, 1);
                }
            }
            foreach (var item in statiszt)
            {
                if (item.Value > 2||item.Value==0)
                {
                    Console.WriteLine(item.Key + " : " + item.Value + " db");
                }
            }
        }

        private static void Elemvizsgálat(elemek[] elem,int i)
        {
            int osszeg;
            int szam1;
            int szam2;
            int legnagyobb = 0 ;
            for (int j = 0; j < i - 1; j++)
            {
                if (!(elem[j].Ev==0 || elem[j + 1].Ev==0))
                {
                    szam1 = elem[j].Ev;
                    szam2 = elem[j + 1].Ev;
                    if (szam1 < szam2)
                    {
                        osszeg = szam2 - szam1;
                    }
                    else if (szam1 > szam2)
                    {
                        osszeg = szam1 - szam2;
                    }
                    else
                    {
                        osszeg = 0;
                    }
                    if (osszeg > legnagyobb) { legnagyobb = osszeg; }
                }
            }
            Console.WriteLine("7.Feladat: " + legnagyobb + " év volt a leghosszabb idöszak két elem felfedezése között.");

        }

        static void Main(string[] args)
        {
            elemek[] elem = new elemek[200];
            StreamReader olvas = new StreamReader("felfedezesek.csv",Encoding.Default);
            string sor = olvas.ReadLine();
            int okor = 0;
            int i = 0;
            while (!olvas.EndOfStream)
            {
                string k = olvas.ReadLine();
                elemek elemi = new elemek(k);
                elem[i] = elemi;
                if (elemi.Okor!=null)
                { okor++; }
                i++;
            }

            

                Console.WriteLine("3. Feladat: Elemek száma: " + i);
            Console.WriteLine("4. Feladat: Felfedezések száma az Ókorban:" + okor+"\n\n");

            Console.WriteLine("5.Feladat: Adjon meg egy Kémiai elem nevét:");
            string bekert = Console.ReadLine();
            if (MegVizsgal(bekert))
            {
                if (!Lekeres(elem, bekert, i)) 
                {
                    Console.WriteLine("6.Feladat: Nincs megjelenithetö elem");
                }
            }
            
            Elemvizsgálat(elem, i);

            Console.WriteLine("8. Feladat: ");
            Statisztika(elem, i);

            Console.ReadKey();
        }

        
    }
}
