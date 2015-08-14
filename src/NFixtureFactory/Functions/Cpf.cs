using System;

namespace NFixtureFactory.Functions
{
	public class Cpf : IAtomicFunction 
	{
		private Boolean _formatted;
		public Cpf (){}

		public Cpf (Boolean formatted)
		{
			_formatted = formatted;
		}

		public T GenerateValue<T>()
		{
			RandomFunction random = new RandomFunction(new RandomFunction.Range(1, 9));
			Int32 a = random.GenerateValue<Int32>();
			Int32 b = random.GenerateValue<Int32>();
			Int32 c = random.GenerateValue<Int32>();
			Int32 d = random.GenerateValue<Int32>();
			Int32 e = random.GenerateValue<Int32>();
			Int32 f = random.GenerateValue<Int32>();
			Int32 g = random.GenerateValue<Int32>();
			Int32 h = random.GenerateValue<Int32>();
			Int32 i = random.GenerateValue<Int32>();

			Int32 j = (a * 10 + b * 9 + c * 8 + d * 7 + e * 6 + f * 5 + g * 4 + h * 3 + i * 2);

			j = j % 11;

			j = j <= 1? 0 : 11 - j;

			Int32 m = (a * 11 + b * 10 + c * 9 + d * 8 + e * 7 + f * 6 + g * 5 + h * 4 + i * 3 + j * 2);

			m = m % 11;

			m = m <= 1? 0 : 11 - m;

			return (T) Convert.ChangeType(String.Format((_formatted ? "{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}" : "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}"), a, b, c, d, e, f, g, h, i, j, m), typeof(T));
		}
	}
}

