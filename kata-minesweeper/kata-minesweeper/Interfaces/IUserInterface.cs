namespace kata_minesweeper.Interfaces
{
    public interface IUserInterface
    {
        void DisplayBoard(ICell[,] board);

        void WelcomePlayer();

        Coordinate PromptMove(ICell[,] board);

        void LoseGame();
        void WinGame();
    }
}