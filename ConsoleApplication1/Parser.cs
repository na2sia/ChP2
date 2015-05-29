using System.Collections.ObjectModel;
using CheckPoint2_1.PartOfTexts;

namespace CheckPoint2_1
{
    class Parser
    {
        public static Text Parse(string fullText)
        {
            var numCurrentSymbol = 0;
            var numFirstSymbol = 0;
            var sentence = new Collection<ISentenceItem>();
            var text = new Text();
            int numPunctuation = 0;

            while (numCurrentSymbol <= fullText.Length-1)
            {
                if (!char.IsLetterOrDigit(fullText[numCurrentSymbol]))
                {
                     if ((char.IsWhiteSpace(fullText[numCurrentSymbol]))||(char.IsPunctuation(fullText[numCurrentSymbol])))
                        {
                            if (numPunctuation < numCurrentSymbol) {sentence.Add(Word.GetWordByStringValue(fullText.Substring(numFirstSymbol, numCurrentSymbol - numFirstSymbol)));}
                            numPunctuation = numCurrentSymbol + 1;
                            numFirstSymbol = numCurrentSymbol;
                            var punctuation = Punctuation.GetPunctuationByStringValue(fullText.Substring(numCurrentSymbol, numPunctuation - numCurrentSymbol));

                            if (punctuation != null)
                            {
                                sentence.Add(punctuation);
                                if (punctuation.IsEndSentence)
                                {
                                    text.Add(new Sentence(sentence));
                                    sentence = new Collection<ISentenceItem>();
                                }

                            }
                            numFirstSymbol = numCurrentSymbol+1;
                        }
                     numFirstSymbol = numCurrentSymbol+1;
                     numPunctuation = numCurrentSymbol + 1; 
 
                }
                numCurrentSymbol++;
            }
            return text;
        }
    }
}

