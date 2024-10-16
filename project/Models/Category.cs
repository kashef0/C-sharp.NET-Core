using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Project.Models;
// Kategoriklass representerar en kategori
public class Category
{
    public int CategoryId { get; set; }

    [Required]
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}
