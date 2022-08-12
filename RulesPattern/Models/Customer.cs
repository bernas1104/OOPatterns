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
    }
}
