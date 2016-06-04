using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class ImportedItem : CartItem
	{
		public ImportedItem() 
		{
			Console.Write(" - imported item - ");
		 }
		const decimal importTax = 0.05m;

		public override decimal Tax
		{
			get
			{
				var duties = importTax * this.BasePrice;
				duties = Math.Round(duties * 2, MidpointRounding.AwayFromZero) / 2;
				return base.Tax + duties;
			}
		}
	}
}
