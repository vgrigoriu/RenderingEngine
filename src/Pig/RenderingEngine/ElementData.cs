using System.Collections.Immutable;

namespace RenderingEngine
{
    public class ElementData
    {
        public string TagName { get; }

        public ImmutableDictionary<string, string> Attributes { get; }

        public ElementData(string tagName, ImmutableDictionary<string, string> attributes)
        {
            TagName = tagName;
            Attributes = attributes;
        }
    }
}
