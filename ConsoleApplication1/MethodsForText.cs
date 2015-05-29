using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CheckPoint2_1.PartOfTexts;

namespace CheckPoint2_1
{
    class MethodsForText
    {
        public static Text SortSentences(Text text)
        {
            var tempText = text.OrderBy(sentence => sentence.Count);
            var newText = new Text();
            foreach (var sentence in tempText)
            {
                newText.Add(sentence);
            }
            return newText;
        }

        public static List<string> WordsInInterrogativeSentences(Text text, int count)
        {
            var tempListWords = new List<string>();

            foreach (var sentenceItem in text.Where(sentence => sentence.IsInterrogativeSentence).SelectMany(sentence => sentence))
            {
                
                if (sentenceItem is Word)
                    if (sentenceItem.Value.Length == count)
                        if (!tempListWords.Contains(sentenceItem.Value)) tempListWords.Add(sentenceItem.Value.ToLower());
            }
            return tempListWords;
        }

       public static Text DeleteWordFromText(Text text, int count)
        {
            var tempText = new Text();
            foreach (var sentence in text)
            {
                var newSentence = new Collection<ISentenceItem>();
                foreach (var sentenceItem in sentence)
                {  
                    if (sentenceItem is Word)
                    {
                        var word = (Word)sentenceItem;
                        if (!word.IsConsonantBegining) newSentence.Add(word);
                        if (word.IsConsonantBegining)
                           if (word.Value.Length != count) newSentence.Add(word);
                    }
                    else newSentence.Add(sentenceItem);
                }
                tempText.Add(new Sentence(newSentence));
            }
            return tempText;
         }

        public static Sentence ReplaceWordFromSentence(Text text, int sentencesNumber, int wordsCount, string substring)
        {
            var sentence = new Collection<ISentenceItem>();
            foreach (var sentenceItem in text.ElementAt(sentencesNumber))
            {
                if (sentenceItem is Word)
                {
                    var word = (Word)sentenceItem;
                    if (word.Value.Length == wordsCount)
                        word = Word.GetWordByStringValue(substring);
                    sentence.Add(word);
                }
                else sentence.Add(sentenceItem);
            }
            return new Sentence(sentence);
        }
    }
}
