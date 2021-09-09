using DapperStoreProcedureCRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.DTO.Grade
{
    public class StudentGrade_Get_DTO : StudentGrade
    {
        public string SubjectName { get; set; }
    }
}
