namespace VegetableNinja.Models.Vegetables
{
    public interface IGameObject
    {
        char Sign { get; }

        int Row { get; set; }

        int Col { get; set; }
    }
}