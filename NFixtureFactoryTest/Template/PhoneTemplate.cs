using System;
using NFixtureFactory.Loader;
using NFixtureFactory;
using NFixtureFactoryTest.Model;

namespace NFixtureFactoryTest.Template
{
	public class PhoneTemplate : ITemplateLoader
	{
		public static readonly String Valid_Template = "Valid Phone";

		#region ITemplateLoader implementation

		public void Load ()	{

			Fixture.Of<Phone>().AddTemplate (Valid_Template, 
				new Rule ()
				            .Add("Number", 55555555M)
			);
		}

		#endregion
	}
}

