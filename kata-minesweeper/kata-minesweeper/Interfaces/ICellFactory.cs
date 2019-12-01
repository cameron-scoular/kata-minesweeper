namespace kata_minesweeper.Interfaces
{
    public interface ICellFactory
    {
        MineCell CreateMineCell();
        SafeCell CreateSafeCell(); 
    }
}