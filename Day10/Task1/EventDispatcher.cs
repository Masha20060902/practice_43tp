namespace Task1
{
    public sealed class EventDispatcher
    {
        private static EventDispatcher _dispatcher = new EventDispatcher();

        public static EventDispatcher Dispatcher => _dispatcher;
        private Dictionary<string, List<Action>> _dispatchers = new Dictionary<string, List<Action>>();
        private EventDispatcher()
        {
        }
        public void Subscribe(string eventType, Action handler)
        {
            if (!_dispatchers.ContainsKey(eventType))
            {
                _dispatchers[eventType] = new List<Action>();
            }
            _dispatchers[eventType].Add(handler);
        }
        public void Unsubscribe(string eventType, Action handler)
        {
            _dispatchers[eventType].Remove(handler);
        }
        public void Dispatch(string eventType)
        {
            foreach (var action in _dispatchers[eventType].ToList())
            {
                action.Invoke();
            }
        }
    }
}
