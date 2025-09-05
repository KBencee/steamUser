using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace streamUserWpf
{
    internal class Jatek
    {
        public Jatek(string nev, int id, int ertekeles, int ertekelokSzama, DateOnly kiadas)
        {
            Nev = nev;
            Id = id;
            Ertekeles = ertekeles;
            ErtekelokSzama = ertekelokSzama;
            Kiadas = kiadas;
        }

        public string Nev { get; set; }
        public int Id { get; set; }
        public int Ertekeles { get; set; }
        public int ErtekelokSzama { get; set; }
        public DateOnly Kiadas { get; set; }
    }
}
