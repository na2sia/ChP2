using System;
using System.IO;
using CheckPoint2_1.PartOfTexts;

namespace CheckPoint2_1
{
    class Program
    {
        static void Main()
        {
            try
            {
                var textsString = new Reader().ReadText();

                var text = Parser.Parse(textsString);
                Console.WriteLine(text+Environment.NewLine);
              
                Console.WriteLine("Sorted:");
                Console.WriteLine(MethodsForText.SortSentences(text) + Environment.NewLine);
              
                Console.WriteLine("Words in interrogative sentences:"); 
                foreach (var word in MethodsForText.WordsInInterrogativeSentences(text, 2))
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine();
              
                Console.WriteLine("Delete words in sentences:");
                Console.WriteLine(MethodsForText.DeleteWordFromText(text, 7) + Environment.NewLine);
              
                Console.WriteLine("Replace words in sentences:"); 
                Console.WriteLine(MethodsForText.ReplaceWordFromSentence(text, 0, 7, "replaced word")); 
                             
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
            Console.ReadKey();
            
        }
       

 
    }
}
