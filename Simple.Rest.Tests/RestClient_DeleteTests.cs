﻿namespace Simple.Rest.Tests
{
    using System;
    using System.Net;
    using NUnit.Framework;
    using Rest;
    using Serializers;

    [TestFixture]
    public class RestClientDeleteTests
    {
        private IRestClient _xmlRestClient;
        private IRestClient _jsonRestClient;

        private string _baseUrl;
        private TestService _testService;
        
        [Test]
        public void should_delete_json_object()
        {
            // ARRANGE
            var url = new Uri(_baseUrl + "/api/employees/1");

            // ACT
            var task = _jsonRestClient.DeleteAsync(url);
            task.Wait();

            var response = task.Result;
            
            // ASSIGN
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void should_delete_xml_object()
        {
            // ARRANGE
            var url = new Uri(_baseUrl + "/api/employees/1");

            // ACT
            var task = _xmlRestClient.DeleteAsync(url);
            task.Wait();

            var response = task.Result;

            // ASSIGN
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _baseUrl = $"http://{Environment.MachineName}:8083";

            _testService = new TestService(_baseUrl);

            _jsonRestClient = new RestClient(new JsonSerializer());
            _xmlRestClient = new RestClient(new XmlSerializer());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _testService.Dispose();
        }
    }
}
