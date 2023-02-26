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
        int numRows = _cells.GetLength(0);
        int numColumns = _cells.GetLength(1);

        // Check for horizontal wins
        for (int row = 0; row < numRows; row++) {
            if (_cells[row, 0] == symbol && _cells[row, 1] == symbol && _cells[row, 2] == symbol)
                return true;
        }

        // Check for vertical wins
        for (int column = 0; column < numColumns; column++) {
            if (_cells[0, column] == symbol && _cells[1, column] == symbol && _cells[2, column] == symbol)
                return true;
        }

        // Check for diagonal wins
        if (_cells[1, 1] == symbol) {
            if ((_cells[0, 0] == symbol && _cells[2, 2] == symbol) || (_cells[0, 2] == symbol && _cells[2, 0] == symbol))
                return true;
        }

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