using System.Text;

namespace Practice2024
{
    internal class Pirates
    {
        static void Main(string[] args)
        {

            // 92 PTS IN JUDGE

            Dictionary<string, int[]> towns = new Dictionary<string, int[]>();
            string input;

            while ((input = Console.ReadLine()).TrimEnd() != "Sail")
            {
                string[] info = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string townName = info[0];
                int population = int.Parse(info[1]);
                int gold = int.Parse(info[2]);


                if (towns.ContainsKey(townName) == false)
                {
                    towns[townName] = new int[2];
                }

                towns[townName][0] += population;
                towns[townName][1] += gold;

            }

            while ((input = Console.ReadLine()).TrimEnd() != "End")
            {
                string[] info = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = info[0];

                switch (command)
                {
                    case "Plunder":
                        Plunder(info, towns);
                        break;
                    case "Prosper":
                        Prosper(info, towns);
                        break;
                    default:
                        break;
                }
            }

            StringBuilder result = new StringBuilder();

            if (towns.Count < 0)
            {
                result.AppendLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                result.AppendLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    result.AppendLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg ");
                }
            }

            Console.WriteLine(result);
        }

        private static void Prosper(string[] info, Dictionary<string, int[]> towns)
        {
            string townName = info[1];
            int gold = int.Parse(info[2]);

            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }

            towns[townName][1] += gold;
            var town = towns.Where(x => x.Key == townName).FirstOrDefault();

            string result = String.Format("{0} gold added to the city treasury. {1} now has {2} gold.", gold, town.Key, town.Value[1]);
            Console.WriteLine(result);
        }

        private static void Plunder(string[] info, Dictionary<string, int[]> towns)
        {
            string townName = info[1];
            int populationKilled = int.Parse(info[2]);
            int goldStolen = int.Parse(info[3]);

            int totalKilledpopulation = towns[townName][0] < populationKilled ? towns[townName][0] : populationKilled;
            int totalStolenGold = towns[townName][1] < goldStolen ? towns[townName][1] : goldStolen;

            towns[townName][0] -= populationKilled;
            towns[townName][1] -= goldStolen;

            if (towns[townName][0] <= 0 || towns[townName][1] <= 0)
            {
                Console.WriteLine($"{townName} plundered! {totalStolenGold} gold stolen, {totalKilledpopulation} citizens killed.");
                Console.WriteLine($"{townName} has been wiped off the map!");
                towns.Remove(townName);
            }
            else
            {
                Console.WriteLine($"{townName} plundered! {goldStolen} gold stolen, {populationKilled} citizens killed.");
            }
        }
    }
}



