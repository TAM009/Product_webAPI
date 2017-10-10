using ProductApi.Models;
using Microsoft.EntityFrameworkCore;//To integrate database with webapi
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; //For using task and asynchronous feature in webapi
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductGroupController:Controller
    {
        private readonly ProductContext _context;

        public ProductGroupController(ProductContext context)
        {
            _context=context;
        }


        [HttpGet]
        public async Task<List<ProductGroup>> Get()
        {
            return await _context.ProductGroupTable.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProductGroup")]
        public async Task<List<ProductGroup>> GetById(int id)
        {
            ProductGroup objProductGroup= await _context.ProductGroupTable.FindAsync(id);

            List<ProductGroup> productGroup= new List<ProductGroup>();

            try
            {
                productGroup.Add(objProductGroup);
            }
            catch(Exception ex)
            {
                throw new Exception( ex.Message);
            }
            return productGroup;
        }  

        [HttpPost] //Post method
        public async Task Create([FromBody] ProductGroup item)
        {
            try
            {
                _context.ProductGroupTable.Add(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  


        [HttpPut("{id}")] //Update method
        public async Task Update(int id, [FromBody] ProductGroup item)
        {
            var res=_context.ProductGroupTable.FirstOrDefault(t =>t.ID==id);
            res.ProductGroupName=item.ProductGroupName;

            try
            {
                _context.ProductGroupTable.Update(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")] //Delete Method
        public async Task Delete(int id)
        {
            var res = _context.ProductGroupTable.FirstOrDefault(t => t.ID == id);
            try
            {
                _context.ProductGroupTable.Remove(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}