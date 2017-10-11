using System;
using ProductApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace InfoService
{
    public interface IProductInfoService //1.Creating Interface for dependency injection.
    {
        Task<List<ProductInfo>> GetAll();
        Task<List<ProductInfo>> GetUsingId(int id);
        Task Create([FromBody] ProductInfo item);
        Task Update(int id, [FromBody] ProductInfo item);
        Task Delete(int id);
        bool IsAlphaName(ProductInfo item);
        bool IsNumericRate(ProductInfo item);
        bool IsNumericGroupID(ProductInfo item);

    }
}