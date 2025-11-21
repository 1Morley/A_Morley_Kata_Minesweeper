using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    public interface Iterator<T>
    {
        T Next();
        bool HasNext();
        T GetCurrent();
    }
}
