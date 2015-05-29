using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoint2_1.PartOfTexts
{

    class Sentence : ICollection<ISentenceItem>
    {
        private readonly ICollection<ISentenceItem> sentenceItemsCollection;

        public Sentence(ICollection<ISentenceItem> tempCollection)
        {
            sentenceItemsCollection = tempCollection;
            IsReadOnly = sentenceItemsCollection.IsReadOnly;
            Count = sentenceItemsCollection.Count;
            IsInterrogativeSentence = CheckIsInterrogativeSentence();
        }

        public bool IsInterrogativeSentence { get; private set; }
        #region ICollection
        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return sentenceItemsCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(ISentenceItem item)
        {
            sentenceItemsCollection.Add(item);
            Count = sentenceItemsCollection.Count;
        }
        public void Clear()
        {
            sentenceItemsCollection.Clear();
            Count = 0;
        }
        public bool Contains(ISentenceItem item)
        {
            return sentenceItemsCollection.Contains(item);
        }
        public void CopyTo(ISentenceItem[] array, int arrayIndex)
        {
            sentenceItemsCollection.CopyTo(array, arrayIndex);
        }
        public bool Remove(ISentenceItem item)
        {
            return sentenceItemsCollection.Remove(item);
        }
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        #endregion
        public override string ToString()
        {
           return sentenceItemsCollection.Aggregate("", (current, iSentenceItem) => current + iSentenceItem.Value);
        }

        private bool CheckIsInterrogativeSentence()
        {
            if (this.Last() is Punctuation)
            {
                return (this.Last() == Punctuation.GetPunctuationByStringValue("?") ||
                        this.Last() == Punctuation.GetPunctuationByStringValue("?!"));
            }
            
            throw new FormatException("Sentence hasn't punctuation in the end");
        }

    }
}
