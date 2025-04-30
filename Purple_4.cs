using Lab8;
using System;
using System.Text;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output = null;
        private (string, char)[] _codes;

        public string Output => _output;

        public Purple_4(string input, (string, char)[] codes)
            : base(input)
        {
            _codes = codes;
        }

        public override void Review()
        {
            if (Input == null || _codes == null)
                return;

            var builder = new StringBuilder(Input);

            foreach (var (seq, key) in _codes)
            {
                builder.Replace(key.ToString(), seq);
            }
            _output = builder.ToString();
        }

        public override string ToString() => _output;
    }
}
