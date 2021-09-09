using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Services
{
    public interface ISubjectServices
    {
        Task<bool> Put(int id, Subject_Update_DTO subject_update_Dto); // automapping?
        Task<IEnumerable<Subject>> GetAll();
        Task<Subject> GetById(int id);
        Task<bool> Delete(int id);
        Task<Subject> Post(Subject_Create_DTO subject_create_Dto);
    }
}
