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
            Console.WriteLine("The way: ");
            string path = @"labtest.xr";
            StreamReader str = new StreamReader(path);
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
                    if ((subline == "-") && (line[i + 1] >= 46) && (line[i + 1] <= 57))
                    {
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
                Console.WriteLine("Build Successful.");
                Parser parser = new Parser(LexemTable);
                try
                {
                    if (parser.IsDefined())
                    {
                        if (parser.IsAssign())
                        Console.WriteLine("All is Correct.");
                    }
                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}