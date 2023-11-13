using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sachy_finalni
{
    public class Bunka
    {
        //Potřebné vnitřní proměnné pro práci, které drží každé jedno políčko v šachovnici

        public int CisloRadky { get; set; }
        public int CisloSLoupce { get; set; }
        public bool Zabrano { get; set; }
        public bool Dalsitah { get; set; }
        public string Typ { get; set; } 

        public Bunka(int x, int y, string typ)
        {
            CisloRadky = x;
            CisloSLoupce = y;
            Typ = typ;
        }
    }
}
