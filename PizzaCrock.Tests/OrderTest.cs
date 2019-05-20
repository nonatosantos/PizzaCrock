using PizzaCrock.Domain.Busines;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Infra;
using PizzaCrock.Infra.Repositories;
using System.Collections.Generic;
using Xunit;

namespace PizzaCrock.Tests
{
    public class OrderTest
    {
        private Order _orderCalabresa;
        private Size _sizeM;
        private Flavor _flavorCalabresa;   

  
        public OrderTest()
        {

            _sizeM = new Size("M", 20.00M, 20);
            _flavorCalabresa = new Flavor("Calabresa", 20);
            _orderCalabresa = new Order(0, 0);
            _orderCalabresa.Flavor = _flavorCalabresa;
            _orderCalabresa.Size = _sizeM;
            _orderCalabresa.AddItem("Extra Bacon", 5, 5.00M);

        }

        [Fact]
        public void ExpectedPriceSize()
        {
            var expected = 20.00M;
            Assert.Equal(expected, _sizeM.Price);            
        }

        [Fact]
        public void ExpectedTimeSize()
        {
            var expected = 20;
            Assert.Equal(expected, _sizeM.PreparationTime);
          
        }

        [Fact]
        public void CountAdditional()
        {
            var expected = 1;
            Assert.Equal(expected, _orderCalabresa.Additional.Count);
        }

        [Fact]
        public void TotalTimeAdditionals()
        {        
            var expected = 25;
            Assert.Equal(expected, OrderBusines.CalculateTotalTime(_orderCalabresa));
        }

        [Fact]
        public void TotalPrice()
        {         
           
            var totalPrice = OrderBusines.CalculateTotalPrice(_orderCalabresa);
            var expected = 25.00M;
            Assert.Equal(expected, totalPrice);
       
        }

     
    }
}
