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
        [EnableCors]
        [Route("/Order")]
        public IEnumerable<Order> Get()
        {
            return OrderHandler.GetOrderProduct();
        }
        
        [HttpGet]
        [EnableCors]
        [Route("/Order/gst")]
        public float GST([FromBody] Order order)
        {
            return OrderHandler.GST(order);
        }

        [HttpGet]
        [EnableCors]
        [Route("/Order/total")]
        public float Total([FromBody] Order order)
        {
            return OrderHandler.Total(order);
        }

        [HttpPost]
        [EnableCors]
        [Route("/Order")]
        public void Post([FromBody] Order order)
        {
            OrderHandler.OrderPost(order);
        }
        
        [HttpDelete]
        [EnableCors]
        [Route("/Order")]
        public float DeleteOrder([FromBody] Order order)
        {
            return OrderHandler.DeleteOrder(order);
        }

        [HttpPut]
        [EnableCors]
        [Route("/Order")]
        public float PutOrder([FromBody] Order order)
        {
            return OrderHandler.PutOrder(order);
        }


        

    }
}
