using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public class VeteranDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            return customer.IsVeteran ? .10m : 0;
        }
    }
}
