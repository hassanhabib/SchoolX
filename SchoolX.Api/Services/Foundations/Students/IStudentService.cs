using SchoolX.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Api.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> RetrieveStudentByIdAsync(Guid studentId);
    }
}
