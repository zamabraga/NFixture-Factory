using System;
using System.Collections;
using System.Collections.Generic;

namespace NFixtureFactory
{
	public class Fixture
	{
		private static IDictionary<Type, TemplateHolder> templates = new Dictionary<Type, TemplateHolder>();

		public static TemplateHolder Of(Type clazz)
		{
			TemplateHolder template = templates[clazz];
			if(template == null)
			{
				template = new TemplateHolder(clazz);
				templates.Add(clazz, template);
			}
			return template;

		}

		public static ObjectFactory From(Type clazz) {
			return new ObjectFactory(Of(clazz));
		} 


	}
}

