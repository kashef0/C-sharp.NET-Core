
                                                // CHATBOT PROGRAM

// den koden som jag skrev skapar ett enkelt chatbot program som kan utföra några saker och beräkningar
// t.ex. att konvertera fot till meter, F till C och ge info om datum och tid.


// definiera området ChatBot
namespace ChatBot
{
    class Program
    {
    static void Main(string[] args)
    {

    // definiera boolean variable för att jämföra sen om program kommer att köras eller inte
    bool restartChatBot = true;

    // do while forloop för att program försätter körs så länge restartChatBot är true
    do {
        // art text som kopierade från (https://www.asciiart.eu/electronics/robots)
        // @ tecken för att skapa verbatim string literals
        Console.WriteLine(@"
       _______
     _/       \_
    / |       | \
   /  |__   __|  \
  |__/((o| |o))\__|
  |      | |      |
  |\     |_|     /|
  | \           / |
   \| /  ___  \ |/
    \ | / _ \ | /    Hej! 
     \_________/
      _|_____|_
 ____|_________|____
/                   \");


        string? name;
        
        Console.WriteLine("Välkomna, Jag är Robotik");
        Console.Write("vad heter du? ");
        name = Console.ReadLine();
        // kontrollera om angiven värde konverterad till int
        if(double.TryParse(name, out double number)) {
            Console.WriteLine($"Please enter your name not a {number}");
        } else {
            Console.WriteLine($"Hej {name}, välj vad du vill göra: ");
        }

        Console.WriteLine(@"
            1. konvertera feet till meter
            2. konvertera från F till C
            3. datum och tiden just nu
        ");

        string? NumberCase, case1, case2;
        Console.Write("välj ett altrnativ 1, 2 eller 3? ");
        // läsa användarens input och lagrar det i varibel
        NumberCase = Console.ReadLine();
        int convertedNumberCase;
        
        // kontrollera om NumberCase är null och konvertera till intger
        if (int.TryParse(NumberCase ?? "", out convertedNumberCase)) {
            if (convertedNumberCase > 3 || convertedNumberCase < 1) {
                Console.WriteLine($"Du har angett {convertedNumberCase}, Vänligen ange ett giltigt nummer");
            } else {
                // switch stas för att völja case beroende på användarens val
                switch (Convert.ToInt32(NumberCase)) {
                    case 1:
                        Console.Write("Vänligen, Ange antal fot? ");
                        case1 = Console.ReadLine();
                        //avrundar ett tal till ett visst antal decimaler
                        Console.WriteLine(Math.Round(Convert.ToDouble(case1)/3.2808, 2) + " meter");
                        break;
                    case 2:
                        Console.Write("Vänligen, Ange en temperatur i Fahrenheit? ");
                        case2 = Console.ReadLine();
                        Console.WriteLine(Math.Round(Convert.ToDouble(case2) - 32 / 1.8000, 2) + "°C");
                        break;
                    case 3:
                        Console.WriteLine(string.Format("Datum och tid på {0:D}, {0:HH:mm:ss}.", DateTime.Now));
                        break;
                }
            }
        } else {
            Console.WriteLine("Ogiltig inmatning. Ange ett giltigt heltal");
        }
        // starta om program beroende på användarens val
        Console.WriteLine("Vill du starta om chatbot? (ja/nej)");
        string? restartChat = Console.ReadLine()?.ToLower();
        restartChatBot = restartChat == "ja";
    } while (restartChatBot);

    Console.WriteLine("Tack för att du använde Robotik!");
    }

    }

}