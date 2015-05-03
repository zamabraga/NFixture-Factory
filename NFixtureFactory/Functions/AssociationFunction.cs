using System;
using System.Collections.Generic;

namespace NFixtureFactory.Functions
{
	public class AssociationFunction<T>: IAssociationFunction<T>
	{

		private IList<String> _labels;

		public AssociationFunction(String label)
		{
			_labels = new List<String> (){ label };

		}

		#region IAssociationFunction implementation

		public IFunction TargetAttribute (string targetAttribute)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IAtomicFunction implementation

		public T GenerateValue<T> ()
		{
			return new FixtureFunction (_labels).GenerateValue<T> ();
		}

		#endregion

	}
}

