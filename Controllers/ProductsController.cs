
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //synchronous
            // var products=context.Products.ToList();
            // return Ok(products);
            return await _context.Products.ToListAsync();
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int id)
        {
            var products=await _context.Products.FindAsync(id);
            return Ok(products);
        }
    }
}