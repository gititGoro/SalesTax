using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class CartItem
	{
		public CartItem()
		{
		}

		public ITax [] Taxes { get; set; }
		public string Name { get; set; }
		public decimal BasePrice { get; set; }
		protected virtual decimal Tax
		{
			get
			{
				decimal tax = 0;
				foreach(var taxType in Taxes)
				{
					tax += taxType.Calculate(this.BasePrice);
				}
				return tax;
			}
		}

		public decimal RoundedTax
		{
			get
			{
				return Math.Ceiling(this.Tax * 20) / 20;
			}
		}
		public decimal DisplayPrice
		{
			get
			{
				return this.RoundedTax + this.BasePrice;
			}
		}
	}
}
