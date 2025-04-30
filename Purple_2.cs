using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output;
        public string[] Output
        {
            get
            {
                if (_output == null)
                    return null;

                string[] copy = new string[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }

        public Purple_2(string input) : base(input) { }

        public override string ToString()
        {
            if (this._output == null) return null;

            return String.Join(Environment.NewLine, this._output);
        }

        public override void Review()
        {
            if (Input == null) return;

            string[] words_input = this.Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] lines = new string[words_input.Length];
            int lines_count = 0;

            StringBuilder line = new StringBuilder();

            for (int i = 0; i < words_input.Length; i++)
            {
                string w = words_input[i];
                if (line.Length + w.Length + (line.Length > 0 ? 1 : 0) <= 50)
                {
                    if (line.Length > 0)
                        line.Append(' ');
                    line.Append(w);
                }
                else
                {
                    lines[lines_count++] = line.ToString();
                    line.Clear();
                    line.Append(w);
                }
            }


            if (line.Length > 0)
            {
                lines[lines_count++] = line.ToString();
            }

            Array.Resize(ref lines, lines_count);

            // добавляем пробелы
            for (int idx = 0; idx < lines.Length; idx++)
            {
                if (lines[idx].Length == 50)
                    continue;

                string currentLine = lines[idx];
                string[] words = currentLine.Split(' ');

                int totalSpacesNeeded = 50 - currentLine.Length;
                int gaps = words.Length - 1;

                if (gaps == 0)
                {
                    lines[idx] = currentLine;
                    continue;
                }


                int baseSpaces = totalSpacesNeeded / gaps;
                int extraSpaces = totalSpacesNeeded % gaps;


                StringBuilder newLine = new StringBuilder();
                for (int j = 0; j < words.Length; j++)
                {
                    newLine.Append(words[j]);
                    if (j < words.Length - 1)
                    {
                        newLine.Append(' ', 1 + baseSpaces + (j < extraSpaces ? 1 : 0));
                    }
                }
                lines[idx] = newLine.ToString();
            }

            _output = new string[lines.Length];
            Array.Copy(lines, _output, lines.Length);
        }
    }
}