using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite2
{
    public class ArtefactContainer : IArtefactContainer
    {
        public string Name { get; private set; }
        private List<IArtefact> _children = new List<IArtefact>();

        public ArtefactContainer(string name)
        {
            Name = name;
        }

        public void AddArtefact(IArtefact artifact)
        {
            this._children.Add(artifact);
        }

        public void RemoveArtefact(IArtefact artifact)
        {
            this._children.Remove(artifact);
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetWeight()
        {
            return _children.Sum((next) => next.GetWeight());
        }

        public int GetPowerBuf()
        {
            return _children.Sum((next) => next.GetPowerBuf());
        }

        public int GetCount()
        {
            return _children.Sum((next) => next.GetCount());
        }
    }
}
