using System;
using kata_minesweeper.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace kata_minesweeper
{
    public class SafeCell : ICell
    {
        private IRenderer CellRenderer;

        public static int SafeCellsRemaining;
     
        public CellStatus CellStatus { get; private set; }

        public int AdjacentMineCount { get; private set; }

        public SafeCell(IRenderer renderer)
        {
            CellStatus = CellStatus.Covered;
            CellRenderer = renderer;
        }
        

        public void Interact(GameProcessor gameProcessor)
        {
            CellStatus = CellStatus.Uncovered;
            SafeCellsRemaining--;
        }

        public char GetRenderSymbol()
        {
            return CellRenderer.GetRenderSymbol(CellStatus);
        }

        public void SetAdjacentMineCount(int adjacentMineCount)
        {
            AdjacentMineCount = adjacentMineCount;
            CellRenderer.UncoveredRenderSymbol = adjacentMineCount.ToString()[0];
        }
        
        public void SetupCell()
        {
            CellRenderer.CoveredRenderSymbol = '.';
            CellRenderer.UncoveredRenderSymbol = AdjacentMineCount.ToString()[0];
        }

    }
}