﻿using System;
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
        public void PrettyPrinterOutputsElementName()
        {
            Node node = new Element("dodo");

            var sut = new PrettyPrinter();
            var output = sut.PrettyPrint(node);

            Assert.Contains("dodo", output);
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
        }
    }
}