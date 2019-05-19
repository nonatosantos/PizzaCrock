using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Domain.Repositories;
using PizzaCrock.Domain.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCrock.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaCrockDbContext _context;

        public OrderRepository(PizzaCrockDbContext context)
        {
            _context = context;
        }



        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public async Task Save(Order order)
        {

            await _context.SaveChangesAsync();

        }

        public IEnumerable<OrderViewModel> GetAll()
        {

            return _context.Orders
           .Include(x => x.Size)
           .Include(x => x.Flavor)
           .Include(x => x.Additional)
           .Select(x => new OrderViewModel
           {
               Id = x.Id,
               SizeId = x.Size.Id,
               Size = x.Size.SizeValue,
               FlavorId = x.Flavor.Id,
               Flavor = x.Flavor.Description,
               TotalPrice = x.Size.Price + soma(),
               PreparationTime = x.Size.PreparationTime + x.Flavor.AdditionalMinutes + CalculateTimeTotal()
                 })

                 .AsNoTracking().ToList();     
            
     
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrderViewModel GetById(int id)
        {

            return _context.Orders.AsNoTracking().Where(x => x.Id == id).Include(x => x.Size)
            .Include(x => x.Flavor)
            .Include(x => x.Additional)
            .Select(x => new OrderViewModel
            {
                Id = x.Id,
                SizeId = x.Size.Id,
                Size = x.Size.SizeValue,
                FlavorId = x.Flavor.Id,
                Flavor = x.Flavor.Description,
                TotalPrice = x.Size.Price + soma(),
                PreparationTime = x.Size.PreparationTime + x.Flavor.AdditionalMinutes + CalculateTimeTotal()                
            }).AsNoTracking().First();

        }

        public decimal soma()
        {
            List<Order> orders = _context.Orders.ToList();
            var add = from p in orders
                      select p;

            var valor = 0m;
            foreach(var rs in add)
            {
                valor = rs.Additional.ToList().Sum(x => x.AdditionalPrice);
            }
            return valor;
            
        }

        public int CalculateTimeTotal()
        {
            List<Order> orders = _context.Orders.ToList();
            var additional = from p in orders
                      select p;

            var time = 0;
            foreach (var minutes in additional)
            {
                time = minutes.Additional.ToList().Sum(x => x.AdditionalMinutes);
            }
            return time;

        }


    }
}
