using CSharp_Project.Methods;
using CSharp_Project.Models;
using CSharp_Project.Repo;
using CSharp_Project.Validation;



namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ladda data från JSON-filer
            CatRepo.ChechFileExist();
            ProdRepo.ChechFileExist();
            TransRepo.ChechFileExist();
            // Oändlig loop för att visa huvudmenyn tills användaren avslutar
            while (true)
            {
                Console.Clear();
                // Metod för att skapa en dynamisk meny baserat på de argument som skickas in
                TableForm.UiApp("HuvudMenu", "Hantera Kategorier", "Hantera Produkter", "Hantera Transaktioner", "Avsluta", "");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ManageCategories();
                        break;
                    case "2":
                        ManageProducts();
                        break;
                    case "3":
                        ManageTransactions();
                        break;
                    case "4":
                        ManageTransactions();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, Tryck på valfri tangent för att försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Menu för att hantera kategorier
        static void ManageCategories()
        {
            while (true)
            {
                Console.Clear();
                TableForm.UiApp("Hantera Kategorier", "Lägg till kategori", "Uppdatera kategori", "Delete kategorier", "Visa kategorier", "Tillbaka");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CateMethod.AddCategory();
                        break;
                    case "2":
                        CateMethod.UpdateCategory();
                        break;
                    case "3":
                        CateMethod.DeleteCategories();
                        break;
                    case "4":
                        CateMethod.ListOfCategories();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, Tryck på valfri tangent för att försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Menu för att hantera produkter
        static void ManageProducts()
        {
            while (true)
            {
                Console.Clear();
                TableForm.UiApp("Hantera Produkter", "Lägg till produkt", "Uppdatera produkt", "Radera produkt", "Visa produkter", "Tillbaka");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ProdMethod.AddProduct();
                        break;
                    case "2":
                        ProdMethod.UpdateProduct();
                        break;
                    case "3":
                        ProdMethod.DeleteProduct();
                        break;
                    case "4":
                        ProdMethod.ListOfProducts();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, Tryck på valfri tangent för att försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }


        // Menu för att hantera transaktioner
        public static void ManageTransactions()
        {
            while (true)
            {
                Console.Clear();
                TableForm.UiApp("Hantera Transactioner", "Registera en transaction", "Visa alla Transkationer", "Söka efter Transaction", "Tillbaka", "");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        TransMethods.RegisterSale();
                        break;
                    case "2":
                        TransMethods.GetTransactions();
                        break;
                    case "3":
                        TransMethods.SearchTrans();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, Tryck på valfri tangent för att försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
