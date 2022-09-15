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
        [Route("/Order/Procedure")]
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
    }
}
