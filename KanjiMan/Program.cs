using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KanjiMan
{
    class Program
    {
        static void Main()
        {
            var kanjiDeck = Anki.ImportKanjiDeck();
            var sentenceDeck = Anki.ImportSentenceDeck();

            foreach (var sentence in sentenceDeck)
            {
                foreach (var kanji in kanjiDeck)
                {
                    if (sentence.Expression.Contains(kanji.Symbol))
                    {
                        Console.WriteLine(kanji.Symbol);
                    }
                }
            }



            Console.WriteLine("stop");
        }
    }
}
