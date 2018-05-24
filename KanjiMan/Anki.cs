using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KanjiMan
{
    public class Anki
    {
        public static List<Kanji> ImportKanjiDeck()
        {
            const string path = @"C:\Users\nick\misc. VS\Anki\KanjiMan\kanjiDeck.txt";
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

            int id = 0;

            foreach (var note in notes)
            {
                var kanji = new Kanji
                {
                    Id = "K" + id,
                    Symbol = note[0],
                    Keyword = note[1],
                    Radicals = note[2],
                    Story1 = note[3],
                    Story2 = note[4],
                    Story3 = note[5],
                    ImgSrc = note[6]
                };

                kanjiDeck.Add(kanji);
                id++;
            }

            return kanjiDeck;
        }

        public static List<Sentence> ImportSentenceDeck()
        {
            const string path = @"C:\Users\nick\misc. VS\Anki\KanjiMan\sentenceDeck.txt";
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

            int id = 0;

            foreach (var note in notes)
            {
                var sentence = new Sentence
                {
                    Id = "S" + id,
                    Expression = note[0],
                    Reading = note[1],
                    Definition = note[2],
                    Note = note[3],
                    Sound = note[4]
                };

                sentenceDeck.Add(sentence);
                id++;
            }

            return sentenceDeck;
        }

        public static void WriteDeckToTxt(List<Card> idDeck, List<Kanji> kanjiDeck, List<Sentence> sentenceDeck)
        {
            const string path = @"C:\Users\nick\misc. VS\Anki\KanjiMan\outDeck.txt";

            int id;

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var card in idDeck)
                {
                    if (card.Id[0] == 'S')
                    {
                        id = Convert.ToInt32(card.Id.TrimStart('S'));

                        writer.Write(sentenceDeck[id].Expression + "\t");
                        writer.Write(sentenceDeck[id].Reading + "\t");
                        writer.Write(sentenceDeck[id].Definition + "\t");
                        writer.Write(sentenceDeck[id].Note + "\t");
                        writer.Write(sentenceDeck[id].Sound);
                        writer.WriteLine();
                    }

                    else if (card.Id[0] == 'K')
                    {
                        id = Convert.ToInt32(card.Id.TrimStart('K'));

                        writer.Write(kanjiDeck[id].Symbol + "\t");
                        writer.Write(kanjiDeck[id].Keyword + "\t");
                        writer.Write(kanjiDeck[id].Radicals + "\t");
                        writer.Write(kanjiDeck[id].Story1 + "\t");
                        writer.Write(kanjiDeck[id].Story2 + "\t");
                        writer.Write(kanjiDeck[id].Story3 + "\t");
                        writer.Write(kanjiDeck[id].ImgSrc);
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
