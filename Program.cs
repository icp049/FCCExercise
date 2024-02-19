using System;
using System.Diagnostics;

public class Solution
{
    private static int[] RollDice(int numDice)
    {
        Random rand = new Random();
        int[] dice = new int[numDice];
        for (int i = 0; i < numDice; i++)
        {
            dice[i] = rand.Next(1, 7); //just used random function to get die faces
        }
        return dice;
    }

    private static int FindMinDie(int[] dice)
    {
        int minDie = dice[0];
        foreach (int die in dice)
        {
            if (die < minDie)
            {
                minDie = die;
            }
        }
        return minDie; //return lowest value
    }

    private static int CountOccurrences(int[] array, int value)
    {
        int count = 0;
        foreach (int element in array)
        {
            if (element == value)
            {
                count++;
            }
        }
        return count; //return occurrences
    }

    public static void SimulateDiceGame(int iterations, int n)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        //let n be the number of dice
        int[] scores = new int[n * 6 + 1]; //all possibilities. I put 6 because each die has 6 faces as constant then + 1 for all combinations

        for (int i = 0; i < iterations; i++)
        {
            //score initiates at 9
            int remainingDice = n;
            int totalScore = 0;

            while (remainingDice > 0)
            {
                int[] dice = RollDice(remainingDice);

                //checks if there are 3s 
                if (Array.IndexOf(dice, 3) != -1)
                {
                    totalScore += 0;
                    remainingDice -= CountOccurrences(dice, 3);
                }
                else
                {
                    //remove lowest die 
                    int minDie = FindMinDie(dice);
                    totalScore += minDie;
                    remainingDice--;
                }
            }

            //totalscore
            scores[totalScore]++;
        }

        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed; //enclose simulation in a stopwatch function

        Console.WriteLine($"Number of simulations was {iterations} using {n} dice.");
        //for loop for results
        for (int score = 0; score <= n * 6; score++)
        {
            Console.WriteLine($"Total {score} occurs {scores[score] * 1.0 / iterations:F2} occurred {scores[score]} times.");
        }
        Console.WriteLine($"Total simulation took {elapsedTime.TotalSeconds:F2} seconds."); //F2 are formatters
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution.SimulateDiceGame(100, 2);
    }
}
