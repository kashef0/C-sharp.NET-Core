// C# program för att hitta dagen för datum


using System.Resources;

namespace BirthDay
{
    class VeckoDag
    {
        static void Main()
        {
            bool inputReset = true;
            string? inputResetValue;
            
            Console.WriteLine("Ange dag, månad och år för det datum, du är intresserad av, \noch tryck på enter för att ta reda på vilken veckodag det var.\n");
            do {
            int inputBirthDay, inputBirthMonth, inputBirthYear;
            
            do {
            Console.Write("Vänligen ange födelsedag (dag): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthDay)) {
                Console.WriteLine("Ogiltlig värde, vänligen ange dagen som siffra.)");
            
            } else if (inputBirthDay < 1|| inputBirthDay > 31) {
                Console.WriteLine("Ogiltig dag. Vänligen ange ett tal mellan 1 och 31.)");
                
            }
            } while(inputBirthDay < 1|| inputBirthDay > 31);
            
            do {
            Console.Write("Vänligen ange födelsedag (månad): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthMonth)) {
                Console.WriteLine("Ogiltlig värde, vänligen ange månaden som siffra.");
            } else if (inputBirthMonth > 12|| inputBirthMonth < 1) {
                Console.WriteLine("Info: året har 12 månader. Vänligen ange ett tal mellan 1 och 12.)");
            }
            } while(inputBirthMonth > 12|| inputBirthMonth < 1);

            do {

            Console.Write("Vänligen ange födelsedag (år): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthYear)) {
                Console.WriteLine("Vänligen ange året som nummer (1999)");
            } else if (Convert.ToString(inputBirthYear).Length != 4 || inputBirthYear > 2024) {
                Console.WriteLine("Du har angett ett fel format på året eller ogiltigt år.");
            }
            } while(Convert.ToString(inputBirthYear).Length != 4 || inputBirthYear > 2024);

            /*
            använde try catch för ändra format på dagen och månaden den kommer att 
            lägga till 0 före om dem minder än 10.
            */
            DateTime date;

            bool ISDate = true;
            try {
                date = new DateTime(inputBirthYear, inputBirthMonth, inputBirthDay);
                // Console.WriteLine($"\nDet angivna datumet är: {newDayFormat}-{newMonthFormat}-{inputBirthYear} eller {nameOfDay}/{nameOfMonth}/{inputBirthYear}");

            } catch (ArgumentOutOfRangeException) {
                
                ISDate = false;
            }

            if (ISDate) {
                date = new DateTime(inputBirthYear, inputBirthMonth, inputBirthDay);
                Console.WriteLine($"\nDet angivna datumet är: {date.ToString("dd/MM/yyyy")} är en giltig datum och var på en {date.Day}/{date.Month}/{date.Year}.");
            } else {
                Console.WriteLine("Ogiltigt datum. Vänligen ange giltligt datum.");
            }


            Zellercongruence(inputBirthDay, inputBirthMonth, inputBirthYear);

            Console.Write("Vill du försätta skriv (ja/nej)? ");
            inputResetValue = Console.ReadLine()?.ToLower();

            if (inputResetValue == "ja") {
                Console.WriteLine("ett nytt försök!");
            } else if (inputResetValue == "nej") {
                inputReset = false;
                Console.WriteLine("Välkona tillbaka!");
            }
            } while(inputReset);
            
        }

        // Zeller’s Congruence
        // det är alogritm för att hitta veckodagen för vilken datum
        static void Zellercongruence(int day,
                    int month, int year)
        {
            if (month == 1) {
                month = 13;
                year--;
            } else if (month <= 2)
            {
                month = 14;
                year--;
            } 
            int q = day;
            int m = month;
            int k = year % 100;
            int j = year / 100;
            int h = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            h = h % 7;

            // skriva ut dagen för datum enligt användaren input ovan
            switch (h)
            {
                case 0:
                    Console.WriteLine("Det var lördagen, Lördagsbarn ska mödorna trycka");
                    break;

                case 1:
                    Console.WriteLine("Det var söndagen, Söndagsbarn får leva och njuta rikt och vist och sedan berömligt sluta");
                    break;

                case 2:
                    Console.WriteLine("Det var måndagen, Måndagsbarn har fagert skinn");
                    break;

                case 3:
                    Console.WriteLine("Det var tisdagen, Tisdagsbarn har älskligt sinn");
                    break;

                case 4:
                    Console.WriteLine("Det var onsdagen, Onsdagsbarn är fött till ve");
                    break;

                case 5:
                    Console.WriteLine("Det var torsdagen, Torsdagsbarn får mycket se");
                    break;

                case 6:
                    Console.WriteLine("Det var fredagen, Fredagsbarn får kärlek och lycka");
                    break;
            }
        }

    }
}