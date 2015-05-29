using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_1.PartOfTexts
{
    class Word:IWord, IComparable<Word>
    {

        public string Value { get; private set; }
        public bool IsConsonantBegining { get; private set; }
        private Word(string word, bool consonante)
        {
            Value = word;
            IsConsonantBegining = consonante;
        }
               
        public static readonly char[] Consonant =
        {
            'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g',
            'h','k','l','z', 'x', 'c', 'v', 'b', 'n', 'm',
             'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ф', 'в', 'п',
             'р','л','д','ж','ч','с','м','т','б'
        };

        public static Word GetWordByStringValue(string value)
        {
            return new Word(value, Consonant.Contains(value.First()));
        }

        public int CompareTo(Word other)
        {
            return String.Compare(Value, other.Value, StringComparison.Ordinal);
        }

       
    }
}
