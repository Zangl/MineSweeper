using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanglMineSweeper
{
    public class Tile
    {
        public bool HasMine { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Tile(int x, int y, bool hasMine)
        {
            X = x;
            Y = y;  
            HasMine = hasMine;
        }

        public override string? ToString()
        {
            return $"({(char)('A' + (X))}{Y})";
        }
    }
}
