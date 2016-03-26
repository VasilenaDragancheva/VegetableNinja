namespace VegetableNinja.Models
{
    using Contracts;

    public class BlankSpace : IBlankSpace
    {
        public char Sign
        {
            get
            {
                return '-';
            }
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}