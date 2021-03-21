#nullable enable
using System;
using cwiczenia2_zen_s19743.Model;
using cwiczenia2_zen_s19743.Repository;
using Microsoft.AspNetCore.Http;
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
        public IActionResult UpdateStudentByIndexNumber(string? indexNumber, [FromBody] Student student)
        {
            Student updatedStudent;

            try
            {
                updatedStudent = _repository.UpdateStudentByIndexNumber(indexNumber, student);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return NoContent();
            }
            

            return Ok(updatedStudent);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            Student addedStudent;
            try
            {
                addedStudent = _repository.AddStudent(student);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(addedStudent);
        }
        
        [HttpDelete]
        [Route("{indexNumber?}")]
        public IActionResult DeleteStudentByIndexNumber(string? indexNumber)
        {
            try
            {
                _repository.DeleteStudentByIndexNumber(indexNumber);
            }
            catch (Exception)
            {
                return NoContent();
            }
            
            return Ok();
        }
    }
}