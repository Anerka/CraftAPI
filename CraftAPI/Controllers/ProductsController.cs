using System.Collections.Generic;
using CraftAPI.Models;
using CraftAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CraftAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductsService productsService)
        {
            this.ProductsService = productsService;
        }

        public JsonFileProductsService ProductsService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductsService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string productId,[FromQuery] int rating)
        {
            ProductsService.AddRating(productId, rating);

            return Ok();
        }
    }
}