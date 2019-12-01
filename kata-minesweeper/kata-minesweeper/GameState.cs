using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class GameState
    {

        public ICell[,] GameBoard { get; set; }

        public bool GameIsActive;

    }
}