// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

namespace CheckGender 
{
    public class Program {
        static void Main(string[] args) {
        string? IsMale;
        Console.Write("Please enter your gender (male or female): ");
        IsMale = Console.ReadLine();

        if(double.TryParse(IsMale, out double Number)) 
        {
            Console.WriteLine("you should enter your gnder not a number");
        } else 
        {
        if (IsMale?.GetType() == typeof(string)) {
            if (IsMale?.ToLower() == "male") {
                Console.WriteLine("You are male.");
            } else if (IsMale?.ToLower() == "female") {
                Console.WriteLine("You are female.");
            } else {
                Console.WriteLine("Please enter a valid gender (male or female).");
            }
        } else {
            Console.WriteLine("Please enter a valid gender as a string.");
        }

        }

    }
    }
    
}



