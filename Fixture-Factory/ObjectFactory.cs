using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureFactory
{
	public class ObjectFactory
	{

		private TemplateHolder _templateHolder;

		public ObjectFactory(TemplateHolder templateHolder) {
			_templateHolder = templateHolder;
		}

		private Rule FindRule(String label) {
			Rule rule = _templateHolder.GetRule (label);

			if (rule == null) {
				throw new InvalidOperationException(String.Format(Resources.NO_SUCH_LABEL_MESSAGE, _templateHolder.Clazz.Name, label));
			}
			return rule;
		}

		private Object CreateObject(Rule rule) {

			IDictionary<String, Property> constructorArguments = new Dictionary<String, Property>();
			IList<Property> deferredProperties = new List<Property>();
			Type clazz = _templateHolder.Clazz;

			Object result = null;


			return result;
		}


		public T Gimme<T>(String label)
		{
			Rule rule = FindRule(label);
			return (T) CreateObject(rule);
		}


	}
}

