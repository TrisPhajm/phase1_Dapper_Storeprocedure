using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.DTO
{
    public class Subject_Create_DTO
    {
        [Required]
        public string Name { get; set; }
    }
}
