using ClassLibraryStructuralPatterns.Composite1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryStructuralPatterns.Lab_7
{
    public class DepthFirstEnumerator : IEnumerator<LightNode>
    {
        private LightNode rootNode;
        private Stack<LightNode> stack;
        private LightNode currentNode;

        public DepthFirstEnumerator(LightNode root)
        {
            rootNode = root;
            stack = new Stack<LightNode>();
            stack.Push(rootNode);
        }

        public LightNode Current => currentNode;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (stack.Count == 0)
            {
                return false;
            }

            currentNode = stack.Pop();

            if (currentNode is LightElementNode elementNode)
            {
                for (int i = elementNode.ChildNodesCount - 1; i >= 0; i--)
                {
                    stack.Push(elementNode.GetChildNode(i));
                }
            }

            return true;
        }

        public void Reset()
        {
            stack.Clear();
            stack.Push(rootNode);
            currentNode = null;
        }

        public void Dispose()
        {
        }
    }
}
