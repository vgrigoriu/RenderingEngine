using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderingEngine;

namespace HtmlParser
{
    public class Parser
    {
        private int position;
        private readonly string input;

        public static Node Parse(string source)
        {
            var nodes = new Parser(source).ParseNodes();

            if (nodes.Count() == 1)
            {
                return nodes.Single();
            }

            return new Element("html", nodes);
        }

        private Parser(string input)
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

        private Node ParseNode()
        {
            if (NextCharacter() == '<')
            {
                return ParseElement();
            }

            return ParseText();
        }

        private Node ParseElement()
        {
            var nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '<');

            var tagName = ParseTagName();
            var attributes = ParseAttributes();

            nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '>');

            var children = ParseNodes();

            nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '<');
            nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '/');
            var closingTagName = ParseTagName();
            Trace.Assert(closingTagName == tagName);
            nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '>');

            return new Element(tagName, attributes, children);
        }

        private List<Node> ParseNodes()
        {
            var nodes = new List<Node>();

            while (true)
            {
                ConsumeWhitespace();
                if (IsAtEof() || StartsWith("</"))
                {
                    break;
                }
                nodes.Add(ParseNode());
            }

            return nodes;
        }

        private IDictionary<string, string> ParseAttributes()
        {
            var attributes = new Dictionary<string, string>();
            while (true)
            {
                ConsumeWhitespace();
                if (NextCharacter() == '>')
                {
                    break;
                }

                var pair = ParseAttribute();
                attributes.Add(pair.Key, pair.Value);
            }

            return attributes;
        }


        private KeyValuePair<string, string> ParseAttribute()
        {
            var name = ParseTagName();

            var nextCharacter = ConsumeCharacter();
            Trace.Assert(nextCharacter == '=');

            var value = ParseAttributeValue();

            return new KeyValuePair<string, string>(name, value);
        }

        private string ParseAttributeValue()
        {
            var openQuote = ConsumeCharacter();
            Trace.Assert(openQuote == '"' || openQuote == '\'');

            var value = ConsumeWhile(c => c != openQuote);

            var closeQuote = ConsumeCharacter();
            Trace.Assert(closeQuote == openQuote);

            return value;
        }

        private Node ParseText()
        {
            return new Text(ConsumeWhile(c => c != '<'));
        }
    }
}
