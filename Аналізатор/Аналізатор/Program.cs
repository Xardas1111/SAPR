using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Аналізатор
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            string line;
            StreamReader str = new StreamReader(@"lab1t.xr");
            bool key = true;
            while (!str.EndOfStream && (key == true))
            {
                NumberOfLines++;
                line = str.ReadLine();
                if (!IsValid(line)) 
                {
                    Console.WriteLine("И еще у тебя ошибка в {0} строке.",NumberOfLines);
                    key = false;
                    break;
                }
                string subline = "";
                int i=0;
                for (i=0;i<line.Length;i++)
                {
                    subline += line[i];
                    if ((subline == " ") || (subline == "\t")) 
                    { 
                        subline = ""; 
                        continue; 
                    }
                    if (IsSeparator(subline)) 
                    {
                        if (i < line.Length - 1)
                        {
                            if (IsSeparator(subline + line[i + 1]) && (line.Length > 2))
                            {
                                i++;
                                if (!GetLexem(subline + line[i]))
                                {
                                    Console.WriteLine("Error in line {0}", NumberOfLines);
                                    key = false;
                                    break;
                                }
                                subline = "";
                                continue;
                            }
                            else 
                            {
                                if (!GetLexem(subline))
                                {
                                    Console.WriteLine("Error in line {0}", NumberOfLines);
                                    key = false;
                                    break;
                                }
                                subline = ""; 
                                continue; 
                            }
                        }
                    }
                    if ((i < line.Length - 1) && (subline != ""))
                    {
                        if ((line.Length > 2) && IsSeparator(Convert.ToString(line[i + 1]))) 
                        {
                            if (!GetLexem(subline))
                            {
                                Console.WriteLine("Error in line {0}", NumberOfLines);
                                key = false;
                                break;
                            }
                            subline = ""; 
                            continue; 
                        }
                    }
                    if ((i == line.Length - 1) && (subline != "")) 
                    {
                        if (!GetLexem(subline))
                        {
                            Console.WriteLine("Error in line {0}", NumberOfLines);
                            key = false;
                            break;
                        }
                        subline = ""; 
                        continue; 
                    }
                }
                if (str.Peek()!=-1)
                    LexemTable.Add(new Lexem(++LexemNumber, NumberOfLines, "¶", 27, 0));
            }
            str.Close();
            if (key)
            {
                StreamWriter str1 = new StreamWriter(@"labt.txt");
                for (int i = 0; i < LexemTable.Count; i++)
                    str1.WriteLine("{0,-8} {1,-10} {2,-16} {3,-10} {4,-10}", LexemTable[i].Number, LexemTable[i].LineNumber, LexemTable[i].LexName, LexemTable[i].Code, LexemTable[i].IdCode);
                str1.WriteLine("//////////////////////////");
                for (int i=0;i<ConstTable.Count;i++)
                    str1.WriteLine("{0,-12} {1,-8}", ConstTable[i].ConstName, ConstTable[i].ConstCode);
                str1.WriteLine("//////////////////////////");
                for (int i = 0; i < IdTable.Count; i++)
                    str1.WriteLine("{0,-12} {1,-8} {2,-8}", IdTable[i].IdName, IdTable[i].IdCode, IdTable[i].IdType);
                Console.WriteLine("Build successful.");
                str1.Close();
            }
            Console.ReadKey();
        }
    }
}