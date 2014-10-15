using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Аналізатор
{
    partial class Program
    {
        static int LexemNumber = 0;
        static int NumberOfLines = 0;
        static int ConstCodeNumber = 0;
        static int IdCodeNumber = 0;
        static string[] lexem = { "int", "real", "print", "scan", "while", "do", "if", "moveto", "=", "<>", "<=", ">=", "<", ">", "==", "AND", "OR", ",", "+", "-", "*", "/", "{", "}", "(", ")", ":", "NOT" };
        static string[] terminal = { "int", "real", "print", "scan", "while", "do", "if", "moveto", "AND", "OR", "NOT" };
        static string[] separator = { "=", "<>", "<=", ">=", "<", ">", "==", ",", "+", "-", "*", "/", "{", "}", "(", ")", ":", " " };
        struct Lexem 
        {
            public int Number;
            public int LineNumber;
            public string LexName;
            public int Code;
            public int IdCode;
        }
        static bool IsSeparator(string sub) 
        {
            for (int i = 0; i < separator.Length; i++)
                if (sub == separator[i]) return true;
            return false;
        }
        static bool IsTerminal(string sub)
        {
            for (int i = 0; i < terminal.Length; i++)
                if (sub == terminal[i]) return true;
            return false;
        }

        static void GetLexem(string name) 
        { 
            
        }
    }
}