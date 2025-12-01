using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    public class PlainDisplay : IDisplay
    {
        public string FormatString(string message)
        {
            return message;
        }
    }
}
