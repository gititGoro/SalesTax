using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class ImportTax : ITax
	{
		private const decimal taxRate = 0.05m;
		public decimal Calculate(decimal value)
		{
			return value * taxRate;
		}
	}
}
