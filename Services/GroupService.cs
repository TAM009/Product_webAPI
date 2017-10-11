using System;
using ProductApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GroupService
{
    public class GroupMethods:IProductGroupService
    {
        private readonly ProductContext _context;

        public GroupMethods(ProductContext context)
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
            if(item.ProductGroupName.Equals(typeof(string)))
            {
            res.ProductGroupName=item.ProductGroupName;
            }

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