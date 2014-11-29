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
            if (IsPrint() || IsScan() || IsIf() || IsWhile() || IsAssign() || IsDefined())
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
            if (IsOp())
            {
                if (GetLexem().Code == 27)
                {
                    MoveToNextLexem();
                    if (IsOpList())
                    {
                        return true;
                    }
                    else
                    {
                        throw new ApplicationException("Wrong syntax in line " + GetLexem().LineNumber);
                    }
                }
                else
                {
                    throw new ApplicationException("Needs to start from a new line in line " + GetLexem().LineNumber);
                }
            }
            else 
            {
                if (IsDefined())
                {
                    if (GetLexem().Code == 27)
                    {
                        MoveToNextLexem();
                        if (IsOpList())
                        {
                            return true;
                        }
                        else
                        {
                            throw new ApplicationException("Wrong syntax in line " + GetLexem().LineNumber);
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Needs to start from a new line in line " + GetLexem().LineNumber);
                    }
                }
                else 
                {
                    
                    //if (GetLexem().Code == 23)
                    //{
                        return true;
                    //}
                    //else
                    //{
                    //    throw new ApplicationException("WTF^&! in line " + GetLexem().LineNumber);
                    //}
                    
                }
            }
        }

        public bool IsProgram() 
        {
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
                            return true;
                        }
                        else
                        {
                            throw new ApplicationException("Wrong program ending in line " + GetLexem().LineNumber);
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Something gone wrong in line " + GetLexem().LineNumber);
                    }
                }
                else
                {
                    throw new ApplicationException("Needs to start from a new line in line " + GetLexem().LineNumber);
                }
            }
            else 
            {
                throw new ApplicationException("Wrong beginning of program in line " + GetLexem().LineNumber);
            }
        }
    }
}