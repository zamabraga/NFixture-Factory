using System;
using NFixtureFactory.Functions;
using System.Reflection;

namespace NFixtureFactory
{
	public class Property 
	{
		private const Int32 PRIME = 31;


		public String Name {
			get; private set;
		}

		public IFunction Function
		{
			get; private set;
		}


		public Property (String name, IFunction function)
		{
			if (String.IsNullOrWhiteSpace (name)) {
				throw new ArgumentNullException (Resources.EXCEPTION_MESSAGE_PROPERTY_NAME_NULL);
			}

			if (function == null) {
				throw new ArgumentNullException (Resources.EXCEPTION_MESSAGE_PROPERTY_FUNCTION_NULL);
			}

			Name = name;
			Function = function;
		}

		public Property (String name, Object value) : this (name, new IdentityFunction(value)){}

		public Object GetValue() {

			IAtomicFunction function = ((IAtomicFunction) Function);
			Type type = typeof(Object);
			if(Function.GetType().GenericTypeArguments.Length > 0)
			 	type = Function.GetType ().GenericTypeArguments[0];
			MethodInfo mi = function.GetType ().GetMethod ("GenerateValue");
			MethodInfo method = mi.MakeGenericMethod(type);
			return method.Invoke (function, null);	
		}


		public override Boolean Equals (object obj)
		{
			if (this == obj)
				return true;
			if (obj == null)
				return false;

			if(this.GetType() != obj.GetType())
				return false;

			Property other = (Property)obj;
			if (Name == null) {
				if (other.Name != null) {
					return false;
				}
			} else if (!Name.Equals(other.Name)) {
				return false;
			}

			return true;
		}

		public override Int32 GetHashCode ()
		{
			Int32 result = 1; 
			result = PRIME * result + (( String.IsNullOrWhiteSpace(Name)) ? 0 : Name.GetHashCode());
			return result;

		}
	}
}

