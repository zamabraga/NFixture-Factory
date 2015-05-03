using System;
using NFixtureFactory.Loader;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest.Template
{
	public class ClientTemplate : ITemplateLoader
	{

		public static readonly String PROPERTY_LABEL = "Name";
		public static readonly String PROPERTY_VALUE = "Same Name";
		public static  readonly String VALID_TEMPLATE_NAME = "Valid";

		public static  readonly String VALID_ADDRESS_TEMPLATE = "Valid Address";
		public static  readonly String STREET = "AV. JK";
		public static  readonly String CITY = "Brasilia";
		public static  readonly String STATE = "Distrito Federal";
		public static  readonly String COUNTRY = "Brazil";
		public static  readonly Int32 ZIPCODE = 72000000;
			

		#region ITemplateLoader implementation

		public void Load ()
		{
			Fixture.Of(typeof(Client)).AddTemplate(VALID_TEMPLATE_NAME, 
				new Rule()
					.Add(PROPERTY_LABEL, PROPERTY_VALUE)
					.Add("Address", Rule.One<Address>(VALID_ADDRESS_TEMPLATE))	
			);

			Fixture.Of (typeof(Address)).AddTemplate (VALID_ADDRESS_TEMPLATE, 
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

