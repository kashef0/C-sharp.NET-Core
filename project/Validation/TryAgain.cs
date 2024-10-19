using System;

namespace CSharp_Project.Validation;

public class TryAgain
{
    // Metod som meddelar användaren att de gjort ett ogiltigt val och ger dem tid att vänta innan de försöker igen
    public static void newTry()
    {
        Console.WriteLine("Ogiltigt värde, försök igen efter: 3 secunder");

        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
        Console.Clear();
        Console.WriteLine("Tryck på valfri tangent för att försöka igen\n");
    }
}
