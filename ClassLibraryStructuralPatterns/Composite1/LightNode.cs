using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Composite1
{
    public abstract class LightNode
    {
        public abstract string GetOuterHtml();

        // Метод для виводу innerHTML
        public abstract string GetInnerHtml();

        // Додавання дочірнього елемента
        public virtual void AppendChild(LightNode node) { }

        public virtual void ReplaceChild(LightNode newNode, LightNode oldNode) { }

        public virtual void RemoveChild(LightNode node) { }

        // Вставка дочірнього елемента перед іншим елементом
        public virtual void InsertBefore(LightNode newNode, LightNode refNode) { }

        // Метод клонування
        public abstract LightNode Clone();

        //Шаблон - темплейт
        public virtual void OnCreated() { }

        public virtual void OnInserted(object e) { }

        public virtual void OnRemoved(object e) { }

        public virtual void OnStylesApplied() { }
    }
}
