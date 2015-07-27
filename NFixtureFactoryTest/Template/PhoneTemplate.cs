using System;
using NFixtureFactory.Loader;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest.Template
{
	public class PhoneTemplate : ITemplateLoader
	{
		public static readonly String Valid_Template = "Valid Phone";

		
		public void Load ()	{

            Fixture.Of<Phone>().AddTemplate(Valid_Template)
                                .ForMember(e => e.Number, 55555555M);
		}
		
	}
}

