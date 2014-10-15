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
            StreamReader str = new StreamReader(@"f:\lab1t.xr");
            while (!str.EndOfStream)
            {
                NumberOfLines++;
                line = str.ReadLine();
                string subline = "";
                int i=0;
                for (i=0;i<line.Length;i++)
                {
                    subline += line[i];
                    if (IsSeparator(subline)) 
                    {
                        if (i < line.Length - 1)
                        {
                            if (IsSeparator(subline + line[i + 1]) && (line.Length > 2)) { i++; subline = ""; }
                            else subline = "";
                        }
                    }
                    if ((i < line.Length - 1) && (subline != ""))
                    {
                        if ((line.Length > 2) && IsSeparator(Convert.ToString(line[i + 1]))) subline = "";
                    }
                    if ((i == line.Length - 1) && (subline != "")) subline = "";
                }
            }
            Console.ReadKey();
        }
    }
}