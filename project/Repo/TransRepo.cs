using System;
using CSharp_Project.Models;
using Newtonsoft.Json;


namespace CSharp_Project.Repo;

public class TransRepo
{
    // Filväg för att lagra transaktionsdata i JSON-format
    private const string filePath = "transaction.json";
    private static List<Transaction> transactions = new List<Transaction>();

    // Metod för att kontrollera om transaktionsfilen finns
    public static void ChechFileExist()
    {


        if (File.Exists(filePath))
        {
            string existingData = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingData))
            {
                // omvandlar json-data till en lista av Prop objekt.
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(existingData) ?? new List<Transaction>();
            }

        }
    }

    // Metod för att spara den listan av transaktioner till JSON-filen
    public static void SaveToJsonFile()
    {
        // Serialisera transaktionslistan till en formaterad JSON-sträng
        string Json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
        File.WriteAllText(filePath, Json);
    }

    // Metod för att lägga till en ny transaktion
    public static void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        var transaction = new Transaction
        {
            ProductId = productId,
            ProductName = productName,
            Timestamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            CashierName = cashierName,
        };

        // Kontrollera om det finns befintliga transaktioner för att bestämma nästa TransactionId
        if (transactions != null && transactions.Count() > 0)
        {
            // Hämta det maximala befintliga TransactionId och öka det för den nya transaktionen
            var maxId = transactions.Max(x => x.TransactionId);
            transaction.TransactionId = maxId + 1;
        }
        else
        {
            transaction.TransactionId = 1;
        }

        transactions?.Add(transaction);
        SaveToJsonFile();
    }

    // Metod för att hämta alla transaktioner
    public static IEnumerable<Transaction> GetAllTransactions() => transactions;

    // Metod för att söka transaktioner baserat på cashier's namn och datum
    public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        // kontrollera om det användaren har inte angett cashier's namn 
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            // Om inget cashier's namn anges, filtrera transaktionerna bara efter datumsvall
            return transactions.Where(x => x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
        }
        else
        {
            // Om ett cashier's namn anges, filtrera transaktionerna efter både cashier's namn och datumvall
            return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
