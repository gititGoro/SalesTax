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
				if (name.ToLower().Contains("import"))
					AddToItemDictionary(name, new ImportedItem() { BasePrice = basePrice, Name = name });
				else
					AddToItemDictionary(name, new CartItem { BasePrice = basePrice, Name = name });
			}

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
