using System;
using NFixtureFactory.Loader;
using NFixtureFactoryTest.Model;
using NFixtureFactory;

namespace NFixtureFactoryTest.Template
{
	public class AddressTemplate : ITemplateLoader
	{
		public static  readonly String VALID_ADDRESS_TEMPLATE = "Valid Address";
		public static  readonly String STREET = "AV. JK";
		public static  readonly String CITY = "Brasilia";
		public static  readonly String STATE = "Distrito Federal";
		public static  readonly String COUNTRY = "Brazil";
		public static  readonly Int32 ZIPCODE = 72000000;

		#region ITemplateLoader implementation

		public void Load ()		{
			
			Fixture.Of<Address>().AddTemplate (VALID_ADDRESS_TEMPLATE, 
				new Rule ()
				.Add("Street", STREET)
				.Add("City", CITY)
				.Add("State", STATE)
				.Add("Country", COUNTRY)
				.Add("ZipCode", ZIPCODE)
			);
		}

		#endregion
	}
}

