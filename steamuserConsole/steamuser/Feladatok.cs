using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace steamuser
{
    internal class Feladatok
    {
        public List<Jatek> jatekLista;

        public Feladatok(string filePath)
        {
            jatekLista = new List<Jatek>();
            foreach (var item in File.ReadAllLines(filePath, Encoding.UTF8).Skip(1))
            {
                try
                {
                    string[] parts = item.Split(';');
                    string nev = parts[0];
                    int id = Convert.ToInt32(parts[1]);
                    int ertekeles = Convert.ToInt32(parts[2]);
                    int ertekelokSzama = Convert.ToInt32(parts[3]);
                    DateOnly kiadas = DateOnly.Parse(parts[4]);
                    Jatek ujJatek = new(nev, id, ertekeles, ertekelokSzama, kiadas);
                    jatekLista.Add(ujJatek);
                }
                catch
                {
                    continue;
                }
            }
        }

        public void Feladat2()
        {
            int jatekszam = jatekLista.Count;
            Console.WriteLine($"{jatekszam} játék található a fájlban");
        }

        public void Feladat3()
        {
            Console.Write("Kezdőév: ");
            int kezdo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Záróév: ");
            int zaro = Convert.ToInt32(Console.ReadLine());
            var szurtJatekok = jatekLista
                .Where(x => x.Kiadas.Year >= kezdo && x.Kiadas.Year <= zaro)
                .ToList();

            string outputFile = $"{kezdo}-{zaro}.csv";
            var lines = new List<string>
            {
                "Nev;Id;Ertekeles;ErtekelokSzama;Kiadas"
            };
            lines.AddRange(szurtJatekok.Select(j =>
                $"{j.Nev};{j.Id};{j.Ertekeles};{j.ErtekelokSzama};{j.Kiadas}"));

            File.WriteAllLines(outputFile, lines, Encoding.UTF8);

            Console.WriteLine($"{szurtJatekok.Count} játék mentve a(z) {outputFile} fájlba.");
        }

        public void Feladat4()
        {
            Console.Write("Minimális értékelési pont: ");
            int minErtekeles = Convert.ToInt32(Console.ReadLine());
            var szurtJatekok = jatekLista
                .Where(x => x.Ertekeles >= minErtekeles)
                .ToList();
            string outputFile = $"min{minErtekeles}.csv";
            var lines = new List<string>
            {
                "Nev;Id;Ertekeles;ErtekelokSzama;Kiadas"
            };
            lines.AddRange(szurtJatekok.Select(j =>
                $"{j.Nev};{j.Id};{j.Ertekeles};{j.ErtekelokSzama};{j.Kiadas}"));
            File.WriteAllLines(outputFile, lines, Encoding.UTF8);
            Console.WriteLine($"{szurtJatekok.Count} játék mentve a(z) {outputFile} fájlba.");
        }

        public void Feladat5()
        {
            Console.Write("Maximális értékelési pont: ");
            int maxErtekeles = Convert.ToInt32(Console.ReadLine());
            var szurtJatekok = jatekLista
                .Where(x => x.Ertekeles <= maxErtekeles)
                .ToList();
            string outputFile = $"max{maxErtekeles}.csv";
            var lines = new List<string>
            {
                "Nev;Id;Ertekeles;ErtekelokSzama;Kiadas"
            };
            lines.AddRange(szurtJatekok.Select(j =>
                $"{j.Nev};{j.Id};{j.Ertekeles};{j.ErtekelokSzama};{j.Kiadas}"));
            File.WriteAllLines(outputFile, lines, Encoding.UTF8);
            Console.WriteLine($"{szurtJatekok.Count} játék mentve a(z) {outputFile} fájlba.");
        }

        public void Feladat6()
        {
            Console.Write("Melyik oszlop szerint szeretnéd rendezni a fájlt? (1: Név, 2: Id, 3: Értékelés, 4: Értékelők száma, 5: Kiadás éve): ");
            int oszlop = Convert.ToInt32(Console.ReadLine());
            var rendezettJatekok = oszlop switch
            {
                1 => jatekLista.OrderBy(j => j.Nev).ToList(),
                2 => jatekLista.OrderBy(j => j.Id).ToList(),
                3 => jatekLista.OrderBy(j => j.Ertekeles).ToList(),
                4 => jatekLista.OrderBy(j => j.ErtekelokSzama).ToList(),
                5 => jatekLista.OrderBy(j => j.Kiadas).ToList(),
                _ => throw new ArgumentException("Érvénytelen oszlop szám"),
            };
            string outputFile = $"orderedBy{oszlop}.csv";
            var lines = new List<string>
            {
                "Nev;Id;Ertekeles;ErtekelokSzama;Kiadas"
            };
            lines.AddRange(rendezettJatekok.Select(j =>
                $"{j.Nev};{j.Id};{j.Ertekeles};{j.ErtekelokSzama};{j.Kiadas}"));
            File.WriteAllLines(outputFile, lines, Encoding.UTF8);
            Console.WriteLine($"{rendezettJatekok.Count} játék mentve a(z) {outputFile} fájlba.");
        }
    }
}
