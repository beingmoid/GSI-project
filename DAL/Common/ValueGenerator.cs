using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Common
{
	public abstract class GSIValueGenerator : ValueGenerator
	{
		public override bool GeneratesTemporaryValues => false;
	}
}
