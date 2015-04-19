using System;
using NUnit.Framework;
using NFixtureFactory.Loader;
using NFixtureFactoryTest.Model;
using NFixtureFactory;
using NFixtureFactoryTest.Template;

namespace NFixtureFactoryTest
{
	[TestFixture()]
	public class FixtureFactoryLoaderTest
	{
		[SetUp]
		public void SetUp()
		{
			FixtureFactoryLoader.LoadTemplates();
		}

		[Test()]
		public void ShouldLoadClientTemplate()
		{
			Client client = Fixture.From<Client>().Gimme(ClientTemplate.VALID_TEMPLATE_NAME);
			Assert.IsNotNull (client);
			Assert.AreEqual (ClientTemplate.PROPERTY_VALUE, client.Name);

		}

	}
}

