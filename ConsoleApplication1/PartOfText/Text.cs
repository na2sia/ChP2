using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckPoint2_1.PartOfTexts
{
    class Text : ICollection<Sentence>
    {
        private readonly ICollection<Sentence> sentencesCollection;

        public Text()
        {
            sentencesCollection = new Collection<Sentence>();
            IsReadOnly = sentencesCollection.IsReadOnly;
            Count = sentencesCollection.Count;
            
        }

        #region ICollection
        public IEnumerator<Sentence> GetEnumerator()
        {
            return sentencesCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Sentence item)
        {
            sentencesCollection.Add(item);
            Count = sentencesCollection.Count;
        }

        public void Clear()
        {
            sentencesCollection.Clear();
            Count = 0;
        }

        public bool Contains(Sentence item)
        {
            return sentencesCollection.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            sentencesCollection.CopyTo(array, arrayIndex);
        }

        public bool Remove(Sentence item)
        {
            return sentencesCollection.Remove(item);
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
