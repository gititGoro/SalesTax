using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public interface ITax
	{
		decimal Calculate(decimal value);
	}
}
