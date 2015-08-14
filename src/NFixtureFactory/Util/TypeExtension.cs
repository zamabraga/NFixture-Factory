using System;

namespace System
{
	public static class TypeExtension
	{
		public static Type GenericType(this Type type)
		{			
			return type.GenericTypeArguments[0];
		}
	}
}

