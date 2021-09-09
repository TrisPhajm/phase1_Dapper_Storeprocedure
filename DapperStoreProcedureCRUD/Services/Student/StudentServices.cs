using Dapper;
using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly SqlConnection _sql;
        public StudentServices(IConfiguration configuration)
        {
            _sql = new SqlConnection(configuration.GetConnectionString("DapperDB"));

        }

        public async Task<Student> Post(Student_Create_DTO student_create_dto)
        {
            try
            {
                var created_student = await _sql.QueryFirstAsync<Student>("Tri_CreateStudent",
                    new
                    {
                        Name = student_create_dto.Name,
                        Class = student_create_dto.Class
                    }
                    , commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return created_student;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _sql.ExecuteAsync("Tri_DeleteStudentById"
                    , new
                    {
                        Id = id
                    }
                , commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                var student = await _sql.QueryAsync<Student>("Tri_GetStudents", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return student;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Student> GetById(int id)
        {
            try
            {
                var student = await _sql.QueryFirstAsync<Student>("Tri_GetStudentById", new { Id = id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return student;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Put(int id, Student_Update_DTO student_update_dto)
        {
            try
            {
                await _sql.ExecuteAsync("Tri_PutStudentById"
                    , new
                    {
                        Id = id,
                        Name = student_update_dto.Name,
                        Class = student_update_dto.Class
                    }
                , commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
