using System;
using CSharp_Project.Models;
using CSharp_Project.Repo;
using System.Linq;
using CSharp_Project.Validation;
using ConsoleTables;

namespace CSharp_Project.Methods;

public class TransMethods
{
    // Metod för att registrera en försäljningstransaktion.
    public static void RegisterSale()
    {
        Console.Clear();
        var products = ProdRepo.GetProducts();
         // Skapar en tabell för att visa tillgängliga produkter med ID och namn
        var table = new ConsoleTable("ProductID", "product namn");
        foreach (var x in products)
        {
            table.AddRow(
                x.ProductId,
                x.Name
            );
        }
        table.Write();
        Console.WriteLine("\nRegistrera Försäljning:");

        Console.Write("Cashier namn: ");
        string cashierName = Console.ReadLine() ?? string.Empty;
        while (int.TryParse(cashierName, out _) || string.IsNullOrEmpty(cashierName))
        {
            Console.Write("skriv cashier namn (det går inte att vara tomt eller nummer): ");
            cashierName = Console.ReadLine() ?? string.Empty;
        }
        bool IsChecked = true;
        while (IsChecked)
        {
            Console.Write("Produkt ID: ");
            string? productIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(productIdInput) && int.TryParse(productIdInput, out _))
            {
                if (int.TryParse(productIdInput, out int productId))
                {
                    // Hämtar produkten från repo om Produkt ID är giltigt
                    var product = ProdRepo.GetProductById(productId);
                    if (product != null)
                    {
                        bool IsCheck = true;
                        while (IsCheck)
                        {
                            Console.Write("Antal sålda: ");
                            string? inputSoldQty = Console.ReadLine();
                            if (int.TryParse(inputSoldQty, out int soldQty))
                            {
                                // Kontroll för att säkerställa att det finns tillräckligt 
                                if (product.Quantity < soldQty)
                                { Console.WriteLine("Product räcker inte."); }
                                else if (soldQty <= 0 || string.IsNullOrEmpty(inputSoldQty))
                                {
                                    Console.WriteLine("Antal måste vara större än noll");
                                }
                                else
                                {
                                    // Om allt är giltigt, registrera försäljninge
                                    IsCheck = false;
                                    IsChecked = false;
                                    TransRepo.Add(cashierName, product.ProductId, product.Name ?? string.Empty, product.Price ?? 0, product.Quantity ?? 0, soldQty);
                                    product.Quantity -= soldQty; // Minska antalet kvarvarande produkter
                                    ProdRepo.UpdateProduct(productId, product); // Uppdatera produkt
                                    Console.WriteLine("Försäljning registrerad. Tryck på valfri tangent för att fortsätta...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt värde");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Produkt inte hittad. Tryck på valfri tangent för att fortsätta...");
                    }
                }


            }
            else
            {
                Console.Write("Ange Produkt ID (det går inte att vara tomt eller ord): ");
            }

        }

    }
    // Metod för att hämta och visa alla transaktioner
    public static void GetTransactions()
    {
        var transactions = TransRepo.GetAllTransactions();
        if (transactions == null || transactions.Count() == 0)
        {
            Console.WriteLine("Det finns inga transcaktioner att visa ");
            return;
        }
        Console.Clear();
        Console.WriteLine("Transaktioner:");
        string totalAllSoldProducts = string.Format("{0:c}", transactions.Sum(x => x.Price * x.SoldQty));
        var table = new ConsoleTable("Transaktion ID", "Product Name", "Timestamp", "Quantity", "Cashier", "Price", "Total Sum");
        foreach (var transaction in transactions)
        {
            string totalSum = string.Format("{0:c}", transaction.Price * transaction.SoldQty);
            table.AddRow(
            transaction.TransactionId,
            transaction.ProductName,
            transaction.Timestamp.ToString("yy-MM-dd hh:mm"),
            transaction.SoldQty,
            transaction.CashierName,
            string.Format("{0:c}", transaction.Price),
            totalSum
        );
        }
        table.AddRow("", "", "", "", "", "total summa sålda varor:", totalAllSoldProducts);
        table.Write();
        Console.WriteLine($"Antal Transaktioner: {transactions.Count()}");
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }

     // Metod för att söka transaktioner baserat på kassörens namn och datumintervall
    public static void SearchTrans()
    {
        // Hämta kassörens namn (valfritt)
        Console.Write("Ange kassörens namn (valfritt): ");
        string? cashierName = Console.ReadLine() ?? string.Empty;

        // Hämta startdatum och validera
        DateTime startDate;
        while (true)
        {
            Console.Write("Ange startdatum (åååå-mm-dd): ");
            string? startInput = Console.ReadLine();
            if (DateTime.TryParse(startInput, out startDate))
            {
                break;
            }
            else
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
            }
        }

        // Hämta slutdatum och validera
        DateTime endDate;
        while (true)
        {
            Console.Write("Ange slutdatum (åååå-mm-dd): ");
            string? endInput = Console.ReadLine();
            if (DateTime.TryParse(endInput, out endDate))
            {
                // Kontrollera att slutdatum är efter eller samma som startdatum
                if (endDate >= startDate)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Slutdatumet måste vara efter eller samma som startdatumet. Försök igen.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
            }
        }

        // Hämta transaktioner från repo
        var transactions = TransRepo.Search(cashierName, startDate, endDate);

        // Kontrollera om det finns några transaktioner
        if (transactions != null)
        {
            string totalAllSoldProducts = string.Format("{0:c}", transactions.Sum(x => x.Price * x.SoldQty));
            var table = new ConsoleTable("Transaktion ID", "Product Name", "Timestamp", "Quantity", "Cashier", "Price", "Total Sum");
            foreach (var trans in transactions)
            {
                string totalSum = string.Format("{0:c}", trans.Price * trans.SoldQty);
                table.AddRow(
                trans.TransactionId,
                trans.ProductName,
                trans.Timestamp.ToString("yy-MM-dd hh:mm"),
                trans.SoldQty,
                trans.CashierName,
                string.Format("{0:c}", trans.Price),
                totalSum
                );
            }
            table.AddRow("", "", "", "", "", $"total summa sålda varor:", totalAllSoldProducts);
            table.Write();
            Console.WriteLine($"Antal Transaktioner: {transactions.Count()}");
        }
        else
        {
            Console.WriteLine("Inga transaktioner hittades för angivet sökfilter.");
        }

        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }



}
