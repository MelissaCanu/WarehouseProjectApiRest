using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WarehouseProjectApiRest.Models;
using WarehouseProjectApiRest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseProjectApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase // warehousecontroller extends ControllerBase, this way it can handle HTTP requests(GET, POST, PUT, DELETE)
    {   
        private readonly IWarehouseService _warehouseService; // IWarehouseService is the interface that defines the methods that the service must implement

        public WarehouseController(IWarehouseService warehouseService) // constructor: service is injected in the controller
        {
            _warehouseService = warehouseService;
        }

        // GET: api/<WarehouseController>
        [HttpGet("batches")]
        public ActionResult<IEnumerable<ProductBatch>> Get() 
        {
            return Ok(_warehouseService.GetAllBatches());
        }

        // POST api/<WarehouseController>
        [HttpPost("batches")]
        public ActionResult AddBatch([FromBody] ProductBatch batch)
        {
            try
            {
                _warehouseService.AddBatch(batch); // add the batch to the warehouse (using the service injected in the controller)
                return Ok(); // 200 OK
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("products/buy/{productId}")]
        
        public ActionResult RemoveProduct(int productId, [FromQuery] int quantity) //fromquery/frombody: the difference is how you pass the data to the method 
        {
            try
            {
                _warehouseService.RemoveProduct(productId, quantity); //remove the product from the warehouse 
                return Ok(); // 200 OK
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
       
        }
    }
}
