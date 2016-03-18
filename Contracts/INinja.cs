namespace VegetableNinja
{
    using System.Collections.Generic;

    using Models.Vegetables;

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