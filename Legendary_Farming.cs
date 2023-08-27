namespace Practice_2023;

class Legendary_Farming
{
    static void Main(string[] args)
    {

        Dictionary<string, string> legendaryItems = new Dictionary<string, string>()
        {
            {"shards","Shadowmourne"},
            {"fragments" ,"Valanyr"},
            { "motes","Dragonwrath " },
        };

        Dictionary<string, double> keyMaterials = new Dictionary<string, double>()
            {
            {"shards",0},
            {"fragments" ,0},
            { "motes",0},
        };

        Dictionary<string, double> regMterials = new Dictionary<string, double>();

        string input = Console.ReadLine();
        string keyMaterial = string.Empty;
        string legendaryItem = string.Empty;

        while (input != "END")
        {
            string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < arr.Length; i += 2)
            {
                string curMaterial = arr[i + 1].ToLower();
                double qty = double.Parse(arr[i]);

                if (keyMaterials.ContainsKey(curMaterial))
                {
                    keyMaterials[curMaterial] += qty;

                    if (keyMaterials.Values.Any(x => x >= 250))
                    {
                        break;
                    }
                }
                else
                {
                    regMterials[curMaterial] = regMterials.ContainsKey(curMaterial) ? regMterials[curMaterial] += qty : qty;
                }
            }

            keyMaterial = keyMaterials.FirstOrDefault(x => x.Value >= 250).Key;

            if (keyMaterial != string.Empty && keyMaterial != null)
            {
                legendaryItem = legendaryItems[keyMaterial];
                keyMaterials[keyMaterial] -= 250;
                input = "END";
            }
            else
            {
                input = Console.ReadLine();
            }
        }

        Console.WriteLine($"{legendaryItem} obtained!");

        foreach (var mqp in keyMaterials.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{mqp.Key}: {mqp.Value}");
        }
        foreach (var mqp in regMterials.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{mqp.Key}: {mqp.Value}");
        }
    }
}