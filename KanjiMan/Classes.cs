using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiMan
{
    public class Card
    {
        public int Id { get; set; }
        public int Position { get; set; }
    }

    public class Sentence : Card
    {
        public string Expression { get; set; }
        public string Reading { get; set; }
        public string Definition { get; set; }
        public string Note { get; set; }
        public string Sound { get; set; }

        public List<string> ExtractKanji()
        {
            var kanjiList = new List<string>();

            foreach (var s in this.Expression)
            {
                if ((int) s > 19000 && (int) s < 41000)
                {
                    kanjiList.Add(s.ToString());
                }
            }

            return kanjiList;
        }
    }

    public class Kanji : Card
    {
        public string Symbol { get; set; }
        public string Keyword { get; set; }
        public string Radicals { get; set; }
        public string Story1 { get; set; }
        public string Story2 { get; set; }
        public string Story3 { get; set; }
        public string ImgSrc { get; set; }
    }
}
