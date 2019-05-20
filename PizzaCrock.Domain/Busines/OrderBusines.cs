using PizzaCrock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PizzaCrock.Domain.Busines
{
    public static class OrderBusines
    {
       
       
        public  static int CalculateTotalTime(Order order)
        {
            var timeTotal = 0;
            var timeSize = order.Size.PreparationTime;
            var timeAdditional =  order.Additional.ToList().Sum(x => x.AdditionalMinutes);
            timeTotal = timeTotal + timeSize + timeAdditional;
            return timeTotal;
        }

        public static decimal CalculateTotalPrice(Order order)
        {
            var priceTotal = 0.0M;
            var priceSize = order.Size.Price;
            var priceAdditional = order.Additional.ToList().Sum(x => x.AdditionalPrice);
            priceTotal = priceTotal +priceSize + priceAdditional;
            return priceTotal;
        }

    }
}
