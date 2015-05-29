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
                Console.WriteLine(text);
                Console.ReadLine();

                Console.WriteLine("Sorted:"); 
                Console.WriteLine(MethodsForText.SortSentences(text));
                Console.ReadLine();

                Console.WriteLine("Words in interrogative sentences:"); 
                foreach (var word in MethodsForText.WordsInInterrogativeSentences(text, 2))
                {
                    Console.WriteLine(word);
                }
                Console.ReadLine();

                Console.WriteLine("Delete words in sentences:"); 
                Console.WriteLine(MethodsForText.DeleteWordFromText(text, 7));
                Console.ReadLine();

                Console.WriteLine("Replace words in sentences:"); 
                Console.WriteLine(MethodsForText.ReplaceWordFromSentence(text, 3, 6, "replaced word")); 
                Console.ReadLine();
               
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
            
        }
       

 
    }
}
