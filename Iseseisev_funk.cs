using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Põhikonstruktsioonid_2
{
    internal class Iseseisev_funk
    {
        public static double [] Tekstist_arvud()
        {
           Console.WriteLine("Sisestage numbrid tühikuga: ");
            string arv = Console.ReadLine();
            string[] arvu = arv.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double[] arvud = new double[arvu.Length];
            for (int i = 0; i < arvu.Length; i++)
            {
                arvud[i] = Convert.ToDouble(arvu[i]);
            }
            return arvud;
        }
    }
    internal class Valuuta
    {
        public string Nimetus;
        public double KurssEurSuhte;
        public Valuuta() { }
        public Valuuta(string nimetus, double kurss)
        {
            Nimetus = nimetus;
            KurssEurSuhte = kurss;
        }
        public static void KursssEur()
        {
            Dictionary<string, Valuuta> kurss = new Dictionary<string, Valuuta>
        {
            { "EUR", new Valuuta("EUR", 1.0) },
            { "USD", new Valuuta("USD", 0.93) },
            { "GBP", new Valuuta("GBP", 1.15) },
            { "JPY", new Valuuta("JPY", 0.006) }
        };
            Console.WriteLine("Sisesta summ: ");
            double summ = double.Parse(Console.ReadLine());
            Console.WriteLine("Sisesta valuutanime: ");
            string valuut = Console.ReadLine().ToUpper();
            Valuuta val = null;
            try
            {
                val = kurss[valuut]; 
                double euro = summ * val.KurssEurSuhte;
                double usd = euro / 0.93;

                Console.WriteLine($"{summ} {val.Nimetus} = {euro:F2} EUR");
                Console.WriteLine($"{euro:F2} EUR = {usd:F2} USD");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Valuut ei leitud!");
            }

        }

    }

}



