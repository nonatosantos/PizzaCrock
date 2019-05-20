using PizzaCrock.Shared.Entities;

namespace PizzaCrock.Domain.Entities
{
    public class Size : Entity
    {
        public Size(string sizeValue, decimal price, int preparationTime)
        {
            SizeValue = sizeValue;
            Price = price;
            PreparationTime = preparationTime;
        }    

        public string SizeValue { get; private set; }
        public decimal Price { get; private set; }
        public int PreparationTime { get; set; }
    }
}
