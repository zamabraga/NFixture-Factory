using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections;


namespace NFixtureFactory.Functions
{
	public class FixtureFunction: IAtomicFunction 
	{
		private IList<String> _labels;
		private Int32 _quantity;

		public FixtureFunction (IList<String> labels)
		{
			_labels = labels;
		}

		public FixtureFunction (IList<String> labels, Int32 quantity) : this(labels)
		{
			_quantity = quantity;
		}


		#region Private implementation

		private T Generate<T>(ObjectFactory<T> objectFactory)
		{			
			return	objectFactory.Gimme(_labels.First());
		}

		private T GenerateList<T>()
		{		
			
			Type genericMethodType = typeof(T).GenericTypeArguments[0];
			Type outValueType = typeof(List<>);
            outValueType = outValueType.MakeGenericType(genericMethodType);
			var outValue = Activator.CreateInstance(outValueType);


			MethodInfo fromMI = typeof(Fixture).GetMethod("From");
			MethodInfo fromM = fromMI.MakeGenericMethod(genericMethodType);
			var objectFactory = fromM.Invoke (typeof(Fixture), BindingFlags.Static, null, null, null);	

			for (int i = 0; i < _quantity; i++) {

                var obj = objectFactory.GetType().GetMethod("Gimme").Invoke(objectFactory, new[] { _labels.First() });  
                outValue.GetType().GetMethod("Add").Invoke(outValue, new[] { obj });              
               
			}

			return (T) outValue;
		}


		#endregion


		#region IAtomicFunction implementation

		public T GenerateValue<T> ()
		{				
			if (_quantity > 0) 
			{
				return GenerateList<T>();

			} else {
				return Generate<T>(Fixture.From<T>());
			}
		}

		#endregion


	}
}

