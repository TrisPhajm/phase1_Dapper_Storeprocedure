using Dapper;
using DapperStoreProcedureCRUD.DTO;
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
    public class SubjectServices : ISubjectServices
    {
        private readonly SqlConnection _sql;
        public SubjectServices(IConfiguration configuration)
        {
            _sql = new SqlConnection(configuration.GetConnectionString("DapperDB"));

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _sql.ExecuteAsync("Tri_DeleteSubjectById"
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

        public async Task<IEnumerable<Subject>> GetAll()
        {
            try
            {
                var list_subject = await _sql.QueryAsync<Subject>("Tri_GetSubjects", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return list_subject;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Subject> GetById(int id)
        {
            try
            {
                var subject = await _sql.QueryFirstAsync<Subject>("Tri_GetSubjectById", new { Id = id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return subject;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Subject> Post(Subject_Create_DTO subject_create_Dto)
        {
                var created_subject = await _sql.QueryFirstAsync<Subject>("Tri_CreateSubject",
                    new
                    {
                        Name = subject_create_Dto.Name
                    }
                    , commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return created_subject;
           
        }

        public async Task<bool> Put(int id, Subject_Update_DTO subject_update_Dto)
        {
            try
            {
                await _sql.ExecuteAsync("Tri_PutSubjectById"
                    , new
                    {
                        Id = id,
                        Name = subject_update_Dto.Name
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
