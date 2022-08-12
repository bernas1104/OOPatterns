using RulesPattern.Extensions;
using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public class SeniorDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            return customer.IsSenior() ? .05m : 0;
        }
    }
}
