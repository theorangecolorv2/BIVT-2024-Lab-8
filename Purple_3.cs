using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        private (string, char)[] _codes = new (string, char)[0];
        public string Output => _output;
        public (string, char)[] Codes => _codes;

        public Purple_3(string input) : base(input) { }

        public override void Review()
        {
            if (Input == null) return;

            string[] all_pairs = new string[Input.Length * 2];
            int pairs_count = 0;
            for (int i = 0; i < Input.Length - 1; i++)
            {
                if (char.IsLetter(Input[i]) && char.IsLetter(Input[i + 1]))
                {
                    all_pairs[pairs_count++] = string.Concat(Input[i], Input[i + 1]);
                }
            }

            Array.Resize(ref all_pairs, pairs_count);

            var top5 = all_pairs
            .GroupBy(p => p)                  // обьединяем одинпковые пары в группы                  
            .OrderByDescending(g => g.Count())
            .ThenBy(g => Input.IndexOf(g.Key))
            .Take(5)
            .Select(g => new
            {              // создаем обьект с такими полями
                Pair = g.Key,
                Count = g.Count(),
                FirstIndex = Input.IndexOf(g.Key)
            }).ToArray();



            char[] aviable_codes = new char[95];
            int codes_count = 0;

            for (int i = 32; i <= 126; i++)
            {
                char c = (char)i;
                if (Input.IndexOf(c) == -1)
                {
                    aviable_codes[codes_count++] = c;
                    if (codes_count == 5) { break; }
                }

            }

            int max_possible_replacements = Math.Min(codes_count, Math.Min(top5.Length, 5));
            _codes = new (string, char)[max_possible_replacements];

            for (int i = 0; i < _codes.Length; i++)
            {
                _codes[i] = (top5[i].Pair, aviable_codes[i]);
            }


            var sb = new StringBuilder(Input);
            foreach (var (pair, code) in _codes)
            {
                sb.Replace(pair, code.ToString());
            }
            _output = sb.ToString();

        }

        public override string ToString() => _output;

    }
}
