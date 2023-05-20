using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite2
{
    public class MarvelHero
    {
        private List<IArtefact> _artifacts = new List<IArtefact>();
        public string Name { get; private set; }

        private int _power;

        private bool logging = false;

        public MarvelHero(string name, int power)
        {
            this.Name = name;
            this._power = power;
        }

        public void AddArtifact(IArtefact artifact)
        {
            this._artifacts.Add(artifact);
            if (logging)
                Console.WriteLine($"{artifact.GetName()} artefact with the power {artifact.GetPowerBuf()} has been added");
        }

        public void RemoveArtifact(IArtefact artifact)
        {
            this._artifacts.Remove(artifact);
            if (logging)
                Console.WriteLine($"{artifact.GetName()} artefact with the power {artifact.GetPowerBuf()} has been removed");

        }

        public void SetLogging(bool logging)
        {
            this.logging = logging;
        }

        public void Strike()
        {
            int totalPower = this._artifacts.Aggregate(this._power, (sum, next) => sum += next.GetPowerBuf());
            Console.WriteLine($"{this.Name} hits with power {totalPower}");
        }

        public void CalculateArtefictsWeight()
        {
            int totalArtifactsWeight = this._artifacts.Aggregate(0, (sum, next) => sum += next.GetWeight());
            Console.WriteLine($"Total artefact weight: {totalArtifactsWeight}");
        }

        public void CountArtifacts()
        {
            int totalArtifactCount = this._artifacts.Count;
            Console.WriteLine($"{this.Name} has {totalArtifactCount} artefact");
        }
    }
}
