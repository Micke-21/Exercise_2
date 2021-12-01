using System;
using System.Linq;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMeny = true;

            do
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Huvudmeny");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("Välj vad de vill göra genom att ange en siffra.");
                Console.WriteLine();
                Console.WriteLine("1. Ungdom elle pensionär.");
                Console.WriteLine("4. Beräkna pris för ett sällskap.");
                Console.WriteLine("2. Upprepa tio gånger");
                Console.WriteLine("3. Det tredje ordet");
                Console.WriteLine("0. Avsluta");
                Console.Write("Ange val ");
                string val = Console.ReadLine().Trim();

                switch (val)
                {
                    case "0":
                        showMeny = false;
                        //Environment.Exit(0);
                        break;
                    case "1": // Ungom eller pensionär
                        Console.Write("Ange din ålder ");

                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            if (age < 5)
                                Console.WriteLine("Ungdomspris: Gratis");
                            else if (age < 20)
                                Console.WriteLine("Ungdomspris: 80 kr");
                            else if (age > 64 && age < 101)
                                Console.WriteLine("Pensionärspris: 90 kr");
                            else if (age > 100)
                                Console.WriteLine("Pensionärspris: Gratis");
                            else
                                Console.WriteLine("Standardpris 120 kr");
                        }
                        else
                        {
                            Console.WriteLine("Du angav inte en ålder.");
                        }
                        Console.WriteLine();
                        break;

                    case "4": //  Pris för helt sällskap
                        int totalCost = 0;
                        Console.WriteLine("Hur många är ni som vill gå på bio? ");
                        if (int.TryParse(Console.ReadLine(), out int antBes))
                        {
                            for (int i = 0; i < antBes; i++)
                            {
                                Console.Write("Ange ålder för besökare {0} ", i + 1);
                                if (int.TryParse(Console.ReadLine(), out int ageN)) // under 5 och över 100 gratis
                                {
                                    if (ageN >= 5 && ageN < 20)             // 5 to 19 Ungdom
                                        totalCost += 80;
                                    else if (ageN > 64 && ageN < 101)       // 65 to 100 Pensionär
                                        totalCost += 90;
                                    else if (ageN <= 64 && ageN >= 20)      // 20 to 64 Stantadpris
                                        totalCost += 120;
                                }
                                else
                                {
                                    Console.WriteLine("Felaktig angiven ålder");
                                    i--;
                                }
                            }
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Totalkostnaden för sällskapet på {0} personer blir {1} kr.\n", antBes, totalCost);
                        break;
                    case "2": // Upprepa tio gånger
                        Console.WriteLine("Ange en godtycklig text. ");
                        string myText = Console.ReadLine();
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write($"{i + 1} {myText}");
                        }
                        Console.WriteLine();
                        break;
                    case "3": // Det treje ordet
                        Console.WriteLine("Ange en mening på minst tre ord");
                        string mySentence = Console.ReadLine();
                        
                        string[] myWords = mySentence.Trim().Split(" ");
                        myWords = myWords.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // remove the blanks in the array
                        if (myWords.Length < 3)
                        {
                            Console.WriteLine("Det måste var minst tre ord i meningen!");
                        }
                        else
                        {
                            Console.WriteLine($"Det tredje ordet i meningen är \"{myWords[2]}\".");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Felaktigt val ");
                        break;
                }

            } while (showMeny);


        }
    }
}
