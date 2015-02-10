using System.Collections.Generic;

using HtmlParser;

using NUnit.Framework;

namespace RenderingEngine.Tests
{
	public class PrettyPrinterTests
	{
		public void PrettyPrinterOutputsEmptyElement()
		{
			Node node = new Element("dodo");

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.That(output, Is.EqualTo("<dodo />"));
		}

		public void PrettyPrinterOutputsEmptyElementWithAttributes()
		{
			Node node = new Element("dodo", new Dictionary<string, string> { { "mimi", "fifi" } });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.That(output, Is.EqualTo("<dodo mimi=\"fifi\" />"));
		}

		public void PrettyPrinterOutputsElementWithElementChild()
		{
			Node node = new Element("dodo", new[] { new Element("kiki") });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.That(output, Is.EqualTo(@"<dodo>
    <kiki />
</dodo>"));
		}

		public void PrettyPrinterElementWithTextChild()
		{
			Node node = new Element("dodo", new[] { new Text("Ana are mere.") });

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.That(output, Is.EqualTo(@"<dodo>
    Ana are mere.
</dodo>"));
		}

		public void PrettyPrinterComplexElement()
		{
			Node node = Parser.Parse("<a b='c'><d>e</d>f<g></g></a>");

			var sut = new PrettyPrinter();
			var output = sut.PrettyPrint(node);

			Assert.That(output, Is.EqualTo(@"<a b=""c"">
    <d>
        e
    </d>
    f
    <g />
</a>"));
		}
	}
}
