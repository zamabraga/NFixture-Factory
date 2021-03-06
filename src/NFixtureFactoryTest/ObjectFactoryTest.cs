﻿using System;
using NUnit.Framework;
using NFixtureFactory;
using NFixtureFactoryTest.Model;
using System.Diagnostics.CodeAnalysis;

namespace NFixtureFactoryTest
{
    [TestFixture(), ExcludeFromCodeCoverage]
	public class ObjectFactoryTest
	{

		private readonly String PROPERTY_LABEL = "Name";
		private readonly String PROPERTY_VALUE = "Same Name";
		private readonly String TEMPLATE_NAME = "ShouldCreateNewObject Test Template";


		[Test()]
		public void ShouldCreateNewObject()
		{
			
			ObjectFactory<Client> objectFactory = new ObjectFactory<Client>(new TemplateHolder<Client>()
				.AddTemplate (TEMPLATE_NAME, new Rule ()
											.Add(PROPERTY_LABEL, PROPERTY_VALUE)											
								 )
			);

			var obj = objectFactory.Gimme(TEMPLATE_NAME);
			Assert.IsNotNull(obj);
			Assert.IsInstanceOf<Client>(obj);
			Assert.AreEqual (PROPERTY_VALUE, ((Client)obj).Name);
		}

	}
}

