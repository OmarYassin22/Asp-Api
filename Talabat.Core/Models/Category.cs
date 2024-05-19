using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Access.Models
{
    [Table("Category")]

    public class Category:BaseModel
    {
        public string Name { get; set; }

    }
}
