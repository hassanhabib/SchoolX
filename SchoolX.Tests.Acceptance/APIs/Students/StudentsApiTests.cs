using FluentAssertions;
using Newtonsoft.Json;
using SchoolX.Api.Models.Students;
using SchoolX.Tests.Acceptance.Brokers;
using System;
using System.Net;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace SchoolX.Tests.Acceptance.APIs.Students
{
    [Collection(nameof(ApiTestCollection))]
    public class StudentsApiTests
    {
        private readonly SchoolXApiBroker schoolXApiBroker;
        private readonly WireMockServer wireMockServer;

        public StudentsApiTests(SchoolXApiBroker schoolXApiBroker)
        {
            this.schoolXApiBroker = schoolXApiBroker;
            this.wireMockServer = WireMockServer.Start(6220);
        }
          

        private static Student CreateRandomStudent() =>
            new Filler<Student>().Create();

        [Fact]
        public async Task ShouldRetrieveStudentByIdAsync()
        {
            // given
            Student randomStudent = CreateRandomStudent();
            Student retrievedStudent = randomStudent;
            Student expectedStudent = retrievedStudent;
            Guid inputStudentId = randomStudent.Id;

            string retrievedStudentBody =
                JsonConvert.SerializeObject(retrievedStudent);

            this.wireMockServer
                .Given(Request.Create()
                    .WithPath($"/api/students/{inputStudentId}")
                    .UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBody(retrievedStudentBody));

            // when
            Student actualStudent = await this.schoolXApiBroker
                .GetStudentByIdAsync(inputStudentId);

            // then
            actualStudent.Should().BeEquivalentTo(expectedStudent);
        }
    }
}
