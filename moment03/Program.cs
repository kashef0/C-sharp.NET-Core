using moment03.methods;


namespace Name
{
    class Program
    {
        static void Main()
        {
            bool isCorrect = true;
            Console.WriteLine(@"
            Hej och välkomna till min gästbok. Här har du två olika alternativ:
            att lägga till ett inlägg i gästboken genom att ange namn och inlägg,
            att radera ett inlägg genom att ange siffran som står på vänster sida av gästnamnet.

                1. Skriv i gästboken
                2. Ta bort inlägg

                X. Avsluta 
            ");
            // En loop som fortsätter tills användaren gör ett korrekt val
            while (isCorrect)
            {
                Console.Write("Vänligen, välj ett val: ");
                string? numberOfCase = Console.ReadLine();
                // Kollar om användarens val är 1, 2 eller X (för att avsluta).
                if (numberOfCase == "1" || numberOfCase == "2" || numberOfCase?.ToLower() == "x")
                {
                    switch (numberOfCase)
                    {
                        case "1":
                            AddElement.AddGuest();
                            break;
                        case "2":
                            DeleteElement.DeleteGuest();
                            break;
                        case "x":
                            break;
                    }
                    isCorrect = false;
                }
                else
                {
                    Console.WriteLine("Vänligen, ange ett giltigt alternativ!");
                }

            }
        }

    }
}


