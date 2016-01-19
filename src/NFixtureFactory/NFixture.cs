using System;
using System.Collections;
using System.Collections.Generic;

namespace NFixtureFactory
{
	public class NFixture
	{
		private static IDictionary<Type, Object> templates = new Dictionary<Type, Object>();

		public static TemplateHolder<T> Of<T>()
		{
			Type clazz = typeof(T);
			TemplateHolder<T> template = null;
			if (!templates.ContainsKey (clazz)) {
				template = new TemplateHolder<T>();
				templates.Add (clazz, template);
			} else {
				template = (TemplateHolder<T>) templates [clazz];
			}
			return template;

		}

		public static ObjectFactory<T> From<T>() {

			return new ObjectFactory<T>(Of<T>());
		} 


	}
}

