using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanglMineSweeper.Interfaces
{
    public interface IBoard
    {
        Player Player { get;}
        Tile[,] Tiles { get; set; }
        int MovesTaken { get; set; }
        int PlayerX { get; set; }
        int PlayerY { get; set; }
        string StatusText { get; }
        void MovePlayer(Direction direction);
        void Initialise(int BoardMaxX, int BoardMaxY, int mineCount);
    }
}
