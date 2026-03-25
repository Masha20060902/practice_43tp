using System.Collections;
namespace Task2
{
    internal class MySet<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();
        public bool Add(T item)
        {
            if (_items.Contains(item))
            {
                return false;
            }
            _items.Add(item);
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        public void Intersect(MySet<T> other)
        {
            _items.RemoveAll(x => !other._items.Contains(x));
        }
        public bool Remove(T item)
        {
            _items.Remove(item);
            return true;
        }
        public void Union(MySet<T> other)
        {
            foreach (var x in other._items)
            {
                if (!_items.Contains(x))
                {
                    _items.Add(x);
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
