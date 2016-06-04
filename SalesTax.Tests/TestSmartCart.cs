using System.Linq;
using NUnit.Framework;

namespace SalesTax.Tests
{
	[TestFixture]
	public class TestSmartCart
	{
		[Test]
		public void TestAddItemForTestInput1()
		{
			string name1 = "book";
			string name2 = "music CD";
			string name3 = "chocolate bar";

			decimal price1 = 12.49m;
			decimal price2 = 14.99m;
			decimal price3 = 0.85m;

			SmartCart cart = new SmartCart();

			cart.AddItem(name1, price1, 1);
			cart.AddItem(name2, price2, 1);
			cart.AddItem(name3, price3, 1);

			Assert.That(cart.Total, Is.EqualTo(29.83m));
			Assert.That(cart.TotalTax, Is.EqualTo(1.5m));
			Assert.That(cart.Items.Count, Is.EqualTo(3));
			var itemTypes = cart.Items.ToArray();

			Assert.That(itemTypes[0].Key, Is.EqualTo(name1));
			Assert.That(itemTypes[0].Value.Count, Is.EqualTo(1));
			var item = itemTypes[0].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(0));
			Assert.That(item.DisplayPrice, Is.EqualTo(12.49m));

			Assert.That(itemTypes[1].Key, Is.EqualTo(name2));
			Assert.That(itemTypes[1].Value.Count, Is.EqualTo(1));
			item = itemTypes[1].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(1.5));
			Assert.That(item.DisplayPrice, Is.EqualTo(16.49m));

			Assert.That(itemTypes[2].Key, Is.EqualTo(name3));
			Assert.That(itemTypes[2].Value.Count, Is.EqualTo(1));
			item = itemTypes[2].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(0));
			Assert.That(item.DisplayPrice, Is.EqualTo(0.85m));
		}

		[Test]
		public void TestAddItemForTestInput2()
		{
			string name1 = "imported box of chocolates";
			string name2 = "imported bottle of perfume";

			decimal price1 = 10m;
			decimal price2 = 47.5m;

			SmartCart cart = new SmartCart();

			cart.AddItem(name1, price1, 1);
			cart.AddItem(name2, price2, 1);

			Assert.That(cart.Total, Is.EqualTo(65.15m));
			Assert.That(cart.TotalTax, Is.EqualTo(7.65m));
			Assert.That(cart.Items.Count, Is.EqualTo(2));
			var itemTypes = cart.Items.ToArray();

			Assert.That(itemTypes[0].Key, Is.EqualTo(name1));
			Assert.That(itemTypes[0].Value.Count, Is.EqualTo(1));
			var item = itemTypes[0].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(0.5m));
			Assert.That(item.DisplayPrice, Is.EqualTo(10.5m));

			Assert.That(itemTypes[1].Key, Is.EqualTo(name2));
			Assert.That(itemTypes[1].Value.Count, Is.EqualTo(1));
			item = itemTypes[1].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(7.15));
			Assert.That(item.DisplayPrice, Is.EqualTo(54.65m));
		}

		[Test]
		public void TestAddItemForTestInput3()
		{
			string name1 = "imported bottle of perfume";
			string name2 = "bottle of perfume";
			string name3 = "packet of headache pills ";
			string name4 = "box of imported chocolates";

			decimal price1 = 27.99m;
			decimal price2 = 18.99m;
			decimal price3 = 9.75m;
			decimal price4 = 11.25m;

			SmartCart cart = new SmartCart();

			cart.AddItem(name1, price1, 1);
			cart.AddItem(name2, price2, 1);
			cart.AddItem(name3, price3, 1);
			cart.AddItem(name4, price4, 1);

			Assert.That(cart.Total, Is.EqualTo(74.68m));
			Assert.That(cart.TotalTax, Is.EqualTo(6.7m));
			Assert.That(cart.Items.Count, Is.EqualTo(4));
			var itemTypes = cart.Items.ToArray();

			Assert.That(itemTypes[0].Key, Is.EqualTo(name1));
			Assert.That(itemTypes[0].Value.Count, Is.EqualTo(1));
			var item = itemTypes[0].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(4.2m));
			Assert.That(item.DisplayPrice, Is.EqualTo(32.19m));

			Assert.That(itemTypes[1].Key, Is.EqualTo(name2));
			Assert.That(itemTypes[1].Value.Count, Is.EqualTo(1));
			item = itemTypes[1].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(1.9m));
			Assert.That(item.DisplayPrice, Is.EqualTo(20.89m));

			Assert.That(itemTypes[2].Key, Is.EqualTo(name3));
			Assert.That(itemTypes[2].Value.Count, Is.EqualTo(1));
			item = itemTypes[2].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(0));
			Assert.That(item.DisplayPrice, Is.EqualTo(9.75m));

			Assert.That(itemTypes[3].Key, Is.EqualTo(name4));
			Assert.That(itemTypes[3].Value.Count, Is.EqualTo(1));
			item = itemTypes[3].Value.FirstOrDefault();
			Assert.That(item.Tax, Is.EqualTo(0.6m));
			Assert.That(item.DisplayPrice, Is.EqualTo(11.85m));
		}
	}
}
