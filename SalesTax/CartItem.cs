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
		public virtual decimal Tax
		{
			get
			{
				if (exempt.Any(item => item.Contains(Name)))
					return 0;
				return BasePrice * SalesTax;
			}
		}
		public decimal DisplayPrice
		{
			get
			{
				return this.Tax + this.BasePrice;
			}
		}
	}
}
