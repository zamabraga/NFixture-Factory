using NUnit.Framework;
using System;
using FixtureFactory;
using FixtureFactory.Functions;

namespace FixtureFactoryTest
{
	[TestFixture ()]
	public class PropertyTest
	{

		[Test()]
		public void ShoudNotAllowNullName ()
		{
			Assert.Throws<ArgumentNullException> (() => new Property(null, null), "Name must not be null" );

		}

		[Test()]
		public void ShoudNotAllowNullFunction ()
		{
			Assert.Throws<ArgumentNullException> (() => new Property("Name", null), "Function must not be null" );
		}

		[Test()]
		public void ShouldReturnValueFromIdentityFunction()
		{
			String value = "same value";
			Property property = new Property("attr", new IdentityFunction(value));
			Assert.AreEqual(value, property.GetValue());

		}

		[Test()]
		public void ShouldReturnNull() {
			Property property = new Property("attr", (Object) null);
			Assert.IsNull(property.GetValue());
		}


	}
}

