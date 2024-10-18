using System;
using CSharp_Project.Models;
using CSharp_Project.Repo;
using Newtonsoft.Json;


public class ProdRepo
{

    // Filväg för att spara och hämta produktdata i JSON-format
    private const string filePath = "product.json";

    // Lista för att lagra produkter
    private static List<Product> _products = new List<Product>();

    // Metod för att kontrollera om filen finns och läsa befintliga produkter från den
    public static void ChechFileExist()
    {

        // Kontrollera om filen existerar
        if (File.Exists(filePath))
        {
            string existingData = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingData))
            {
                // omvandlar json-data till en lista av Prop objekt.
                _products = JsonConvert.DeserializeObject<List<Product>>(existingData) ?? new List<Product>();
            }

        }
    }

     // Metod för att spara produktlistan _products till en JSON-fil
    public static void SaveToJsonFile()
    {
        string Json = JsonConvert.SerializeObject(_products, Formatting.Indented);
        File.WriteAllText(filePath, Json);
    }

    // Metod för att hämta listan över alla produkter
    public static List<Product> GetProducts() => _products;

    // Metod för att lägga till en ny produkt
    public static void AddProduct(Product product)
    {
        if (_products != null && _products.Count() > 0)
        {
            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            SaveToJsonFile();
        }
        else
        {
            product.ProductId = 1;
        }
        if (_products == null) _products = new List<Product>();
        _products.Add(product);
    }

    // Metod för att hämta en produkt baserat på dess id
    public static Product? GetProductById(int productId, bool loadCategory = false)
    {
        // hitta produkten baserat på dess id
        var product = _products.FirstOrDefault(x => x.ProductId == productId);
        if (product != null)
        {
            // Skapa en ny produkt baserad på hittad produkt
            var prod = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
            // Om loadCategory är sant, hämta och koppla kategori info
            if (loadCategory && prod.CategoryId.HasValue)
            {
                prod.Category = CatRepo.GetCategoryById(prod.CategoryId.Value);
            }
            return prod;
        }

        return null;
    }

     // Metod för att uppdatera en befintlig produkt
    public static void UpdateProduct(int productId, Product product)
    {
        if (productId != product.ProductId) return;

        var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
        if (productToUpdate != null)
        {
            // Uppdatera produktens egenskaper med de nya värdena och spara till json-filen
            productToUpdate.Name = product.Name;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
            SaveToJsonFile();
        }
    }

    // Metod för att radera en produkt från listan baserat på dess id
    public static void DeleteProduct(int productId)
    {
        var product = _products.FirstOrDefault(x => x.ProductId == productId);
        if (product != null)
        {
            _products.Remove(product);
            SaveToJsonFile();
        }
    }

}
