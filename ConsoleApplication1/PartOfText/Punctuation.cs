using System.Linq;

namespace CheckPoint2_1.PartOfTexts
{
    class Punctuation : IPunctuation
    {
        private Punctuation(string stringValue, bool isEnd)
        {
            Value = stringValue;
            IsEndSentence = isEnd;
        }
        public string Value { get; private set; }
        public bool IsEndSentence { get; private set; }

        public static readonly Punctuation[] VariablesPunctuations =
        {
            new Punctuation(".", true),
            new Punctuation("?", true),
            new Punctuation("!", true),
            new Punctuation("?!", true),
            new Punctuation("...", true),
            new Punctuation("-", false),
            new Punctuation(":", false),
            new Punctuation(";", false),
            new Punctuation(",-", true),
            new Punctuation(",", false),
            new Punctuation(")", false),
            new Punctuation("(", false),
            new Punctuation(" ", false)
        };

        public static Punctuation GetPunctuationByStringValue(string value)
        {
            return VariablesPunctuations.FirstOrDefault(x => x.Value == value);
        }
    }
}
