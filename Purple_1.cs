using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;

        public Purple_1(string input) : base(input) { }

        public override string ToString()
        {
            return this.Output;
        }

        public override void Review()
        {
            if (this.Input == null)
            {
                _output = this.Input;
                return;
            }


            string[] input_split = this.Input.Split(' ');
            string[] reversed_split = new string[input_split.Length];
            int k = 0;

            foreach (string word in input_split)
            {

                if (char.IsDigit(word[0]))
                {
                    reversed_split[k++] = word;
                    continue;
                }


                char[] letters = new char[word.Count(p => char.IsLetter(p) || p == '-' || p == '\'')];
                char[] result = new char[word.Length];
                char[] letters_reversed = new char[letters.Length];

                int j = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsLetter(word[i]) || word[i] == '-' || word[i] == '\'')
                    {
                        letters[j] = word[i];
                        j++;
                    }
                }

                

                for (int i = 0; i < letters.Length; i++)
                {
                    letters_reversed[i] = letters[letters.Length - i - 1];
                }

                j = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsLetter(word[i]) || word[i] == '-' || word[i] == '\'')
                    {
                        result[i] = letters_reversed[j];
                        j++;
                    }
                    else
                    {
                        result[i] = word[i];
                    }
                }

                reversed_split[k] = new string(result);
                k++;

            }

            _output = String.Join(" ", reversed_split);

        }


        }
}
