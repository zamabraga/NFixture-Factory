using NUnit.Framework;
using System;
using FixtureFactory;

namespace FixtureFactoryTest
{
	[TestFixture ()]
	public class ObjectFactoryTest
	{




		[Test()]
		public void ShouldCreateNewObject()
		{
			ObjectFactory objectFactory = new ObjectFactory (new TemplateHolder());
			var result = objectFactory.Gimme ("Valid");
		}



	}
}

