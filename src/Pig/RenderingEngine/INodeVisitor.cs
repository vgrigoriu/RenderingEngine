﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderingEngine
{
	public interface INodeVisitor
	{
		void Visit(Element element);

		void Visit(Text element);
	}
}
