using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    public class BoldDisplayDecor : DisplayDecorator
    {
        public BoldDisplayDecor(IDisplay parentDisplay) : base(parentDisplay)
        { }

        public override string FormatString(string message)
        {
            // italic and bold because the bold is very hard to see
            return ParentDisplay.FormatString($"\x1b[3m\x1b[1m{message}\x1b[0m");
        }
    }
}
