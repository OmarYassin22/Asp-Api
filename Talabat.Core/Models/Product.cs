using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Access.Models
{
    public class Product:BaseModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int? BrandId { get; set; }
        public Brand ProductBrand { get; set; }
        public int? CategoryId { get; set; }
        public Category ProductCategory { get; set; }


    }
}
