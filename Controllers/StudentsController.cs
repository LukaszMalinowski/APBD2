using System;
using System.Collections.Generic;
using System.IO;
using cwiczenia2_zen_s19743.Model;
using cwiczenia2_zen_s19743.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia2_zen_s19743.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _repository = new StudentFileRepository();
        
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_repository.getAllStudents());
        }
    }
}