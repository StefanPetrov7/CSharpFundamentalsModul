namespace Practice_2023;

class SoftUni_Exam_Results
{
    static void Main(string[] args)
    {

        // 100 points, howevere Better data structure can be used, also problem description is not given clearly.

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
            }
            else
            {
                AddUser(userName, command, points, results);
                AddSubmission(command, submissions);
            }
        }

        Dictionary<string, int> finalResults = new Dictionary<string, int>();

        foreach (var user in results)
        {
            string name = user.Key;

            foreach (var languageResults in user.Value)
            {
                int points = languageResults.Value;

                finalResults[name] = points;
            }
        }

        Console.WriteLine("Results:");

        foreach (var kvp in finalResults.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key} | {kvp.Value}");
        }

        Console.WriteLine("Submissions:");

        foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
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
        else
        {
            int oldPoints = results[userName][languages];
            results[userName][languages] = points > oldPoints
                ? results[userName][languages] = points : results[userName][languages] = oldPoints;
        }
    }
}
