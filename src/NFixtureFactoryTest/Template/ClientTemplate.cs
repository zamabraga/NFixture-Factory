using System;
using NFixtureFactory.Loader;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest.Template
{
	public class ClientTemplate : ITemplateLoader
	{

        public static readonly String VALID_TEMPLATE_NAME = "valid client";
        public static readonly String PROPERTY_VALUE = "Jorg Ancrath";
		public static readonly Int32 QUANTITY_OF_PHONES = 2;


		#region ITemplateLoader implementation

		public void Load ()
		{          
            NFixture.Of<Client>().AddTemplate(VALID_TEMPLATE_NAME)
                                .ForMember(e => e.Name, PROPERTY_VALUE)
                                .ForMember(e => e.Address, Rule.One<Address>(AddressTemplate.VALID_ADDRESS_TEMPLATE))
                                .ForMember(e => e.Phones, Rule.Has<Phone>(QUANTITY_OF_PHONES).Of(PhoneTemplate.Valid_Template))
                                .ForMember(e => e.CPF, Rule.Cpf());                
		}

		#endregion




	}
}

