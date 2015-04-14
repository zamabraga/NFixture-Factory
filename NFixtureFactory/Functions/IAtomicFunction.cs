using System;

namespace NFixtureFactory.Functions
{
	public interface IAtomicFunction: IFunction
	{
		T GenerateValue<T>();
	}
}

