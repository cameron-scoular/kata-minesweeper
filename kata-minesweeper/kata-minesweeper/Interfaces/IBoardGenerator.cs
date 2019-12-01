namespace kata_minesweeper.Interfaces
{
    public interface IBoardGenerator
    {
        ICell[,] GenerateBoard(int maxXSize, int maxYSize, double mineProportion);
    }
}