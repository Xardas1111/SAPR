using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Аналізатор
{
    public partial class Parser
    {
        public bool IsOp() 
        {
            if (IsPrint() || IsScan() || IsIf() || IsWhile() || IsAssign())
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool IsOpList() 
        { 
            
        }
    }
}
