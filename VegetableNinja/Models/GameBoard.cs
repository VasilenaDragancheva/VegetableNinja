namespace VegetableNinja.Models
{
    using Contracts;

    public class GameBoard : IGameBoard
    {
        public GameBoard(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Board = new IGameObject[rows, cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IGameObject[,] Board { get; set; }
    }
}