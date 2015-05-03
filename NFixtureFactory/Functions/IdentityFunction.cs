using System;

namespace NFixtureFactory.Functions
{
	public class IdentityFunction: IAtomicFunction
	{

		private Object _value;

		public IdentityFunction(Object value){
			_value = value;
		}

		#region IAtomicFunction implementation

		public T GenerateValue<T> ()
		{
			return (T)_value;
		}

		#endregion

	
	}
}

