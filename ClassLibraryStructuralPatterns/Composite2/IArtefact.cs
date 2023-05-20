using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite2
{
    public interface IArtefact
    {
        public string GetName();
        public int GetWeight();
        public int GetPowerBuf();
        public int GetCount();
    }
}
