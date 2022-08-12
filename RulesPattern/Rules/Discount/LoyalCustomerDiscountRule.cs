using RulesPattern.Extensions;
using RulesPattern.Models;

namespace RulesPattern.Rules.Discount
{
    public class LoyalCustomerDiscountRule : IDiscountRule
    {
        private readonly int _yearsAsCustomer;
        private readonly decimal _discount;
        private readonly DateTime _date;

        public LoyalCustomerDiscountRule(
            int yearsAsCustomer,
            decimal discount,
            DateTime? date = null
        )
        {
            _yearsAsCustomer = yearsAsCustomer;
            _discount = discount;
            _date = date.ToValueOrDefault();
        }

        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (customer.HasBeenLoyalForYears(_yearsAsCustomer, _date))
            {
                var birthdayRule = new BirthdayDiscountRule();

                return _discount +
                    birthdayRule.CalculateCustomerDiscount(customer);
            }

            return 0;
        }
    }
}
