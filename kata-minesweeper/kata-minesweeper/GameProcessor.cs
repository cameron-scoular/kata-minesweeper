using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class GameProcessor
    {

        public GameState GameState;
        public IBoardGenerator BoardGenerator;
        public IUserInterface UserInterface;

        public GameProcessor(IBoardGenerator boardGenerator, IUserInterface userInterface, GameState gameState)
        {
            GameState = gameState;
            BoardGenerator = boardGenerator;
            UserInterface = userInterface;
        }

        public void PlayGame()
        {
            while (GameState.GameIsActive)
            {
                UserInterface.DisplayBoard(GameState.GameBoard);
                var selectedCoordinates = UserInterface.PromptMove(GameState.GameBoard);
                
                GameState.GameBoard[selectedCoordinates.XPos, selectedCoordinates.YPos].Interact(this);
                
            }
        }

        public void SetupGame(int maxXBoardSize, int maxYBoardSize, double mineProportion)
        {
            GameState.GameIsActive = true;
            GameState.GameBoard = BoardGenerator.GenerateBoard(maxXBoardSize, maxYBoardSize, mineProportion);
            UserInterface.WelcomePlayer();
        }

        public void LoseGame()
        {
            GameState.GameIsActive = false;
            UserInterface.DisplayBoard(GameState.GameBoard);
            UserInterface.LoseGame();
        }
    }
}