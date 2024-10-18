using System;
using System.Runtime.CompilerServices;
using CSharp_Project.Models;
using Newtonsoft.Json;

namespace CSharp_Project.Repo;

public class CatRepo
{
    private const string filePath = "category.json";
    private static List<Category> _categories = new List<Category>();

    public static void ChechFileExist()
    {
        

        if (File.Exists(filePath))
        {
            string existingData = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingData))
            {
                // omvandlar json-data till en lista av Prop objekt.
                _categories = JsonConvert.DeserializeObject<List<Category>>(existingData) ?? new List<Category>();
            }

        }
    }

    public static void SaveToJsonFile()
    {
        string Json = JsonConvert.SerializeObject(_categories, Formatting.Indented);
            File.WriteAllText(filePath, Json);
    }

    public static void AddCategory(Category category)
    {
        var maxId = _categories.Max(x => x.CategoryId);
        category.CategoryId = maxId + 1;
        _categories.Add(category);
        SaveToJsonFile();
    }

    public static List<Category> GetCategories() => _categories;

    public static Category? GetCategoryById(int categoryId)
    {
        var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category != null)

            return new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };

        return null;
    }

    public static void UpdateCategory(int categoryId, Category category)
    {
        if (categoryId != category.CategoryId) return;

        var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
            SaveToJsonFile();
        }
    }

    public static void DeleteCategory(int category)
    {
        var cate = _categories.FirstOrDefault(x => x.CategoryId == category);
        if (cate != null)
            _categories.Remove(cate);
            SaveToJsonFile();
    }

}
