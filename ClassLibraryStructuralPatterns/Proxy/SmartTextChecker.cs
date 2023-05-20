using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Proxy
{
    public class SmartTextChecker : ITextReader
    {
        private ITextReader _reader;


        public SmartTextChecker(ITextReader reader)
        {
            _reader = reader;
        }
        public char[][] Read(string path)
        {
            int _numLines = 0;
            int _numChars = 0;
            Console.WriteLine($"Opening file: {path}");
            char[][] result = _reader.Read(path);
            Console.WriteLine($"Closing file: {path}");

            foreach (char[] row in result)
            {
                _numLines++;
                _numChars += result.Length;
            }

            Console.WriteLine($"Total lines read: {_numLines}");
            Console.WriteLine($"Total characters read: {_numChars}");

            return result;
        }
    }
}
