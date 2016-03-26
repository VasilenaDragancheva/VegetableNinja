namespace VegetableNinja.Contracts
{
    public interface IGameObject
    {
        char Sign { get; }

        int Row { get; set; }

        int Col { get; set; }
    }
}