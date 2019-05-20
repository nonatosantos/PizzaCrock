using Microsoft.AspNetCore.Mvc;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Domain.ViewModels;
using PizzaCrock.Infra.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaCrock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
     
        private readonly OrderRepository _repository;

        public OrdersController( OrderRepository repository)
        {           
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
    

            return  CreatedAtAction("GetOrder", new { id = order.Id }, order.DateOrder);
        }
        
    }
}
