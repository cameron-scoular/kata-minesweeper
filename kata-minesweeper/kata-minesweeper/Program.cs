using System;

namespace kata_minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellRenderer = new CellRenderer();
            
            var boardGenerator = new RandomBoardGenerator();
            
            var inputHandler = new UserInputHandler();
            
            var userInterface = new ConsoleUserInterface(inputHandler);
            
            var gameProcessor = new GameProcessor(boardGenerator, userInterface, new GameState());

            gameProcessor.SetupGame(15, 15, 0.2);
            
            gameProcessor.PlayGame();

        }
    }
}