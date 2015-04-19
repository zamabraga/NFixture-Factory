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
			TemplateHolder template = null;
			if (!templates.ContainsKey (clazz)) {
				template = new TemplateHolder (clazz);
				templates.Add (clazz, template);
			} else {
				template = templates [clazz];
			}
			return template;

		}

		public static ObjectFactory<T> From<T>() {

			return new ObjectFactory<T>(Of(typeof(T)));
		} 


	}
}

