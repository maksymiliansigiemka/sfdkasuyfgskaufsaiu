using System;
using System.Collections.Generic;

class Program
{
    // Definicja klasy Produkt, który będzie przechowywał dane o produkcie
    public class Produkt
    {
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }

        // Konstruktor klasy Produkt
        public Produkt(string nazwa, int ilosc, double cena)
        {
            Nazwa = nazwa;
            Ilosc = ilosc;
            Cena = cena;
        }
    }

    static void Main(string[] args)
    {
        // Lista przechowująca produkty w magazynie
        List<Produkt> magazyn = new List<Produkt>();

        while (true)
        {
            // Wyświetlenie menu głównego
            Console.Clear();
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");
            Console.Write("Opcja: ");

            // Wczytanie wyboru użytkownika
            int wybor = Convert.ToInt32(Console.ReadLine());

            // Obsługa poszczególnych opcji
            switch (wybor)
            {
                case 1:
                    // Dodawanie produktu
                    DodajProdukt(magazyn);
                    break;

                case 2:
                    // Usuwanie produktu
                    UsunProdukt(magazyn);
                    break;

                case 3:
                    // Wyświetlanie listy produktów
                    WyswietlProdukty(magazyn);
                    break;

                case 4:
                    // Aktualizacja produktu
                    AktualizujProdukt(magazyn);
                    break;

                case 5:
                    // Obliczanie wartości magazynu
                    ObliczWartoscMagazynu(magazyn);
                    break;

                case 6:
                    // Zakończenie programu
                    Console.WriteLine("Dziękujemy za korzystanie z programu. Do widzenia!");
                    return;

                default:
                    Console.WriteLine("Nieprawidłowy wybór! Wybierz opcję ponownie.");
                    break;
            }

            // Czekaj na naciśnięcie klawisza przed ponownym wyświetleniem menu
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }

    // Funkcja do dodawania produktu
    static void DodajProdukt(List<Produkt> magazyn)
    {
        Console.WriteLine("\nDodaj nowy produkt:");

        // Wczytywanie danych produktu
        Console.Write("Nazwa produktu: ");
        string nazwa = Console.ReadLine();

        Console.Write("Ilość: ");
        int ilosc = Convert.ToInt32(Console.ReadLine());

        Console.Write("Cena jednostkowa: ");
        double cena = Convert.ToDouble(Console.ReadLine());

        // Tworzenie nowego obiektu Produkt
        Produkt nowyProdukt = new Produkt(nazwa, ilosc, cena);

        // Dodanie produktu do magazynu
        magazyn.Add(nowyProdukt);

        Console.WriteLine("Produkt został dodany do magazynu.");
    }

    // Funkcja do usuwania produktu
    static void UsunProdukt(List<Produkt> magazyn)
    {
        Console.WriteLine("\nUsuń produkt:");

        // Wczytanie nazwy produktu do usunięcia
        Console.Write("Podaj nazwę produktu do usunięcia: ");
        string nazwa = Console.ReadLine();

        // Szukanie produktu w magazynie
        Produkt produktDoUsuniecia = magazyn.Find(p => p.Nazwa.Equals(nazwa, StringComparison.OrdinalIgnoreCase));

        // Jeśli produkt został znaleziony, usuwamy go
        if (produktDoUsuniecia != null)
        {
            magazyn.Remove(produktDoUsuniecia);
            Console.WriteLine("Produkt został usunięty z magazynu.");
        }
        else
        {
            Console.WriteLine("Produkt o podanej nazwie nie został znaleziony.");
        }
    }

    // Funkcja do wyświetlania listy produktów
    static void WyswietlProdukty(List<Produkt> magazyn)
    {
        Console.WriteLine("\nLista produktów w magazynie:");

        // Sprawdzenie, czy magazyn jest pusty
        if (magazyn.Count == 0)
        {
            Console.WriteLine("Magazyn jest pusty.");
        }
        else
        {
            // Wyświetlenie informacji o każdym produkcie
            foreach (Produkt produkt in magazyn)
            {
                Console.WriteLine($"Nazwa: {produkt.Nazwa}, Ilość: {produkt.Ilosc}, Cena: {produkt.Cena} PLN");
            }
        }
    }

    // Funkcja do aktualizacji produktu
    static void AktualizujProdukt(List<Produkt> magazyn)
    {
        Console.WriteLine("\nAktualizuj produkt:");

        // Wczytanie nazwy produktu do aktualizacji
        Console.Write("Podaj nazwę produktu do aktualizacji: ");
        string nazwa = Console.ReadLine();

        // Szukanie produktu w magazynie
        Produkt produktDoAktualizacji = magazyn.Find(p => p.Nazwa.Equals(nazwa, StringComparison.OrdinalIgnoreCase));

        // Jeśli produkt został znaleziony, umożliwiamy modyfikację
        if (produktDoAktualizacji != null)
        {
            Console.WriteLine("Co chcesz zmienić?");
            Console.WriteLine("1. Ilość");
            Console.WriteLine("2. Cena");
            Console.WriteLine("3. Oba");

            int wybor = Convert.ToInt32(Console.ReadLine());

            if (wybor == 1 || wybor == 3)
            {
                Console.Write("Podaj nową ilość: ");
                produktDoAktualizacji.Ilosc = Convert.ToInt32(Console.ReadLine());
            }

            if (wybor == 2 || wybor == 3)
            {
                Console.Write("Podaj nową cenę jednostkową: ");
                produktDoAktualizacji.Cena = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Produkt został zaktualizowany.");
        }
        else
        {
            Console.WriteLine("Produkt o podanej nazwie nie został znaleziony.");
        }
    }

    // Funkcja do obliczania wartości magazynu
    static void ObliczWartoscMagazynu(List<Produkt> magazyn)
    {
        double wartoscMagazynu = 0;

        // Obliczanie wartości wszystkich produktów w magazynie
        foreach (Produkt produkt in magazyn)
        {
            wartoscMagazynu += produkt.Ilosc * produkt.Cena;
        }

        Console.WriteLine($"Całkowita wartość magazynu: {wartoscMagazynu} PLN");
    }
}
