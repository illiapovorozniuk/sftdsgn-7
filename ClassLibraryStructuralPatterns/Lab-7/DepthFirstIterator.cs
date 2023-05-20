using ClassLibraryStructuralPatterns.Composite1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Lab_7
{
    public class DepthFirstIterator : IEnumerable<LightNode>
    {
        private LightNode rootNode;

        public DepthFirstIterator(LightNode root)
        {
            rootNode = root;
        }

        public IEnumerator<LightNode> GetEnumerator()
        {
            return new DepthFirstEnumerator(rootNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
