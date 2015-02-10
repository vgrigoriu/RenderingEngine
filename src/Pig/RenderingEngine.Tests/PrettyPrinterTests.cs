using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace RenderingEngine.Tests
{
    public class PrettyPrinterTests
    {
        [Fact]
        public void PrettyPrinterOutputsEmptyElement()
        {
            Node node = new Element("dodo");

            var sut = new PrettyPrinter();
            var output = sut.PrettyPrint(node);

            Assert.Equal("<dodo />", output);
        }

		[Fact]
		public void PrettyPrinterOutputsEmptyElementWithAttributes()
		{
			Node node = new Element("dodo", new Dictionary<string, string> { {"mimi", "fifi"} });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Contains("<dodo mimi=\"fifi\" />", output);
		}

		[Fact]
		public void PrettyPrinterOutputsElementWithElementChild()
		{
			Node node = new Element("dodo", new[] {new Element("kiki") });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Contains(@"<dodo>
    <kiki />
</dodo>", output);
		}

		[Fact]
		public void PrettyPrinterElementWithTextChild()
		{
			Node node = new Element("dodo", new[] { new Text("Ana are mere."),  });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Contains(@"<dodo>
    Ana are mere.
</dodo>", output);
		}

		private class PrettyPrinter : INodeVisitor
        {
            private readonly StringBuilder accumulator = new StringBuilder();

			private string prefix = string.Empty;

            public PrettyPrinter()
            {
            }

            internal string PrettyPrint(Node node)
            {
                node.Accept(this);

                return accumulator.ToString();
            }

			void INodeVisitor.Visit(Text element)
			{
				accumulator.Append(prefix);
				accumulator.Append(element.Content);
			}

			void INodeVisitor.Visit(Element element)
			{
				accumulator.Append(prefix);
				accumulator.AppendFormat("<{0}", element.Content.TagName);
				foreach (var attribute in element.Content.Attributes)
				{
					accumulator.AppendFormat(" {0}=\"{1}\"", attribute.Key, attribute.Value);
				}

				if (!element.Children.Any())
				{
					accumulator.Append(" />");
				}
				else
				{
					accumulator.Append(">");
					prefix = prefix + "    ";
					foreach (var child in element.Children)
					{
						accumulator.AppendLine();
						child.Accept(this);
					}
					prefix = prefix.Substring(4);

					accumulator.AppendLine();
					accumulator.Append(prefix);
					accumulator.AppendFormat("</{0}>", element.Content.TagName);
				}
			}
		}
    }
}
