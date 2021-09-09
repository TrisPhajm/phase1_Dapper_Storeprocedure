using DapperStoreProcedureCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Service;

namespace UI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IClientService _client_service;

        public IActionResult Index()
        {
            return View();
        }
        public SubjectController(IClientService clientService)
        {
            _client_service = clientService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllSubjects()
        {
            var response = await _client_service.GetAll<Subject>("/api/Subject");
            return new OkObjectResult(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetSubjectById(int subjectId)
        {
            var response = await _client_service.GetById<Subject>("/api/Subject/" + subjectId);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSubject(int subjectId)
        {
            var response = await _client_service.Delete("/api/Subject/" + subjectId);
            if (response)
                return Ok("delete successfully");
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }
            if (subject.Id == 0)
            {
                bool create_response = await _client_service.Post("/api/Subject", subject);
                return create_response ? View() : BadRequest();
            }
            bool update_response = await _client_service.Put("/api/Subject/" + subject.Id, subject);
            return update_response ? View() : BadRequest();
        }
    }
}
