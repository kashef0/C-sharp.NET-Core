using Newtonsoft.Json;
using moment03;

namespace moment03.methods;

public static class AddElement
{
    public static void AddGuest()
    {
        bool isReset = true;
        do
        {
            string? inputName = null, inputPost = null;
            bool isValid = true;
            string filePath = "guestBook.json"; // Filvägen till JSON-filen
            List<Prop> guestBook = new List<Prop>();  // Skapar en lista av typen Prop som används för att lagra gäster och poster.

            while (isValid)
            {
                Console.Write("Ange gästname: ");
                inputName = Console.ReadLine()?.FirstCharToUpper();  // class för att ändra första bokstaven i namn och inlägg till stora bokstavet om strängen inte är tom. 
                Console.Write("ange en post: ");
                inputPost = Console.ReadLine()?.FirstCharToUpper();


                // Kollar om både namn och post är tomma.
                if (string.IsNullOrWhiteSpace(inputName) && string.IsNullOrWhiteSpace(inputPost))
                {
                    Console.WriteLine("Vänligen, ange ett giltigt värde");
                }
                // Kollar om både namn och post är int.
                else if (int.TryParse(inputName, out int num) && int.TryParse(inputPost, out int num1))
                {

                    Console.WriteLine("Du har angett numeric, vänligen, ange ett giltigt värde");

                }
                else
                {
                    isValid = false;
                }
            }

            // kollar om json-filen existerar och läser in dess data.
            if (File.Exists(filePath))
            {
                string existingData = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    // omvandlar json-data till en lista av Prop objekt.
                    guestBook = JsonConvert.DeserializeObject<List<Prop>>(existingData) ?? new List<Prop>();
                }

            }
            // Genererar ett unikt id genom att ta det högsta id som finns och öka det med 1.
            int uniqueId = guestBook.Any() ? guestBook.Max(global => global.Id) + 1 : 1;
            Prop NameBook;
            if (!string.IsNullOrEmpty(inputName) && !string.IsNullOrEmpty(inputPost))
            {
                // skapar ett nytt Prop objekt med namn, post och id.
                NameBook = new Prop(inputName, inputPost, uniqueId);
                guestBook.Add(NameBook); // lägger till objektet i listan
            }

            // serialiserar listan till json och sparar den i filen.
            string guestString = JsonConvert.SerializeObject(guestBook, Formatting.Indented);
            File.WriteAllText(filePath, guestString);

            for (int i = 0; i < guestBook.Count; i++)
            {
                Console.WriteLine($"[{guestBook[i].Id}] {guestBook[i].guestName} - {guestBook[i].posts}");
            }
            Console.WriteLine("Data har lagts till gästboken");

            // // frågar användaren om de vill fortsätta lägga till fler inlägg.
            isReset = NewTry.CheckedInput();



        } while (isReset);

    }
}
