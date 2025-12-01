using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class GridDisplayDecor : DisplayDecorator
    {
        public GridDisplayDecor(IDisplay parentDisplay) : base(parentDisplay)
        { }

        public override string FormatString(string message)
        {
            return ParentDisplay.FormatString($"[ {message} ]");
        }
    }
}
