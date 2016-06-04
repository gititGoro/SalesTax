using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class Program
	{
		static void Main(string[] args)
		{
			while(!File.Exists("input.txt"))
			{
				Console.WriteLine("Please put your input in input.txt in the local directory and then press any key to continue.");
				Console.ReadKey();
				Console.Clear();
			}

			string[] input = File.ReadAllLines("input.txt");

			SmartCart cart = new SmartCart();
			Console.WriteLine("INPUT:");
			foreach (var line in input)
			{
				string currentLine = line;
				int quantity = int.Parse(currentLine.Substring(0, currentLine.IndexOf(" ")).Trim());
				currentLine = currentLine.Substring(currentLine.IndexOf(" ") + 1);
				string name = currentLine.Substring(0, currentLine.LastIndexOf("at")).Trim();
				decimal basePrice = decimal.Parse(currentLine.Substring(currentLine.LastIndexOf("at") + 2).Trim());
				Console.WriteLine($"{quantity} {name} at {basePrice}");

				cart.AddItem(name, basePrice, quantity);
			}

			Console.WriteLine($"{Environment.NewLine}OUTPUT:");
			foreach(var itemType in cart.Items)
			{
				int count = itemType.Value.Count;
				Console.WriteLine($"{count} {itemType.Key}{(count > 1 ? "s" : "")} at {itemType.Value.Sum(item => item.DisplayPrice)}");
			}
			Console.WriteLine($"Sales Tax: {cart.TotalTax}");
			Console.WriteLine($"Total: {cart.Total}");
			Console.ReadLine();
		}
	}
}
