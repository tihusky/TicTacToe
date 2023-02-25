public enum PlayerSymbol {
    Empty,
    X,
    Y
}

public class Player {
    public string Name { get; }
    public PlayerSymbol Symbol { get; }
    public int Choice { get; set; }

    public Player(string name, PlayerSymbol symbol) {
        Name = name;
        Symbol = symbol;
        Choice = 0;
    }
}