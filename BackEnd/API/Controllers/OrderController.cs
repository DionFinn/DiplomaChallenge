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
            return OrderHandler.GetOrder();
        }

        []
    }
}
