using Microsoft.AspNetCore.Mvc;
using SchoolX.Api.Models.Students;
using SchoolX.Api.Services.Foundations.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService) =>
            this.studentService = studentService;

        [HttpGet("{studentId}")]
        public async ValueTask<ActionResult<Student>> GetStudentByIdAsync(Guid studentId)
        {
            Student retrievedStudent = await this.studentService
                .RetrieveStudentByIdAsync(studentId);

            return Ok(retrievedStudent);
        }
    }
}
