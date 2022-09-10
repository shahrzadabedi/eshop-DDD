using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController: ControllerBase
    {
        private ICommandBus _bus;
        public OrderController(ICommandBus bus)
        {
            this._bus = bus;
        }

        [HttpPost]
        public IActionResult Post(PlaceOrder command)
        {
            try
            {
                _bus.Dispatch(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }
    }
}
