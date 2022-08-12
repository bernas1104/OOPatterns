using RulesPattern.Extensions;
using RulesPattern.Models;

namespace RulesPattern.UseCases
{
    public class PredicateExtDiscountUseCase
    {
        #pragma warning disable
        public decimal Action(Customer customer)
        {
            decimal discount = 0;
            if (customer.IsSenior())
            {
                discount = .05m;
            }

            if (customer.IsBirthday())
            {
                discount = Math.Max(discount, .10m);
            }

            if (customer.HasPurchasedBefore())
            {
                if (customer.HasBeenLoyalForYears(1))
                {
                    discount = Math.Max(discount, .10m);
                    if (customer.HasBeenLoyalForYears(5))
                    {
                        discount = Math.Max(discount, .12m);
                        if (customer.HasBeenLoyalForYears(10))
                        {
                            discount = Math.Max(discount, .2m);
                        }
                    }

                    if (customer.IsBirthday())
                    {
                        discount += .10m;
                    }
                }
            } else
            {
                discount = Math.Max(discount, .15m);
            }

            // if (customer.IsVeteran)
            // {
            //     discount = Math.Max(discount, .10m);
            // }

            return discount;
        }
    }
}
