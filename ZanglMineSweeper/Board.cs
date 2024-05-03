using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper
{
    public class Board : IBoard
    {
        IPlayer _player;
        public int MovesTaken { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public Board(IPlayer player)
        {
            _player = player;
        }


        public Tile[,] Tiles { get; set; }

        public Player? Player => _player as Player;

        public string StatusText
        {
            get
            {
                return $"Player position is {_player.CurrentTile.ToString()} {_player.StatusText} Moves Taken = {MovesTaken}";
            }
        }

        public void Initialise(int boardMaxX, int boardMaxY, int mineCount)
        {
            Tiles = new Tile[boardMaxX, boardMaxY];

            Random randomGenerator = new Random();
            var minesAdded = 0;
            for (int x = 0; x < boardMaxX; x++)
            {
                for (int y = 0; y < boardMaxY; y++)
                {
                    if (randomGenerator.Next(6) == 1 && minesAdded < mineCount)
                    {
                        // On the roll of a dice whilst adding tiles to the array, add a mine, if we have not reached the mine count
                        Tiles[x, y] = new Tile(x,y,true);
                        minesAdded++;
                        Debug.WriteLine($"Mine added at {x},{y}");
                    }
                    else
                    {
                        Tiles[x, y] = new Tile(x,y,false);
                    }
                }
            }

            // Set the player to column 0 row (0-7)
            var randomRowCount = randomGenerator.Next(7);
            
            _player.Lives = 3;
            _player.CurrentTile = Tiles[0, randomRowCount];
            if (_player.CurrentTile != null)
            {
                PlayerX = _player.CurrentTile.X;
            }
            if (_player.CurrentTile != null)
            {
                PlayerY = _player.CurrentTile.Y;
            }
        }

        public void MovePlayer(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (PlayerY < 7)
                    {
                        PlayerY++;
                    }
                    break;
                case Direction.Down:
                    if (PlayerY > 0)
                    {
                        PlayerY++;
                    }
                    break;
                case Direction.Left:
                    if (PlayerX > 0)
                    {
                        PlayerX--;
                    }
                    break;
                case Direction.Right:
                    if (PlayerX < 7)
                    {
                        PlayerX++;
                    }
                    break;
            }

            _player.CurrentTile = Tiles[PlayerX, PlayerY];

            if (_player.CurrentTile.HasMine)
            {
                _player.Lives--;
            }

            MovesTaken++;
        }
    }
}
