using System;
using System.Collections.Generic;
using GameOfDice.Models;

namespace GameOfDice
{
    class DiceGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no. of players.");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Points to accumulate.");
            int M = Convert.ToInt32(Console.ReadLine());

            var playersList = new List<Player>();
            int currentRank = 1;

            int index = 1;
            while (index <= N)
            {
                playersList.Add(new Player { name = "Payer-" + index });
                index++;
            }

            var dice = new Dice();

            do
            {
                foreach (var p in playersList)
                {
                    if (p.rank < 0)
                    {
                        if (p.skipRoll)
                        {
                            Console.WriteLine(p.name + " had 2 consecutive \"1\"s rolled, so you are not allowed to roll this round.");
                            p.skipRoll = false;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine(p.name + ", press 'r' to roll the dice.");
                                char ch;
                                do
                                {
                                    ch = Console.ReadKey().KeyChar;
                                } while (ch != 'r');

                                dice.rollDice();
                                Console.WriteLine("\nRolling Dice... " + dice.value);
                                p.score += dice.value;
                                if (p.score >= M)
                                {
                                    p.rank = currentRank;
                                    currentRank++;
                                }
                                if (p.lastRollValue == 1 && dice.value == 1)
                                {
                                    p.skipRoll = true;
                                }
                                if (dice.value == 6)
                                {
                                    Console.WriteLine(p.name + " rolled a 6, so you are allowed to roll again.");
                                }
                                p.lastRollValue = dice.value;
                            } while (dice.value == 6);
                        }
                    }
                }

                foreach(var p in playersList)
                {
                    Console.WriteLine(p.name + " - score: " + p.score + ",rank: " + (p.rank > 0 ? p.rank : "-"));
                }
            } while (!isGameOver(playersList));
        }

        private static bool isGameOver(List<Player> playersList)
        {
            foreach(var p in playersList)
            {
                if (p.rank == -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
