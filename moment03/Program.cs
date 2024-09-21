// 

using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;


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
            while (isCorrect)
            {
                Console.Write("Vänligen, välj ett val: ");
                string? numberOfCase = Console.ReadLine();
                if (numberOfCase == "1" || numberOfCase == "2" || numberOfCase?.ToLower() == "x")
                {
                    switch (numberOfCase)
                    {
                        case "1":
                            AddGuest();
                            break;
                        case "2":
                            DeleteGuest();
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

        static void AddGuest()
        {
            bool isReset = true;
            do
            {
                string? inputName = null, inputPost = null;
                bool isValid = true;
                string filePath = "guestBook.json";
                List<Prop> guestBook = new List<Prop>();

                while (isValid)
                {
                    Console.Write("Ange gästname: ");
                    inputName = Console.ReadLine();
                    Console.Write("ange en post: ");
                    inputPost = Console.ReadLine();
                    inputName = string.IsNullOrEmpty(inputName) ? string.Empty : char.ToUpper(inputName[0]) + inputName.Substring(1);
                    inputPost = string.IsNullOrEmpty(inputPost) ? string.Empty : char.ToUpper(inputPost[0]) + inputPost.Substring(1);
                    // FirstCharToUpper(inputName, inputPost);
                    if (string.IsNullOrWhiteSpace(inputName) && string.IsNullOrWhiteSpace(inputPost))
                    {
                        Console.WriteLine("Vänligen, ange ett giltigt värde");
                    }
                    else if (int.TryParse(inputName, out int unm) && int.TryParse(inputPost, out int num1))
                    {

                        Console.WriteLine("Du har angett numeric, vänligen, ange ett giltigt värde");

                    }
                    else
                    {
                        isValid = false;
                    }
                }


                if (File.Exists(filePath))
                {
                    string existingData = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        guestBook = JsonConvert.DeserializeObject<List<Prop>>(existingData) ?? new List<Prop>();
                    }

                }

                int uniqueId = guestBook.Any() ? guestBook.Max(global => global.Id) + 1 : 1;
                Prop NameBook;
                if (!string.IsNullOrEmpty(inputName) && !string.IsNullOrEmpty(inputPost))
                {
                    NameBook = new Prop(inputName, inputPost, uniqueId);
                    guestBook.Add(NameBook);
                }


                string guestString = JsonConvert.SerializeObject(guestBook, Formatting.Indented);
                File.WriteAllText(filePath, guestString);

                for (int i = 0; i < guestBook.Count; i++)
                {
                    Console.WriteLine($"[{guestBook[i].Id}] {guestBook[i].guestName} - {guestBook[i].posts}");
                }
                Console.WriteLine("Data har lagts till gästboken");

                Console.Write("Vill du försätta? (ja/nej): ");
                string? input = Console.ReadLine()?.ToLower();
                if (input == "ja")
                {
                    isReset = true;
                }
                else if (input == "nej")
                {
                    isReset = false;
                }


            } while (isReset);

        }

        static void DeleteGuest()
        {
            bool isReset = true;
            int inputUser;
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
            while (isReset)
            {
                foreach (var j in guestBook)
                {
                    Console.WriteLine($"[{j.Id}] {j.guestName} - {j.posts}");
                }
                Console.Write("Vänligen, ange nummer på vilket gästnamn du vill ta bort: ");
                inputUser = Convert.ToInt32(Console.ReadLine());


                var itemRemove = guestBook.SingleOrDefault(r => r.Id == inputUser);
                if (itemRemove != null && itemRemove.Id == inputUser)
                {
                    guestBook.Remove(itemRemove);
                    string guestString = JsonConvert.SerializeObject(guestBook, Formatting.Indented);
                    File.WriteAllText(filePath, guestString);
                    Console.WriteLine($"Gästnamnet med ID: {inputUser} har raderats!");
                    foreach (var x in guestBook)
                    {
                        Console.WriteLine($"[{x.Id}] {x.guestName} - {x.posts}");
                    }
                    Console.Write("Vill du försätta? (ja/nej): ");
                    string? input = Console.ReadLine()?.ToLower();
                    if (input == "ja")
                    {
                        isReset = true;
                    }
                    else if (input == "nej")
                    {

                        isReset = false;
                    }

                }
                else
                {
                    Console.WriteLine($"Gästnamnet med ID: {inputUser} hittades inte.");

                }
            }

        }
    }
}


