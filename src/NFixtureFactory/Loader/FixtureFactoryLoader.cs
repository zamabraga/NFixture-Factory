using System;
using NFixtureFactory.Util;

namespace NFixtureFactory.Loader
{
	public class FixtureFactoryLoader
	{
		public static void LoadTemplates()
		{
			foreach (var clazz in ClassLoaderUtils.GetClassesForPackage()) 
			{
				ITemplateLoader templateLoader = (ITemplateLoader) Activator.CreateInstance (clazz);
				templateLoader.Load ();
			}
		}
	}
}

