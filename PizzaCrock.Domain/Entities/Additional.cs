using PizzaCrock.Shared.Entities;

namespace PizzaCrock.Domain.Entities
{
    public class Additional : Entity
    {
        public Additional(string description, int additionalMinutes, decimal additionalPrice )
        {
            Description = description;
            AdditionalMinutes = additionalMinutes;
            AdditionalPrice = additionalPrice;
        }
     
        public string Description { get; private set; }
        public decimal AdditionalPrice { get; private set; }
        public int AdditionalMinutes { get; private set; }
    }
}
