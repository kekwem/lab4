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
            Console.WriteLine("7.Menu");
        }
        static void Main(string[] args)
        {
            var tablica_english = new Dictionary<int, string>()
            {
                { 1, "Apple"},
                { 2, "Car"},
                { 3, "Chair"},
                { 4, "Man"},
                { 5, "House"},
                { 6, "Sun"},
                { 7, "Environment"},
                { 8, "Tree"},
                { 9, "Sword"},
                { 10, "Book"},
                { 11, "Bootle"},
                { 12, "Sugar"},
                { 13, "Mountain"},
                { 14, "Tea"},
                { 15, "Language"}
            };

            var tablica_poland = new Dictionary<int, string>()
            {
                { 1, "Jablko"},
                { 2, "Samochod"},
                { 3, "Krzeslo"},
                { 4, "Czlowiek"},
                { 5, "Dom"},
                { 6, "Slonce"},
                { 7, "Srodowisko"},
                { 8, "Drzewo"},
                { 9, "Miecz"},
                { 10, "Ksiazka"},
                { 11, "Butelka"},
                { 12, "Cukier"},
                { 13, "Gora"},
                { 14, "Herbata"},
                { 15, "Jezyk"}
            };

            List<string> lista_tlimaczen_1 = new List<string>();
            List<string> lista_tlimaczen_2 = new List<string>();
            Random r = new Random();
            int ind_tab_orig = tablica_english.Count;
            int wybor;
            int wybor_opc;
            menu();
            do
            {
                wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("1.Angielski -> Polski\n2.Polski -> Angielski");
                        wybor_opc = int.Parse(Console.ReadLine());
                        if (wybor_opc == 1)
                        {
                            bool jest = false;
                            Console.WriteLine("Wpisz slowo dla przetlumaczenia");
                            string slowo = Console.ReadLine();
                            for (int i = 1; i <= tablica_english.Count; i++)
                            {
                                if (slowo.Equals(tablica_english[i]))
                                {
                                    Console.WriteLine($"Przetlumaczenie: {tablica_poland[i]}");
                                    lista_tlimaczen_1.Add(tablica_english[i]);
                                    lista_tlimaczen_2.Add(tablica_poland[i]);
                                    jest = true;
                                    break;
                                }
                            }
                            if (!jest)
                            {
                                Console.WriteLine("Brak slowa w slowniku");
                            }
                        }
                        else if (wybor_opc == 2)
                        {
                            bool jest = false;
                            Console.WriteLine("Wpisz slowo dla przetlumaczenia");
                            string slowo = Console.ReadLine();
                            for (int i = 1; i <= tablica_poland.Count; i++)
                            {
                                if (slowo.Equals(tablica_poland[i]))
                                {
                                    Console.WriteLine($"Przetlumaczenie: {tablica_english[i]}");
                                    lista_tlimaczen_1.Add(tablica_poland[i]);
                                    lista_tlimaczen_2.Add(tablica_english[i]);
                                    jest = true;
                                    break;
                                }
                            }
                            if (!jest)
                            {
                                Console.WriteLine("Brak slowa w slowniku");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        List<string> lista_slow_pol = new List<string>();
                        foreach (var item in tablica_poland)
                        {
                            lista_slow_pol.Add(item.Value);
                        }
                        lista_slow_pol.Sort();
                        List<string> lista_slow_en = new List<string>();
                        foreach (var item in tablica_english)
                        {
                            lista_slow_en.Add(item.Value);
                        }
                        lista_slow_en.Sort();
                        Console.WriteLine("1.Angielski -> Polski\n2.Polski -> Angielski");
                        wybor_opc = int.Parse(Console.ReadLine());
                        if (wybor_opc == 1)
                        {
                            for (int i = 0; i < lista_slow_en.Count; i++)
                            {
                                for (int j = 1; j <= tablica_english.Count; j++)
                                {
                                    if (lista_slow_en[i] == tablica_english[j])
                                    {
                                        Console.WriteLine(lista_slow_en[i] + "\t" + tablica_poland[j]);
                                    }
                                }
                            }
                        }
                        else if (wybor_opc == 2)
                        {
                            for (int i = 0; i < lista_slow_pol.Count; i++)
                            {
                                for (int j = 1; j <= tablica_poland.Count; j++)
                                {
                                    if (lista_slow_pol[i] == tablica_poland[j])
                                    {
                                        Console.WriteLine(lista_slow_pol[i] + "\t" + tablica_english[j]);
                                    }
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
                            int index = tablica_english.Count + 1;
                            Console.WriteLine("Wprowadz angielska i polska wersje slowa");
                            string slowo_eng = Console.ReadLine();
                            string slowo_pol = Console.ReadLine();
                            tablica_english.Add(index, slowo_eng);
                            tablica_poland.Add(index, slowo_pol);
                        }
                        else if(wybor_opc == 2)
                        {
                            if (tablica_english.Count > ind_tab_orig)
                            {
                                for (int i = ind_tab_orig + 1; i <= tablica_english.Count; i++)
                                {
                                    Console.WriteLine($"{i - ind_tab_orig}.{tablica_english[i]}");
                                }
                                Console.WriteLine("Jakie slowo chcesz usunac?");
                                int slowo = int.Parse(Console.ReadLine());
                                var tablica_eng_inna = new Dictionary<int, string>();
                                var tablica_pol_inna = new Dictionary<int, string>();
                                for (int i = slowo + ind_tab_orig + 1; i <= tablica_english.Count; i++)
                                {
                                    tablica_eng_inna.Add(i - 1, tablica_english[i]);
                                    tablica_pol_inna.Add(i - 1, tablica_poland[i]);
                                }
                                int ilosc_elementow = tablica_english.Count;
                                for (int i = ind_tab_orig + slowo; i <= ilosc_elementow; i++)
                                {
                                    tablica_english.Remove(i);
                                    tablica_poland.Remove(i);
                                }
                                ilosc_elementow = tablica_english.Count;
                                for (int i = ind_tab_orig + slowo; i <= tablica_eng_inna.Count + ilosc_elementow; i++)
                                {
                                    tablica_english.Add(i, tablica_eng_inna[i]);
                                    tablica_poland.Add(i, tablica_pol_inna[i]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Brak wlasnych slow!");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        if (lista_tlimaczen_1.Count > 0)
                        {
                            for (int i = 0; i < lista_tlimaczen_1.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{lista_tlimaczen_1[i]} --> {lista_tlimaczen_2[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Brak historii tlumaczen");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        HashSet<int> tablica_uzyw = new HashSet<int>();
                        int praw_odp = 0;
                        int niepraw_odp = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            int liczba;
                            bool byla_uzyta;
                            do
                            {
                                byla_uzyta = false;
                                liczba = r.Next(1, tablica_english.Count + 1);
                                foreach (var item in tablica_uzyw)
                                {
                                    if (item == liczba)
                                    {
                                        byla_uzyta = true;
                                    }
                                }
                                if (!byla_uzyta)
                                {
                                    tablica_uzyw.Add(liczba);
                                }
                            } while (byla_uzyta);
                            Console.WriteLine($"Jakie jest przetlumaczenie slowa {tablica_english[liczba]}?");
                            string tlumacz = Console.ReadLine();
                            if (tlumacz.Equals(tablica_poland[liczba]))
                            {
                                praw_odp++;
                            }
                            else
                            {
                                niepraw_odp++;
                                Console.WriteLine($"Prawidlowa odpowiedz: {tablica_poland[liczba]}");
                            }
                        }
                        Console.WriteLine($"Prawidlowe odpowiedzi: {praw_odp}, niepraw. odpowiedzi : {niepraw_odp}\n");
                        break;
                    case 6:
                        HashSet<int> tablica_uzyw_2 = new HashSet<int>();
                        praw_odp = 0;
                        niepraw_odp = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            int liczba;
                            bool byla_uzyta;
                            do
                            {
                                byla_uzyta = false;
                                liczba = r.Next(1, tablica_english.Count + 1);
                                foreach (var item in tablica_uzyw_2)
                                {
                                    if (item == liczba)
                                    {
                                        byla_uzyta = true;
                                    }
                                }
                                if (!byla_uzyta)
                                {
                                    tablica_uzyw_2.Add(liczba);
                                }
                            } while (byla_uzyta);
                            Console.WriteLine($"Jakie jest przetlumaczenie slowa {tablica_poland[liczba]}?");
                            string tlumacz = Console.ReadLine();
                            if (tlumacz.Equals(tablica_english[liczba]))
                            {
                                praw_odp++;
                            }
                            else
                            {
                                niepraw_odp++;
                                Console.WriteLine($"Prawidlowa odpowiedz: {tablica_english[liczba]}");
                            }
                        }
                        Console.WriteLine($"Prawidlowe odpowiedzi: {praw_odp}, niepraw. odpowiedzi : {niepraw_odp}\n");
                        break;
                    case 7:
                        menu();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Nie ma podanej opcji\n");
                        break;
                }
            } while (wybor != 0);
        }
    }
}
