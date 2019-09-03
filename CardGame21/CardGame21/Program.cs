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
        private int cardsOnHandComputer;
        private bool twoAces;
        public int ReturnCardsOnHand()
        {
            return cardsOnHandComputer;
        }
        public bool TwoAces()
        {
            return twoAces;
        }
        public int PlayComputer(Card[] cards, int pointPlayer, int cardsOnHandPlayer)
        {
            int points = cards[cardsOnHandPlayer].CardValue + cards[cardsOnHandPlayer + 1].CardValue;
            cardsOnHandComputer = 2;
            twoAces = false;
            int indexCards = cardsOnHandPlayer + 2;
            bool giveCard = true;
            if (points == 22 && cardsOnHandComputer == 2)
            {
                Console.WriteLine("Computer has two Aces!He won!");
                twoAces = true;
            }
            else
            {
                do
                {
                    if (pointPlayer > 21)
                    {
                        break;
                    }
                    else if (points <= 15)
                    {
                        points += cards[indexCards].CardValue;
                        cardsOnHandComputer++;
                    }
                    else
                    {
                        giveCard = false;
                    }
                } while (giveCard);
                Console.WriteLine($"Computer have: {points} points\n");
            }
            return points;
        }
    }

    struct Player
    {
        private int cardsOnHandPlayer;
        private bool twoAces;
        public int ReturnCardsOnHand()
        {
            return cardsOnHandPlayer;
        }
        public bool TwoAces()
        {
            return twoAces;
        }
        public int Play(Card[] cards, int cardsOnHandComputer)
        {
            Console.WriteLine($"You have fallen: \n\t\t{cards[cardsOnHandComputer].Name} - {cards[cardsOnHandComputer].Suit}," +
                                                           $"\n\t\t{cards[cardsOnHandComputer + 1].Name} - {cards[cardsOnHandComputer + 1].Suit}\n");

            int points = cards[cardsOnHandComputer].CardValue + cards[cardsOnHandComputer + 1].CardValue;
            twoAces = false;
            cardsOnHandPlayer = 2;
            int indexCards = cardsOnHandComputer + 2;
            if (points == 22 && cardsOnHandPlayer == 2)
            {
                Console.WriteLine("You have two Aces!You win!");
                twoAces = true;
            }
            else
            {
                ConsoleKey keyToContinue;
                do
                {
                    Console.WriteLine($"This is: \t{points} points");
                    Console.WriteLine("\nDo you want another card?\n\tPress Y (yes) / N (No)");
                    do
                    {
                        keyToContinue = Console.ReadKey().Key;
                        if (keyToContinue != ConsoleKey.Y && keyToContinue != ConsoleKey.N)
                        {
                            Console.WriteLine("\nYou entered an unknown letter!Try Again!");
                        }
                        else if (keyToContinue == ConsoleKey.Y)
                        {
                            points += cards[indexCards].CardValue;
                            Console.WriteLine($"\nYou have fallen: { cards[indexCards].Name} - { cards[indexCards].Suit}");
                            cardsOnHandPlayer++;
                            indexCards++;
                            break;
                        }
                    } while (keyToContinue != ConsoleKey.N);
                    Console.WriteLine();
                } while (keyToContinue != ConsoleKey.N);
            }
            return points;
        }
    }

    struct Card
    {
        public CardName Name;
        public int CardValue;
        public CardSuit Suit;
        public static Card[] CreateDesk()
        {
            Card[] cards = new Card[36];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                CardSuit cardSuit = (CardSuit)i;
                for (int j = 2; j <= 11; j++)
                {
                    if (j == 5)
                    {
                        continue;
                    }
                    CardName cardName = (CardName)j;
                    int cardValue = (int)(CardName)j;
                    cards[index].Suit = cardSuit;
                    cards[index].Name = cardName;
                    cards[index].CardValue = cardValue;
                    index++;
                }
            }
            return cards;
        }

        public static Card[] ShuffleCards(Card[] cards, Random rmd)
        {
            for (int i = 0; i < 100; i++)
            {
                int indexFirstCard = rmd.Next(0, cards.Length);
                int indexSecondCard = rmd.Next(0, cards.Length);
                Card tmp = cards[indexFirstCard];
                cards[indexFirstCard] = cards[indexSecondCard];
                cards[indexSecondCard] = tmp;
            }
            return cards;
        }
    }

    class Program
    {
        public static bool AceWinner(bool acesPlayer, bool acesComputer)
        {
            bool rez = true;
            if (acesPlayer)
            {
                Console.WriteLine("Player Win!");
                rez = true;
            }
            else if (acesComputer)
            {
                Console.WriteLine("Computer Win!");
                rez = false;
            }
            return rez;
        }

        public static bool PointsWinner(int player, int computer)
        {
            bool rez = true;
            if (player < computer & computer <= 21 || player > 21)
            {
                Console.WriteLine("Computer Win!");
                rez = false;
            }
            else if (computer < player & player <= 21 || computer > 21)
            {
                Console.WriteLine("Player Win!");
                rez = true;
            }
            else if (player > 21 & computer > 21)
            {
                if (player < computer)
                {
                    Console.WriteLine("Player Win!");
                    rez = true;
                }
                else
                {
                    Console.WriteLine("Computer Win!");
                    rez = false;
                }
            }
            else if (player == computer)
            {
                Console.WriteLine("Computer Win!");
                rez = false;
            }
            return rez;
        }

        static void Main(string[] args)
        {
            Card[] cards = Card.CreateDesk();
            ConsoleKey keyForContnueGame;
            int winsPlayer = 0;
            int winsComputer = 0;
            do
            {
                Console.WriteLine("Hi! Velcome to Simlple card game \"21\"! \nLet's determine who will start:\nClick E(for Eagle) or T(for Tails)!");

                bool again = true;
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

                Random rmd = new Random();
                bool whoStarts = true;
                int num = rmd.Next(1, 35);
                if (num % 2 == 0)
                {
                    Console.WriteLine("Tails fell out!");
                    if (key == ConsoleKey.T)
                    {
                        Console.WriteLine("You starts!\n\tPress any key to continue.....");
                    }
                    else
                    {
                        Console.WriteLine("Computer starts!\n\tPress any key to continue.....");
                        whoStarts = false;
                    }
                }
                else
                {
                    Console.WriteLine("Eagle fell out!");
                    if (key == ConsoleKey.E)
                    {
                        Console.WriteLine("You starts!\n\tPress any key to continue.....");
                    }
                    else
                    {
                        Console.WriteLine("Computer starts!\n\tPress any key to continue.....");
                        whoStarts = false;
                    }
                }
                Console.ReadKey();
                Console.Clear();

                Card[] ShuffledDeck = Card.ShuffleCards(cards, rmd);
                Player pleyer = new Player();
                Computer computer = new Computer();
                bool winner = false;
                if (whoStarts)
                {
                    int pointsPleyerFirst = pleyer.Play(ShuffledDeck, 0);
                    int cardsPlayer = pleyer.ReturnCardsOnHand();
                    bool twoAcesPlayer = pleyer.TwoAces();
                    bool twoAcesComputer = false;
                    if (twoAcesPlayer)
                    {
                        winner = AceWinner(twoAcesPlayer, twoAcesComputer);
                    }
                    else
                    {
                        int pointsComputerFirst = computer.PlayComputer(ShuffledDeck, pointsPleyerFirst, cardsPlayer);
                        twoAcesComputer = computer.TwoAces();
                        if (twoAcesComputer)
                        {
                            winner = AceWinner(twoAcesPlayer, twoAcesComputer);
                        }
                        else
                        {
                            winner = PointsWinner(pointsPleyerFirst, pointsComputerFirst);
                        }
                    }
                }
                else
                {
                    int pointsComputerSecond = computer.PlayComputer(ShuffledDeck, 0, 0);
                    int cardsComputer = computer.ReturnCardsOnHand();
                    bool twoAcesComputer = computer.TwoAces();
                    bool twoAcesPlayer = false;
                    if (twoAcesComputer)
                    {
                        winner = AceWinner(twoAcesPlayer, twoAcesComputer);
                    }
                    else
                    {
                        int pointsPleyerSecond = pleyer.Play(ShuffledDeck, cardsComputer);
                        twoAcesPlayer = pleyer.TwoAces();
                        if (twoAcesPlayer)
                        {
                            winner = AceWinner(twoAcesPlayer, twoAcesComputer);
                        }
                        else
                        {
                            winner = PointsWinner(pointsPleyerSecond, pointsComputerSecond);
                        }
                    }
                }

                if (winner)
                {
                    winsPlayer++;
                }
                else
                {
                    winsComputer++;
                }

                Console.WriteLine("\nDo you want to start new game?\n\tPress Y(yes)/N(no) ");
                do
                {
                    keyForContnueGame = Console.ReadKey().Key;
                    if (keyForContnueGame != ConsoleKey.Y && keyForContnueGame != ConsoleKey.N)
                    {
                        Console.WriteLine("You entered an unknown letter!Try Again!");
                    }
                    else if (keyForContnueGame == ConsoleKey.Y)
                    {
                        break;
                    }
                } while (keyForContnueGame != ConsoleKey.N);
                Console.Clear();
            } while (keyForContnueGame != ConsoleKey.N);

            Console.WriteLine($"Game is completed!\n\nYou win: \t{winsPlayer} times\n\nComputer win: \t{winsComputer} times\n" +
                $"\nThanks for playing my game!Have a nice Day!");

            Console.ReadLine();
        }

    }

}




