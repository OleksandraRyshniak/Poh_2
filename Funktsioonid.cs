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
    internal class Inimene
    {
        public string Nimi;
        public int Vanus;
        public string Sugu;
        public float Pikkus;
        public float Kaal;
        public string Aktiivsustase;

        public Inimene(string nimi, int vanus, string sugu, float pikkus, float kaal, string aktiivsus)
        {
            Nimi = nimi;
            Vanus = vanus;
            Sugu = sugu;
            Pikkus = pikkus;
            Kaal = kaal;
            Aktiivsustase = aktiivsus;
        }
        public static void  SisestaAndmed()
        {
            Console.Write("Sisesta nimi: ");
            string nimi = Console.ReadLine();
            Console.Write("Sisesta vanus: ");
            int vanus = int.Parse(Console.ReadLine());
            Console.Write("Sisesta sugu (mees/naine): ");
            string sugu = Console.ReadLine().ToLower();
            Console.Write("Sisesta pikkus cm: ");
            float pikkus = float.Parse(Console.ReadLine());
            Console.Write("Sisesta kaal kg: ");
            float kaal = float.Parse(Console.ReadLine());
            Console.Write("Sisesta aktiivsustase (madal/keskmine/suur): ");
            string aktiivsus = Console.ReadLine().ToLower();
            Inimene inimene = new Inimene(nimi, vanus, sugu, pikkus, kaal, aktiivsus);
            if (inimene.Sugu != "naine" )
            {
                float bmr = 88.36f + (13.4f * kaal) + (4.8f * pikkus) - (5.7f * vanus);
                Console.WriteLine($"Põhiainevahetus (BMR): {bmr} kcal/päevas");
            }
            else if (inimene.Sugu == "mees")
            {
                float bmr = 447.6f + (9.2f * kaal) + (3.1f * pikkus) - (4.3f * vanus);
                Console.WriteLine($"Põhiainevahetus (BMR): {bmr} kcal/päevas");
            }
            else
            {
                Console.WriteLine("Sisesta sugu õigesti!");
            }
            Toode.SalvestaTootedFaili();
            List<string> toode_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Toode.txt");
                foreach (string rida in File.ReadAllLines(path))
                {
                    toode_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
            foreach (string toode in toode_list)
            {
                Console.WriteLine(toode);
            }

        }
    }
}
    
