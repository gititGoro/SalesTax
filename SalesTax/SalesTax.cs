using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class SalesTax : ITax
	{
		private const decimal taxRate = 0.1m;
		public decimal Calculate(decimal value)
		{
			return  value * taxRate;
		}
	}
}
