using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3
{
    internal interface IStringIO
    {
        public string GetString();
        public void PrintString(string output);
        public void Clear();
        public void Exit();
    }
}
