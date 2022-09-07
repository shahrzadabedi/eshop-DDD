using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderCotroller: ControllerBase
    {
        private ICommandBus _bus;
        public OrderCotroller(ICommandBus bus)
        {
            this._bus = bus;
        }

        [HttpPost]
        public IActionResult Post(PlaceLoanApplication command)
        {
            _bus.Dispatch(command);
            return Ok();
        }
    }
}
