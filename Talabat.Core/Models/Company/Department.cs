using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Access.Models.Company
{
    //[Table("Department", Schema ="Company")]
    public class Department:BaseModel
    {
        public string Name { get; set; }

    }
}
