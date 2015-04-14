using NUnit.Framework;
using System;
using NFixtureFactory;
using NFixtureFactory.Functions;

namespace NFixtureFactoryTest
{
	[TestFixture ()]
	public class PropertyTest
	{

		private readonly String PROPERTY_NAME_NULL = "Name must not be null" ;
		private readonly String PROPERTY_FUNCTION_NULL = "Function must not be null";
		private readonly String IDENTITY_FUNCTION_VALUE = "same value";

		[Test()]
		public void ShouldNotAllowNullName ()
		{
			Assert.Throws<ArgumentNullException> (() => new Property(null, null), PROPERTY_NAME_NULL );

		}

		[Test()]
		public void ShoudNotAllowNullFunction ()
		{
			Assert.Throws<ArgumentNullException> (() => new Property("Name", null), PROPERTY_FUNCTION_NULL );
		}

		[Test()]
		public void ShouldReturnValueFromIdentityFunction()
		{
			Property property = new Property("attr", new IdentityFunction(IDENTITY_FUNCTION_VALUE));
			Assert.AreEqual(IDENTITY_FUNCTION_VALUE, property.GetValue());

		}

		[Test()]
		public void ShouldReturnNull() {
			Property property = new Property("attr", (Object) null);
			Assert.IsNull(property.GetValue());
		}


	}
}

