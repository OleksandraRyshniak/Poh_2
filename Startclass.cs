using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Põh_2
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
        }
    }
}
