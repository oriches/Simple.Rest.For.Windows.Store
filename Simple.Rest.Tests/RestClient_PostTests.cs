using System;
using System.Linq;
using NUnit.Framework;
using Simple.Rest.Serializers;
using Simple.Rest.Tests.Controllers;
using Simple.Rest.Tests.Dto;

namespace Simple.Rest.Tests
{
    [TestFixture]
    public class RestClientPostTests
    {
        private IRestClient _jsonRestClient;
        private IRestClient _xmlRestClient;

        private string _baseUrl;
        private TestService _testService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _baseUrl = $"http://{Environment.MachineName}:8082";

            _testService = new TestService(_baseUrl);

            _jsonRestClient = new RestClient(new JsonSerializer());
            _xmlRestClient = new RestClient(new XmlSerializer());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _testService.Dispose();
        }

        [Test]
        public void should_post_json_object()
        {
            // ARRANGE
            var url = new Uri(_baseUrl + "/api/employees");
            var maxId = EmployeesController.Employees.Max(e => e.Id);

            // ACT
            var newEmployee = new Employee {FirstName = "Alex", LastName = "Chauhan"};
            var task = _jsonRestClient.PostAsync(url, newEmployee);
            task.Wait();

            var result = task.Result.Resource;

            // ASSIGN
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(++maxId));
            Assert.That(result.FirstName, Is.EqualTo(newEmployee.FirstName));
            Assert.That(result.LastName, Is.EqualTo(newEmployee.LastName));
        }

        [Test]
        public void should_post_xml_object()
        {
            // ARRANGE
            var url = new Uri(_baseUrl + "/api/employees");
            var maxId = EmployeesController.Employees.Max(e => e.Id);

            // ACT
            var newEmployee = new Employee {FirstName = "Alex", LastName = "Chauhan"};
            var task = _xmlRestClient.PostAsync(url, newEmployee);
            task.Wait();

            var result = task.Result.Resource;

            // ASSIGN
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(++maxId));
            Assert.That(result.FirstName, Is.EqualTo(newEmployee.FirstName));
            Assert.That(result.LastName, Is.EqualTo(newEmployee.LastName));
        }
    }
}