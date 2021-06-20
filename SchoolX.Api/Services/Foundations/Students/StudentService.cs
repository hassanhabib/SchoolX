using SchoolX.Api.Brokers.Apis;
using SchoolX.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Api.Services.Foundations.Students
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolEmApiBroker schoolEmApiBroker;

        public StudentService(ISchoolEmApiBroker schoolEmApiBroker) =>
            this.schoolEmApiBroker = schoolEmApiBroker;

        public ValueTask<Student> RetrieveStudentByIdAsync(Guid studentId) =>
            this.schoolEmApiBroker.GetStudentByIdAsync(studentId);
    }
}
