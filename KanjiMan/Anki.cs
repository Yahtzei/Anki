using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiMan
{
    public class Anki
    {
        public static List<Kanji> ImportKanjiDeck()
        {
            const string path = @"C:\Users\nick\misc. VS\KanjiMan\KanjiMan\kanjiDeck.txt";
            var kanjiDeck = new List<Kanji>();

            var notes = new List<List<string>>();

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    notes.Add(line.Split('\t').ToList());
                }
            }

            foreach (var note in notes)
            {
                var kanji = new Kanji
                {
                    Symbol = note[0],
                    Keyword = note[1],
                    Radicals = note[2],
                    Story1 = note[3],
                    Story2 = note[4],
                    Story3 = note[5],
                    ImgSrc = note[6]
                };

                kanjiDeck.Add(kanji);
            }

            return kanjiDeck;
        }

        public static List<Sentence> ImportSentenceDeck()
        {
            const string path = @"C:\Users\nick\misc. VS\KanjiMan\KanjiMan\sentenceDeck.txt";
            var sentenceDeck = new List<Sentence>();

            var notes = new List<List<string>>();

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    notes.Add(line.Split('\t').ToList());
                }
            }

            foreach (var note in notes)
            {
                var sentence = new Sentence
                {
                    Expression = note[0],
                    Reading = note[1],
                    Definition = note[2],
                    Note = note[3],
                    Sound = note[4]
                };

                sentenceDeck.Add(sentence);
            }

            return sentenceDeck;
        }
    }
}
