using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Põhikonstruktsioonid_2.Osa4_Osa5_funktsioonid;

namespace Põhikonstruktsioonid_2
{
    internal class Startclass
    {
        static void Main(string[] args)
        {
            Osa4_Osa5_funktsioonid.Kirjuta_failisse();
            Console.WriteLine("Faili nimi: ");
            string fail = Console.ReadLine();
            Osa4_Osa5_funktsioonid.Faili_lugemine(fail);
            Console.WriteLine("Faili nimi: ");
            string fail1 = Console.ReadLine();
            Osa4_Osa5_funktsioonid.Ridade_lugemine(fail1);

            Osa4_Osa5_funktsioonid.ArrayList();
            Osa4_Osa5_funktsioonid.Tuple();
            Person.Per();
            Osa4_Osa5_funktsioonid.LinkedList();
            Osa4_Osa5_funktsioonid.Dictionary();

            //Ülesanne 
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("1. Ülesanne");
            Console.WriteLine("Tere tulemast kalorite kalkulaatorisse!");
            Inimene.SisestaAndmed();

            Console.WriteLine("2. Ülesanne");
            Dictionary<string, string> maakonnad = new Dictionary<string, string>();
            maakonnad.Add("Harju maakond", "Tallinn");
            maakonnad.Add("Hiiu maakond", "Kärdla");
            maakonnad.Add("Ida-Viru maakond", "Jõhvi");
            maakonnad.Add("Järva maakond", "Paide");
            maakonnad.Add("Lääne maakond", "Haapsalu");
            Console.WriteLine("Tere! Tahad teada, mis maakonnad on ja mis nende pealinnad?");
            string v = Console.ReadLine();
            if (v.ToLower() == "jah")
            {
                Console.WriteLine("Kui tahad teada linna, sisesta maakond, aga kui tahad teada maakonda, sisesta linn.");
                string vastus = Console.ReadLine();
                Funktsioonid.Maakond_linnad(vastus, maakonnad);
                Funktsioonid.Mang(maakonnad);
            }
            else if (v.ToLower() == "ei")
            {
                Console.WriteLine("Okei, head päeva!");
            }
            else
            {
                Console.WriteLine("Palun vasta jah või ei!");
            }

            double[] numbers = Iseseisev_funk_Osa5.Tekstist_arvud();
            double max = numbers.Max();
            double min = numbers.Min();
            double kesk = numbers.Average();
            double sum = numbers.Sum();
            int suur = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > kesk)
                {
                    suur++;
                }
            }
            Array.Sort(numbers);
            Console.WriteLine($"Max arv: {max}");
            Console.WriteLine($"Min arv: {min}");
            Console.WriteLine($"Keskmine arv: {kesk}");
            Console.WriteLine($"Summa arvud: {sum}");
            Console.WriteLine($"Arvu on suuremad kui keskmine: {suur}");
            Console.WriteLine($"Numbrid järjest: {string.Join(", ", numbers)}");

            Console.WriteLine("2. Ülesanne");
            Valuuta.KursssEur();

        }
    }
}
