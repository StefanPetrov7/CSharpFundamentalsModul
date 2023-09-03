using System.Text;

namespace Practice_2023;

class Vehicle_Catalogue
{
    static void Main(string[] args)
    {
        string command = string.Empty;
        List<Vehicle> vehicles = new List<Vehicle>();

        while ((command = Console.ReadLine()) != "End")
        {
            string[] arg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle viechle = new Vehicle(arg[0], arg[1], arg[2], int.Parse(arg[3]));
            vehicles.Add(viechle);
        }

        while ((command = Console.ReadLine()) != "Close the Catalogue")
        {
            Vehicle vehicle = vehicles.FirstOrDefault(x => x.Made == command);

            if (vehicle == null)
            {
                continue;
            }

            Console.WriteLine(vehicle.ToString());
        }

        if (vehicles.Any(x => x.Type.ToLower() == "car"))
        {
            Console.WriteLine($"Cars have average horsepower of: {vehicles.Where(x => x.Type.ToLower() == "car").Average(x => x.Hp):f2}.");
        }
        else
        {
            Console.WriteLine($"Cars have average horsepower of: 0.");
        }

        if (vehicles.Any(x => x.Type.ToLower() == "truck"))
        {
            Console.WriteLine($"Trucks have average horsepower of: {vehicles.Where(x => x.Type.ToLower() == "truck").Average(x => x.Hp):f2}.");
        }
        else
        {
            Console.WriteLine($"Trucks have average horsepower of: 0.");
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string made, string color, int hp)
        {
            this.Type = type;
            this.Made = made;
            this.Color = color;
            this.Hp = hp;
        }

        public string Type { get; set; }

        public string Made { get; set; }

        public string Color { get; set; }

        public int Hp { get; set; }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Type: {this.Type.Replace(this.Type[0], char.ToUpper(this.Type[0]))}");
            text.AppendLine($"Model: {this.Made}");
            text.AppendLine($"Color: {this.Color}");
            text.AppendLine($"Horsepower: {this.Hp}");
            return text.ToString().TrimEnd();
        }
    }
}
