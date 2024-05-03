using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper
{
    public class Game : IGame
    {
        private const int BoardMaxX = 8;
        private const int BoardMaxY = 8;

        IBoard _board;

        public Game(IBoard board)
        {
            _board = board;

            Initialise();
        }

        public string StatusText
        {
            get
            {
                return _board.StatusText;
            }
        }

        public bool GameOver
        {
            get
            {
                if (_board.Player.CurrentTile.X == (BoardMaxX -1) && _board.Player.IsDead == false ||
                    _board.Player.IsDead == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public IBoard GetBoard()
        {
            return _board;
        }

        public void Initialise()
        {
            _board.Initialise(BoardMaxX, BoardMaxY, mineCount: 10);
        }
    }
}
