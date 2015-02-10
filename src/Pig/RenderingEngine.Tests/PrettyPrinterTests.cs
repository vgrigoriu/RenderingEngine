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

		private class PrettyPrinter : INodeVisitor
        {
            private StringBuilder accumulator = new StringBuilder();

            public PrettyPrinter()
            {
            }

            internal string PrettyPrint(Node node)
            {
                node.Accept(this);

                return accumulator.ToString();
            }

			void INodeVisitor.Visit(Element element)
			{
				accumulator.AppendFormat("<{0} />", element.Content.TagName);
			}
		}
    }
}
