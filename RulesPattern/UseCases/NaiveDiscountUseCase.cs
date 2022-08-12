using RulesPattern.Models;

namespace RulesPattern.UseCases
{
    public class NaiveDiscountUseCase
    {
        public decimal Action(Customer customer)
        {
            decimal discount = 0;

            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                discount = .05m;
            }

            if (
                customer.DateOfBirth.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Month == DateTime.Today.Month
            )
            {
                discount = Math.Max(discount, .10m);
            }

            if (customer.DateFirstPurchase.HasValue)
            {
                if (customer.DateFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    discount = Math.Max(discount, .10m);
                    if (customer.DateFirstPurchase.Value < DateTime.Now.AddYears(-5))
                    {
                        discount = Math.Max(discount, .12m);
                        if (customer.DateFirstPurchase.Value < DateTime.Now.AddYears(-10))
                        {
                            discount = Math.Max(discount, .2m);
                        }
                    }

                    if (
                        customer.DateOfBirth.Day == DateTime.Today.Day &&
                        customer.DateOfBirth.Month == DateTime.Today.Month
                    )
                    {
                        discount = Math.Max(discount, .10m);
                    }
                }
            }
            else
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
