namespace VegetableNinja.Core
{
    using System;

    using Contracts;

    using Models.Vegetables;

    public class VegetableFactory
    {
        public IVegetable CreateVegetable(char sign)
        {
            switch (sign)
            {
                case 'A':
                    return new Asparagus();
                case 'B':
                    return new Broccoli();
                case 'C':
                    return new CherryBerry();
                case 'M':
                    return new Mushroom();
                case 'R':
                    return new Royal();
                default:
                    throw new ArgumentException();
            }
        }
    }
}