using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Põhikonstruktsioonid_2
{
    internal class Iseseisev_too_Osa5
    {
        static void Main(string[] args)
        {
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
