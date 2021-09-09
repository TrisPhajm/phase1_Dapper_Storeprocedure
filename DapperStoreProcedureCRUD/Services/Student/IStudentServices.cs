using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Services
{
    public interface IStudentServices
    {
        Task<bool> Put(int id, Student_Update_DTO student_update_Dto); // automapping?
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Delete(int id);
        Task<Student> Post(Student_Create_DTO student_Create_Dto);
    }
}
