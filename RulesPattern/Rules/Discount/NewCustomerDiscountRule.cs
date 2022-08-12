using RulesPattern.Extensions;
using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public class NewCustomerDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            return !customer.HasPurchasedBefore() ? .15m : 0;
        }
    }
}
