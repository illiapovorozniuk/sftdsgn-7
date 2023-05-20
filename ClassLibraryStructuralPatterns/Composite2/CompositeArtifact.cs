using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite2
{
    public class CompositeArtifact : Artefact, IArtefactContainer
    {
        private List<IArtefact> _children = new List<IArtefact>();
        public CompositeArtifact(string name, int weight, int powerBuf) : base(name, weight, powerBuf)
        {
        }

        public void AddArtefact(IArtefact artifact)
        {
            this._children.Add(artifact);
        }

        public void RemoveArtefact(IArtefact artifact)
        {
            this._children.Remove(artifact);
        }

        public override int GetWeight()
        {
            return this._children.Aggregate(this._weight, (sum, next) => sum += next.GetWeight());
        }

        public override int GetPowerBuf()
        {
            return this._children.Aggregate(this._powerBuf, (sum, next) => sum += next.GetPowerBuf());
        }

        public override int GetCount()
        {
            return this._children.Aggregate(0, (sum, next) => sum += next.GetCount());
        }
    }
}
