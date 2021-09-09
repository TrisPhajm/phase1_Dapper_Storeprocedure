using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.DTO
{
    public class Student_Create_DTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
    }
}
