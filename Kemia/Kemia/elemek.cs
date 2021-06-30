using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class elemek
    {
        private int ev;
        private string okor;
        private string nev;
        private string vegyjel;
        private int Rendszam;
        private string felfedezö;

        public int Ev { get => ev; set => ev = value; }
        public string Okor { get => okor; set => okor = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszama { get => Rendszam; set => Rendszam = value; }
        public string Felfedezö { get => felfedezö; set => felfedezö = value; }


        public elemek(string sor)
        {
            string[] elemsor = sor.Split(';');
            if (elemsor[0].Contains( "kor"))
            {
                Ev = 0;
                Okor = elemsor[0];
            }
            else 
            {
                ev = int.Parse(elemsor[0]);
            }
            Nev = elemsor[1];
            Vegyjel = elemsor[2];
            Rendszama = int.Parse(elemsor[3]);
            Felfedezö = elemsor[4];
        }
    
    }
}
