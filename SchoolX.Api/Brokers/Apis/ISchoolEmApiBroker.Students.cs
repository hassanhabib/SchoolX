using SchoolX.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Api.Brokers.Apis
{
    public partial interface ISchoolEmApiBroker
    {
        ValueTask<Student> GetStudentByIdAsync(Guid studentId);
    }
}
