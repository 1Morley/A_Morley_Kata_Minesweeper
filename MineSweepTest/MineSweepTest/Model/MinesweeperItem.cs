using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class MinesweeperItem:IGridItem
    {
        public int BombRangeCount{ get; set; }

        public bool Hidden{ get; set; }

        public bool Bomb{ get; set; }

        public bool Marked { get; set; }

        public IDisplay display { get; private set; }

        public MinesweeperItem()
        {
            display = new GridDisplayDecor(new PlainDisplay());
            Hidden = true;
        }

        public string GetMark()
        {
            if (Marked)
            {
                return display.FormatString("=");
            }
            if (Hidden)
            {
                return display.FormatString("-");
            }
            if (Bomb)
            {
                display = new BoldDisplayDecor(display);
                return display.FormatString("X");
            }
            if (BombRangeCount == 0)
            {
                return display.FormatString(" ");
            }
            return display.FormatString(BombRangeCount.ToString());
        }

    }
}
