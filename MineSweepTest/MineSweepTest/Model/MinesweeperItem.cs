using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    public class MinesweeperItem:IGridItem
    {
        public int BombRangeCount{ get; set; }

        public bool Hidden{ get; set; }

        public bool Bomb{ get; set; }

        public bool Marked { get; set; }


        public MinesweeperItem()
        {
            Hidden = true;
        }

        public string GetMark()
        {
            if (Marked)
            {
                return "=";
            }
            if (Hidden)
            {
                return "-";
            }
            if (Bomb)
            {
                return "X";
            }
            if (BombRangeCount == 0)
            {
                return " ";
            }
            return BombRangeCount.ToString();
        }

    }
}
