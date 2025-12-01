using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class ProperCaseDisplayDecor : DisplayDecorator
    {
        public ProperCaseDisplayDecor(IDisplay parentDisplay) : base(parentDisplay)
        { }

        public override string FormatString(string message)
        {
            string updatedMessage = message.ToLower();
            updatedMessage = char.ToUpper(updatedMessage[0]) + updatedMessage.Substring(1);

            return ParentDisplay.FormatString($"{updatedMessage}");
        }
    }
}
