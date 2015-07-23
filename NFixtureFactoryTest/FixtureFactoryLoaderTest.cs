﻿using System;
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
		[TestFixtureSetUp()]
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
			Assert.AreEqual (client.Address.Street, AddressTemplate.STREET);
			Assert.AreEqual (client.Address.City, AddressTemplate.CITY);
			Assert.AreEqual (client.Address.State, AddressTemplate.STATE);
			Assert.AreEqual (client.Address.Country, AddressTemplate.COUNTRY);
			Assert.AreEqual (client.Address.ZipCode, AddressTemplate.ZIPCODE);
		}

		[Test()]
		public void ShouldLoadCompanyTemplate()
		{
			Company company = Fixture.From<Company>().Gimme(CompanyTemplate.VALID_COMPANY_TEMPLATE_NAME);
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
			Assert.Throws<ApplicationException>(() => FixtureFactoryLoader.LoadTemplates(), Resources.EXCEPTION_MESSAGE_EXIST_RULE_LABEL);
		}

	}
}

