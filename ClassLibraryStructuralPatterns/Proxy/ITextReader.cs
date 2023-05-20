using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Proxy
{
    public interface ITextReader
    {
        public char[][] Read(string path);
    }
}
