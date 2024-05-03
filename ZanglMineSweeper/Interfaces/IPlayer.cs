using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanglMineSweeper.Interfaces
{
    public interface IPlayer
    {
        int Lives { get; set; }
        Tile CurrentTile { get; set; }
        bool IsDead { get; }
        string StatusText { get; }
    }
}
