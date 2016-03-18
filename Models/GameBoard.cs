using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja.Models
{
    using Contracts;

    using Vegetables;

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
