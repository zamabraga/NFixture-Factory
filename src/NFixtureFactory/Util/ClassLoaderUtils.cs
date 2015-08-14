using System;
using System.Collections.Generic;
using System.Linq;
using NFixtureFactory.Loader;

namespace NFixtureFactory.Util
{
	public class ClassLoaderUtils
	{

		public static IEnumerable<Type> GetClassesForPackage()
		{
			var clazz = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(e => e.GetTypes())
				.Where(e => e.IsClass && e.GetInterfaces().Any(i => i == typeof(ITemplateLoader)));
						
			return clazz;
		}
	}
}

