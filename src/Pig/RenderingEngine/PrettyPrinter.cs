using System.Linq;
using System.Text;

namespace RenderingEngine
{
	public class PrettyPrinter : INodeVisitor
	{
		private readonly StringBuilder accumulator = new StringBuilder();

		private string prefix = string.Empty;

		public PrettyPrinter()
		{
		}

		public string PrettyPrint(Node node)
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