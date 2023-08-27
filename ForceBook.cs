namespace Practice_2023;

class ForceBook
{
    static void Main(string[] args)
    {
        // Cannot be tested, no solution in Judge. 

        const string ADD_USER = "|";
        const string END_PROGRAM = "Lumpawaroo";
        string input = string.Empty;

        Dictionary<string, List<string>> userData = new Dictionary<string, List<string>>();

        while ((input = Console.ReadLine()) != END_PROGRAM)
        {
            string[] cmd = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (input.Contains(ADD_USER))
            {
                AddUser(userData, cmd);
            }
            else
            {
                ChnageUserSide(userData, cmd);
            }
        }

        userData = userData
            .Where(x => x.Value.Count > 0)
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(k => k.Key)
            .ToDictionary(x => x.Key, y => y.Value);


        foreach (var userSidePair in userData)
        {
            string side = userSidePair.Key;
            List<string> users = userSidePair.Value
                .OrderBy(x => x)
                .ToList();
            int count = users.Count;

            Console.WriteLine($"Side:{side}, Members: {count}");
            users.ForEach(name => Console.WriteLine($"! {name}"));
        }
    }

    private static void ChnageUserSide(Dictionary<string, List<string>> userData, string[] cmd)
    {
        string side = cmd[1];
        string userName = cmd[0];

        if (userData.ContainsKey(side) == false)
        {
            userData[side] = new List<string>();
        }

        foreach (var userSide in userData)
        {
            if (userSide.Value.Contains(userName))
            {
                userSide.Value.Remove(userName);
                break;
            }
        }

        userData[side].Add(userName);
        Console.WriteLine($"{userName} joins the {side} side!");
    }

    private static void AddUser(Dictionary<string, List<string>> userData, string[] cmd)
    {
        string side = cmd[0];
        string userName = cmd[1];

        if (userData.ContainsKey(side) == false)
        {
            userData[side] = new List<string>();
        }

        if (userData.Values.Any(list => list.Contains(userName)) == false)
        {
            userData[side].Add(userName);
        }
    }
}