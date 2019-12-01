using System;
using System.Text;
using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class ConsoleUserInterface : IUserInterface
    {

        public IInputHandler InputHandler;

        public ConsoleUserInterface(IInputHandler inputHandler)
        {
            InputHandler = inputHandler;
        }

        public void WelcomePlayer()
        {
            Console.WriteLine("Welcome to Minesweeper!");
        }

        public Coordinate PromptMove(ICell[,] board)
        {
            
            while (true)
            {
                Console.WriteLine("Please enter your move e.g. '3 5'");
                var stringInput = Console.ReadLine();

                var moveValidation = InputHandler.ValidateInput(stringInput, board);
                
                switch (moveValidation)
                {
                    case MoveValidation.Valid:
                        return InputHandler.ParseCoordinate(stringInput);
                    case MoveValidation.InvalidString:
                        Console.WriteLine("The move you entered is not a valid input string");
                        break;
                    case MoveValidation.InvalidUncoveredCell:
                        Console.WriteLine("The cell you selected has already been uncovered");
                        break;
                    case MoveValidation.InvalidOutOfRange:
                        Console.WriteLine("The coordinates you specified are out of the board's range");
                        break;
                }
            }
            


        }
        
        public void DisplayBoard(ICell[,] board)
        {

            for (var y = board.GetLength(1) - 1; y >= 0; y--)
            {
                var rowStringBuilder = new StringBuilder();
                rowStringBuilder.Append(IntegerToDisplayString(y));
                rowStringBuilder.Append("| ");

                for(var x = 0; x < board.GetLength(0); x++)
                {
                    var renderCell = board[x, y];
                    rowStringBuilder.Append($"{renderCell.GetRenderSymbol()}  ");
                }
                
                Console.WriteLine(rowStringBuilder);
            }

            WriteXAxisLine(board);

            WriteXAxisNumbers(board);
        }

        public void LoseGame()
        {
            Console.WriteLine("You have lost the game!");
        }

        private static void WriteXAxisLine(ICell[,] board)
        {
            var rowLineStringBuilder = new StringBuilder();
            
            rowLineStringBuilder.Append("  |");
            
            for (var x = 0; x < board.GetLength(0); x++)
            {
                rowLineStringBuilder.Append("___");
            }

            Console.WriteLine(rowLineStringBuilder);
        }

        private void WriteXAxisNumbers(ICell[,] board)
        {
            var xAxisRowStringBuilder = new StringBuilder();
            xAxisRowStringBuilder.Append("   ");
            for (var x = 0; x < board.GetLength(0); x++)
            {
                xAxisRowStringBuilder.Append($"{IntegerToDisplayString(x)} ");
            }

            Console.WriteLine(xAxisRowStringBuilder);
        }

        private string IntegerToDisplayString(int integer){
            
            if (integer < 0 || integer > 99)
            {
                throw new ArgumentException();
            }

            if (integer < 10)
            {
                return $"0{integer + 1}"; // Plus one so display indices starts at 1 not 0
            }
            else
            {
                return integer.ToString();
            }
        }
    }

}
