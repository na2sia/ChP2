using System.Linq;

namespace CheckPoint2_1.PartOfTexts
{
    class Punctuation : IPunctuation
    {
        private Punctuation(string stringValue, bool isFinish)
        {
            Value = stringValue;
            IsFinishSentence = isFinish;
        }
        public string Value { get; private set; }
        public bool IsFinishSentence { get; private set; }

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
