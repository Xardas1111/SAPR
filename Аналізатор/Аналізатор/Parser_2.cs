using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Аналізатор
{
    public partial class Parser
    {
        public bool IsOpList() 
        {
            return true;
        }

        public bool IsIf() 
        {
            if (GetLexem().Code == 7)
            {
                MoveToNextLexem();
                if (IsLogExpression())
                {
                    if (GetLexem().Code == 27)
                    {
                        MoveToNextLexem();
                        if (GetLexem().Code == 22)
                        {
                            MoveToNextLexem();
                            if (GetLexem().Code == 27)
                            {
                                MoveToNextLexem();
                                if (IsOpList())
                                {
                                    if (GetLexem().Code == 23)
                                    {
                                        MoveToNextLexem();
                                        return true;
                                    }
                                    else
                                    {
                                        throw new ApplicationException("Need a closing bracket in line " + GetLexem().LineNumber);
                                    }
                                }
                                else
                                {
                                    throw new ApplicationException("Need an operation list in line " + GetLexem().LineNumber);
                                }
                            }
                            else
                            {
                                throw new ApplicationException("Need to start from a new line in line " + GetLexem().LineNumber);
                            }
                        }
                        else
                        {
                            throw new ApplicationException("Need an opening bracket in line " + GetLexem().LineNumber);
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Need to start from a new line in line " + GetLexem().LineNumber);
                    }
                }
                else
                {
                    throw new ApplicationException("Need a logical expression in line " + GetLexem().LineNumber);
                }
            }
            else 
            {
                return false;
            }
        }


    }
}
