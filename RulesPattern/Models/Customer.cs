using RulesPattern.Extensions;

namespace RulesPattern.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? DateFirstPurchase { get; private set; }
        public bool IsVeteran { get; private set; }

        public Customer(
            Guid? id, DateTime dateOfBirth,
            bool isVeteran, DateTime? dateFirstPurchase = null
        )
        {
            Id = id ?? Guid.NewGuid();
            DateOfBirth = dateOfBirth;
            DateFirstPurchase = dateFirstPurchase;
            IsVeteran = isVeteran;
        }

        public bool IsSenior(DateTime? date = null)
        {
            return DateOfBirth < date.ToValueOrDefault().AddYears(-65);
        }

        public bool IsBirthday(DateTime? date = null)
        {
            date = date.ToValueOrDefault();
            return DateOfBirth.Day == date.Value.Day &&
                DateOfBirth.Month == date.Value.Month;
        }

        public bool HasBeenLoyalForYears(
            int numberOfYears,
            DateTime? date = null
        )
        {
            if (!HasPurchasedBefore())
            {
                return false;
            }

            numberOfYears = -1 * numberOfYears;
            return DateFirstPurchase!.Value <
                date.ToValueOrDefault().AddYears(numberOfYears);
        }

        public bool HasPurchasedBefore()
        {
            return DateFirstPurchase.HasValue;
        }
    }
}
