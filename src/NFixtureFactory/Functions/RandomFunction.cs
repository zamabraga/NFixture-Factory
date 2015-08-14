using System;

namespace NFixtureFactory.Functions
{
	public class RandomFunction : IAtomicFunction 
	{
		public class Range
		{			
			public Int32 Max{ get; set;}
			public Int32 Min{ get; set;}

			public Range(Int32 min, Int32 max)
			{
				Min = min;
				Max = max;
			}
		}


		private Object[] _dataset;
		private Range _range;

		public RandomFunction ()
		{
			
		}
		public RandomFunction (Range range) : this()
		{			
			_range = range;
		}

		public T GenerateValue<T>()
		{
			Object result;
			Random random = new Random ();
			if (typeof(T) == typeof(Int32)) 
			{
				result = _range == null ? random.Next() : (Int32) random.Next(_range.Min, _range.Max) ;
			}else{
				result = random.Next();
			}
			return (T)result;
		}


	}
}

