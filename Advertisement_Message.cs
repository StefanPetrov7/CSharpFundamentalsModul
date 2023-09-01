namespace Practice_2023;

class Advertisement_Message
{
    static void Main(string[] args)
    {

        Message message = new Message();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(message);
        }
    }
}

class Message
{
    private string[] phrases = new string[]
    {
        "Excellent product.",
        "Such a great product.",
        "I always use that product.",
        "Best product of its category.",
        "Exceptional product.",
        "I can’t live without this product."
    };

    private string[] events = new string[]
    {
        "Now I feel good.",
        "I have succeeded with this product.",
        "Makes miracles. I am happy of the results!",
        "I cannot believe but now I feel awesome.", "" +
        "Try it yourself, I am very satisfied.",
        "I feel great!"
    };

    private string[] authors = new string[]
   {
       "Diana",
       "Petya",
       "Stella",
       "Elena",
       "Katya",
       "Iva",
       "Annie",
       "Eva"
   };

    private string[] cities = new string[]
    {
        "Burgas",
        "Sofia",
        "Plovdiv",
        "Varna",
        "Ruse"
    };

    public override string ToString()
    {
        Random index = new Random();

        return $"{phrases[index.Next(0, phrases.Length)]} " +
            $"{events[index.Next(0, events.Length)]}" +
            $" {authors[index.Next(0, authors.Length)]} –" +
            $" {cities[index.Next(0, cities.Length)]}.";
    }
}