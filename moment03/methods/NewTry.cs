using System;

namespace moment03;

public static class NewTry
{
    public static bool CheckedInput()
    {

        bool isReset = false;
        bool isValid = false;
        while (!isValid)
        {
            // frågar användaren om de vill fortsätta lägga till fler inlägg.
                Console.Write("Vill du försätta? (ja/nej): ");
                string? input = Console.ReadLine()?.ToLower();
            if (input == "ja")
            {
                Console.WriteLine("Du valse att försätta.");
                isValid = true;
                isReset = true;
            }
            else if (input == "nej")
            {
                Console.WriteLine("Du valse att avsluta.");
                isValid = true;
                isReset = false;
            } else {
                Console.WriteLine("Ogiltigt värde, vänligen ange (ja/nej)");
                
            }
        } 
            return isReset;
            
    }
}