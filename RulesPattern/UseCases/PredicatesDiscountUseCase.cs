using RulesPattern.Models;

#pragma warning disable

namespace RulesPattern.UseCases
{
    public class PredicatesDiscountUseCase
    {
        public decimal Action(Customer customer)
        {
            decimal discount = 0;
            if (IsSenior(customer))
            {
                discount = .05m;
            }

            if (IsBirthday(customer))
            {
                discount = Math.Max(discount, .10m);
            }

            if (HasPurchasedBefore(customer))
            {
                if (HasBeenLoyalForYears(customer, 1))
                {
                    discount = Math.Max(discount, .10m);
                    if (HasBeenLoyalForYears(customer, 5))
                    {
                        discount = Math.Max(discount, .12m);
                        if (HasBeenLoyalForYears(customer, 10))
                        {
                            discount = Math.Max(discount, .2m);
                        }
                    }

                    if (IsBirthday(customer))
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

        private static bool HasBeenLoyalForYears(
            Customer customer,
            int numberOfYears
        )
        {
            numberOfYears *= -1;
            return customer.DateFirstPurchase!.Value <
                DateTime.Now.AddYears(numberOfYears);
        }

        private static bool HasPurchasedBefore(Customer customer)
        {
            return customer.DateFirstPurchase.HasValue;
        }

        private static bool IsBirthday(Customer customer)
        {
            return customer.DateOfBirth.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Month == DateTime.Today.Month;
        }

        private static bool IsSenior(Customer customer)
        {
            return customer.DateOfBirth < DateTime.Now.AddYears(-65);
        }
    }
}
