using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class ImportedItem : CartItem
	{
		const decimal importTax = 0.05m;
		public ImportedItem()
		{
		
		}

		protected override decimal Tax
		{
			get
			{
				var duties = importTax * this.BasePrice;
				return base.Tax + duties;
			}
		}

	}
}
