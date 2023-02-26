public class Board {
    private readonly PlayerSymbol[,] _cells;
    
    public Board() {
        _cells = new PlayerSymbol[3,3];

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                _cells[i, j] = PlayerSymbol.Empty;
            }
        }
    }

    public PlayerSymbol[,] Cells {
        get => (PlayerSymbol[,])_cells.Clone();
    }

    public bool CellIsEmpty(int cellNumber) {
        (int row, int column) = NumberToIndices(cellNumber);

        return _cells[row, column] == PlayerSymbol.Empty;
    }

    public void Update(int cellNumber, PlayerSymbol symbol) {
        (int row, int column) = NumberToIndices(cellNumber);

        _cells[row, column] = symbol;
    }

    public bool PlayerWon(PlayerSymbol symbol) {
        return false;
    }

    private (int, int) NumberToIndices(int cellNumber) {
        return cellNumber switch {
            1 => (0, 0),
            2 => (0, 1),
            3 => (0, 2),
            4 => (1, 0),
            5 => (1, 1),
            6 => (1, 2),
            7 => (2, 0),
            8 => (2, 1),
            _ => (2, 2),
        };
    }
}