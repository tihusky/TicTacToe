public class Game {
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private Board _board;

    public Game() {
        _player1 = new Player("Player 1", PlayerSymbol.X);
        _player2 = new Player("Player 2", PlayerSymbol.O);
        _currentPlayer = _player1;
        _board = new Board();
    }

    public void Run() {
        while (true) {
            UserInterface.DisplayBoard(_board);
            UserInterface.WriteLine($"{_currentPlayer.Name}, what square do you want to play in?");
            _currentPlayer.Choice = UserInterface.GetIntInRange(">", 1, 9);

            if (!_board.CellIsEmpty(_currentPlayer.Choice)) {
                UserInterface.WriteLineColored("Invalid choice!", ConsoleColor.Red);
                continue;
            }

            _board.Update(_currentPlayer.Choice, _currentPlayer.Symbol);

            if (_board.PlayerWon(_currentPlayer.Symbol)) {
                UserInterface.WriteLineColored($"{_currentPlayer.Name} won!", ConsoleColor.Green);
                break;
            } else if (_board.AllCellsFilled()) {
                UserInterface.WriteLineColored("It's a draw!", ConsoleColor.Yellow);
                break;
            }

            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }
    }
}