using SchoolX.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Api.Brokers.Apis
{
    public partial class SchoolEmApiBroker
    {
        const string StudentsRelativeUrl = "api/students";

        public async ValueTask<Student> GetStudentByIdAsync(Guid studentId) =>
            await this.GetAsync<Student>($"{StudentsRelativeUrl}/{studentId}");
    }
}
