using System.Collections.Immutable;
using Xunit;

namespace RenderingEngine.Tests
{
    public class ElementDataTests
    {
        [Fact]
        public void TagNameIsSetViaConstructorParameter()
        {
            var tagName = "blink";
            var noAttributes = ImmutableDictionary.Create<string, string>();

            var sut = new ElementData(tagName, noAttributes);

            Assert.Equal(tagName, sut.TagName);
        }

        [Fact]
        public void AttributesAreSetViaConstructorParameter()
        {
            var tagName = "blink";
            var noAttributes = ImmutableDictionary.Create<string, string>();

            var sut = new ElementData(tagName, noAttributes);

            Assert.Equal(noAttributes, sut.Attributes);
        }
    }
}
