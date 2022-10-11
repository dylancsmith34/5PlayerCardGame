using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;


public class Cards
{
    public static void Main(string[] args)
    {
        
        //Create 52-card deck
        List<string> clubs = Card("Club");
        List<string> diamonds = Card("Diamond");
        List<string> hearts = Card("Heart");
        List<string> spades = Card("Spade");

        List<string> deck = clubs.Concat(diamonds).Concat(hearts).Concat(spades).ToList();
        Console.WriteLine("\n>> What is your name?");
        string name = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine(">> Ok {0}, Let's start the game. You need to play till round 3.", name);
        Console.WriteLine("Press any key to continue Round 1...");
        Console.ReadKey();

        //Create players
        string[] players = new string[5] { "Peter", "Mike", "Rose", "Anna", name };
        
        //getting card from deck
        Random random = new Random();
        int roundcounter = 1;
        int round = 1;

        while (round < 4)
        {
            string winner = "to be decided";
            int max_point = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nRound" + round);
            Console.ResetColor();

            foreach (string player in players)
            {
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(">> " + player);
                Console.ResetColor();
                int card1_index = random.Next(deck.Count);
                string card1 = deck[card1_index];
                deck.Remove(card1);
                Console.ResetColor();

                int card2_index = random.Next(deck.Count);
                string card2 = deck[card2_index];
                deck.Remove(card2);

                int card3_index = random.Next(deck.Count);
                string card3 = deck[card3_index];
                deck.Remove(card3);

                Console.WriteLine(card1);
                int card1_point = Point(card1);

                Console.WriteLine(card2);
                int card2_point = Point(card2);

                Console.WriteLine(card3);
                int card3_point = Point(card3);

                int total_point = card1_point + card2_point + card3_point;
                Console.WriteLine(">> {0} Point", total_point);
                Console.WriteLine();

                if (total_point > max_point)
                {
                    max_point = total_point;
                    winner = player;
                }

            }//foreach player ends
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>" + winner + " wins round " + round + " with " + max_point + " points! ");
            Console.ResetColor();
            ++roundcounter;
            if (roundcounter < 4)
            {
                Console.WriteLine("If you would like to go to round" + roundcounter);
            }
            if (round < 3)
            {
                Console.WriteLine("Press any key to continue to the next round.");
                Console.ReadKey();
            }
            round++;

        }//while loop end
    }
    public static List<string> Card(string symbols)
    {
        List<string> cards = new List<string> ();
        for (int i = 2; i < 11; i++)
        {
            cards.Add(symbols + " " + i);
        }
        cards.Add(symbols + " " + "Jack");
        cards.Add(symbols + " " + "Queen");
        cards.Add(symbols + " " + "King");
        cards.Add(symbols + " " + "Ace");

        return cards;
    } //Cards func ends

    public static int Point(string card)
    {
        int point;
        string[] splited = card.Split(' ');
        if (splited[1] == "Jack")
        {
            point = 10;
        }
        else if(splited[1] == "Queen")
        {
            point = 10;
        }
        else if(splited[1] == "King")
        {
            point = 10;
        }
        else if(splited[1] == "Ace")
        {
            point = 11;
        }
        else
        {
            point = Int32.Parse(splited[1]);
        }
        return point;
    }//point func ends

}//Main class ends

