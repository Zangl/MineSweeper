using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper
{
    public class Player : IPlayer
    {
        public int Lives { get; set; }
        public Tile CurrentTile { get; set; }
        public bool IsDead => Lives <= 0;
        public string StatusText
        {
            get
            {
                return $"Lives = {Lives}";
            }
        }
    }
}
