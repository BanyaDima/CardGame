using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    struct Card
    {
        public string Name;
        public int CardValue;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[36];            //creating a deck of cards

            for (int i = 0; i < cards.Length; i++)
            {
                if (i >= 0 && i <= 3)
                {
                    cards[i].Name = "Aces";
                    cards[i].CardValue = 11;
                }
                if (i >= 4 && i <= 7)
                {
                    cards[i].Name = "King";
                    cards[i].CardValue = 4;
                }
                if (i >= 8 && i <= 11)
                {
                    cards[i].Name = "Lady";
                    cards[i].CardValue = 3;
                }
                if (i >= 12 && i <= 15)
                {
                    cards[i].Name = "Jack";
                    cards[i].CardValue = 2;
                }
                if (i >= 16 && i <= 19)
                {
                    cards[i].Name = "10";
                    cards[i].CardValue = 10;
                }
                if (i >= 20 && i <= 23)
                {
                    cards[i].Name = "9";
                    cards[i].CardValue = 9;
                }
                if (i >= 24 && i <= 27)
                {
                    cards[i].Name = "8";
                    cards[i].CardValue = 8;
                }
                if (i >= 28 && i <= 31)
                {
                    cards[i].Name = "7";
                    cards[i].CardValue = 7;
                }
                if (i >= 32 && i <= 35)
                {
                    cards[i].Name = "6";
                    cards[i].CardValue = 6;
                }
            }

            Console.WriteLine("Hi! Velcome to Siml card game \"21\"! \nLet's determine who will start:\nClick E(for Eagle) or T(for Tails)!");

            bool again = true;                         //input validation    
            string keyForStart = null;

            do
            {
                string keyForCheck = Console.ReadLine().ToUpper();

                if (keyForCheck != "E" && keyForCheck != "T")
                {
                    Console.WriteLine("You entered an unknown letter!Try Again!");
                    again = true;
                }
                else
                {
                    again = false;
                    keyForCheck = keyForStart;
                }

            } while (again);

            Random rmd = new Random();                             //determining who will start the game
            int num = rmd.Next(1, 36);
            if (num % 2 == 0)
            {
                Console.WriteLine("Tails fell out!");

                if (keyForStart == "T" && num % 2 == 0)
                {
                    Console.WriteLine("You began!");
                }
                else
                {
                    Console.WriteLine("Computer Begain!");
                }
            }
            else
            {
                Console.WriteLine("Eagle fell out!");

                if (keyForStart == "E" && num % 2 != 0)
                {
                    Console.WriteLine("You began!");
                }
                else
                {
                    Console.WriteLine("Began coputer");
                }
            }











            Console.ReadKey();




            Console.ReadKey();
        }

    }

}


