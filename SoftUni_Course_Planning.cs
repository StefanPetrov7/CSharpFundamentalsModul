namespace Practice_2023;

class SoftUni_Course_Planning
{
    static void Main(string[] args)
    {
        // 77 Points only :( 

        const string ADD = "Add";
        const string INSERT = "Insert";
        const string REMOVE = "Remove";
        const string SWAP = "Swap";
        const string EXERCISE = "Exercise";
        const string COURSE_START = "course start";

        List<string> courses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

        string input;

        while ((input = Console.ReadLine()) != COURSE_START)
        {
            string[] commands = input.Split(":").ToArray();
            string commmand = commands[0];

            switch (commmand)
            {
                case ADD:
                    AddLesson(courses, commands);
                    break;
                case INSERT:
                    InsertLesson(courses, commands);
                    break;
                case REMOVE:
                    RemoveLesson(courses, commands);
                    break;
                case SWAP:
                    SwapLesson(courses, commands);
                    break;
                case EXERCISE:
                    ExerciseLessons(courses, commands);
                    break;
            }
        }

        int counter = 0;

        foreach (string lesson in courses)
        {
            counter++;
            Console.WriteLine($"{counter}.{lesson}");
        }
    }

    private static void ExerciseLessons(List<string> courses, string[] commands)
    {
        string lesson = commands[1];
        string exercise = lesson + "-Exercise";

        if (!courses.Contains(exercise))
        {
            if (!courses.Contains(lesson))
            {
                courses.Add(lesson);
            }
            courses.Add(exercise);
        }
    }

    private static void SwapLesson(List<string> courses, string[] commands)
    {
        string lesson = commands[1];
        string exercise = lesson + "-Exercise";
        string lesson2 = commands[2];
        string exercise2 = lesson2 + "-Exercise";

        if (courses.Contains(lesson) && courses.Contains(lesson2))
        {
            int index1 = courses.FindIndex(x => x == lesson);
            int index2 = courses.FindIndex(x => x == lesson2);
            courses[index1] = lesson2;
            courses[index2] = lesson;
        }

        if (courses.Contains(exercise))
        {
            courses.Remove(exercise);
            int index1 = courses.FindIndex(x => x == lesson);
            courses.Insert(index1 + 1, exercise);
        }

        if (courses.Contains(exercise2))
        {
            courses.Remove(exercise2);
            int index2 = courses.FindIndex(x => x == lesson2);
            courses.Insert(index2 + 1, exercise2);
        }
    }

    private static void RemoveLesson(List<string> courses, string[] commands)
    {
        string lesson = commands[1];
        string exercise = lesson + "-Exercise";

        if (courses.Contains(lesson))
        {
            courses.Remove(lesson);
        }

        if (courses.Contains(exercise))
        {
            courses.Remove(exercise);
        }
    }

    private static void InsertLesson(List<string> courses, string[] commands)
    {
        string lesson = commands[1];
        int index = int.Parse(commands[2]);

        if (!courses.Contains(lesson))
        {
            if (index <= courses.Count - 1)
            {
                courses.Insert(index, lesson);
            }
        }
    }

    private static void AddLesson(List<string> courses, string[] commands)
    {
        string lesson = commands[1];

        if (!courses.Contains(lesson))
        {
            courses.Add(lesson);
        }
    }
}