using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace CSharp_Project.Validation;

public class ProdVallation
{
    // Metod för att kontrollera om ett inmatat värde är ett giltigt nummer
    public static (string? input, bool IsChecked) CheckValue(string? input, bool IsValid)
    {
        while (IsValid)
        {

            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Du har angett tomt värde. ");
            }
            else if (!double.TryParse(input, out _))
            {
                Console.Write("Ogiltigt värde, vänligen. ");
            }
            else
            {
                IsValid = false;
            }
            if (IsValid)
            {
                Console.Write("Ange ett nummer: ");
                input = Console.ReadLine();

            }


        }
        return (input, IsValid);
    }
}
