using PizzaCrock.Domain.Entities;
using System.Collections.Generic;

namespace PizzaCrock.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int FlavorId { get; set; }
        public string Flavor { get; set; }
        public int PreparationTime { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<Additional> Additionals { get; set; }  


    }
}
