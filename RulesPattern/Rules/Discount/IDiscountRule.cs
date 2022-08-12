using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public interface IDiscountRule
    {
        decimal CalculateCustomerDiscount(Customer customer);
    }
}
