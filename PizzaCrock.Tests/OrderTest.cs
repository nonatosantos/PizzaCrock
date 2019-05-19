using PizzaCrock.Domain.Entities;
using PizzaCrock.Infra;
using PizzaCrock.Infra.Repositories;
using System.Collections.Generic;
using Xunit;

namespace PizzaCrock.Tests
{
    public class OrderTest
    {
        private Order _order;
        private Size _size;
        private Flavor _flavor;   

  
        public OrderTest()
        {       

            _flavor = new Flavor("Calabresa", 5);
            _size = new Size("P", 20.00M, 20);
            _order = new Order(_flavor.Id, _size.Id);            
            _order.AddItem("Retirar Cebola",0,0);
            _order.AddItem("Bordas Recheadas", 8, 0);
            _order.AddItem("Extra Bacon", 1, 5.00m);

        }

        [Fact]
        public void ExpectedPriceSize()
        {
            var expected = 20.00M;
            Assert.Equal(expected, _size.Price);            
        }

        [Fact]
        public void ExpectedTimeSize()
        {
            var expected = 20;
            Assert.Equal(expected, _size.PreparationTime);
          
        }

        [Fact]
        public void CountAdditional()
        {
            var expected = 3;
            Assert.Equal(expected, _order.Additional.Count);
        }

        [Fact]
        public void TotalAdditionals()
        {
            List<Additional> list = _order.GetTitens(_order);

            var time = 0;
            foreach(Additional orderTime in list)
            {
                time  = orderTime.AdditionalMinutes;
            }
            var expected = 8;
            Assert.Equal(expected, time);
        }  
    }
}
