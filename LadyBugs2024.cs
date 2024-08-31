namespace LadyBugs2024
{
    internal class LadyBugs2024
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] bugIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            AddBugs(field, bugIndexes);

            string input = Console.ReadLine();

            while (input.ToLower().TrimEnd() != "end")
            {
                string[] commands = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                int bug = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLength = int.Parse(commands[2]);

                if (direction.ToLower() == "right")
                {
                    MoveTheBugRight(field, bug, flyLength);
                }
                else
                {
                    MoveTheBugLeft(field, bug, flyLength);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", field));
        }

        public static void AddBugs(int[] field, int[] bugIndex)
        {

            for (int i = 0; i < bugIndex.Length; i++)
            {
                if (bugIndex[i] < 0 || bugIndex[i] > field.Length - 1)
                {
                    continue;
                }
                else
                {
                    field[bugIndex[i]] = 1;
                }
            }
        }

        private static bool IsLandingOut(int landIndex, int[] arr)
        {
            if (landIndex < 0 || landIndex > arr.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsInputValid(int[] field, int bugIndex)
        {
            if (bugIndex < 0 || bugIndex > field.Length - 1 || field[bugIndex] == 0)
            {
                return true;
            }

            return false;
        }

        private static void MoveTheBugRight(int[] field, int bugIndex, int flyLength)
        {

            if (IsInputValid(field, bugIndex))
            {
                return;
            }

            int landIndex = bugIndex + flyLength;

            if (IsLandingOut(landIndex, field))
            {
                field[bugIndex] = 0;
                return;
            }

            field[bugIndex] = 0;

            for (int i = landIndex; i < field.Length; i++)
            {
                if (field[i] == 1)
                {
                    continue;
                }

                field[i] = 1;
                break;
            }
        }

        private static void MoveTheBugLeft(int[] field, int bugIndex, int flyLength)
        {
            int landIndex = bugIndex - flyLength; // (- - = + ) 

            if (IsInputValid(field, bugIndex))   
            {
                return;
            }

            if (IsLandingOut(landIndex, field)) 
            {
                field[bugIndex] = 0;
                return;
            }

            field[bugIndex] = 0;

            for (int i = landIndex; i >= 0; i--)
            {
                if (field[i] == 1)
                {
                    continue;
                }

                field[i] = 1;
                break;
            }
        }
    }
}
