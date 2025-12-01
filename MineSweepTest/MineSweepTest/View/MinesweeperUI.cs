using MineSweepTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.View
{
    internal class MinesweeperUI:GridUI<MinesweeperItem>
    {
        public void GetGridSize(out int rowSize, out int columnSize) 
        {
            int maxSize = 25;
            int minSize = 8;
            rowSize = BasicUI.getInt($"Row size (between {minSize} and {maxSize}): ", minSize, maxSize );
            columnSize = BasicUI.getInt($"Column size (between {minSize} and {maxSize}): ", minSize, maxSize);
            return;
        }

        public void MarkItemCords(int rowSize, int columnSize, out int row, out int column)
        {
            GetItemCords("Mark Item", rowSize, columnSize, out row, out column);
        }
        public void SelectItemCords(int rowSize, int columnSize, out int row, out int column)
        {
            GetItemCords("Select Item", rowSize, columnSize, out row, out column);
        }

        public bool SelectOrMarkSelect()
        {
            string[] optionList = { "Select", "Mark" };
            int userInput = BasicUI.getIndexFromList(optionList, false);
            return (userInput == 1);
        }

        public void EndGameDisplay(bool win)
        {
            if(win)
            {
                Console.WriteLine("YOU WIN :D");
            }
            else
            {
                Console.WriteLine("YOUR DEAD :D");
            }
        }
    }
}
