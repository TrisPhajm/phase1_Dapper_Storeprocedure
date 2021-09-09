using DapperStoreProcedureCRUD.DTO.Grade;
using DapperStoreProcedureCRUD.Model;
using DapperStoreProcedureCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeServices _studentGradeService;

        public StudentGradeController(IStudentGradeServices studentgradeservice)
        {
            _studentGradeService = studentgradeservice ?? throw new ArgumentNullException(nameof(studentgradeservice));
        }
        //GET api/[controller]/{id}
        [HttpGet("{studentid}")]
        public async Task<ActionResult<IEnumerable<StudentGrade_Get_DTO>>> GetStudentGradeByStudentId(int studentid)
        {
            var response = await _studentGradeService.GetByStudentId(studentid);
            if (response == null || !response.Any())
            {
                return NotFound("No Result");
            }
            return Ok(response);
        }
        //POST api/[controller]
        //[HttpPost]
        //public async Task<ActionResult<StudentGrade_Create_DTO>> CreateStudentGrade(StudentGrade_Create_DTO studentgrade_create_Dto)
        //{
        //    var response = await _studentGradeService.Post(studentgrade_create_Dto);
        //    if (response == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Created("successful", response);
        //}
        //PUT api/[controller]/{id}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> ChangeStudentGradeData(int id, StudentGrade_Update_DTO studentgrade_update_dto)
        //{
        //    var student_response = await GetStudentById(id);
        //    if (student_response == null)
        //    {
        //        return NotFound();
        //    }
        //    bool response = await _studentGradeService.Put(id, student_update_dto);
        //    if (response)
        //    {
        //        return NoContent();
        //    }
        //    return BadRequest();
        //}
        //DELETE api/[controller]/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteStudentGradeById(int id)
        //{
        //    var student_response = await GetStudentById(id);
        //    if (student_response == null)
        //    {
        //        return NotFound();
        //    }
        //    bool response = await _studentGradeService.Delete(id);
        //    if (response)
        //    {
        //        return NoContent();
        //    }
        //    return BadRequest();
        //}
    }
}
