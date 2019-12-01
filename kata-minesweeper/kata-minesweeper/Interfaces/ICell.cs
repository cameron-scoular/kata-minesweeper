namespace kata_minesweeper.Interfaces
{
    public interface ICell
    {

        void Interact(GameProcessor gameProcessor);

        char GetRenderSymbol();

        void SetupCell();
        
        CellStatus CellStatus { get; }

    }
}