namespace Practice_2023;

class Articles_2
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Article> articles = new List<Article>();

        for (int i = 0; i < n; i++)
        {
            string[] cmd = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Article article = new Article(cmd[0], cmd[1], cmd[2]);
            articles.Add(article);
        }

        string criteria = Console.ReadLine();

        switch (criteria)
        {
            case "title":
                foreach (var article in articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine(article.ToString());
                }
                break;
            case "content":
                foreach (var article in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(article.ToString());
                }
                break;
            case "author":
                foreach (var article in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(article.ToString());
                }
                break;
        }

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

