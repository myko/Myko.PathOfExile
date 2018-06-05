using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Myko.PathOfExile.ItemFilters
{
    public class ItemFilter
    {
        private string _text;

        public string Text
        {
            get => _text; set
            {
                if (_text != value)
                {
                    _text = value;
                    ParseBlocks();
                }
            }
        }

        public IEnumerable<Block> Blocks { get; private set; }

        public ItemFilter(string path)
        {
            Text = File.ReadAllText(path);
        }

        private void ParseBlocks()
        {
            var blocks = new List<Block>();

            var lines = _text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var builder = new StringBuilder();

            foreach (var line in lines)
            {
                if (Regex.IsMatch(line, @"\s*Show\s*#*"))
                {
                    blocks.Add(new Block { Text = builder.ToString() });
                    builder.Clear();
                }

                builder.AppendLine(line);
            }

            Blocks = blocks;
        }
    }

    public class Block
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
