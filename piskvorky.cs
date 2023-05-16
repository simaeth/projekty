//Checkers made by Simon Skala, i used a existing code from leet code, chat gpt, my knowledge and something that i found on github
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dáma
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Hra();
        }
    }

    public class Checker
    {
        public string Symbol { get; }
        public int[] Pozice { get; set; }
        public string Barva { get; }

        public Checker(string barva, int[] pozice)
        {
            int circleId;

            if (barva == "bila")
            {
                circleId = int.Parse("25CE", System.Globalization.NumberStyles.HexNumber);
                Barva = "bila";
            }
            else
            {
                circleId = int.Parse("25C9", System.Globalization.NumberStyles.HexNumber);
                Barva = "cerna";
            }

            Symbol = char.ConvertFromUtf32(circleId);
            Pozice = pozice;
        }
    }

    public class Deska
    {
        public string[][] Grid { get; set; }
        public List<Checker> Checkers { get; set; }

        public Deska()
        {
            Checkers = new List<Checker>();
            CreateDeska();
        }

        private void CreateDeska()
        {
            Grid = new string[][]
            {
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "}
            };
        }

        public void GenerateCheckers()
        {
            int[][] bilePozice = new int[][]
            {
                new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0,  5 }, new int[] { 0, 7 },
                new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1,  4 }, new int[] { 1,  6 },
                new int[] { 2, 1 }, new int [] { 2, 3 }, new int[] { 2,  5 }, new int[] { 2, 7}
            };

            int[][] cernePozice = new int[][]
            {
                new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5,  6 },
                new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 },
                new int[] { 7, 0 }, new int[] { 7, 2 }, new int [] { 7, 4 }, new int[] { 7,  6 }
            };

            for (int i = 0; i < 12; i++)

            {
                Checker bila = new Checker("bila", bilePozice[i]);
                Checker cerna = new Checker("cerna", cernePozice[i]);
                Checkers.Add(bila);
                Checkers.Add(cerna);
            }
            return;
        }
        //Pokud nemate Visual Studio 2019 a starsi tak pravdepodobne budete mit misto kolecek otazniky na desce


        public void PlaceCheckers()
        {
            foreach (var dama in Checkers)
            {

                this.Grid[dama.Pozice[0]][dama.Pozice[1]] = dama.Symbol;
            }
            return;
        }


        public void DrawBoard()
        {
            CreateDeska();
            PlaceCheckers();
            Console.WriteLine("  0 1 2 3 4 5 6 7 ");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + " " + String.Join(" ", this.Grid[i]));
            }
            return;
        }


        public Checker SelectChecker(int radek, int sloupec)
        {
            return Checkers.Find(x => x.Pozice.SequenceEqual(new List<int> { radek, sloupec }));
        }


        public void RemoveChecker(Checker dama)
        {
            Checkers.Remove(dama);
            return;
        }

        //tady je BOOL
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Barva == "bila") || !Checkers.Exists(x => x.Barva == "bila");
        }
    }
    //bílý


    public class Hra
    {
        public Hra()
        {
            Deska deska = new Deska();
            deska.GenerateCheckers();
            deska.DrawBoard();

            Console.WriteLine("\nPokud chcete damu posunout o jedno pole vpřed, zadejte 'posunuti'.");
            Console.WriteLine("\nPokud je pro jednu z vašich dam k dispozici skok, musíte zadat 'skocit'.");

            string moznost = Console.ReadLine();

            do
            {
                switch (moznost)
                {
                    case "posunuti":

                        Console.WriteLine("Chcete-li se přesunout, zadejte radek:");
                        int radek = int.Parse(Console.ReadLine());
                        Console.WriteLine("Zadejte sloupec:");
                        int sloupec = int.Parse(Console.ReadLine());

                        if (deska.SelectChecker(radek, sloupec) != null)
                        {
                            Checker dama = deska.SelectChecker(radek, sloupec);
                            Console.WriteLine("Přesunout do kterého radku?: ");
                            int newRadek = int.Parse(Console.ReadLine());
                            Console.WriteLine("Přesunout do kterého sloupce?: ");
                            int newSloupec = int.Parse(Console.ReadLine());
                            dama.Pozice = new int[] { newRadek, newSloupec };
                            deska.DrawBoard();
                        }
                        else
                        {
                            Console.WriteLine("Neplatný input (nevím jak to prelozit)");
                            Console.WriteLine("Zadejte platný radek:");
                            radek = int.Parse(Console.ReadLine());
                            Console.WriteLine("Zadejte platný sloupec:");
                            sloupec = int.Parse(Console.ReadLine());
                        }
                        break;

                    case "skocit":

                        Console.WriteLine("Vyberte radek, který chcete odstranit:");
                        int removeRadek = int.Parse(Console.ReadLine());
                        Console.WriteLine("Vyberte sloupec, který chcete odstranit:");
                        int removeSloupec = int.Parse(Console.ReadLine());
                        Checker changeDama = deska.SelectChecker(removeRadek, removeSloupec);
                        deska.RemoveChecker(changeDama);
                        deska.DrawBoard();
                        break;

                    default:

                        Console.WriteLine("Neplatný input (nevím jak to prelozit)");
                        break;
                }
            }
            while (deska.CheckForWin() != true);
        }
    }
}