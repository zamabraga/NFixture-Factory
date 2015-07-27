using NFixtureFactory.Functions;
using NFixtureFactory.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NFixtureFactory
{
	public class TemplateHolder<TType>
	{

		private readonly IDictionary<String, Rule> _rules = new Dictionary<String, Rule>();

		public Type Clazz{ get; private set;}
        public String _label;

		public IDictionary<String,Rule> Rules
		{
			get{ return new Dictionary<String, Rule>(_rules); }
		}


		public TemplateHolder ()
		{
			Clazz = typeof(TType);
		}

        public TemplateHolder<TType> AddTemplate(String label)
        {
            if (_rules.Keys.Contains(label))
                throw new ApplicationException(Resources.EXCEPTION_MESSAGE_EXIST_RULE_LABEL);
            
            _rules.Add(label, new Rule());
            _label = label;
            return this;
        }


		public TemplateHolder<TType> AddTemplate(String label, Rule rule) {			
			if (_rules.Keys.Contains (label))
				throw new ApplicationException (Resources.EXCEPTION_MESSAGE_EXIST_RULE_LABEL);	
            
			_rules.Add(label, rule);
			return this;
		}

        public TemplateHolder<TType> ForMember(Expression<Func<TType, Object>> destinationMember, Object value)
        {
            MemberInfo property = ReflectionUtils.FindProperty(destinationMember);
            _rules[_label].Add(property.Name, value);
            return this;
        }

        public TemplateHolder<TType> ForMember(Expression<Func<TType, Object>> destinationMember, IFunction function)
        {
            MemberInfo property = ReflectionUtils.FindProperty(destinationMember);
            _rules[_label].Add(property.Name, function);
            return this;
        }

		public Rule GetRule(String label)
		{
			return _rules.ContainsKey(label) ? _rules [label] : null;
		}
	}
}

