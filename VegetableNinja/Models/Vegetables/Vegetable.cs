namespace VegetableNinja.Models.Vegetables
{
    using Contracts;

    public class Vegetable : IVegetable
    {
        private int turnsAfterCollection = 1;

        public Vegetable(char sign, int powerEffect, int staminaEffect, int turnsToRegrow)
        {
            this.Sign = sign;
            this.PowerEffect = powerEffect;
            this.StaminaEffect = staminaEffect;
            this.TurnsToRegrow = turnsToRegrow;
            this.Collected = false;
        }

        public int PowerEffect { get; private set; }

        public int StaminaEffect { get; private set; }

        public int TurnsToRegrow { get; private set; }

        public char Sign { get; private set; }

        public bool Collected { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public void Update()
        {
            // TODO find right check depedning on problem
            if (this.Collected)
            {
                this.turnsAfterCollection++;
            }

            if (this.turnsAfterCollection == this.TurnsToRegrow)
            {
                this.Collected = false;
                this.turnsAfterCollection = 0;
            }
        }
    }
}