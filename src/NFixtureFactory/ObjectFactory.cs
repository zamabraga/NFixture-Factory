using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NFixtureFactory
{
	public class ObjectFactory<T>{

		private TemplateHolder<T> _templateHolder;

		public ObjectFactory(TemplateHolder<T> templateHolder) {
			_templateHolder = templateHolder;
		}

		private Rule FindRule(String label) {
			Rule rule = _templateHolder.GetRule (label);

			if (rule == null) {
				throw new InvalidOperationException(String.Format(Resources.EXCEPTION_MESSAGE_NO_SUCH_LABEL_MESSAGE, _templateHolder.Clazz.Name, label));
			}
			return rule;
		}

		private Object CreateObject(Rule rule) {


			Object obj = Activator.CreateInstance (_templateHolder.Clazz);
			foreach (var property in rule.Properties) {
				
				_templateHolder.Clazz.InvokeMember(property.Name, BindingFlags.SetProperty, null, obj, new object[]{ property.GetValue()});
			}

			return obj;
		}


		public T Gimme(String label)
		{
			Rule rule = FindRule(label);
			return (T) CreateObject(rule);
		}

		public IEnumerable<T> Gimme(Int32 quantity, String label)
		{
			IList<T> list = new List<T> ();
			Rule rule = FindRule (label);
			for (int i = 0; i < quantity; i++) {
				list.Add ((T) CreateObject (rule));
			}

			return list;

		}


	}
}

