using System;
using NFixtureFactory.Loader;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest.Template
{
	public class CompanyTemplate : ITemplateLoader
	{


		public static readonly String PROPERTY_VALUE = "Same Company";
		public static  readonly String VALID_COMPANY_TEMPLATE_NAME = "Company Valid";

		public static  readonly String VALID_COMPANY_ADDRESS_TEMPLATE = "Valid Company Address";
		public static  readonly String STREET = "AV. JK";
		public static  readonly String CITY = "Brasilia";
		public static  readonly String STATE = "Distrito Federal";
		public static  readonly String COUNTRY = "Brazil";
		public static  readonly Int32 ZIPCODE = 72000000;
			

		#region ITemplateLoader implementation

		public void Load ()
		{
			Fixture.Of<Company>().AddTemplate(VALID_COMPANY_TEMPLATE_NAME)
                                 .ForMember(e => e.Name, PROPERTY_VALUE)
                                 .ForMember(e => e.Address, Rule.One<Address>(AddressTemplate.VALID_ADDRESS_TEMPLATE))
                                 .ForMember(e => e.CNPJ, Rule.Cnpj());				
			
		}

		#endregion




	}
}

