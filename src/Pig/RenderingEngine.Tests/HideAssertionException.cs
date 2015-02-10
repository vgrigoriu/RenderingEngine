using Fixie;
using NUnit.Framework;

namespace RenderingEngine.Tests
{
	public class HideAssertionException : Convention
	{
		public HideAssertionException()
		{
			HideExceptionDetails
				.For<AssertionException>()
				.For(typeof(Assert));
		}
	}
}
