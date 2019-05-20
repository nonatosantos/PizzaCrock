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
        private Size _sizeP;
        private Size _sizeM;
        private Size _sizeG;
        private Flavor _flavorCalabresa;
        private Flavor _flavorPortuguesa;
        private Flavor _flavorMarguerita;


        public OrderTest()
        {
            _sizeP = new Size("P", 20.00M, 15);
            _sizeM = new Size("M", 30.00M, 20);
            _sizeG = new Size("G", 40.00M, 25);

            _flavorCalabresa = new Flavor("Calabresa", 0);
            _flavorMarguerita = new Flavor("Marguerita", 0);
            _flavorPortuguesa = new Flavor("Portuguesa", 5);

            _orderCalabresa = new Order(0, 0);
            _orderCalabresa.Flavor = _flavorCalabresa;
            _orderCalabresa.Size = _sizeM;
            _orderCalabresa.AddItem("Extra Bacon", 0, 3.00M);
            _orderCalabresa.AddItem("Bordas Recheadas", 5, 5.00M);

        }

        [Fact]
        public void ExpectedPriceSizeP()
        {
            var expected = 20.00M;
            Assert.Equal(expected, _sizeP.Price);
        }

        [Fact]
        public void ExpectedPriceSizeM()
        {
            var expected = 30.00M;
            Assert.Equal(expected, _sizeM.Price);            
        }

        [Fact]
        public void ExpectedPriceSizeG()
        {
            var expected = 40.00M;
            Assert.Equal(expected, _sizeG.Price);
        }

        [Fact]
        public void ExpectedTimeSizeM()
        {
            var expected = 20;
            Assert.Equal(expected, _sizeM.PreparationTime);
          
        }
        [Fact]
        public void ExpectedTimeAdditionalFlavorPortuguesa()
        {
            var expected = 5;
            Assert.Equal(expected, _flavorPortuguesa.AdditionalMinutes);

        }

        [Fact]
        public void ExpectedTimeAdditionalFlavorCalabresaAndMarguerita()
        {
            var expected = 0;
            Assert.Equal(expected, _flavorCalabresa.AdditionalMinutes);
            Assert.Equal(expected, _flavorMarguerita.AdditionalMinutes);

        }

        [Fact]
        public void CountAdditionalOrderCalabresa()
        {
            var expected = 2;
            Assert.Equal(expected, _orderCalabresa.Additional.Count);
        }

        [Fact]
        public void TotalTimeAdditionalsOrderCalabresa()
        {        
            var expected = 25;
            var timeAdditional = OrderBusines.CalculateTotalTime(_orderCalabresa);
            Assert.Equal(expected, timeAdditional);
        }

        [Fact]
        public void TotalPriceOrderCalabresa()        {         
           
            var totalPrice = OrderBusines.CalculateTotalPrice(_orderCalabresa);
            var expected = 38.00M;
            Assert.Equal(expected, totalPrice);
       
        }

     
    }
}
