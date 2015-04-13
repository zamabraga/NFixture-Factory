using System;

namespace FixtureFactory.Functions
{
	public interface IAtomicFunction: IFunction
	{
		T GenerateValue<T>();
	}
}

