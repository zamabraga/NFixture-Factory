using System;
using NFixtureFactory.Util;

namespace NFixtureFactory.Loader
{
	public class NFixtureFactoryLoader
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


    [Obsolete("use NFixtureFactoryLoader", false)]
    public class FixtureFactoryLoader : NFixtureFactoryLoader
    { 
    
    }
}

