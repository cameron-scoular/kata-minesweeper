using System;
using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class CellRenderer : IRenderer
    {
        public char CoveredRenderSymbol { get; set; }
        public char UncoveredRenderSymbol { get; set; }

        public char GetRenderSymbol(CellStatus cellStatus)
        {
            switch (cellStatus)
            {
                case CellStatus.Covered:
                    return CoveredRenderSymbol;
                case CellStatus.Uncovered:
                    return UncoveredRenderSymbol;
                default:
                    throw new Exception();
            }
        }
        
    }
}