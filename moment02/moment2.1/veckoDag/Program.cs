// See https://aka.ms/new-console-template for more information


namespace BirthDay
{
    class VeckoDag
    {
        static void Main()
        {
            int inputBirthDay, inputBirthMonth, inputBirthYear;
            Console.WriteLine("Ange dag, månad och år för det datum, du är intresserad av, \noch tryck på enter för att ta reda på vilken veckodag det var.\n");

            Console.Write("Vänligen ange din födelsedag (dag): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthDay)) {
                Console.WriteLine("Ogiltlig värde, vänligen ange dagen som siffra.)");
                return;
            } else if (inputBirthDay > 31|| inputBirthDay < 1) {
                Console.WriteLine("Ogiltig dag. Vänligen ange ett tal mellan 1 och 31.)");
                return;
            }

            Console.Write("Vänligen ange din födelsedag (månad): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthMonth)) {
                Console.WriteLine("Ogiltlig värde, vänligen ange månaden som siffra.");
                return;
            } else if (inputBirthMonth > 12|| inputBirthMonth < 1) {
                Console.WriteLine("Info: året har 12 månader. Vänligen ange ett tal mellan 1 och 12.)");
                return;
            }

            Console.Write("Vänligen ange din födelsedag (år): ");
            if (!int.TryParse(Console.ReadLine(), out inputBirthYear)) {
                Console.WriteLine("Vänligen ange året som nummer (1999)");
                return;
            } else if (Convert.ToString(inputBirthYear).Length != 4 || inputBirthYear > 2024) {
                Console.WriteLine("Du har angett ett fel format på året eller ogiltigt år.");
                return;
            }

            /*
            använde try catch för ändra format på dagen och månaden den kommer att 
            lägga till 0 före om dem minder än 10.
            */
            DateTime date;
            string newDayFormat = inputBirthDay.ToString("D2");
            string newMonthFormat = inputBirthMonth.ToString("D2");

            try {
                date = new DateTime(inputBirthYear, inputBirthMonth, inputBirthDay);
                Console.WriteLine($"Det angivna datumet är: {newDayFormat}-{newMonthFormat}-{inputBirthYear}");

            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Ogiltigt datum. Vänligen ange giltligt datum.");
            }


            Zellercongruence(inputBirthDay, inputBirthMonth, inputBirthYear);

            Console.Write("vill du countiune press ja else press no: ");
            
            
        }


        static void Zellercongruence(int day,
                    int month, int year)
        {
            if (month == 1)
            {
                month = 13;
                year--;
            }
            if (month == 2)
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
            switch (h)
            {
                case 0:
                    Console.WriteLine("Det var lördagen, Lördagsbarn ska mödorna trycka");
                    break;

                case 1:
                    Console.WriteLine(@"Det var söndagen, 
                    Söndagsbarn får leva och njuta rikt och vist och sedan berömligt sluta");
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

            Console.WriteLine(h);
        }

    }
}