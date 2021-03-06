using ProductApi.Models;
using InfoService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;


namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductInfoController:Controller //4.Using the infoservice defined in startup in the controller.
    {
        private readonly ProductContext _context;

        private IProductInfoService _service;

        public ProductInfoController(ProductContext context,IProductInfoService service)
        {
            _context=context;
            _service=service;
        }

        [HttpGet]
        public Task<List<ProductInfo>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetProductInfo")]
        public Task<List<ProductInfo>> GetUsingId(int id)
        {
            return _service.GetUsingId(id);
        }

        [HttpPost] //Post method
        public Task Create([FromBody] ProductInfo item)
        {
            return _service.Create(item);
        }

        [HttpPut("{id}")] //Update method
        public Task Update(int id, [FromBody] ProductInfo item)
        {
            return _service.Update(id,item);
        }

        [HttpDelete("{id}")] //Delete Method
        public Task Delete(int id)
        {
            return _service.Delete(id);
        }

        public bool IsAlphaName(ProductInfo item)
        {
            return _service.IsAlphaName(item);
        }

        public bool IsNumericRate(ProductInfo item)
        {
            return _service.IsNumericRate(item);
        }

        public bool IsNumericGroupID(ProductInfo item)
        {
            return _service.IsNumericGroupID(item);
        }


        /*[HttpGet]
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

                try
                {
                    if(IsAlphaName(item) && IsNumericRate(item) && IsNumericGroupID(item))
                    await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    throw new Exception("Please make sure that all the inputs are given in the proper format");
                }

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
            
            try
            {   
                try
                {
                    if(IsAlphaName(item))
                    res.ProductName=item.ProductName;
                }
                catch(Exception ex)
                {
                    //throw new Exception("Product name can contain only alphabets and space");
                    throw new Exception(ex.Message);
                }


                try
                {
                    if(IsNumericRate(item))
                    res.Rate=item.Rate;
                }
                catch(Exception)
                {
                    throw new Exception("rate can consist only integer input");
                } 


                try
                {
                    if(IsNumericGroupID(item))   
                    res.GroupID=item.GroupID;
                }
                catch(Exception)
                {
                    throw new Exception("GroupID can consist only integer input");
                } 


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
            
            try
            {
                var res = _context.ProductInfoTable.FirstOrDefault(t => t.ID == id);
                _context.ProductInfoTable.Remove(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        //TypeSafe Check
        public bool IsAlphaName(ProductInfo item)
        {   
            try
            {
                string pattern="[a-zA-Z]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.ProductName.ToString().Trim())==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsNumericRate(ProductInfo item)
        {   
            try
            {
                string pattern="^[0-9]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.Rate.ToString().Trim())==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsNumericGroupID(ProductInfo item)
        {   
            try
            {
                string pattern="^[0-9]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.GroupID.ToString().Trim())==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/


    }
}