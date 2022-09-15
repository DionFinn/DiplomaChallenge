using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Classes;
using Backend.DatabaseHandlers;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("/Order")]
        public IEnumerable<Order> Get()
        {
            return OrderHandler.GetOrderProduct();
        }

        [HttpPost]
        [Route("/Order")]
        public void Post([FromBody] Order order)
        {
            OrderHandler.OrderPost(order);
        }
        
        [HttpDelete]
        [Route("/Order")]
        public float DeleteOrder([FromBody] Order order)
        {
            return OrderHandler.DeleteOrder(order);
        }

        [HttpPut]
        [Route("/Order")]
        public float PutOrder([FromBody] Order order)
        {
            return OrderHandler.PutOrder(order);
        }


        

    }
}
