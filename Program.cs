using System;
using System.Collections.Generic;
namespace lab4_console
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("1.Przetlumacz");
            Console.WriteLine("2.Wyswietl slownictwo");
            Console.WriteLine("3.Dodaj/Usun Slowo");
            Console.WriteLine("4.Historia tlumaczen");
            Console.WriteLine("5.Test angielski");
            Console.WriteLine("6.Test polski");
        }
        static void Main(string[] args)
        {
            var slownictwo = new Dictionary<string, string>()
            {
                { "Jablko", "Apple"},
                { "Samochod", "Car"},
                { "Krzeslo", "Chair"},
                { "Czlowiek", "Man"},
                { "Dom", "House"},
                { "Slonce", "Sun"},
                { "Srodowisko", "Environment"},
                { "Drzewo", "Tree"},
                { "Miecz", "Sword"},
                { "Ksiazka", "Book"},
                { "Butelka", "Bottle"},
                { "Cukier", "Sugar"},
                { "Gora", "Mountain"},
                { "Herbata", "Tea"},
                { "Jezyk", "Language"}
            };

            int wybor;
            int wybor_opc;
            int ilosc_slow_bazowa = slownictwo.Count;
            List<string> lista_historii_1 = new List<string>();
            List<string> lista_historii_2 = new List<string>();
            Random r = new Random();
            do {
                menu();
                wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("1.Angielski -> Polski\n2.Polski -> Angielski");
                        wybor_opc = int.Parse(Console.ReadLine());
                        string slowo;
                        if (wybor_opc == 1)
                        {
                            bool jest_w_slowniku = false;
                            slowo = Console.ReadLine();
                            foreach(var item in slownictwo)
                            {
                                if (slowo == item.Value)
                                {
                                    Console.WriteLine(item.Key);
                                    lista_historii_1.Add(item.Value);
                                    lista_historii_2.Add(item.Key);
                                    jest_w_slowniku = true;
                                    break;
                                }
                            }
                            if (!jest_w_slowniku)
                            {
                                Console.WriteLine("Brak slowa w slowniku!");
                            }
                        }
                        else if (wybor_opc == 2)
                        {
                            bool jest_w_slowniku = false;
                            slowo = Console.ReadLine();
                            foreach (var item in slownictwo)
                            {
                                if (slowo == item.Key)
                                {
                                    Console.WriteLine(item.Value);
                                    lista_historii_1.Add(item.Key);
                                    lista_historii_2.Add(item.Value);
                                    jest_w_slowniku = true;
                                    break;
                                }
                            }
                            if (!jest_w_slowniku)
                            {
                                Console.WriteLine("Brak slowa w slowniku!");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        List<string> lista_slow = new List<string>();
                        Console.WriteLine("1.Angielski -> Polski\n2.Polski -> Angielski");
                        wybor_opc = int.Parse(Console.ReadLine());
                        if (wybor_opc == 1)
                        {
                            foreach(var item in slownictwo)
                            {
                                lista_slow.Add(item.Value);
                            }
                            lista_slow.Sort();
                        }
                        else if (wybor_opc == 2)
                        {
                            foreach (var item in slownictwo)
                            {
                                lista_slow.Add(item.Key);
                            }
                            lista_slow.Sort();
                        }
                        foreach (var slowo_1 in lista_slow)
                        {
                            foreach (var slowo_2 in slownictwo)
                            {
                                if (slowo_1.Equals(slowo_2.Value))
                                {
                                    Console.WriteLine($"{slowo_1} -> {slowo_2.Key}");
                                }
                                if (slowo_1.Equals(slowo_2.Key))
                                {
                                    Console.WriteLine($"{slowo_1} -> {slowo_2.Value}");
                                }
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("1.Dodaj slowo\n2.Usun slowo");
                        wybor_opc = int.Parse(Console.ReadLine());
                        if (wybor_opc == 1)
                        {
                            Console.WriteLine("Wpisz angieska i polska wersje slowa");
                            string wersja_en = Console.ReadLine();
                            string wersja_pol = Console.ReadLine();
                            slownictwo.Add(wersja_pol, wersja_en);
                        }
                        else if (wybor_opc == 2)
                        {
                            if (slownictwo.Count > ilosc_slow_bazowa)
                            {
                                Console.WriteLine("Jakie slowo chcesz usunac?");
                                lista_slow = new List<string>();
                                foreach (var item in slownictwo)
                                {
                                    lista_slow.Add(item.Key);
                                }
                                for (int i = 0 + ilosc_slow_bazowa; i < lista_slow.Count; i++)
                                {
                                    Console.WriteLine($"{i - ilosc_slow_bazowa + 1}.{lista_slow[i]}");
                                }
                                int index = int.Parse(Console.ReadLine());
                                slownictwo.Remove(lista_slow[index + ilosc_slow_bazowa - 1]);
                            }
                            else
                            {
                                Console.WriteLine("Brak slow wlasnych!");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        if (lista_historii_1.Count != 0)
                        {
                            for (int i = 0; i < lista_historii_1.Count; i++)
                            {
                                Console.WriteLine($"{lista_historii_1[i]} -> {lista_historii_2[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Brak historii tlumaczen!");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        int liczba_praw = 0;
                        int liczba_niepraw = 0;
                        HashSet<int> tablica_uzytych_slow = new HashSet<int>();
                        List<string> tablica = new List<string>();
                        foreach (var item in slownictwo)
                        {
                            tablica.Add(item.Key);
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            int random;
                            bool byl_uzyt;
                            do
                            {
                                byl_uzyt = false;
                                random = r.Next(0, tablica.Count);
                                foreach(var item in tablica_uzytych_slow)
                                {
                                    if (item == random)
                                    {
                                        byl_uzyt = true;
                                    }
                                }
                                tablica_uzytych_slow.Add(random);
                            } while (byl_uzyt);
                            string random_klucz = tablica[random];
                            Console.WriteLine($"Jakie jest tlumaczenie slowa {slownictwo[random_klucz]}");
                            string odpow_testowa = Console.ReadLine();
                            if (odpow_testowa == random_klucz)
                            {
                                liczba_praw++;
                            }
                            else
                            {
                                liczba_niepraw++;
                                Console.WriteLine($"Prawidlowa odpowiedz: {random_klucz}");
                            }
                        }
                        Console.WriteLine($"Praw.odp = {liczba_praw}; Niepraw.odp = {liczba_niepraw}\n");
                        break;
                    case 6:
                        liczba_praw = 0;
                        liczba_niepraw = 0;
                        tablica_uzytych_slow = new HashSet<int>();
                        tablica = new List<string>();
                        foreach (var item in slownictwo)
                        {
                            tablica.Add(item.Key);
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            int random;
                            bool byl_uzyt;
                            do
                            {
                                byl_uzyt = false;
                                random = r.Next(0, tablica.Count);
                                foreach (var item in tablica_uzytych_slow)
                                {
                                    if (item == random)
                                    {
                                        byl_uzyt = true;
                                    }
                                }
                                tablica_uzytych_slow.Add(random);
                            } while (byl_uzyt);
                            string random_klucz = tablica[random];
                            Console.WriteLine($"Jakie jest tlumaczenie slowa {random_klucz}");
                            string odpow_testowa = Console.ReadLine();
                            if (odpow_testowa == slownictwo[random_klucz])
                            {
                                liczba_praw++;
                            }
                            else
                            {
                                liczba_niepraw++;
                                Console.WriteLine($"Prawidlowa odpowiedz: {slownictwo[random_klucz]}");
                            }
                        }
                        Console.WriteLine($"Praw.odp = {liczba_praw}; Niepraw.odp = {liczba_niepraw}\n");
                        break;
                }
            } while (wybor != 0) ;
        }
    }
}
