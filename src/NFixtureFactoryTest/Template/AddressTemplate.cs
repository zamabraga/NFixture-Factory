using System;
using NFixtureFactory.Loader;
using NFixtureFactoryTest.Model;
using NFixtureFactory;

namespace NFixtureFactoryTest.Template
{
    public class AddressTemplate : ITemplateLoader
    {
        public static readonly String VALID_ADDRESS_TEMPLATE = "Valid Address";
        public static readonly String STREET = "Castelo";
        public static readonly String CITY = "Cidade Alta";
        public static readonly String STATE = "Terras Altas de Rennar";
        public static readonly String COUNTRY = "Ancrath";
        public static readonly Int32 ZIPCODE = 72000000;

        #region ITemplateLoader implementation

        public void Load()
        {

            Fixture.Of<Address>().AddTemplate(VALID_ADDRESS_TEMPLATE)
                                    .ForMember(e => e.Street, STREET)
                                    .ForMember(e => e.City, CITY)
                                    .ForMember(e => e.State, STATE)
                                    .ForMember(e => e.Country, COUNTRY)
                                    .ForMember(e => e.ZipCode, ZIPCODE);

        }

        #endregion
    }
}

