public static class UserInterface {
    public static int GetIntInRange(string prompt, int min, int max) {
        while (true) {
            Console.Write($"{prompt} ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number >= min && number <= max)
                return number;
        }
    }

    public static void DisplayBoard(Board board) {
        PlayerSymbol[,] cells = board.Cells;
        int numRows = cells.GetLength(0);
        int numColumns = cells.GetLength(1);

        for (int row = numRows - 1; row >= 0; row--) {
            if (row != numRows - 1)
                Console.WriteLine("---+---+---");

            for (int column = 0; column < numColumns; column++) {
                if (column != 0)
                    Console.Write("|");

                char symbol = cells[row, column] switch {
                    PlayerSymbol.X => 'x',
                    PlayerSymbol.O => 'o',
                    _ => ' '
                };

                Console.Write($" {symbol} ");
            }

            Console.WriteLine();
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