namespace RSLib.CSharp.Collections
{
    using System.Collections;
    using System.Collections.Generic;

    public class ObservableList<T> : IList<T>
    {
        private readonly List<T> _list = new List<T>();

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
        
        public int Count => _list.Count;
        public bool IsReadOnly => false;

        public event System.Action AddEvent;
        public event System.Action RemoveEvent;
        public event System.Action ClearEvent;
        
        public void Add(T item)
        {
            _list.Add(item);
            AddEvent?.Invoke();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            _list.AddRange(collection);
            AddEvent?.Invoke();
        }

        public void Clear()
        {
            _list.Clear();
            ClearEvent?.Invoke();
        }
        
        public bool Remove(T item)
        {
            bool result = _list.Remove(item);
            if (result)
                RemoveEvent?.Invoke();
            
            return result;
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            AddEvent?.Invoke();
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            RemoveEvent?.Invoke();
        }
        
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
    }
}
