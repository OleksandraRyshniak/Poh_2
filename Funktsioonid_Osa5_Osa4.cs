using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Põhikonstruktsioonid_2
{
    internal class Osa4_Osa5_funktsioonid
    {
        public static void Kirjuta_failisse()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt"); //@"..\..\..\Kuud.txt"
                StreamWriter text = new StreamWriter(path, true); // true = lisa lõppu
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();
                text.WriteLine(lause);
                text.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }
        public static void Faili_lugemine(string failnimi)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\" + failnimi + ".txt");
                StreamReader text = new StreamReader(path);
                string laused = text.ReadToEnd();
                text.Close();
                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }
        }
        public static List<string> Ridade_lugemine(string fail)
        {
            List<string> kuude_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fail + ".txt");
                foreach (string rida in File.ReadAllLines(path))
                {
                    kuude_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            kuude_list.Remove("pol");

            if (kuude_list.Count < 0)
                kuude_list[0] = "Veeel kuuu";
            Console.WriteLine("--------------Kustutasime pol-----------");

            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }
            Console.WriteLine("Sisesta kuu nimi, mida otsida:");
            string otsitav = Console.ReadLine();

            if (kuude_list.Contains(otsitav))
                Console.WriteLine("Kuu " + otsitav + " on olemas.");
            else
                Console.WriteLine("Sellist kuud pole.");

            return kuude_list;
        }

        public static void ArrayList()
        {
            ArrayList nimed = new ArrayList();
            nimed.Add("Kati");
            nimed.Add("Mati");
            nimed.Add("Juku");

            if (nimed.Contains("Mati"))
                Console.WriteLine("Mati olemas");

            Console.WriteLine("Nimesid kokku: " + nimed.Count);

            nimed.Insert(1, "Sass");

            Console.WriteLine("Mati indeks: " + nimed.IndexOf("Mati"));
            Console.WriteLine("Mari indeks: " + nimed.IndexOf("Mari"));

            foreach (string nimi in nimed)
                Console.WriteLine(nimi);
        }
        public static void Tuple()
        {
            Tuple<float, char> route = new Tuple<float, char>(2.5f, 'N');
            Console.WriteLine($"Vahemaa: {route.Item1}, Suund: {route.Item2}");
        }

        public static void LinkedList()
        {
            LinkedList<int> loetelu = new LinkedList<int>();
            loetelu.AddLast(5);
            loetelu.AddLast(3);
            loetelu.AddFirst(0);

            foreach (int arv in loetelu)
                Console.WriteLine(arv);

            loetelu.RemoveFirst();
            loetelu.RemoveLast();
            loetelu.AddLast(555);
            loetelu.Remove(555);
        }
        public static void Dictionary()
        {
            Dictionary<int, string> riigid = new Dictionary<int, string>();
            riigid.Add(1, "Hiina");
            riigid.Add(2, "Eesti");
            riigid.Add(3, "Itaalia");

            foreach (var paar in riigid)
                Console.WriteLine($"{paar.Key} - {paar.Value}");

            string pealinn = riigid[2];
            riigid[2] = "Eestimaa";
            riigid.Remove(3);

            Dictionary<char, Person> inimesed = new Dictionary<char, Person>();
            inimesed.Add('k', new Person() { Name = "Kadi" });
            inimesed.Add('m', new Person() { Name = "Mait" });

            foreach (var entry in inimesed)
                Console.WriteLine($"{entry.Key} - {entry.Value.Name}");
        }

        // Ülesanne Kodu
        //2.
        internal class Funktsioonid
        {
            public static void Maakond_linnad(string vastus, Dictionary<string, string> nimi)
            {
                if (vastus == "maakond")
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
                else if (vastus == "linn")
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

        //1.
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

        //Iseseisev töö
        internal class Iseseisev_funk_Osa5
        {
            public static double[] Tekstist_arvud()
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
                double summ = 0;
                Console.WriteLine("Sisesta summ: ");
                try
                {
                    summ = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Viga! Sisesta ainult arvud!");
                }

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

}
    
