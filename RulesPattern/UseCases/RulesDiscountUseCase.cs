using RulesPattern.Models;
using RulesPattern.Rules.Discount;

namespace RulesPattern.UseCases
{
    public class RulesDiscountUseCase
    {
        private readonly List<IDiscountRule> _rules = new List<IDiscountRule>();

        public RulesDiscountUseCase()
        {
            _rules.Add(new BirthdayDiscountRule());
            _rules.Add(new SeniorDiscountRule());
            _rules.Add(new LoyalCustomerDiscountRule(1, 0.10m));
            _rules.Add(new LoyalCustomerDiscountRule(5, 0.12m));
            _rules.Add(new LoyalCustomerDiscountRule(10, 0.15m));
            _rules.Add(new NewCustomerDiscountRule());
            // _rules.Add(new VeteranDiscountRule());
        }

        public decimal Action(Customer customer)
        {
            decimal discount = 0;

            foreach(var rule in _rules)
            {
                discount = Math.Max(
                    discount,
                    rule.CalculateCustomerDiscount(customer)
                );
            }

            return discount;
        }
    }
}
