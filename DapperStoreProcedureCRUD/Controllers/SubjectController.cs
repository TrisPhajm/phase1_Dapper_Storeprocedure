using DapperStoreProcedureCRUD.DTO;
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
    public class SubjectController : Controller
    {
        private readonly ISubjectServices _subject_Service;

        public SubjectController(ISubjectServices subjectservice)
        {
            _subject_Service = subjectservice ?? throw new ArgumentNullException(nameof(subjectservice));
        }
        //GET api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var response = await _subject_Service.GetById(id);
            if (response == null)
            {
                return NotFound("No Result");
            }
            return Ok(response);
        }
        //GET api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubject()
        {
            var response = await _subject_Service.GetAll();
            if (response == null || !response.Any())
            {
                return NotFound("No Result");
            }
            return Ok(response);
        }
        //POST api/[controller]
        [HttpPost]
        public async Task<ActionResult<Subject_Create_DTO>> CreateSubject(Subject_Create_DTO student_create_Dto)
        {
            var response = await _subject_Service.Post(student_create_Dto);
            if (response == null)
            {
                return BadRequest();
            }
            return Created("successful", response);
        }
        //PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeSubjectData(int id, Subject_Update_DTO student_update_dto)
        {
            var student_response = await GetSubjectById(id);
            if (student_response == null)
            {
                return NotFound();
            }
            bool response = await _subject_Service.Put(id, student_update_dto);
            if (response)
            {
                return NoContent();
            }
            return BadRequest();
        }
        //DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubjectById(int id)
        {
            var student_response = await GetSubjectById(id);
            if (student_response == null)
            {
                return NotFound();
            }
            bool response = await _subject_Service.Delete(id);
            if (response)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
