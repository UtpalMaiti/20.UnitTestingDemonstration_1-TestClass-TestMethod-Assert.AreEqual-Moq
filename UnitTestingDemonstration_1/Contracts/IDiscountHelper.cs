using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemonstration_1.Contracts
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalPrice);
    }
}
