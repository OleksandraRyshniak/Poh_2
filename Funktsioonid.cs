using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Põh_2
{
    internal class Funktsioonid
    {
        public static void Kalorite_kalkulaator()
        {
            Toode.SalvestaTootedFaili();
        }
    }
    internal class Toode
    {
        public string Nimi;
        public string Kalorid100g;
        public Toode(string nimi, string kalorid)
        {
            Nimi = nimi;
            Kalorid100g = kalorid;
        }
        public static void SalvestaTootedFaili()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Toode.txt");
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("Sisesta toote nimi: ");
                        string nimi = Console.ReadLine();
                        Console.Write("Sisesta kalorid 100g kohta: ");
                        string kalorid = Console.ReadLine();
                        Toode toode = new Toode(nimi, kalorid);
                        writer.WriteLine($"{toode.Nimi};{toode.Kalorid100g}");
                    }
                }
                Console.WriteLine("Andmed on edukalt salvestatud.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga faili töötlemisel: " + ex.Message);
            }
        }
    }
}
    
