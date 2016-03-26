namespace VegetableNinja.Contracts
{
    public interface IGameBoard
    {
        int Rows { get; }

        int Cols { get; }

        IGameObject[,] Board { get; }
    }
}