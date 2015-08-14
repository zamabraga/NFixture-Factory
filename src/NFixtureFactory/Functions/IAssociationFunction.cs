using System;

namespace NFixtureFactory.Functions
{
	public interface IAssociationFunction<T>: IAtomicFunction
	{
		IFunction TargetAttribute(String targetAttribute);
		IAssociationFunction<T> Of(String label);
	}
}

