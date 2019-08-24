using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    enum CardName
    {
        Jeck = 2,
        Lady = 3,
        King = 4,
        Six = 6,
        Sevem = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Ace = 11

    }
    enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    struct Computer
    {
        public int PlayComputer(Card[] cards, Random rmd, int pointPlayer)
        {
            Card[] cardsComputer = new Card[6];
            int indexCardsComputer = 0;
            int points = 0;
            bool continueGivCard = true;
            int counterAces = 0;

            do
            {
                if (cardsComputer[indexCardsComputer].CardValue == 11)
                {
                    counterAces++;
                    if (counterAces > 1)
                    {
                        Console.WriteLine("You win!");
                        points = 21;
                        break;
                    }
                }
                cardsComputer[indexCardsComputer] = cards[rmd.Next(0, cards.Length)];
                points += cardsComputer[indexCardsComputer].CardValue;

                indexCardsComputer++;

                if (pointPlayer > 21)
                {
                    Console.WriteLine($"Computer have: {points} points");
                    continueGivCard = false;
                }

                if (indexCardsComputer > 1 && points > 15)
                {
                    Console.WriteLine($"Computer have: {points} points");
                    Console.WriteLine();
                    continueGivCard = false;
                }

            } while (continueGivCard);

            return points;
        }
    }
    struct Pleyer
    {
        public int Play(Card[] cards, Random rmd)
        {
            Card[] cardsInHand = new Card[6];

            bool continueGiveCard = true;
            int points = 0;
            int indexCardInHand = 0;
            int counterAces = 0;

            Console.Write("Your card: ");
            do
            {
                if (cardsInHand[indexCardInHand].CardValue == 11)
                {
                    counterAces++;
                    if (counterAces > 1)
                    {
                        Console.WriteLine("You win!");
                        points = 21;
                        break;
                    }
                }

                cardsInHand[indexCardInHand] = cards[rmd.Next(0, cards.Length)];
                points += cardsInHand[indexCardInHand].CardValue;

                Console.Write($"{ cardsInHand[indexCardInHand].Name},{ cardsInHand[indexCardInHand].Suit} ");
                indexCardInHand++;


                if (indexCardInHand > 1)
                {
                    Console.WriteLine($"\nYou have: {points} piints");
                    Console.WriteLine("Do you whont continue?\n\tPres Y (yes) / N (No)");

                    ConsoleKey keyToContinue;
                    bool keyForGivCard = true;

                    do
                    {
                        keyToContinue = Console.ReadKey().Key;
                        if (keyToContinue != ConsoleKey.Y && keyToContinue != ConsoleKey.N)
                        {
                            Console.WriteLine("\nYou entered an unknown letter!Try Again!");
                            keyForGivCard = true;
                        }
                        else if (keyToContinue == ConsoleKey.Y)
                        {
                            keyForGivCard = false;
                        }
                        else if (keyToContinue == ConsoleKey.N)
                        {
                            continueGiveCard = false;
                            keyForGivCard = false;
                        }
                    } while (keyForGivCard);
                    Console.WriteLine();
                }
            } while (continueGiveCard);

            return points;
        }
    }
    struct Card
    {
        public string Name;
        public int CardValue;
        public string Suit;
    }
    class Program
    {
        public static bool WhooWins(int player, int computer)
        {
            bool rez = true;
            if (player <= 21 & computer <= 21)
            {
                if (player > computer)
                {
                    Console.WriteLine("Playaer Win!");
                    rez = true;
                }
                else if (player < computer)
                {
                    Console.WriteLine("Computer Win!");
                    rez = false;
                }
                else
                {
                    Console.WriteLine("The score is equal, but according to the rules the player wins! :)");
                    rez = true;
                }
            }
            else if (player > 21 & computer > 21)
            {
                if (player < computer)
                {
                    Console.WriteLine("Playaer Win!");
                    rez = true;
                }
                else if (player > computer)
                {
                    Console.WriteLine("Computer Win!");
                    rez = false;
                }
                else
                {
                    Console.WriteLine("The score is equal, but according to the rules the player wins! :)");
                    rez = true;
                }
            }
            else if (player <= 21 & computer > 21)
            {
                Console.WriteLine("Player Win!");
                rez = true;
            }
            else if (player > 21 & computer <= 21)
            {
                Console.WriteLine("Computer Win!");
                rez = false;

            }

            return rez;
        }
        static void Main(string[] args)
        {
            Card[] cards = new Card[36];            //creating a deck of cards
            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                string cardSuit = ((CardSuit)i).ToString();

                for (int j = 2; j <= 11; j++)
                {
                    if (j == 5)
                    {
                        continue;
                    }
                    string cardName = ((CardName)j).ToString();
                    int cardValue = (int)((CardName)j);

                    cards[index].Suit = cardSuit;
                    cards[index].Name = cardName;
                    cards[index].CardValue = cardValue;
                    index++;
                }
            }

            bool repeatGame = true;
            int winsPlayer = 0;
            int winsComputer = 0;

            do
            {
                Console.WriteLine("Hi! Velcome to Siml card game \"21\"! \nLet's determine who will start:\nClick E(for Eagle) or T(for Tails)!");

                bool again = true;                         //input validation    
                ConsoleKey key;

                do
                {
                    key = Console.ReadKey().Key;

                    if (key != ConsoleKey.E && key != ConsoleKey.T)
                    {
                        Console.WriteLine("You entered an unknown letter!Try Again!");
                        again = true;
                    }
                    else
                    {
                        again = false;
                    }

                } while (again);
                Console.WriteLine();

                bool whoStarts = true;
                Random rmd = new Random();                             //determining who will start the game
                int num = rmd.Next(1, 35);
                if (num % 2 == 0)
                {
                    Console.WriteLine("Tails fell out!");

                    if (key == ConsoleKey.T)
                    {
                        Console.WriteLine("You began!\n\tPress any key to continue.....");

                    }
                    else
                    {
                        Console.WriteLine("Computer Begain!\nPress any key to continue.....");
                        whoStarts = false;
                    }
                }
                else
                {
                    Console.WriteLine("Eagle fell out!");

                    if (key == ConsoleKey.E)
                    {
                        Console.WriteLine("You began!\nPress any key to continue.....");
                    }
                    else
                    {
                        Console.WriteLine("Computer Begain!\nPress any key to continue.....");
                        whoStarts = false;
                    }
                }
                Console.ReadKey();
                Console.Clear();



                Pleyer pleyer = new Pleyer();
                Computer computer = new Computer();

                int pointsPleyerStartFirst = 0;
                int pointsComputerStartFirst = 0;
                int pointsComputerStartSecond = 0;
                int pointsPleyerStartSecond = 0;
                bool forWins = true;


                switch (whoStarts)
                {
                    case true:
                        pointsPleyerStartFirst = pleyer.Play(cards, rmd);
                        pointsComputerStartFirst = computer.PlayComputer(cards, rmd, pointsComputerStartFirst);

                        forWins = WhooWins(pointsPleyerStartFirst, pointsComputerStartFirst);
                        break;
                    case false:
                        pointsComputerStartSecond = computer.PlayComputer(cards, rmd, pointsComputerStartSecond);
                        pointsPleyerStartSecond = pleyer.Play(cards, rmd);

                        WhooWins(pointsPleyerStartSecond, pointsComputerStartSecond);
                        break;
                }



                if (forWins)
                {
                    winsPlayer++;
                }
                else
                {
                    winsComputer++;
                }

                Console.WriteLine("\nDo you want to start new game?\n\tPres Y(yes)/N(no) ");

                bool repeatInput = true;

                ConsoleKey keyForContnueGame;

                do
                {
                    keyForContnueGame = Console.ReadKey().Key;

                    if (keyForContnueGame != ConsoleKey.Y && keyForContnueGame != ConsoleKey.N)
                    {
                        Console.WriteLine("You entered an unknown letter!Try Again!");
                        repeatInput = true;
                    }
                    else if (keyForContnueGame == ConsoleKey.Y)
                    {
                        repeatInput = false;
                    }
                    else if (keyForContnueGame == ConsoleKey.N)
                    {
                        repeatInput = false;
                        repeatGame = false;
                    }

                } while (repeatInput);

                Console.Clear();

            } while (repeatGame);

            Console.WriteLine($"Game is completed!\n\tYou win: {winsPlayer} times\n\tComputer win: {winsComputer} times\n" +
                $"Thanks for playing my game!Have a nice day!");

            Console.ReadLine();
        }

    }

}




