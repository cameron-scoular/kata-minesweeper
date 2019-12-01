using System;
using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class UserInputHandler : IInputHandler
    {
        public Coordinate ParseCoordinate(string input)
        {
            
            var inputArray = input.Split(' ');

            var xPosString = inputArray[0];

            var yPosString = inputArray[1];

            var xPos = int.Parse(xPosString);
            var yPos = int.Parse(yPosString);
            
            return new Coordinate(xPos - 1, yPos - 1);
            
        }

        public MoveValidation ValidateInput(string input, ICell[,] board)
        {
            Coordinate coordinate;
            
            try
            {
                coordinate = ParseCoordinate(input);
            }
            catch (FormatException e)
            {
                return MoveValidation.InvalidString;
            }

            if ( coordinate.XPos < 0 || coordinate.XPos >= board.GetLength(0) || coordinate.YPos < 0 || coordinate.YPos >= board.GetLength(1))
            {
                return MoveValidation.InvalidOutOfRange;
            }

            if (board[coordinate.XPos, coordinate.YPos].CellStatus == CellStatus.Uncovered)
            {
                return MoveValidation.InvalidUncoveredCell;
            }

            return MoveValidation.Valid;
        }
    }
}