using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Põh_2
{
    internal class Funktsioonid
    {
        public static void Maakond_linnad(string vastus, Dictionary<string,string> nimi)
        {
            if (vastus=="maakond")
            {
                Console.WriteLine("Sisesta maakond: ");
                string maakond = Console.ReadLine();
                if (nimi.ContainsKey(maakond))
                {
                     Console.WriteLine(nimi[maakond]);
                }
                else
                {
                    Console.WriteLine("Lisame su linna ja maakonna");
                    Console.Write("Sisesta maakond: ");
                    string maakond1 = Console.ReadLine();
                    Console.Write("Sisesta linn: ");
                    string linn1 = Console.ReadLine();
                    nimi.Add(maakond1, linn1);
                    Console.WriteLine("Andmed on lisatud!");
                }
            }
            else if (vastus=="linn")
            {
                Console.WriteLine("Sisesta linn: ");
                string linn = Console.ReadLine();
                if (nimi.ContainsValue(linn))
                {
                    foreach (var paar in nimi)
                    {
                        if (paar.Value == linn)
                            Console.WriteLine(paar.Key);
                    }
                }
                else
                {
                    Console.WriteLine("Lisame su linna ja maakonna");
                    Console.Write("Sisesta maakond: ");
                    string maakond = Console.ReadLine();    
                    Console.Write("Sisesta linn: ");
                    string linn1 = Console.ReadLine();
                    nimi.Add(maakond, linn1);
                    Console.WriteLine("Andmed on lisatud!");
                }
            }
            else
            {
                Console.WriteLine("Viga!");
            }
        }
        public static void Mang(Dictionary<string, string> nimi)
        {
            Console.WriteLine("Kas sa tahad mängida mängu? (jah/ei)");
            string vastus = Console.ReadLine().ToLower();
            if (vastus == "jah")
            {
                Console.WriteLine("Ma kirjutan sulle mingi maakonna ja sina pead arvama, mis on selle maakonna pealinn.");
                int oige = 0;
                for (int i = 0; i < 3; i++)
                {
                    Random rand = new Random();
                    int index = rand.Next(nimi.Count);
                    var paar = nimi.ElementAt(index);
                    Console.WriteLine($"Mis on {paar.Key} pealinn?");
                    string vastus1 = Console.ReadLine();
                    if (vastus1.ToLower() == paar.Value.ToLower())
                    {
                        Console.WriteLine("Õige vastus!");
                        oige++;
                    }
                    else
                    {
                        Console.WriteLine($"Vale vastus! Õige vastus on {paar.Value}");
                    }
                }
                float skoor = (float)oige / 3 * 100;
                Console.WriteLine($"Sinu skoor on {skoor}.");
                Console.WriteLine("Mäng läbi! Loodan, et sulle meeldis!");
            }
            else if (vastus == "ei")
            {
                Console.WriteLine("Okei, head päeva!");
            }
            else
            {
                Console.WriteLine("Palun vasta jah või ei!");
            }
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
                using (StreamWriter writer = new StreamWriter(path, false)) ;
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
        public static void SisestaAndmed()
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
            float bmr;
            if (inimene.Sugu == "mees")
                bmr = 88.36f + (13.4f * kaal) + (4.8f * pikkus) - (5.7f * vanus);
            else if (inimene.Sugu == "naine")
                bmr = 447.6f + (9.2f * kaal) + (3.1f * pikkus) - (4.3f * vanus);
            else
            {
                Console.WriteLine("Sisesta sugu õigesti!");
                return;
            }
            Console.WriteLine($"Põhiainevahetus (BMR): {bmr} kcal/päevas");
            Toode.SalvestaTootedFaili();
            List<string> toode_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Toode.txt");
                toode_list = File.ReadAllLines(path).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
            for (int i = 0; i < toode_list.Count; i++)
            {
                string[] osad = toode_list[i].Split(';');
                string toodeNimi = osad[0];
                float kalorid100g = float.Parse(osad[1]);

                float kogusGrammides = bmr / kalorid100g * 100;
                Console.WriteLine($"{i + 1}. {toodeNimi}: {kogusGrammides:F1} g");
            }
        }

    }


}
    
