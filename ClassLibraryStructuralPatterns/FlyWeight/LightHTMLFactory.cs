using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryStructuralPatterns.Composite1;

namespace ClassLibraryStructuralPatterns.FlyWeight
{
    public class LightHTMLFactory
    {
        private readonly Dictionary<string, LightNode> _lightNodes = new();
        public int ObjectCount { get; private set; }

        public LightNode TextNode(string tagName, string text, List<string> cssClasses)
        {
            string key = $"{tagName}:{text}";

            if (_lightNodes.ContainsKey(key))
                return _lightNodes[key];

            ++ObjectCount;
            var newNode = new LightElementNode(tagName, true, false, cssClasses);
            newNode.AppendChild(new LightTextNode(text));
            _lightNodes.Add(key, newNode);

            return newNode;
        }
    }
}
