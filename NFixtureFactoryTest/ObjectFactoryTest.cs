using System;
using NUnit.Framework;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest
{
	[TestFixture ()]
	public class ObjectFactoryTest
	{

		private readonly String PROPERTY_LABEL = "Name";
		private readonly String PROPERTY_VALUE = "Same Name";
		private readonly String TEMPLATE_NAME = "Valid";


		[Test()]
		public void ShouldCreateNewObject()
		{
			ObjectFactory objectFactory = new ObjectFactory (new TemplateHolder (typeof(Client))
				.AddTemplate (TEMPLATE_NAME, new Rule ()
											.Add(PROPERTY_LABEL, PROPERTY_VALUE)											
								 )
			);

			var obj = objectFactory.Gimme<Client>(TEMPLATE_NAME);
			Assert.IsNotNull(obj);
			Assert.IsInstanceOf<Client>(obj);
			Assert.AreEqual (PROPERTY_VALUE, ((Client)obj).Name);
		}

	}
}

