using System;
using ProductApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace GroupService
{
    public interface IProductGroupService
    {
           Task<List<ProductGroup>> Get();
           Task<List<ProductGroup>> GetById(int id);
           Task Create([FromBody] ProductGroup item);
           Task Update(int id, [FromBody] ProductGroup item);
           Task Delete(int id);

    }
}