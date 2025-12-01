using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    public class DisplayDecorator : IDisplay
    {
        internal IDisplay ParentDisplay { get; set; }

        public DisplayDecorator(IDisplay parentDisplay)
        {
            ParentDisplay = parentDisplay;
        }

        public virtual string FormatString(string message)
        {
            return ParentDisplay.FormatString(message);
        }
    }
}
