using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanglMineSweeper.Interfaces
{
    public interface IGame
    {
        IBoard GetBoard();

        string StatusText { get; }
        bool GameOver { get; }

        void Initialise();
    }
}
