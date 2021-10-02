using System.Collections.Generic;
using System.ComponentModel;

namespace WS.Events
{
    public class EventManager<T, TR>
    {
        private static EventManager<T, TR> _eventManager;
        private readonly Dictionary<EventType, IEventHandler<T, TR>> _eventMap = new();

        private EventManager() { }

        public static EventManager<T, TR> GetInstance()
        {
            return _eventManager ??= new EventManager<T, TR>();
        }

        public void AddHandler(EventType type, IEventHandler<T, TR> handler)
        {
            _eventMap[type] = handler;
        }

        public TR Handle(EventType type, T payload)
        {
            return _eventMap[type].Handle(payload);
        }
    }
}