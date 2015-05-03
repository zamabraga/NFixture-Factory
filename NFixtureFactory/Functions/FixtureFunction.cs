using System;
using System.Collections.Generic;
using System.Linq;


namespace NFixtureFactory.Functions
{
	public class FixtureFunction: IAtomicFunction 
	{
		private IList<String> _labels;

		public FixtureFunction (IList<String> labels)
		{
			_labels = labels;
		}


		#region Private implementation

		private T Generate<T>(ObjectFactory<T> objectFactory)
		{
			return	objectFactory.Gimme (_labels.First());
		}

		#endregion


		#region IAtomicFunction implementation

		public T GenerateValue<T> ()
		{
			return Generate<T>(Fixture.From<T>());
		}

		#endregion


	}
}

