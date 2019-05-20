using PizzaCrock.Domain.Busines;
using PizzaCrock.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCrock.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<Additional> _additionals;
        public Order(int flavorId, int sizeId)
        {
            DateOrder = DateTime.Now;
            FlavorId = flavorId;
            SizeId = sizeId;
            _additionals = new List<Additional>();       
          
        }    


        public DateTime DateOrder { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int FlavorId { get; set; }
        public Flavor Flavor { get; set; }
        public int PreparationTime { get;  set; }
        public decimal TotalPrice { get;  set; }
        public IReadOnlyCollection<Additional> Additional => _additionals.ToArray();


        public void AddItem(string description, int minutes, decimal price)
        {
            var additional = new Additional(description, minutes, price);
            _additionals.Add(additional);
        }

        public List<Additional> GetItens(Order order)
        {
            return   order.Additional.ToList();
        }



    }
}
