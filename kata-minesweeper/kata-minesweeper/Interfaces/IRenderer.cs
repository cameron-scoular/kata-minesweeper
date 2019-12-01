namespace kata_minesweeper.Interfaces
{
    public interface IRenderer
    {
        char GetRenderSymbol(CellStatus cellStatus);

        char UncoveredRenderSymbol { get; set; }
        char CoveredRenderSymbol { get; set; }
    }
}