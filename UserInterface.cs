public static class UserInterface {
    public static int GetIntInRange(string prompt, int min, int max) {
        while (true) {
            Console.Write($"{prompt} ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number >= min && number <= max)
                return number;
        }
    }

    public static void Write(string text) {
        Console.Write(text);
    }

    public static void WriteLine(string text) {
        Console.WriteLine(text);
    }

    public static void WriteColored(string text, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public static void WriteLineColored(string text, ConsoleColor color) {
        WriteColored(text + "\n", color);
    }
}