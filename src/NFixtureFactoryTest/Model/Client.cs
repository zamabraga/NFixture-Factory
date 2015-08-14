using System;
using System.Collections.Generic;

namespace NFixtureFactoryTest.Model
{
	public class Client
	{
		public String Name {get;set;}
		public Address Address { get; set; }
		public Decimal CPF {get;set;}
		public IList<Phone> Phones { get; set;}
	}
}

