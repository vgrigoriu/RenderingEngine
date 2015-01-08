using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace RenderingEngine
{
    public class Element : Node<ElementData>
    {
        public Element(string tagName, IDictionary<string, string> attributes, IEnumerable<Node> children)
            : base(new ElementData(tagName, attributes.ToImmutableDictionary()), children)
        {
        }

        public Element(string tagName, IDictionary<string, string> attributes)
            : this(tagName, attributes, Enumerable.Empty<Node>())
        {
        }

        public Element(string tagName, IEnumerable<Node> children)
            : this(tagName, new Dictionary<string, string>(), children)
        {
        }

        public Element(string tagName)
            : this(tagName, new Dictionary<string, string>(), Enumerable.Empty<Node>())
        {
        }
    }
}