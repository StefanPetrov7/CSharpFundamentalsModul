namespace Practice_2023;

class SoftUni_Exam_Results
{
    static void Main(string[] args)
    {
        const string PROGRAM_END = "exam finished";
        const string BANNED = "banned";

        Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, int> submissions = new Dictionary<string, int>();

        string input;

        while ((input = Console.ReadLine()) != PROGRAM_END)
        {
            string[] arg = input.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string userName = arg[0];
            string command = arg[1];
            int points = arg.Length > 2 ? int.Parse(arg[2]) : 0;

            if (command == BANNED)
            {
                RemoveUser(userName, results);
                Console.WriteLine($"{userName}-banned");
            }
            else
            {
                AddUser(userName, command, points, results);
                AddSubmission(command, submissions);
            }
        }

        Console.WriteLine("Results:");

        foreach (var kvp in results)  // OrderByDescending(x => x.Value[x.Key.ToString()])) // fix the sorting 
        {
            string user = kvp.Key;
            int points = kvp.Value[user];
            Console.WriteLine($"{user} | {points}");
        }


        Console.WriteLine("Submissions:");

        foreach (var kvp in submissions)
        {
            string language = kvp.Key;
            int count = kvp.Value;
            Console.WriteLine($"{language} - {count}");
        }

    }

    private static void RemoveUser(string userName, Dictionary<string, Dictionary<string, int>> results)
    {
        if (results.ContainsKey(userName))
        {
            results.Remove(userName);
        }
    }

    private static void AddSubmission(string language, Dictionary<string, int> submissions)
    {
        if (submissions.ContainsKey(language) == false)
        {
            submissions[language] = 0;
        }

        submissions[language]++;

        submissions = submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
    }

    private static void AddUser(string userName, string languages, int points, Dictionary<string, Dictionary<string, int>> results)
    {
        if (results.ContainsKey(userName) == false)
        {
            results[userName] = new Dictionary<string, int>();
        }

        if (results[userName].Any(x => x.Key == languages) == false)
        {
            results[userName][languages] = points;
        }

        int oldPoints = results[userName][languages];  // not working 

        results[userName][languages] = points > oldPoints ? points : oldPoints;
    }
}