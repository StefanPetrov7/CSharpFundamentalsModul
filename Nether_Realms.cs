using System.Text.RegularExpressions;

namespace Practice_2023;

class Nether_Realms
{
    static void Main(string[] args)
    {
        List<Demon> demons = new List<Demon>();
        string input = Console.ReadLine();

        string namesPattern = @"[^,+\s]+";
        string healthPattern = @"[A-Za-z]";
        string devisorsPattern = @"[*/]";
        string decimalNumPattern = @"(?<decimalNumber>[-+]?[0-9]*\.?[0-9]+(?:[eE][-+]?[0-9]+)?)";

        MatchCollection demonsData = Regex.Matches(input, namesPattern);

        for (int i = 0; i < demonsData.Count; i++)
        {
            Demon demon = new Demon();
            demon.Name = demonsData[i].ToString();

            MatchCollection healthArr = Regex.Matches(demonsData[i].ToString(), healthPattern);
            demon.Heath = healthArr.Select(x => char.Parse(x.ToString())).Sum(x => x);

            MatchCollection numbers = Regex.Matches(demonsData[i].ToString(), decimalNumPattern);
            demon.Damage = numbers.Select(x => double.Parse(x.ToString())).Sum(x => x);

            MatchCollection multiplyers = Regex.Matches(demonsData[i].ToString(), devisorsPattern);

            for (int j = 0; j < multiplyers.Count; j++)
            {
                if (multiplyers[j].ToString() == "/")
                {
                    demon.Damage /= 2;
                }
                else if (multiplyers[j].ToString() == "*")
                {
                    demon.Damage *= 2;
                }
            }

            demons.Add(demon);
        }

        demons.OrderBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x));
    }

    class Demon
    {
        public Demon() { }

        public string Name { get; set; }

        public double Heath { get; set; }

        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Heath} health, {this.Damage:f2} damage";
        }
    }
}