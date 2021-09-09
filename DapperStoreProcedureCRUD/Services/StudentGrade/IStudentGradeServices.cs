using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.DTO.Grade;
using DapperStoreProcedureCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Services
{
    public interface IStudentGradeServices
    {
        Task<IEnumerable<StudentGrade_Get_DTO>> GetByStudentId(int studentId);
        //Task<bool> Delete(int id);
        //Task<StudentGrade> Post(StudentGrade_Create_DTO studentgrade_create_dto);
        //Task<bool> Put(int id, StudentGrade_Update_DTO studentgrade_update_dto); // automapping?
        //Task<IEnumerable<StudentGrade>> GetAll();
    }
}
