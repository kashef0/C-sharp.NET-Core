using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Project.Models;
// transaktion  klass representerar en transaktion 
public class Transaction
{
    public int TransactionId { get; set; }
    public DateTime Timestamp { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public double Price { get; set; }
    public int BeforeQty { get; set; }
    public int SoldQty { get; set; }

    [Required]
    public string CashierName { get; set; } = "";

    internal string Sum(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}
