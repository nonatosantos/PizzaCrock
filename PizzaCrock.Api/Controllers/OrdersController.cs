using Microsoft.AspNetCore.Mvc;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Domain.ViewModels;
using PizzaCrock.Infra;
using PizzaCrock.Infra.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaCrock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaCrockDbContext _context;
        private readonly OrderRepository _repository;

        public OrdersController(PizzaCrockDbContext context, OrderRepository repository)
        {
            _context = context;
            _repository = repository;
        }

   
        [HttpGet]
        public IEnumerable<OrderViewModel> GetOrders()
        {
           return _repository.GetAll();
        }

       
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> GetOrder(int id)
        {
            var order = _repository.GetById(id);

            if(order == null)
            {
                return NotFound();
            }

            return order;
        }      
        
        
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _repository.Add(order);
            await _repository.Save(order);

            return  CreatedAtAction("GetOrder", new { id = order.Id });
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }
   
    }
}
