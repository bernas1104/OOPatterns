using RulesPattern.Extensions;
using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public class BirthdayDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            return customer.IsBirthday() ? 0.10m : 0;
        }
    }
}
