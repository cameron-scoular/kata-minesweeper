namespace kata_minesweeper.Interfaces
{
    public interface IInputHandler
    {
        Coordinate ParseCoordinate(string input);

        MoveValidation ValidateInput(string input, ICell[,] board);
    }
}