using ClassLibraryStructuralPatterns.Composite1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Lab_7
{
    public class BreadthFirstEnumerator : IEnumerator<LightNode>
    {
        private LightNode rootNode;
        private Queue<LightNode> queue;
        private LightNode currentNode;

        public BreadthFirstEnumerator(LightNode root)
        {
            rootNode = root;
            queue = new Queue<LightNode>();
            queue.Enqueue(rootNode);
        }

        public LightNode Current => currentNode;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (queue.Count == 0)
            {
                return false;
            }

            currentNode = queue.Dequeue();

            if (currentNode is LightElementNode elementNode)
            {
                for (int i = 0; i < elementNode.ChildNodesCount; i++)
                {
                    queue.Enqueue(elementNode.GetChildNode(i));
                }
            }

            return true;
        }

        public void Reset()
        {
            queue.Clear();
            queue.Enqueue(rootNode);
            currentNode = null;
        }

        public void Dispose()
        {
            // No resources to dispose
        }
    }
}
