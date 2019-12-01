using System;
using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class MineCell : ICell
    {

        public IRenderer CellRenderer;
        

        public CellStatus CellStatus { get; private set; }

        public MineCell(IRenderer renderer)
        {
            CellStatus = CellStatus.Covered;
            CellRenderer = renderer;
        }


        public void Interact(GameProcessor gameProcessor)
        {
            CellStatus = CellStatus.Uncovered;
            gameProcessor.LoseGame();
        }

        public char GetRenderSymbol()
        {
            return CellRenderer.GetRenderSymbol(CellStatus);
        }
        
        public void SetupCell()
        {
            CellRenderer.UncoveredRenderSymbol = '*';
            CellRenderer.CoveredRenderSymbol = '.';
        }
    }
}