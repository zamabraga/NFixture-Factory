using System;
using System.Collections.Generic;

namespace NFixtureFactory.Functions
{
	public class AssociationFunction<T>: IAssociationFunction<T>
	{
		private Type _clazz;
		private IList<String> _labels;
		private Int32 _quantity;

		public AssociationFunction(String label)
		{
			_labels = new List<String> (){ label };
		}

		public AssociationFunction(Int32 quantity)
		{
			_quantity = quantity;
		} 

		#region IAssociationFunction implementation

		public IFunction TargetAttribute (string targetAttribute)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IAtomicFunction implementation

		public TParam GenerateValue<TParam> ()
		{
			return new FixtureFunction (_labels).GenerateValue<TParam> ();
		}

		public IAssociationFunction<T> Of(String label) {
			
			_clazz = typeof(T);
			_labels = new List<String> (){ label };
			return this;
		}
		#endregion

	}
}

