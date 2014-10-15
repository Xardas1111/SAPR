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
            public Lexem(int Number, int LineNumber, string LexName, int Code, int IdCode) 
            { 
                this.Number = Number;
                this.LineNumber = LineNumber;
                this.LexName = LexName;
                this.Code = Code;
                this.IdCode = IdCode;
            }
        }

        struct Id 
        {
            public string IdName;
            public int IdCode;
            public string IdType;
            public Id(string IdName, int IdCode, string IdType) 
            { 
                this.IdName = IdName;
                this.IdCode = IdCode;
                this.IdType = IdType;
            }
        }

        struct Const
        {
            public string ConstName;
            public int ConstCode;
            public Const(string ConstName, int ConstCode)
            {
                this.ConstName = ConstName;
                this.ConstCode = ConstCode;
            }
        }
        static List<Lexem> LexemTable = new List<Lexem>();
        static List<Id> IdTable = new List<Id>();
        static List<Const> ConstTable = new List<Const>();
        static bool IsSeparator(string sub) 
        {
            for (int i = 0; i < separator.Length; i++)
                if (sub == separator[i]) return true;
            return false;
        }

        static bool IsLexem(string sub)
        {
            for (int i = 0; i < lexem.Length; i++)
                if (sub == lexem[i]) return true;
            return false;
        }

        static bool IsTerminal(string sub)
        {
            for (int i = 0; i < terminal.Length; i++)
                if (sub == terminal[i]) return true;
            return false;
        }

        static bool IsId(string sub) 
        {
            if ((Char.IsLower(sub, 0)) || (Char.IsUpper(sub, 0)))
                for (int i = 1; i < sub.Length; i++)
                {
                    if (!(Char.IsLower(sub, i)) && !(Char.IsUpper(sub, i)) && !(Char.IsDigit(sub,i))) return false;
                }
            else return false;
            return true;
        }

        static bool IsConst(string sub) 
        {
            if (!Char.IsDigit(sub, 0)) return false;
            bool point = false;
            for (int i = 1; i < sub.Length; i++) 
            {
                if (sub[sub.Length - 1] == '.') return false;
                if (!Char.IsDigit(sub, i) || (point && (Char.IsDigit(sub, i)))) return false;
                if (sub[i] == '.')
                    point = true;
            }
            return true;
        }
        static bool GetLexem(string name) 
        {
            if (IsLexem(name))
            {
                int c = 0;
                for (int i=0;i<lexem.Length;i++)
                    if(name == lexem[i]) c = i+1;
                LexemTable.Add(new Lexem (++LexemNumber, NumberOfLines, name, c, 0));
                return true;
            }

            if (IsId(name)) 
            {
                LexemTable.Add(new Lexem(++LexemNumber, NumberOfLines, name, 46, ++IdCodeNumber));
                IdTable.Add(new Id(name, IdCodeNumber, "int"));
                return true;
            }

            if (IsConst(name))
            {
                LexemTable.Add(new Lexem(++LexemNumber, NumberOfLines, name, 47, ++ConstCodeNumber));
                IdTable.Add(new Id(name, ConstCodeNumber, "int"));
                return true;
            }
            return false;
        }
    }
}