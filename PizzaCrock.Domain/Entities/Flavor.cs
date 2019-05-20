using PizzaCrock.Shared.Entities;

namespace PizzaCrock.Domain.Entities
{
    public class Flavor : Entity
    {
        public Flavor(string description, int additionalMinutes)
        {
            Description = description;
            AdditionalMinutes = additionalMinutes;
        }

       
        public string Description { get; private set; }
        public int AdditionalMinutes { get; private set; }
    }
}
