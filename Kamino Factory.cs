namespace Practice_2023;

class KaminoFactory
{
    static void Main(string[] args)
    {
        // 90 points :(

        int length = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        const string CLONE_THEM = "clone them!";
        int counter = 1;
        int[] bestDnaStats = new int[4];
        int[] bestDna = new int[length];


        while (input != CLONE_THEM)
        {
            int[] curDna = input
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] curDnaStats = new int[4];

            curDnaStats[3] = counter;

            CheckDnaStats(curDna, curDnaStats);
            bestDna = GiveBestDna(curDnaStats, ref bestDnaStats, curDna, bestDna);

            counter++;

            input = Console.ReadLine().ToLower();

        }

        string result = $"Best DNA sample {bestDnaStats[3]} with sum: {bestDnaStats[2]}.";
        Console.WriteLine($"{result}\n{String.Join(" ", bestDna)}");
    }


    private static void CheckDnaStats(int[] curDna, int[] curDnaStats)
    {
        int bestSequenceLength = 0;
        int curSequence = 0;
        int bestStartingIndex = 0;

        for (int i = 0; i < curDna.Length; i++)
        {
            if (curDna[i] == 1)
            {
                curSequence++;
                curDnaStats[2]++;  // sequence sum
            }

            if (curDna[i] == 0 || i == curDna.Length - 1)
            {
                if (curSequence > bestSequenceLength)
                {
                    bestSequenceLength = curSequence;
                    bestStartingIndex = i - bestSequenceLength;
                }

                curSequence = 0;
            }
        }
        curDnaStats[0] = bestSequenceLength;  // sequence length
        curDnaStats[1] = bestStartingIndex;   // starting index
    }

    public static int[] GiveBestDna(int[] curDnaStats, ref int[] bestDnaStats, int[] curDna, int[] bestDna)
    {
        if (curDnaStats[0] > bestDnaStats[0]) // sequence length
        {
            bestDnaStats = curDnaStats;
            bestDna = curDna;
            return bestDna;
        }
        else if (curDnaStats[0] == bestDnaStats[0])  // sequence length
        {
            if (curDnaStats[1] < bestDnaStats[1])  // sequence start
            {
                bestDnaStats = curDnaStats;
                bestDna = curDna;
                return bestDna;
            }
            else if (curDnaStats[1] == bestDnaStats[1])  // sequence start
            {
                if (curDnaStats[2] > bestDnaStats[2])  // sequence sum
                {
                    bestDnaStats = curDnaStats;
                    bestDna = curDna;
                    return bestDna;
                }
                else
                {
                    return bestDna;
                }
            }
            else
            {
                return bestDna;
            }

        }
        else
        {
            return bestDna;
        }
    }
}