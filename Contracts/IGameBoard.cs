namespace VegetableNinja.Contracts
{
    using Models.Vegetables;

    public interface IGameBoard
    {
        int Rows { get; }

        int Cols { get; }

        IGameObject[,] Board { get; }
    }
}