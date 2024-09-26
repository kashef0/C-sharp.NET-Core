using Newtonsoft.Json;

namespace moment03.methods;

public static class DeleteElement
{
    public static void DeleteGuest()
    {
        bool isReset = true;
        int inputUser; // Variabel för att lagra användarens val av id att radera.
        string filePath = "guestBook.json";
        List<Prop> guestBook = new List<Prop>();

        if (File.Exists(filePath))
        {
            string existingData = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingData))
            {
                guestBook = JsonConvert.DeserializeObject<List<Prop>>(existingData) ?? new List<Prop>();
            }

        }
        // en loop som fortsätter tills användaren har raderat ett inlägg eller avslutat.
        while (isReset)
        {
            foreach (var j in guestBook)
            {
                Console.WriteLine($"[{j.Id}] {j.guestName} - {j.posts}");
            }
            Console.Write("Vänligen, ange nummer på vilket gästnamn du vill ta bort: ");
            inputUser = Convert.ToInt32(Console.ReadLine());

            // söker efter objektet med det id som användaren angett 
            var itemRemove = guestBook.SingleOrDefault(r => r.Id == inputUser);
            // om objektet finns tas det bort från listan
            if (itemRemove != null && itemRemove.Id == inputUser)
            {
                // tar bort från listan
                guestBook.Remove(itemRemove);
                // serialiserar listan till JSON och uppdaterar filen.
                string guestString = JsonConvert.SerializeObject(guestBook, Formatting.Indented);
                File.WriteAllText(filePath, guestString);
                Console.WriteLine($"Gästnamnet med ID: {inputUser} har raderats!");
                foreach (var x in guestBook)
                {
                    Console.WriteLine($"[{x.Id}] {x.guestName} - {x.posts}");
                }
                // // frågar användaren om de vill fortsätta lägga till fler inlägg.
                isReset = NewTry.CheckedInput();

            }
            else
            {
                Console.WriteLine($"Gästnamnet med ID: {inputUser} hittades inte.");

            }
        }

    }
}
