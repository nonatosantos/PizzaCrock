using Microsoft.AspNetCore.Mvc;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaCrock.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Task Save(Order order);       
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        void Delete(int id);
     
        
    }
}
