namespace VegetableNinja
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Models;

    public class Engine
    {
        private readonly IReader reader;

        private readonly VegetableFactory vegetableFactory;

        private readonly List<string> moves;

        private readonly IRenderer renderer;

        private IGameBoard gameBoard;

        public Engine(IReader reader, IRenderer renderer, VegetableFactory vegetableFactory)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.vegetableFactory = vegetableFactory;
            this.moves = new List<string>();
        }

        public INinja FirstPlayer { get; private set; }

        public INinja SecondPlayer { get; private set; }

        public virtual void Run()
        {
            this.FirstPlayer = new Ninja(this.reader.ReadLine());
            this.SecondPlayer = new Ninja(this.reader.ReadLine());
            this.CreateGameBoard();
            if (this.gameBoard.Rows == 0 || this.gameBoard.Cols == 0)
            {
                this.renderer.WriteLine(
                    this.FirstPlayer.Power >= this.SecondPlayer.Power
                        ? this.FirstPlayer.ToString()
                        : this.SecondPlayer.ToString());
            }
            else
            {
                this.PlayGame();
            }
        }

        private void PlayGame()
        {
            bool hasWinner = false;
            var playerOnTurn = this.FirstPlayer;
            this.FirstPlayer.OnTurn = true;

            while (!hasWinner)
            {
                string move = this.reader.ReadLine();
                if (string.IsNullOrEmpty(move))
                {
                    break;
                }

                for (int i = 0; i < move.Length; i++)
                {
                    this.ChangePosition(playerOnTurn, move[i]);
                    playerOnTurn.Stamina--;
                    this.Update();

                    hasWinner = this.HandleCollision(playerOnTurn);
                    if (hasWinner)
                    {
                        break;
                    }

                    if (playerOnTurn.Stamina == 0)
                    {
                        playerOnTurn = this.SwitchPlayers();
                    }
                }
            }

            this.renderer.WriteLine(
                this.FirstPlayer.Power >= this.SecondPlayer.Power
                    ? this.FirstPlayer.ToString()
                    : this.SecondPlayer.ToString());
        }

        private void Update()
        {
            for (int r = 0; r < this.gameBoard.Rows; r++)
            {
                for (int c = 0; c < this.gameBoard.Cols; c++)
                {
                    bool freeSecond = this.SecondPlayer.Row != r && this.SecondPlayer.Col != c;
                    bool freeFirst = this.FirstPlayer.Row != r && this.FirstPlayer.Col != c;
                    bool couldUpdate = this.gameBoard.Board[r, c] is IVegetable && freeFirst && freeSecond;
                    if (couldUpdate)
                    {
                        ((IVegetable)this.gameBoard.Board[r, c]).Update();
                    }
                }
            }
        }

        private INinja SwitchPlayers()
        {
            var currentPlayer = this.FirstPlayer.OnTurn ? this.FirstPlayer : this.SecondPlayer;
            var nextPlayer = !this.FirstPlayer.OnTurn ? this.FirstPlayer : this.SecondPlayer;
            currentPlayer.OnTurn = false;
            nextPlayer.OnTurn = true;
            return nextPlayer;
        }

        private bool HandleCollision(INinja playerOnTurn)
        {
            char signOpponent = playerOnTurn.Sign == this.FirstPlayer.Sign
                                    ? this.SecondPlayer.Sign
                                    : this.FirstPlayer.Sign;
            int col = playerOnTurn.Col;
            int row = playerOnTurn.Row;
            char sign = this.gameBoard.Board[row, col].Sign;
            if (sign == signOpponent)
            {
                return true;
            }

            switch (sign)
            {
                case '-':
                    return false;
                case 'A':
                case 'B':
                case 'C':
                case 'M':
                case 'R':
                    this.CollectVegetable(playerOnTurn);
                    return false;
                default:
                    return false;
            }
        }

        private void CollectVegetable(INinja playerOnTurn)
        {
            IVegetable vegetable = (IVegetable)this.gameBoard.Board[playerOnTurn.Row, playerOnTurn.Col];
            if (!vegetable.Collected)
            {
                playerOnTurn.CollectVegetable(vegetable);
                vegetable.Collected = true;
            }
        }

        private void ChangePosition(INinja playerOnTurn, char p)
        {
            switch (p)
            {
                case 'U':
                    playerOnTurn.Row = Math.Max(0, playerOnTurn.Row - 1);
                    break;

                case 'D':
                    playerOnTurn.Row = Math.Min(this.gameBoard.Rows - 1, playerOnTurn.Row + 1);
                    break;

                case 'L':
                    playerOnTurn.Col = Math.Max(0, playerOnTurn.Col - 1);
                    break;
                case 'R':
                    playerOnTurn.Col = Math.Min(this.gameBoard.Cols - 1, playerOnTurn.Col + 1);
                    break;
            }
        }

        private void CreateGameBoard()
        {
            int[] dimensions = this.reader.ReadLine().Split().Select(int.Parse).ToArray();
            this.gameBoard = new GameBoard(dimensions[0], dimensions[1]);
            for (int row = 0; row < this.gameBoard.Rows; row++)
            {
                string vegetables = this.reader.ReadLine();
                for (int col = 0; col < vegetables.Length; col++)
                {
                    if (vegetables[col] == this.FirstPlayer.Sign)
                    {
                        this.FirstPlayer.Row = row;
                        this.FirstPlayer.Col = col;
                        this.gameBoard.Board[row, col] = this.FirstPlayer;
                    }
                    else if (vegetables[col] == this.SecondPlayer.Sign)
                    {
                        this.SecondPlayer.Row = row;
                        this.SecondPlayer.Col = col;
                        this.gameBoard.Board[row, col] = this.SecondPlayer;
                    }
                    else if (vegetables[col] != '-')
                    {
                        this.gameBoard.Board[row, col] = this.vegetableFactory.CreateVegetable(vegetables[col]);
                    }
                    else
                    {
                        this.gameBoard.Board[row, col] = new BlankSpace();
                    }
                }
            }
        }
    }
}