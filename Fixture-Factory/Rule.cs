using System;
using System.Collections;
using System.Collections.Generic;
using FixtureFactory.Functions;

namespace FixtureFactory
{
	public class Rule
	{
		private readonly ICollection<Property> _properties = new List<Property>();

		public ICollection<Property> Properties 
		{
			get
			{
				return new List<Property>(_properties);
			}

		}

		public Rule (){}

		public Rule Add(String property, Object value)
		{
			_properties.Add(new Property(property, value));
			return this;
		}

		public void Add(String property, IFunction function){
		
			_properties.Add(new Property(property, function ?? new IdentityFunction(null)));
		}



	}
}

