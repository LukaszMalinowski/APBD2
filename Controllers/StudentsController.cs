#nullable enable
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

        [HttpGet] 
        [Route("{indexNumber?}")]
        public IActionResult GetStudentByIndexNumber(string? indexNumber)
        {
            Student student = _repository.getStudentByIndexNumber(indexNumber);
            if (student != null)
                return Ok(student);
            
            return NotFound();
        }
    }
}