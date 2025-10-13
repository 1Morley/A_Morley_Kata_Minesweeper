using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest
{
    public class MineItem
    {
     
        private string bombLabel;
        public string BombLabel
        {
            get { return bombLabel; }
            set
            {
                bombLabel = value;
            }
        }


        private int bombRangeCount;
        public int BombRangeCount
        {
            get { return bombRangeCount; }
            set
            {
                bombRangeCount = value;
                updateBombLabel();
            }
        }


        private bool hidden;
        public bool Hidden
        {
            get { return hidden; }
            set
            {
                hidden = value;
                updateBombLabel();
            }
        }

        private bool bomb;
        public bool Bomb
        {
            get { return bomb; }
            set
            {
                bomb = value;
                bombRangeCount = 10;
                updateBombLabel();
            }
        }

        private bool marked;
        public bool Marked
        {
            get { return marked; }
            set
            {
                marked = value;
                updateBombLabel();
            }
        }

        public MineItem()
        {
            Hidden = true;
        }

        public void updateBombLabel()
        {
            if (Marked)
            {
                BombLabel = "=";
            }
            else if (Hidden)
            {
                BombLabel = "_";
            }
            else if (Bomb)
            {
                BombLabel = "X";
            }
            else
            {
                BombLabel = BombRangeCount.ToString();
            }
        }
    }
}
