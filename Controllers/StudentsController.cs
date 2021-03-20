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
        private readonly IStudentRepository _repository = new StudentFileRepository();
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_repository.GetAllStudents());
        }

        [HttpGet] 
        [Route("{indexNumber?}")]
        public IActionResult GetStudentByIndexNumber(string? indexNumber)
        {
            Student student = _repository.GetStudentByIndexNumber(indexNumber);
            if (student != null)
                return Ok(student);
            
            return NotFound();
        }

        [HttpPut]
        [Route("{indexNumber?}")]
        public IActionResult UpdateStudentByIndexNumber(string? indexNumber,[FromBody] Student student)
        {
            Student updatedStudent = _repository.UpdateStudentByIndexNumber(indexNumber, student);

            if (updatedStudent != null)
                return Ok(updatedStudent);

            return NoContent();
        }
    }
}