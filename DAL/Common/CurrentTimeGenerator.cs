using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Common
{
	public class CurrentTimeGenerator : GSIValueGenerator
	{
		private static bool? _isScopeAvailable;
		protected override object NextValue(EntityEntry entry)
		{

			return DateTime.UtcNow;
		}
	}
}
