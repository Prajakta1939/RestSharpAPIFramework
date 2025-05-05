using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using RestSharpApiTests.Models;

namespace RestSharpApiTests.ApiTests
{
    public class UserApiTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://reqres.in/");
        }

        [Test]
        public void CreateUser_ShouldReturn201()
        {
            // Create the user object to send in the request body
            var user = new User
            {
                Name = "Prajakta",
                Job = "Tester"
            };

            // Create a request for POST method with the body
            var request = new RestRequest("api/users", Method.Post);
            request.AddJsonBody(user);

            // Execute the request
            var response = _client.Execute(request);

            // Assert the response status code is 201 (Created)
            Assert.That((int)response.StatusCode, Is.EqualTo(201));

            // Deserialize the response body into a User object, add a null check
            if (response.Content != null)
            {
                var responseBody = JsonConvert.DeserializeObject<User>(response.Content);

                // Assert that the returned name and job match the request data
                Assert.That(responseBody.Name, Is.EqualTo(user.Name));
                Assert.That(responseBody.Job, Is.EqualTo(user.Job));
            }
            else
            {
                Assert.Fail("Response content is null");
            }
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose(); // Dispose the RestClient
        }
    }
}
