using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms
{
    internal class DeckOfCards
    {
        Random random = new Random();
        public int suitIndex, rankIndex;
        List<string> cards = new List<string>();
        string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        List<string>[,] player;
        public DeckOfCards()
        {
            player = new List<string>[2, 2];

            //Inititalizing the array of Lists
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    player[i, j] = new List<string>();
                }
            }
        }

        //Shuffle logic
        public void Shuffle()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        ExecuteAgain:
                        suitIndex = random.Next(suit.Length);
                        rankIndex = random.Next(rank.Length);
                        string shuffledCard = rank[rankIndex] + " of " + suit[suitIndex];
                        if (cards.Contains(shuffledCard))
                        {
                            goto ExecuteAgain;
                        }
                        else
                        {
                            cards.Add(shuffledCard);
                            player[j, k].Add(shuffledCard);
                        }
                    }
                }
            }
        }

        //Displaying cards of each player
        public void Display()
        {
            int count = 1;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("Player " + count + " has these cards");
                    //Console.WriteLine("Player " + player[i, j]);

                    //Print the cards of each player at index [i, j]
                    foreach (string card in player[i, j])
                    {
                        Console.WriteLine(card);
                    }
                    count++;
                }
            }
        }
    }
}
