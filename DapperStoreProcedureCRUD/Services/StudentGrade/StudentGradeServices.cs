using Dapper;
using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.DTO.Grade;
using DapperStoreProcedureCRUD.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Services
{
    public class StudentGradeServices : IStudentGradeServices
    {
        private readonly SqlConnection _sql;

        public StudentGradeServices(IConfiguration conf)
        {
            _sql = new SqlConnection(conf.GetConnectionString("DapperDB"));
        }
        public async Task<IEnumerable<StudentGrade_Get_DTO>> GetByStudentId(int id)
        {
            try
            {
                var studentGrade_By_StudentId_list = await _sql.QueryAsync<StudentGrade_Get_DTO>("Tri_GetStudentGradeByStudentId", new { StudentId = id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return studentGrade_By_StudentId_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<StudentGrade> Post(StudentGrade_Create_DTO studentgrade_create_dto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Put(int id, StudentGrade_Update_DTO studentgrade_update_dto)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<StudentGrade>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
