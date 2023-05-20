using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStructuralPatterns.Lab_7
{
    public class EventListenerObserved : EventListener
    {
        public string EventType { get; private set; }
        public Action<object> Handler { get; private set; }

        public EventListenerObserved(string eventType, Action<object> handler)
        {
            EventType = eventType;
            Handler = handler;
        }

        public EventListenerObserved Clone()
        {
            return new EventListenerObserved(EventType, Handler);
        }
    }
}
