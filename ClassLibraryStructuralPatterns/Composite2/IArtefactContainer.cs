using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite2
{
    public interface IArtefactContainer : IArtefact
    {
        public void AddArtefact(IArtefact artifact);
        public void RemoveArtefact(IArtefact artifact);
    }
}
