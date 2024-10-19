using System;
using ConsoleTables;
using CSharp_Project.Models;
using CSharp_Project.Repo;
using CSharp_Project.Validation;

namespace CSharp_Project.Methods;

public class CateMethod
{
    // Metod för att lägga till en ny kategori
    public static void AddCategory()
    {
        Console.Clear();    // Rensar konsol
        Console.WriteLine("Lägg till ny kategori:");

        var category = new Category();
        Console.Write("Namn: ");
        category.Name = Console.ReadLine();

        Console.Write("Beskrivning: ");
        category.Description = Console.ReadLine();

        CatRepo.AddCategory(category);      // kalla metod från repo för att lägga till kategori till lagring
        Console.WriteLine("Kategori tillagd. Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();  // Vänta på användarinmatning innan du fortsätter
    }


    // Metod för att lista och visa alla kategorier
    public static void ListOfCategories()
    {
        Console.Clear();
        Console.WriteLine("Kategorier:");
        var categories = CatRepo.GetCategories(); // kalla metod från repo för att få kategori och visa dem
                                                  // Skapar en instans av ConsoleTable med kolumnnamn "ID", "Name" och "Beskrivning".
        var table = new ConsoleTable("ID", "Name", "Beskrivning");
        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId,
                category.Name,
                category.Description
            );
        }
        table.Write();
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }

    // Metod för att uppdatera en befintlig kategori
    public static void UpdateCategory()
    {
        Console.Clear();
        ListOfCategories();                  // Visa alla kategorier så att användaren kan välja en att uppdatera
        Console.WriteLine("\nUppdatera kategori:");

        bool isChecked = true;
        while (isChecked)
        {
            Console.Write("Category ID: ");
            // int categoryId = Convert.ToInt32();
            if (int.TryParse(Console.ReadLine(), out int categoryId)) // kontrollera om input är integer
            {
                var category = CatRepo.GetCategoryById(categoryId);
                if (category != null && category.CategoryId == categoryId)
                {
                    Console.Write("Namn: ");
                    category.Name = Console.ReadLine();

                    Console.Write("Beskrivning: ");
                    category.Description = Console.ReadLine();

                    CatRepo.UpdateCategory(categoryId, category); // kalla metod från repo för att uppdatera kategorin
                    Console.WriteLine("Kategori uppdaterad. Tryck på valfri tangent för att fortsätta...");
                    isChecked = false;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Den katogri finns inte, Tryck på valfri tangent för att försöka igen...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt värde");

            }

        }
    }

    // Metod för att ta bort en kategori
    public static void DeleteCategories()
    {
        Console.Clear();
        bool isChecked = true;
        while (isChecked)
        {
            Console.WriteLine("Kategorier:");
            ShowCategoryInMethod();
            Console.Write("\nVänligen ange categori id för att radera: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                var categiry = CatRepo.GetCategoryById(userInput); // Hämta kategori efter ID från repo
                if (categiry != null && categiry.CategoryId == userInput)
                {
                    Console.Write("Är du säker att du vill radera kategori (ja/nej); ");
                    string userAns = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrEmpty(userAns) && userAns.ToLower() == "ja")
                    {
                        CatRepo.DeleteCategory(userInput); // kalla metod från repo för att ta bort kategorin
                        Console.WriteLine("Kategory raderades, Tryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                        isChecked = false; // Lämna loopen efter lyckad radering
                    }
                    else if (!string.IsNullOrEmpty(userAns) && userAns.ToLower() == "nej")
                    {
                        Console.WriteLine("Radering avbröts.");
                        TryAgain.newTry();
                        Console.ReadKey();
                        isChecked = false;
                    }
                    else
                    {
                        TryAgain.newTry();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Det finns inga categori med det id:et, försök igen");
                    TryAgain.newTry(); // Försök igen mekanism för ogiltig inmatning
                }

            }
            else
            {
                TryAgain.newTry(); // Försök igen mekanism för ogiltig inmatning
            }

        }
    }

    // den här metoden är samma ListOfcategories, för att visa cateid och namn för användaren när vill radera
    // Metod för att visa alla kategorier
    public static void ShowCategoryInMethod()
    {
        var categories = CatRepo.GetCategories();
        // Skapar en instans av ConsoleTable med kolumnnamn "ID", "Name" och "Beskrivning".
        var table = new ConsoleTable("ID", "Name");
        foreach (var x in categories)
        {
            // Lägger till en rad i tabellen för varje kategoriobjekt
            table.AddRow(
                x.CategoryId,
                x.Name
            );
        }

        table.Write();
    }
}

