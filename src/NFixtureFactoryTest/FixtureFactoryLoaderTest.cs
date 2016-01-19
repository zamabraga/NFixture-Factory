using System;
using NUnit.Framework;
using NFixtureFactory.Loader;
using NFixtureFactoryTest.Model;
using NFixtureFactory;
using NFixtureFactoryTest.Template;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace NFixtureFactoryTest
{

    [TestFixture(), ExcludeFromCodeCoverage]
	public class FixtureFactoryLoaderTest
	{
		[TestFixtureSetUp()]
		public void SetUp()
		{
			NFixtureFactoryLoader.LoadTemplates();
		}

		[Test()]
		public void ShouldLoadClientTemplate()
		{
			Client client = NFixture.From<Client>().Gimme(ClientTemplate.VALID_TEMPLATE_NAME);
			Assert.IsNotNull (client);
			Assert.AreEqual (ClientTemplate.PROPERTY_VALUE, client.Name);
			Assert.AreNotEqual (0, client.CPF);
			Assert.NotNull (client.Address);            
			Assert.AreEqual (client.Address.Street, AddressTemplate.STREET);
			Assert.AreEqual (client.Address.City, AddressTemplate.CITY);
			Assert.AreEqual (client.Address.State, AddressTemplate.STATE);
			Assert.AreEqual (client.Address.Country, AddressTemplate.COUNTRY);
			Assert.AreEqual (client.Address.ZipCode, AddressTemplate.ZIPCODE);
            Assert.IsNotNull(client.Phones);
            Assert.AreEqual(ClientTemplate.QUANTITY_OF_PHONES, client.Phones.Count);
		}

		[Test()]
		public void ShouldLoadFiveClientTemplate()
		{
			IEnumerable<Client> clients = NFixture.From<Client>().Gimme(5, ClientTemplate.VALID_TEMPLATE_NAME);
			Assert.IsNotNull (clients);
			Assert.AreEqual(5, clients.Count());

		}

		[Test()]
		public void ShouldLoadCompanyTemplate()
		{
			Company company = NFixture.From<Company>().Gimme(CompanyTemplate.VALID_COMPANY_TEMPLATE_NAME);
			Assert.IsNotNull (company);
			Assert.AreEqual (CompanyTemplate.PROPERTY_VALUE, company.Name);
			Assert.AreNotEqual (0, company.CNPJ);
			Assert.NotNull (company.Address);
			Assert.AreEqual (company.Address.Street, AddressTemplate.STREET);
			Assert.AreEqual (company.Address.City, AddressTemplate.CITY);
			Assert.AreEqual (company.Address.State, AddressTemplate.STATE);
			Assert.AreEqual (company.Address.Country, AddressTemplate.COUNTRY);
			Assert.AreEqual (company.Address.ZipCode, AddressTemplate.ZIPCODE);
		}

		[Test()]
		public void ShouldNotAddTempaleWithExistName()
		{			
			Assert.Throws<ApplicationException>(() => NFixtureFactoryLoader.LoadTemplates(), Resources.EXCEPTION_MESSAGE_EXIST_RULE_LABEL);
		}

	}
}

