using PizzaCrock.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCrock.Domain.Entities
{
    public class Order : Entity
    {
        public readonly IList<Additional> _additionals;
        public Order(int flavorId, int sizeId)
        {
            DateOrder = DateTime.Now;
            FlavorId = flavorId;
            SizeId = sizeId;
            _additionals = new List<Additional>();           
          
        }    


        public DateTime DateOrder { get; private set; }
        public int SizeId { get; set; }
        public Size Size { get; private set; }
        public int FlavorId { get; set; }
        public Flavor Flavor { get; private set; }
        public int PreparationTime { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IReadOnlyCollection<Additional> Additional => _additionals.ToArray();


        public void AddItem(string description, int minutes, decimal price)
        {
            var additional = new Additional(description, minutes, price);
            _additionals.Add(additional);

            // testar contagem do time aqui

        }

        public List<Additional> GetTitens(Order order)
        {
            return   order.Additional.ToList();
        }



    }
}
