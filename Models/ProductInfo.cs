using System.ComponentModel.DataAnnotations; //For model validation.

namespace ProductApi.Models
{
    public class ProductInfo
    {
        [Required,Range(1,9999)]
        public int ID{get;set;}
       
        [Required,Range(1,4)]
        public int GroupID{get;set;}
       
        [Required,StringLength(100)]
        public string ProductName{get;set;}
        
        [Required,Range(0,1000)]
        public int Rate{get;set;}
    } 
}