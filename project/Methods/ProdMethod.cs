using System;
using System.Formats.Asn1;
using ConsoleTables;
using CSharp_Project.Models;
using CSharp_Project.Repo;
using CSharp_Project.Validation;

namespace CSharp_Project.Methods;

// Den här klassen innehåller metoder för att lägga till, uppdatera, radera och lista produkter.
public class ProdMethod
{

    // metod för att ägger till en ny produkt.
    public static void AddProduct()
    {
        bool isChecked = true; // Flagga för att kontrollera om användaren vill fortsätta
        Console.Clear();
        while (isChecked)
        {
            bool isReset = true; // Flagga för att kontrollera i fall användaren anger ogiltigt värde så indata kommer att återställas
            Console.WriteLine("Lägg till ny produkt:");
            var product = new Product();
            string? inputName = string.Empty;
            // hämta produktens namn och säkerställ att det är inte integer eller tom
            while (isReset)
            {
                Console.Write("Namn: ");
                inputName = Console.ReadLine();
                if (int.TryParse(inputName, out _) || string.IsNullOrEmpty(inputName))
                {
                    Console.WriteLine("Vänliga ange product's namn");
                }
                else { isReset = false; }
            }
            isReset = true;
            int inputNum = 0;
            while (isReset)
            {
                Console.Write("Kategori ID: ");
                string? inputCategoryId = Console.ReadLine();
                if (string.IsNullOrEmpty(inputCategoryId) || !int.TryParse(inputCategoryId, out inputNum) || CatRepo.GetCategoryById(inputNum)?.CategoryId != inputNum)
                {
                    Console.WriteLine("Vänliga ange Kategori's Id");
                }
                else { isReset = false; }
            }

            isReset = true;
            Console.Write("Antal: ");
            string? inputQuy = Console.ReadLine();
            int quantity = 0;
            var (_outputQuantity, IsValid) = ProdVallation.CheckValue(inputQuy, isReset);
            isChecked = IsValid;
            quantity = Convert.ToInt32(_outputQuantity);

            isReset = true;
            double price;
            Console.Write("Pris: ");
            string? inputPrice = Console.ReadLine();
            var (_outputPrice, _IsValid) = ProdVallation.CheckValue(inputPrice, isReset);
            isChecked = _IsValid;
            price = Convert.ToDouble(_outputPrice);


            isChecked = false;  // Om alla tidigare indata är giltiga, sätt isChecked till false för att avsluta loopen

            // Lägg till produkten i json-filen genom anvöndning av AddProduct metod
            product.Name = inputName;
            product.CategoryId = inputNum;
            product.Quantity = quantity;
            product.Price = price;
            ProdRepo.AddProduct(product);
            Console.WriteLine("Produkt tillagd. Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();

        }
    }

    // Uppdaterar en befintlig produkt.
    public static void UpdateProduct()
    {
        Console.Clear();
        Console.WriteLine("Uppdatera produkt:");

        bool isChecked = true;
        while (isChecked)
        {

            showProductInMethod(); // Visa tillgängliga produkter
            Console.Write("ProductId: ");
            if (int.TryParse(Console.ReadLine(), out int ProductId))
            {
                var getProductId = ProdRepo.GetProductById(ProductId); // Hämta produkt baserat på ID
                if (getProductId != null)
                {
                    bool isvaldit = true;
                    while (isvaldit)
                    {
                        Console.Write("Namn: ");
                        string productName = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(productName) && !int.TryParse(productName, out _))
                        {
                            getProductId.Name = productName;
                            isvaldit = false;
                        }
                        else
                        {
                            Console.WriteLine("Vänligen ange produkt namn.");
                        }

                    }

                    bool IsReset = true;
                    while (IsReset)
                    {
                        int _categoryId;
                        Console.Write("Kategori ID: ");
                        string? Kategori_ID = Console.ReadLine();
                        var (_outputKategori_ID, _IsValid) = ProdVallation.CheckValue(Kategori_ID, IsReset);
                        _categoryId = Convert.ToInt32(_outputKategori_ID);

                        if (_categoryId == CatRepo.GetCategoryById(_categoryId)?.CategoryId)
                        {
                            getProductId.CategoryId = _categoryId;
                            IsReset = _IsValid;
                        }
                        else
                        {
                            Console.WriteLine("Produkten hittades inte");
                        }

                    }
                    IsReset = true;
                    while (IsReset)
                    {
                        Console.Write("Antal: ");
                        string? inputQuy = Console.ReadLine();
                        var (_outputQuantity, IsValid) = ProdVallation.CheckValue(inputQuy, IsReset);
                        int _quantity = Convert.ToInt32(_outputQuantity);
                        getProductId.Quantity = _quantity;
                        IsReset = IsValid;

                    }
                    IsReset = true;
                    while (IsReset)
                    {
                        double price;
                        Console.Write("Pris: ");
                        string? inputPrice = Console.ReadLine();
                        var (_outputPrice, _IsValid) = ProdVallation.CheckValue(inputPrice, IsReset);
                        price = Convert.ToDouble(_outputPrice);
                        getProductId.Price = price;
                        IsReset = _IsValid;
                    }

                    isvaldit = false;
                
                    // Uppdatera produkten i repo
                    ProdRepo.UpdateProduct(ProductId, getProductId);
                    isChecked = false;
                    Console.WriteLine("Produkt uppdaterad. Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
            else
            {
                TryAgain.newTry(); // Visa felmedelande och be användaren att försöka igen
            }
        }

    }

    // Tar bort en produkt.
    public static void DeleteProduct()
    {
        Console.Clear();

        bool IsChecked = true;
        while (IsChecked)
        {
            showProductInMethod();
            Console.WriteLine("Radera produkt:");
            Console.Write("ProductId: ");
            // Kontrollera om inmatningen är ett giltigt heltal
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = ProdRepo.GetProductById(productId);  // Hämta produkt baserat på ID
                if (product != null && product.ProductId == productId)
                {
                    Console.Write("är du säker att du vill radera product (Ja/nej): ");
                    string? userAns = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userAns) && userAns.ToLower() == "ja")
                    {
                        IsChecked = false;
                        ProdRepo.DeleteProduct(productId);  // Ta bort produkten från repo
                        Console.WriteLine("Produkt raderad. Tryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                    }
                    else if (!string.IsNullOrEmpty(userAns) && userAns.ToLower() == "nej")
                    {
                        Console.WriteLine("Radering avbröts.");
                        TryAgain.newTry();
                        IsChecked = false;
                    }
                    else
                    {
                        TryAgain.newTry();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Det finns inga producter med det id:et, försök igen");
                    TryAgain.newTry();
                }
            }
            else
            {
                TryAgain.newTry();
            }

        }

    }

    // Visar en lista över alla produkter i en tabell.
    public static void ListOfProducts()
    {
        Console.Clear();
        Console.WriteLine("Produkter:");
        var products = ProdRepo.GetProducts();  // Hämta alla produkter
        var table = new ConsoleTable("Product ID", "Product Name", "Kategori ID", "Antal", "Pris");
        foreach (var product in products)
        {
            // Lägg till varje produkt i tabellen
            table.AddRow(
                product.ProductId,
                product.Name,
                product.CategoryId,
                product.Quantity,
                string.Format("{0:c}", product.Price)
            );
        }
        table.Write(); // Skriv ut tabellen
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }

    public static void showProductInMethod()
    {
        var products = ProdRepo.GetProducts();
        var table = new ConsoleTable("Product ID", "Product Name", "Kategori ID", "Antal", "Pris");
        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId,
                product.Name,
                product.CategoryId,
                product.Quantity,
                string.Format("{0:c}", product.Price)
            );
        }
        table.Write();
    }

}
