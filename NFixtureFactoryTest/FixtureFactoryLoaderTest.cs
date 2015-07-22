using System;
using NUnit.Framework;
using NFixtureFactory.Loader;
using NFixtureFactoryTest.Model;
using NFixtureFactory;
using NFixtureFactoryTest.Template;
using System.Diagnostics.CodeAnalysis;

namespace NFixtureFactoryTest
{

    [TestFixture(), ExcludeFromCodeCoverage]
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
			Assert.AreNotEqual (0, client.CPF);
			Assert.NotNull (client.Address);
			Assert.AreEqual (client.Address.Street, ClientTemplate.STREET);
			Assert.AreEqual (client.Address.City, ClientTemplate.CITY);
			Assert.AreEqual (client.Address.State, ClientTemplate.STATE);
			Assert.AreEqual (client.Address.Country, ClientTemplate.COUNTRY);
			Assert.AreEqual (client.Address.ZipCode, ClientTemplate.ZIPCODE);
		}

		[Test()]
		public void ShouldLoadCompanyTemplate()
		{
			Company company = Fixture.From<Company>().Gimme(CompanyTemplate.VALID_TEMPLATE_NAME);
			Assert.IsNotNull (company);
			Assert.AreEqual (CompanyTemplate.PROPERTY_VALUE, company.Name);
			Assert.AreNotEqual (0, company.CNPJ);
			Assert.NotNull (company.Address);
			Assert.AreEqual (company.Address.Street, CompanyTemplate.STREET);
			Assert.AreEqual (company.Address.City, CompanyTemplate.CITY);
			Assert.AreEqual (company.Address.State, CompanyTemplate.STATE);
			Assert.AreEqual (company.Address.Country, CompanyTemplate.COUNTRY);
			Assert.AreEqual (company.Address.ZipCode, CompanyTemplate.ZIPCODE);
		}

	}
}

