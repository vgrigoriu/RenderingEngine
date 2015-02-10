using System.Collections.Generic;

using HtmlParser;
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
			Node node = new Element("dodo", new Dictionary<string, string> { { "mimi", "fifi" } });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Equal("<dodo mimi=\"fifi\" />", output);
		}

		[Fact]
		public void PrettyPrinterOutputsElementWithElementChild()
		{
			Node node = new Element("dodo", new[] { new Element("kiki") });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Equal(@"<dodo>
    <kiki />
</dodo>", output);
		}

		[Fact]
		public void PrettyPrinterElementWithTextChild()
		{
			Node node = new Element("dodo", new[] { new Text("Ana are mere.") });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Equal(@"<dodo>
    Ana are mere.
</dodo>", output);
		}

		[Fact]
		public void PrettyPrinterComplexElement()
		{
			Node node = Parser.Parse("<a b='c'><d>e</d>f<g></g></a>");

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.Equal(@"<a b=""c"">
    <d>
        e
    </d>
    f
    <g />
</a>", output);
		}
	}
}
