namespace Practice_2023;

class Articles
{
    static void Main(string[] args)
    {
        string[] arg = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        int n = int.Parse(Console.ReadLine());
        Article article = new Article(arg[0], arg[1], arg[2]);

        for (int i = 0; i < n; i++)
        {
            string[] cmd = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = cmd[1];

            switch (cmd[0].ToLower())
            {
                case "edit":
                    article.Edit(text);
                    break;
                case "changeauthor":
                    article.ChnageAuthor(text);
                    break;
                case "rename":
                    article.Rename(text);
                    break;
            }
        }

        Console.WriteLine(article.ToString());

    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChnageAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

