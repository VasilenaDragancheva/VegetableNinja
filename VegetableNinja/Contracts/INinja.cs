namespace VegetableNinja.Contracts
{
    public interface INinja : IGameObject
    {
        string Name { get; }

        int Power { get; set; }

        int Stamina { get; set; }

        bool OnTurn { get; set; }

        void CollectVegetable(IVegetable vegetable);

        void EatVegetables();
    }
}