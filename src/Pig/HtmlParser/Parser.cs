using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    internal class Parser
    {
        private int position;
        private readonly string input;

        public Parser(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            this.input = input;
            this.position = 0;
        }

        private char NextCharacter()
        {
            return input[position];
        }

        private bool StartsWith(string what)
        {
            return input.Substring(position).StartsWith(what);
        }

        private bool IsAtEof()
        {
            return position >= input.Length;
        }

        private char ConsumeCharacter()
        {
            return input[position++];
        }

        private string ConsumeWhile(Func<char, bool> predicate)
        {
            var result = new StringBuilder();

            while (!IsAtEof() && predicate(NextCharacter()))
            {
                result.Append(ConsumeCharacter());
            }

            return result.ToString();
        }

        private void ConsumeWhitespace()
        {
            ConsumeWhile(char.IsWhiteSpace);
        }

        private string ParseTagName()
        {
            return ConsumeWhile(char.IsLetterOrDigit);
        }
    }
}
