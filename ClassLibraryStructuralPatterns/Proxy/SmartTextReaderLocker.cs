using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Proxy
{
    public class SmartTextReaderLocker : ITextReader
    {
        private ITextReader _textReader;
        private string _reg;

        public SmartTextReaderLocker(ITextReader textReader, string reg)
        {
            _textReader = textReader;
            _reg = reg;
        }

        public char[][] Read(string path)
        {
            if (Regex.IsMatch(path, $@".*{_reg}.*"))
            {
                return null;
            }
            return _textReader.Read(path);
        }
    }
}
