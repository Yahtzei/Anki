using System;
using System.Collections.Generic;
using System.IO;

namespace KanjiMan
{
    class Program
    {
        static void Main()
        {
            // import kanji and sentences into a list of Kanji and Sentence objects.
            List<Kanji> kanjiDeck = Anki.ImportKanjiDeck();
            List<Sentence> sentenceDeck = Anki.ImportSentenceDeck();
            
            // deck of IDs corresponding to card position in each deck.
            List<Card> idDeck = new List<Card>();

            // for every sentence in sentenceDeck...
            foreach (var sentence in sentenceDeck)
            {
                // add the sentence to the ID deck (every sentence and kanji is given a unique ID upon import. IDs are prefixed with an 'S' or 'K' depending on card type).
                idDeck.Add(sentence);

                // for every kanji in kanjiDeck...
                foreach (var kanji in kanjiDeck)
                {
                    // like ID, Reading, Definition, etc., Expression is a property of type Sentence which contains the original sentence in japanese.
                    // similarly, Symbol is a property of type Kanji which contains the actual kanji.
                    // so, if the sentence's expression contains the kanji's symbol...
                    if (sentence.Expression.Contains(kanji.Symbol))
                    {
                        // and if idDeck does NOT contain that kanji already...
                        if (!idDeck.Contains(kanji))
                            // add it.
                            idDeck.Add((kanji));
                        
                        // otherwise, do nothing.
                    }
                }
            }

            // execute WriteDeckToTxt method which takes the idDeck, kanjiDeck and sentenceDeck as parameters and outputs a single, ordered deck of kanji and sentences in correct order.
            Anki.WriteDeckToTxt(idDeck, kanjiDeck, sentenceDeck);

            Console.WriteLine("stop");
        }
    }
}
