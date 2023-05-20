using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite1
{
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public override string GetOuterHtml()
        {
            return _text;
        }

        public override string GetInnerHtml()
        {
            return _text;
        }

        public override LightNode Clone()
        {
            return new LightTextNode(_text);
        }
    }
}
