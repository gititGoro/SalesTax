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

		const decimal SalesTax = 0.1m;
		protected string[] exempt = { "chocolate", "bread", "tofu", "book", "journal", "pill", "medi", "bandage" };
		public string Name { get; set; }
		public decimal BasePrice { get; set; }
		protected virtual decimal Tax
		{
			get
			{
				if (exempt.Any(item => Name.Contains(item)))
					return 0;
				return BasePrice * SalesTax;
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
