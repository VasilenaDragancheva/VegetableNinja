namespace VegetableNinja
{
    using Models.Vegetables;

    public interface IVegetable : IGameObject
    {
        int PowerEffect { get; }

        int StaminaEffect { get; }

        int TurnsToRegrow { get; }

        bool Collected { get; set; }

        void Update();
    }
}