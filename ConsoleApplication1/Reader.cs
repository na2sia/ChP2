using System;
using System.IO;
using System.Text;

namespace CheckPoint2_1
{
    class Reader 
    {
        public Reader()
        {
            Path = "input.txt"; 
        }

        public string Path { get; private set; }
        

        private static string FormateText(string text)
        {
            var num = 0;
            foreach (var symbol in text)
            {
                if ((symbol == '-' || symbol == '–' || symbol == '—' || symbol == '—') && text[num - 1] == ' ')
                {
                    text = text.Replace(" " +symbol, "-"+" ");
                }
                num++;
            }
            return text;
        }

        private static string Replacement(string text)
        {
            text = text.Replace("\t", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");
            while (text.IndexOf("  ", StringComparison.Ordinal) > -1)
            {
                text = text.Replace("  ", " ");
            }
            return text;
        }

        

        public string ReadText()
        {
            if (File.Exists(Path))
            {
                var text = File.ReadAllText(Path, Encoding.UTF8);
                text = Replacement(text);
                text = FormateText(text);
                text = Replacement(text);
                return text;
            }
            var ex = new FileNotFoundException("File not found");
            Console.WriteLine(ex.ToString());
            Environment.Exit(0);
            return null;
        }
    }
}
