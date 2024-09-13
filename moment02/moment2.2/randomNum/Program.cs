
/* Information: 1. I terminalen skriv dotnet och ett av följande altrnativ (stigande, fallande eller random)
                2. Efter första steget visas ett meddelande som frågar hur många element du vill generera 
*/

using System;
using System.Diagnostics;

namespace RandomNumber
{
    class MyProgram
    {
        static void Main(string[] args)
        {
            int numberOfItems;
            var rand = new Random(); // generera slumpmässiga tal
            bool ISReset = true;
            /* do - while kontrollera att koden ska köras 
             en gång innan en fråga visar upp till användaren om vill försätt */
            if (args == null || args.Length == 0)
            {
                args = new string[] { "ingenting" };
                Console.WriteLine($"du har angett {args[0]}, vänligen ange 'dotnet run' med ett av följande altrnativ (stigande, fallande eller random)");
                    return;
            }
            else if (args.Length > 0)
            {

                if (args[0] == "stigande" || args[0] == "fallande" || args[0] == "random")
                {
                    Console.Write("hur många sffror från (1-100) vill du att skriva ut: ");
                }
                else
                {
                    Console.WriteLine($"du har angett {args[0]}, vänligen ange 'dotnet run' med ett av följande altrnativ (stigande, fallande eller random)");
                    return;
                }
            }
            do
            {

                numberOfItems = Convert.ToInt32(Console.ReadLine());
                if (numberOfItems < 1 || numberOfItems > 100)
                {
                    Console.WriteLine("ange sifra mellan 1 och 100");
                    return;
                }
                Console.WriteLine("\n");
                // Generera och visa random integer värde som användaren anger .
                int[] arrayOfNumbers = new int[numberOfItems];
                for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
                    arrayOfNumbers[i] = rand.Next(1, 100);
                }
                args = args.Select(s => s.ToLower()).ToArray();

                if (args.Length > 0)
                {
                    // Tidsmätning för Array Sorting och ManuelSorting
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Sorting(arrayOfNumbers, args[0]);  // Sortera med inbyggda metoder
                    stopwatch.Stop();
                    Console.WriteLine($"Array Sorting-metoder RunTime: {FormatTime(stopwatch.Elapsed)}\n");

                    // Tidsmätning för ManuelSorting-metoden
                    stopwatch.Restart();
                    ManuelSorting(arrayOfNumbers, args[0]); // Sortera manuellt
                    stopwatch.Stop();
                    Console.WriteLine($"ManuelSorting-metoder RunTime: {FormatTime(stopwatch.Elapsed)}\n");
                }

                // do - while loop kontrollera att användaren anger ja eller nej
                string userResetInput;
                do
                {
                    Console.Write("om du vill försätta tryck Ja annars Nej: ");
                    //  Lagra användarens angivna värde, omvandla till små bokstäver och sätt ett standardvärde
                    userResetInput = Console.ReadLine()?.ToLower() ?? "ja";
                    // if stat för felhantering
                    if (userResetInput == "ja")
                    {
                        ISReset = true;
                        Console.Write("hur många sffror från (1-100) vill du att skriva ut: ");
                        break;
                    }
                    else if (userResetInput == "nej")
                    {
                        ISReset = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Ingen inmatning angavs eller du angett {userResetInput}.");
                    }

                } while (true);

                // funktionen som sorterar talen från störst till minst
                static void ManuelSorting(int[] num, string IsSorted)
                {
                    int[] numberArr = new int[num.Length];
                    // kopiera den gammla array till en ny array
                    Array.Copy(num, numberArr, numberArr.Length);
                    string meddelande = "";
                    for (int i = 0; i < num.Length; i++)
                    {
                        for (int j = 0; j < numberArr.Length - 1; j++)
                        {
                            if (IsSorted == "fallande")
                            {
                                if (numberArr[j] < numberArr[j + 1])
                                {
                                    int temp = numberArr[j];
                                    numberArr[j] = numberArr[j + 1];
                                    numberArr[j + 1] = temp;
                                }
                                meddelande = "Arryen har sorterat fallande manuelt: ";
                            }
                            else if (IsSorted == "stigande")
                            {
                                if (numberArr[j] > numberArr[j + 1])
                                {
                                    int temp = numberArr[j];
                                    numberArr[j] = numberArr[j + 1];
                                    numberArr[j + 1] = temp;
                                }
                                meddelande = "Arryen har sorterat stigande manuelt: ";
                            }
                            else
                            {
                                meddelande = "Arryen har sorterat slumpmäsigt manuelt: ";
                            }
                        }
                    }
                    Console.WriteLine(meddelande);
                    Console.Write("{");
                    foreach (int number in numberArr)
                        Console.Write("{0, 3}", number);
                    Console.WriteLine(" }");

                }
                //funktionen sorterar element stigande och fallande via användning av sort och reverse metod 
                static void Sorting(int[] number, string IsSorted)
                {
                    if (IsSorted == "stigande")
                    {
                        Array.Sort(number);
                        Console.WriteLine("Arryen har sorterat stigande via användning av sort metod: ");
                    }
                    else if (IsSorted == "fallande")
                    {
                        Array.Sort(number);
                        Array.Reverse(number);
                        Console.WriteLine("Arryen har sorterat fallande via användning av sort metod: ");
                    }
                    else if (IsSorted == "random")
                    {
                        Console.WriteLine("Arryen har sorterat slumpmässig sortering: ");
                    }
                    Console.Write("{");
                    foreach (int intValue in number)
                        Console.Write("{0,3}", intValue);
                    Console.WriteLine(" }");
                }

            } while (ISReset);
            {
                Console.WriteLine("Välkomna tillbaka!");
            }
            // funktionen som formatera tider från stopWatch
            static string FormatTime(TimeSpan ts)
            {
                return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            }
        }
    }
}
