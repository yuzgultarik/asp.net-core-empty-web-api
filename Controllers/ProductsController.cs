using core_tarik_api_empty.Data;
using core_tarik_api_empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_tarik_api_empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        #region rafinin yazdıkları
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        #endregion

        [HttpPost("createProduct")]
        public async Task<ActionResult<IActionResult>> PostProductDetail(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {

            var deleteproduct = _context.Products.FirstOrDefault(x => x.id == id);

            if (deleteproduct == null)
            {
                return NotFound();
            }


            _context.Remove(deleteproduct);
            await _context.SaveChangesAsync();
            return Ok();

        }
        

    

    }
}
