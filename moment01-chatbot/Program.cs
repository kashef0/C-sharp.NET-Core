// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Reflection;

// public class Program {
//     static void Main(string[] args)
//     {
//         double heightInMeters = 1.88;
//         Console.WriteLine($"the variables {nameof(heightInMeters)} has the value {heightInMeters}");
//         // Console.WriteLine("Temperature on {0:D} is {1}°C.", DateTime.Today, 23.4);
//     }
        
// }

public class NewProgram {
    static void Main() 
    {
        dynamic anotherName = "ahmad";
        int length = anotherName.Length;
        Console.WriteLine(length);
        decimal c = 0.5M; // M suffix means a decimal literal value
        decimal d = 0.2M;
        if (c + d < 0.3M)
        {
        Console.WriteLine($"{c} + {d} is smallar than 0.3M");
        
        }
        else
        {
        Console.WriteLine($"{c} + {d} is bigger than 0.3M");
        }
    }
}