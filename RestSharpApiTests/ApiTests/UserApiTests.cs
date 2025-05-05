using NUnit.Framework;
using RestSharpApiTests.Utilities;
using RestSharpApiTests.Models;
using Newtonsoft.Json;
using System.IO;

namespace RestSharpApiTests.ApiTests
{
    public class UserApiTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("https://reqres.in/");
        }

        [Test]
        public void CreateUser_ShouldReturn201()
        {
            // Read user data from JSON file
            var json = File.ReadAllText("TestData/CreateUser.json");
            var user = JsonConvert.DeserializeObject<User>(json);

            var response = _apiClient.SendPostRequest("api/users", user);

            Assert.That((int)response.StatusCode, Is.EqualTo(201));

            var responseBody = JsonConvert.DeserializeObject<User>(response.Content);
            Assert.That(responseBody.Name, Is.EqualTo(user.Name));
            Assert.That(responseBody.Job, Is.EqualTo(user.Job));
        }

        [Test]
        public void GetUser_ShouldReturn200()
        {
            var response = _apiClient.SendGetRequest("api/users/2");

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.IsNotEmpty(response.Content);
        }
    }
}
