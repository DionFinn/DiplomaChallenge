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
    [EnableCors]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [EnableCors]
        [Route("/Customer")]
        public IEnumerable<Customer> Get()
        {
            return CustomerHandler.GetCustomer();
        }
    }
}
