using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckPoint2_1.PartOfTexts
{
    class Text : ICollection<Sentence>
    {
        private readonly ICollection<Sentence> _sentencesCollection;

        public Text()
        {
            _sentencesCollection = new Collection<Sentence>();
            IsReadOnly = _sentencesCollection.IsReadOnly;
            Count = _sentencesCollection.Count;
            
        }

        #region methoods of interface
        public IEnumerator<Sentence> GetEnumerator()
        {
            return _sentencesCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Sentence item)
        {
            _sentencesCollection.Add(item);
            Count = _sentencesCollection.Count;
        }

        public void Clear()
        {
            _sentencesCollection.Clear();
            Count = 0;
        }

        public bool Contains(Sentence item)
        {
            return _sentencesCollection.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            _sentencesCollection.CopyTo(array, arrayIndex);
        }

        public bool Remove(Sentence item)
        {
            return _sentencesCollection.Remove(item);
        }
        #endregion
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public override string ToString()
        {
            return this.Aggregate("", (current, sentence) => current + sentence.ToString());
        }
    }
}
