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
		public static  readonly String VALID_TEMPLATE_NAME = "Client Valid";



		#region ITemplateLoader implementation

		public void Load ()
		{
			Fixture.Of<Client>().AddTemplate(VALID_TEMPLATE_NAME, 
				new Rule()
					.Add(PROPERTY_LABEL, PROPERTY_VALUE)
					.Add("Address", Rule.One<Address>(AddressTemplate.VALID_ADDRESS_TEMPLATE))
				    .Add("CPF", Rule.Cpf())
			);

		}

		#endregion




	}
}

