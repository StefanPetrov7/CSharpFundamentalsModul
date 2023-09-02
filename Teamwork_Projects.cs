namespace Practice_2023;

class Teamwork_Projects
{
    static void Main(string[] args)
    {

        // Only 66 points => On the lection, the lector is getting same points :) => Need to figure it out

        const string END_PROGRAM = "end of assignment";
        int n = int.Parse(Console.ReadLine());

        List<Team> teams = new List<Team>();

        for (int i = 0; i < n; i++)
        {
            string[] arg = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string creator = arg[0];
            string teamName = arg[1];
            TryCreateTeam(creator, teamName, teams);
        }

        string input;

        while ((input = Console.ReadLine()) != END_PROGRAM)
        {
            string[] arg = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string userName = arg[0];
            string teamName = arg[1];
            TryJoinTeam(userName, teamName, teams);
        }

        List<Team> teamsToDisband = new List<Team>();
        teamsToDisband.AddRange(teams.Where(x => x.Users.Count == 0));
        teams = teams.Where(x => x.Users.Count > 0).ToList();

        foreach (var team in teams.OrderByDescending(x => x.Users.Count).ThenBy(x => x.TeamName))
        {
            Console.WriteLine(team);
        }

        Console.WriteLine("Teams to disband:");

        if (teamsToDisband.Count > 0)
        {
            foreach (var team in teamsToDisband.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    private static void TryJoinTeam(string userName, string teamName, List<Team> teams)
    {
        Team team = teams.FirstOrDefault(x => x.TeamName == teamName);
        User user = new User(userName);

        if (team == null)
        {
            Console.WriteLine($"Team {teamName} does not exist!");
            return;
        }

        if (team.Users.Any(x => x.Name == userName))
        {
            Console.WriteLine($"Member {userName} cannot join team {teamName}!");
            return;
        }

        if (team.Creator == user.Name)
        {
            Console.WriteLine($"Member {userName} cannot join team {teamName}!");
            return;
        }

        team.Users.Add(user);
    }

    private static void TryCreateTeam(string creator, string teamName, List<Team> teams)
    {
        if (teams.Any(x => x.TeamName == teamName))
        {
            Console.WriteLine($"Team {teamName} was already created!");
            return;
        }

        if (teams.Any(x => x.Creator == creator))
        {
            Console.WriteLine($"{creator} cannot create another team!");
            return;
        }

        teams.Add(new Team(creator, teamName));
        Console.WriteLine($"Team {teamName} has been created by {creator}!");
    }

    public class Team
    {
        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.TeamName = teamName;
            this.Users = new List<User>();
        }

        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<User> Users { get; set; }

        public override string ToString()
        {
            this.Users.OrderBy(x => x.Name);

            return $"{this.TeamName}\n- {this.Creator}\n{string.Join(Environment.NewLine, this.Users)}";
        }
    }

    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return "-- " + this.Name;
        }
    }
}
