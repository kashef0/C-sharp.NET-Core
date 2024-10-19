using System;
using System.Security.Cryptography.X509Certificates;
using ConsoleTables;
using CSharp_Project.Repo;

namespace CSharp_Project.Validation;

public class TableForm
{

    // Metod för att skapa en dynamisk meny baserat på de argument som skickas in
    public static void UiApp(string? menu, string? one, string? two, string? three, string? four, string? five)
    {
        Console.Clear();

        Console.WriteLine("===================================");
        Console.WriteLine($"         {menu}                   ");
        Console.WriteLine("===================================");
        Console.WriteLine($"1. {one}");
        Console.WriteLine($"2. {two}");
        Console.WriteLine($"3. {three}");
        // Kontrollera om det femte valet (five) är tomt eller null
        if (!string.IsNullOrEmpty(five))
        {
            Console.WriteLine($"4. {four}");
            Console.WriteLine($"0. {five}");
        }
        else
        {
            Console.WriteLine($"0. {four}");
        }
        Console.WriteLine("===================================");
        Console.Write("Välj ett alternativ: ");

    }

}
