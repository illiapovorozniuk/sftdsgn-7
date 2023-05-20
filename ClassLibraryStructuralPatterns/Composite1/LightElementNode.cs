using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics.Tracing;
using ClassLibraryStructuralPatterns.Lab_7;
using System.Reflection.Metadata.Ecma335;

namespace ClassLibraryStructuralPatterns.Composite1
{
    public class LightElementNode : LightNode
    {
        private string tagName;
        public List<LightNode> childNodes;
        private bool isBlock;
        private bool isSelfClosing;
        private List<string> classes;
        public List<EventListenerObserved> eventListeners;

        public string TagName { get { return tagName; } }
        public bool IsBlock { get { return isBlock; } }
        public bool IsSelfClosing { get { return isSelfClosing; } }
        public List<string> Classes { get { return classes; } }
        public int ChildNodesCount { get { return childNodes.Count; } }


        public LightElementNode(string tagName, bool isBlock, bool isSelfClosing, List<string> classes)
        {
            this.tagName = tagName;
            this.isBlock = isBlock;
            this.isSelfClosing = isSelfClosing;
            this.classes = classes;
            this.childNodes = new List<LightNode>();
            this.eventListeners = new List<EventListenerObserved>();
            this.OnCreated();
            if (classes.Count != 0) this.OnStylesApplied();
        }

        public override string GetOuterHtml()
        {

            string classesString = classes != null ? string.Join(" ", classes) : "";
            string getAttributes() { string str = " eventAttributes = '"; foreach (EventListenerObserved eve in eventListeners) str += $"{eve.EventType} "; return str + "'"; }
            if (string.IsNullOrEmpty(classesString))
            {
                return $"<{tagName}{GetClosingType()}" +
                    $"{(eventListeners.Count != 0 ? getAttributes() : "")}" +
                    $">{GetInnerHtml()}{(this.isBlock ? $"</{tagName}>" : "")}";
            }
            else
            {
                return $"<{tagName} class=\"{classesString}\"{GetClosingType()}" +
                    $"{(eventListeners.Count != 0 ? getAttributes() : "")}" +
                    $">{GetInnerHtml()}{(this.isBlock ? $"</{tagName}>" : "")}";
            }
        }

        public override string GetInnerHtml()
        {
            int tabCount = 0;
            StringBuilder sb = new StringBuilder();
            foreach (LightNode node in childNodes)
            {

                sb.Append(node.GetOuterHtml() + "\n");
                tabCount++;
            }
            return sb.ToString();
        }

        public void AppendChild(LightNode node)
        {
            childNodes.Add(node);
            node.OnInserted(this);

        }

        public void ReplaceChild(LightNode newNode, LightNode oldNode)
        {
            int index = childNodes.IndexOf(oldNode);
            childNodes[index] = newNode;
        }

        public void RemoveChild(LightNode node)
        {
            childNodes.Remove(node);
            this.OnRemoved(node);
        }

        public void InsertBefore(LightNode newNode, LightNode refNode)
        {
            int index = childNodes.IndexOf(refNode);
            childNodes.Insert(index, newNode);


        }

        public override LightNode Clone()
        {
            List<LightNode> clonedChildNodes = new List<LightNode>();
            foreach (LightNode node in childNodes)
            {
                clonedChildNodes.Add(node.Clone());
            }
            return new LightElementNode(tagName, isBlock, isSelfClosing, classes)
            {
                childNodes = clonedChildNodes
            };
        }

        private string GetDisplayType()
        {
            return isBlock ? "display:block;" : "display:inline;";
        }

        private string GetClosingType()
        {
            return isSelfClosing ? "/" : "";
        }
        //Observed pattern
        public void AddEventListener(string eventType, Action<object> handler)
        {
            EventListenerObserved listener = new EventListenerObserved(eventType, handler);
            eventListeners.Add(listener);
        }
        public void RemoveEventListener(string eventType, Action<object> handler)
        {
            EventListenerObserved listenerToRemove = eventListeners.FirstOrDefault(l => l.EventType == eventType && l.Handler == handler);
            if (listenerToRemove != null)
            {
                eventListeners.Remove(listenerToRemove);
            }
        }
        public void Event(string name)
        {
            foreach (EventListenerObserved eve in eventListeners)
                if (eve.EventType == name)
                {
                    eve.Handler.Invoke(this);
                    break;
                }
        }
        //Шаблон темплейт
        public override void OnCreated()
        {
            Console.WriteLine($"Tag \"{this.TagName}\" was created");
        }

        public override void OnInserted(object e)
        {
            LightElementNode parent = e as LightElementNode;
            Console.WriteLine($"Tag \"{this.TagName}\" was inserted into \"{parent.TagName}\"");
        }

        public override void OnRemoved(object e)
        {

            LightElementNode child = e as LightElementNode;
            if (child is LightElementNode)
                Console.WriteLine($"Tag \"{child.TagName}\" was removed from \"{this.TagName}\"");



        }

        public override void OnStylesApplied()
        {
            Console.WriteLine($"Styles: \"{string.Join(" ", classes)}\" was applied to the tag \"{this.TagName}\"");

        }
        public LightNode GetChildNode(int i)
        {
            LightNode result;
            try
            {
                result = childNodes[i];
            }
            catch { return null; }
            return result;
        }

        //Strategy
        public class Image : LightElementNode
        {
            private string href;

            public string Href { get { return href; } }

            public Image(string href) : base("img", false, true, new List<string>())
            {
                this.href = href;
            }

            public override string GetOuterHtml()
            {
                return $"<{TagName} src=\"{Href}\"/>";
            }

            public override LightNode Clone()
            {
                return new Image(href);
            }
        }
    }
}
