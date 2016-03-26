namespace VegetableNinja.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Ninja : INinja
    {
        private const int InitialPower = 1;

        private const int InitialStamina = 1;

        private string name;

        private int stamina;

        private int power;

        private bool onTurn;

        private List<IVegetable> collectedVegetables;

        public Ninja(string name)
        {
            this.Name = name;
            this.Stamina = InitialStamina;
            this.Power = InitialPower;
            this.collectedVegetables = new List<IVegetable>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of ninja");
                }

                this.name = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }

            set
            {
                value = value <= 0 ? 0 : value;
                this.power = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                value = value <= 0 ? 0 : value;
                this.stamina = value;
            }
        }

        public char Sign
        {
            get
            {
                return this.Name[0];
            }
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool OnTurn
        {
            get
            {
                return this.onTurn;
            }

            set
            {
                if (value == false)
                {
                    this.EatVegetables();
                }

                this.onTurn = value;
            }
        }

        public void CollectVegetable(IVegetable vegetable)
        {
            this.collectedVegetables.Add(vegetable);
        }

        public void EatVegetables()
        {
            foreach (var collectedVegetable in this.collectedVegetables)
            {
                this.Power += collectedVegetable.PowerEffect;
                this.Stamina += collectedVegetable.StaminaEffect;
            }

            this.collectedVegetables = new List<IVegetable>();
        }

        public override string ToString()
        {
            var winner = new StringBuilder();
            winner.AppendFormat("Winner: {0}", this.Name)
                .AppendLine()
                .AppendFormat("Power: {0}", this.Power)
                .AppendLine()
                .AppendFormat("Stamina: {0}", this.Stamina)
                .AppendLine();
            return winner.ToString();
        }
    }
}