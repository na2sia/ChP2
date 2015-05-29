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
                try
                {
                   var word = (Word)sentenceItem;
                    if (word.Value.Length == count)
                    {
                        if (!tempListWords.Contains(word.Value))
                        {
                            tempListWords.Add(word.Value);
                        }
                    }
                }
                catch
                {
                    //Console.WriteLine("In the text there are no questions");      
                }
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
                    try
                    {
                        var word = (Word)sentenceItem;
                        if (word.Value.Length != count)
                            newSentence.Add(word);
                    }
                    catch
                    {
                        newSentence.Add(sentenceItem);
                    }
                }
                tempText.Add(new Sentence(newSentence));
            }
            return tempText;
                /*Text tempText = new Text();
            //tempText = Value.ToList();
            foreach (var sentence in tempText.ElementAt(1))

            //.SelectMany(sentence => sentence.  .Value.Where(word => word.IsConsonant && word.Value.Count() == lenghtOfWords)))
            {
                var word = (Word)sentence;
                if (word.IsConsonantBegining)
                { word = new Word(""); }
                
               // sentence.Select(word=>word.Value. )
                foreach (var sentenceItem in sentence)
                { 
                    var word = (Word)sentenceItem;
                    if (word.Value.Count() == count)
                    { }
                }
                word.Value.Clear();
            }
            return tempText;
           */
        }

        public static Sentence ReplaceWordFromSentence(Text text, int sentencesNumber, int wordsCount, string substring)
        {
            var sentence = new Collection<ISentenceItem>();
            foreach (var sentenceItem in text.ElementAt(sentencesNumber))
            {
                try
                {
                    var word = (Word)sentenceItem;
                    if (word.Value.Length == wordsCount)
                        word=Word.GetWordByStringValue(substring);
                    sentence.Add(word);
                }
                catch
                {
                    sentence.Add(sentenceItem);
                }
            }
            return new Sentence(sentence);
        }
    }
}
