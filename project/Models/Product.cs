using System;
using System.ComponentModel.DataAnnotations;
using CSharp_Project.Validation;

namespace CSharp_Project.Models;
// productklass representerar en product
public class Product
{
    public int ProductId { get; set; }


    public int? CategoryId { get; set; }

    public string? Name { get; set; } = string.Empty;

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public Category? Category { get; set; }
}
