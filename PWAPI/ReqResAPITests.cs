using Microsoft.Playwright;
using System.Text.Json;

namespace PWAPI
{
    public class ReqResAPITests
    {
        IAPIRequestContext requestContext;
        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://reqres.in/api/",
                    IgnoreHTTPSErrors = true,
                });
        }

        [Test]
        [TestCase(2)]
        public async Task GetAllUsers(int pno)
        {
            var getresponse = await requestContext.GetAsync(url: "users?page=" + pno);
            
            await Console.Out.WriteLineAsync("Res : \n " + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + getresponse.StatusText);

           

            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body : \n " + responseBody.ToString());
        }
        [Test]
        [TestCase(2)]
        public async Task GetSingleUser(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "users/" + uid);

            await Console.Out.WriteLineAsync("Res : \n " + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + getresponse.StatusText);



            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body : \n " + responseBody.ToString());
        }
        //parametization for get, post, put and delete
        [Test]
        [TestCase(22)]
        public async Task GetSingleUserNotFound(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "users/" + uid);

            await Console.Out.WriteLineAsync("Res : \n " + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + getresponse.StatusText);



            Assert.That(getresponse.Status.Equals(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body : \n " + responseBody.ToString());
            Assert.That(responseBody.ToString(), Is.EqualTo("{}"));


        }
        [Test]
        [TestCase("John", "Eng")]
        public async Task PostUser(string nm, string jb)
        {
            var postData = new
            {
                name = "John",
                job = "Engineer"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var postresponse = await requestContext.PostAsync(url: "users",
                new APIRequestContextOptions
                {
                    Data = jsonData
                });

            await Console.Out.WriteLineAsync("Res : \n " + postresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + postresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + postresponse.StatusText);



            Assert.That(postresponse.Status.Equals(201));
            Assert.That(postresponse, Is.Not.Null);

           


        }
        [Test]
        [TestCase(2, "John", "Eng")]
        public async Task PutUser(int uid, string nm, string jb)
        {
            var postData = new
            {
                name = nm,
                job = jb
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var postresponse = await requestContext.PutAsync(url: "users/" + uid,
                new APIRequestContextOptions
                {
                    Data = jsonData
                });

            await Console.Out.WriteLineAsync("Res : \n " + postresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + postresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + postresponse.StatusText);



            Assert.That(postresponse.Status.Equals(200));
            Assert.That(postresponse, Is.Not.Null);




        }
        [Test]
        [TestCase(2)]
        public async Task DeleteUser(int uid)
        {


            var postresponse = await requestContext.DeleteAsync(url: "users/" + uid);
                

            await Console.Out.WriteLineAsync("Res : \n " + postresponse.ToString());
            await Console.Out.WriteLineAsync("Code : \n " + postresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n " + postresponse.StatusText);



            Assert.That(postresponse.Status.Equals(204));
            Assert.That(postresponse, Is.Not.Null);
        }




        
    }
}