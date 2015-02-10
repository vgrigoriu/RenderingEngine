using System.Collections.Immutable;

using NUnit.Framework;

namespace RenderingEngine.Tests
{
    public class ElementDataTests
    {
	    private const string TagName = "blink";

	    public void TagNameIsSetViaConstructorParameter()
        {
		    var noAttributes = ImmutableDictionary.Create<string, string>();

            var sut = new ElementData(TagName, noAttributes);

            Assert.That(sut.TagName, Is.EqualTo(TagName));
        }

        public void AttributesAreSetViaConstructorParameter()
        {
            var noAttributes = ImmutableDictionary.Create<string, string>();

            var sut = new ElementData(TagName, noAttributes);

            Assert.That(sut.Attributes, Is.SameAs(noAttributes));
        }
    }
}
