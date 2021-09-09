using DapperStoreProcedureCRUD.DTO;
using DapperStoreProcedureCRUD.Model;
using DapperStoreProcedureCRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoreProcedureCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentservices)
        {
            _studentService = studentservices ?? throw new ArgumentNullException(nameof(studentservices)); 
        }
        //GET api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var response = await _studentService.GetById(id);
            if (response == null)
            {
                return NotFound("No Result");
            }
            return Ok(response);
        }
        //GET api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            var response = await _studentService.GetAll();
            if (response == null || !response.Any())
            {
                return NotFound("No Result");
            }
            return Ok(response);
        }
        //POST api/[controller]
        [HttpPost]
        public async Task<ActionResult<Student_Create_DTO>> CreateStudent(Student_Create_DTO student_create_Dto)
        {
            var response = await _studentService.Post(student_create_Dto);
            if (response == null)
            {
                return BadRequest();
            }
            return Created("successful", response);
        }
        //PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeStudentData(int id, Student_Update_DTO student_update_dto)
        {
            var student_response = await GetStudentById(id);
            if (student_response == null)
            {
                return NotFound();
            }
            bool response = await _studentService.Put(id, student_update_dto);
            if (response)
            {
                return NoContent();
            }
            return BadRequest();
        }
        //DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            var student_response = await GetStudentById(id);
            if (student_response == null)
            {
                return NotFound();
            }
            bool response = await _studentService.Delete(id);
            if (response)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
