using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Proxy
{
    public class SmartTextReader : ITextReader
    {
        public char[][] Read(string path)
        {
            string[] lines = File.ReadAllLines(path);

            char[][] charArray = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                charArray[i] = lines[i].ToCharArray();
            }

            return charArray;
        }
    }
}
