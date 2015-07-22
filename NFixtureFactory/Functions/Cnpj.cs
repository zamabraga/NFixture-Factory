using System;

namespace NFixtureFactory.Functions
{
	public class Cnpj  : IAtomicFunction 
	{		
		private Boolean _formatted;

		public Cnpj(){}

		public Cnpj (Boolean formatted)
		{
			_formatted = formatted;
		}

		public T GenerateValue<T>()
		{
			RandomFunction random = new RandomFunction(new RandomFunction.Range(1, 9));
			Int32 a  = random.GenerateValue<Int32>();
			Int32 b  = random.GenerateValue<Int32>();
			Int32 c  = random.GenerateValue<Int32>();
			Int32 d  = random.GenerateValue<Int32>();
			Int32 e  = random.GenerateValue<Int32>();
			Int32 f  = random.GenerateValue<Int32>();
			Int32 g  = random.GenerateValue<Int32>();
			Int32 h  = random.GenerateValue<Int32>();
			Int32 i  = 0;
			Int32 j = 0;
			Int32 l = 0;
			Int32 m = 1;

			int n = m*2+l*3+j*4+i*5+h*6+g*7+f*8+e*9+d*2+c*3+b*4+a*5;
			n = n % 11 < 2 ? 0 : 11 - (n % 11);

			int o = n*2+m*3+l*4+j*5+i*6+h*7+g*8+f*9+e*2+d*3+c*4+b*5+a*6;
			o = o % 11 < 2 ? 0 : 11 - (o % 11);

			return (T) Convert.ChangeType(String.Format((_formatted ? "{0}{1}.{2}{3}{4}.{5}{6}{7}/{8}{9}{10}{11}-{12}{13}" : "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}"), a, b, c, d, e, f, g, h, i, j, l, m, n, o), typeof(T));
		}

	}
}

