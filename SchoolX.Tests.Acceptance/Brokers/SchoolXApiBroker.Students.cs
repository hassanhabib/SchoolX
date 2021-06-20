using SchoolX.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace SchoolX.Tests.Acceptance.Brokers
{
    public partial class SchoolXApiBroker
    {
        const string StudentApiRelativeUrl = "api/students";

        public async ValueTask<Student> GetStudentByIdAsync(Guid studentId)
        {
            return await this.apiFactoryClient.GetContentAsync<Student>(
                relativeUrl: $"{StudentApiRelativeUrl}/{studentId}");
        }
    }
}
