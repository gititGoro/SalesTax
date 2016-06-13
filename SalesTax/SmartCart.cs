using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class SmartCart
	{
		public SmartCart()
		{
			this.Items = new Dictionary<string, List<CartItem>>();
		}
		public Dictionary<string, List<CartItem>> Items { get; private set; }

		public void AddItem(string name, decimal basePrice, decimal quantity)
		{
			for (int i = 0; i < quantity; i++)
			{
				var taxes = GetTaxes(name);
				AddToItemDictionary(name, new CartItem { BasePrice = basePrice, Name = name, Taxes = taxes });
			}

		}
		protected string[] exempt = { "chocolate", "bread", "tofu", "book", "journal", "pill", "medi", "bandage" };
		private ITax [] GetTaxes (string productName)
		{
			List<ITax> taxes = new List<ITax>();
			if(!exempt.Any(item=>productName.ToLower().Contains(item)))
			{
				taxes.Add(new SalesTax());
			}
			if (productName.ToLower().Contains("import"))
			{
				taxes.Add(new ImportTax());
			}
			return taxes.ToArray();
		}

		private void AddToItemDictionary(string name, CartItem item)
		{
			if (this.Items.ContainsKey(name))
			{
				this.Items[name].Add(item);
			}
			else
			{
				this.Items.Add(name, new List<CartItem> { item });
			}
		}

		public decimal TotalTax
		{
			get
			{
				return Items.SelectMany(item => item.Value).Sum(item => item.RoundedTax);
			}
		}

		public decimal Total
		{
			get
			{
				return Items.SelectMany(item => item.Value).Sum(item => item.DisplayPrice);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var itemType in this.Items)
			{
				var itemList = itemType.Value.ToArray();
				stringBuilder.AppendLine($"{itemList.Length} {itemType.Key}: {itemList.Sum(item=>item.DisplayPrice)}");
			}
			var flatList = this.Items.SelectMany(item => item.Value).ToArray();
			stringBuilder.AppendLine($"Sales Tax: {flatList.Sum(item => item.RoundedTax)}");
			stringBuilder.AppendLine($"Total: {flatList.Sum(item => item.DisplayPrice)}");
			return stringBuilder.ToString();
		}
	}
}
