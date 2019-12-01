using System;
using System.Collections.Generic;
using kata_minesweeper.Interfaces;

namespace kata_minesweeper
{
    public class RandomBoardGenerator : IBoardGenerator
    {

        public ICell[,] Board;
        private readonly Random RandomGenerator = new Random();

        public ICell[,] GenerateBoard(int maxXSize, int maxYSize, double mineProportion)
        {

            Board = new ICell[maxXSize, maxYSize];
            
            var totalMinesOnBoard = ((int)Math.Round(mineProportion * maxXSize * maxYSize));

            var boardCoordinateList = GenerateBoardCoordinateList(maxXSize, maxYSize);

            var remainingFreeCoordinateList = AddMineCellsToBoard(boardCoordinateList, totalMinesOnBoard);
            
            AddSafeCellsToBoard(remainingFreeCoordinateList);
            
            SetCellSymbols();

            return Board;
        }

        public List<Coordinate> GenerateBoardCoordinateList(int maxXSize, int maxYSize)
        {
            var boardCoordinateList = new List<Coordinate>();
            
            for (var x = 0; x < maxXSize; x++)
            {
                for (var y = 0; y < maxYSize; y++)
                {
                    boardCoordinateList.Add(new Coordinate(x, y));
                }
            }

            return boardCoordinateList;
        }

        public List<Coordinate> AddMineCellsToBoard(List<Coordinate> freeCoordinateList, int numberOfMines)
        {

            for (var i = 0; i < numberOfMines; i++)
            {

                var randomCoordinateIndex = RandomGenerator.Next(0, freeCoordinateList.Count - 1);
                
                var randomCoordinate = freeCoordinateList[randomCoordinateIndex];
                
                Board[randomCoordinate.XPos,randomCoordinate.YPos] = new MineCell(new CellRenderer());
                
                freeCoordinateList.RemoveAt(randomCoordinateIndex);
                
            }

            return freeCoordinateList;

        }

        public void AddSafeCellsToBoard(List<Coordinate> freeCoordinateList)
        {
            SafeCell.SafeCellsRemaining = 0;
            
            foreach (var freeCoordinate in freeCoordinateList)
            {
                Board[freeCoordinate.XPos , freeCoordinate.YPos ] = new SafeCell(new CellRenderer());
                SafeCell.SafeCellsRemaining++;
            }

            foreach (var freeCoordinate in freeCoordinateList)
            {
                var adjacentMineCount = CalculateAdjacentMineCount(freeCoordinate);
                ((SafeCell) Board[freeCoordinate.XPos, freeCoordinate.YPos]).SetAdjacentMineCount(adjacentMineCount); 
            }
        }

        public int CalculateAdjacentMineCount(Coordinate cellCoordinate)
        {

            var adjacentMineCount = 0;
            
            for(var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    try
                    {
                        if (Board[cellCoordinate.XPos + xDelta, cellCoordinate.YPos + yDelta] is MineCell)
                        {
                            adjacentMineCount++;
                        }
                    }
                    catch (IndexOutOfRangeException e) {}
                    
                }
            }

            return adjacentMineCount;

        }

        public void SetCellSymbols()
        {
            foreach (var cell in Board)
            {
                cell.SetupCell();
            }
        }
    }
}