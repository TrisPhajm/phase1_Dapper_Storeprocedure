using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models;
using UI.Service;

namespace UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IClientService _client_service;

        public IActionResult Index()
        {
            return View();
        }
        public StudentController(IClientService clientService)
        {
            _client_service = clientService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            var response = await _client_service.GetAll<Student>("/api/Student");
            return new OkObjectResult(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetStudentById(int studentId)
        {
            var response = await _client_service.GetById<Student>("/api/Student/"+studentId);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            var response = await _client_service.Delete("/api/Student/" + studentId);
            if (response)
                return Ok("delete successfully");
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            if (student.Id == 0)
            {
                bool create_response = await _client_service.Post("/api/Student", student);
                return create_response ? View() : BadRequest();
            }
            bool update_response = await _client_service.Put("/api/Student/" + student.Id, student);
            return update_response ? View() : BadRequest();
        }
        public async Task<ActionResult> Detail(int studentId)
        {
            var student = await _client_service.GetById<Student>("/api/Student/" + studentId); ;
            var student_grade_list = await _client_service.GetDataListById<StudentGrade>("/api/StudentGrade/" + studentId);
            var student_grade_model = new StudentGradeModel
            {
                student = student,
                student_grade_list = student_grade_list
            };
            return View(student_grade_model);
        }
    }
}
