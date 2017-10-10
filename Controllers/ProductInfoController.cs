using ProductApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductInfoController:Controller
    {
        private readonly ProductContext _context;

        public ProductInfoController(ProductContext context)
        {
            _context=context;
        }


        [HttpGet]
        public async Task<List<ProductInfo>> GetAll()
        {
            return await _context.ProductInfoTable.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProductInfo")]
        public async Task<List<ProductInfo>> GetUsingId(int id)
        {
            ProductInfo objProductInfo= await _context.ProductInfoTable.FindAsync(id);

            List<ProductInfo> productInfo= new List<ProductInfo>();

            try
            {
                productInfo.Add(objProductInfo);
            }
            catch(Exception ex)
            {
                throw new Exception( ex.Message);
            }
            return productInfo;
        }  

        [HttpPost] //Post method
        public async Task Create([FromBody] ProductInfo item)
        {
            try
            {
                _context.ProductInfoTable.Add(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  


        [HttpPut("{id}")] //Update method
        public async Task Update(int id, [FromBody] ProductInfo item)
        {
            var res=_context.ProductInfoTable.FirstOrDefault(t =>t.ID==id);
            
            res.ProductName=item.ProductName;
            res.Rate=item.Rate;
            res.GroupID=item.GroupID;

            try
            {
                _context.ProductInfoTable.Update(res);
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
            var res = _context.ProductInfoTable.FirstOrDefault(t => t.ID == id);
            try
            {
                _context.ProductInfoTable.Remove(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}