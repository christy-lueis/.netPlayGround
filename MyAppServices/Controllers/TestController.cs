using Log.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppServices.Services;
using MydbServices.Interfaces;
using MydbServices.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MyAppServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogging logging;
        private IArea _area = null;
        public TestController(ILogging _logging)
        {
            logging = _logging;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {

            try
            {
                logging.LogToDb("Get", id);
                Rectangle rectangle = new Rectangle()
                {
                    length = 10,
                    breadth = 2
                };
                logging.LogToDb("Geting", id);
                Circle cir = new Circle()
                {
                    radius = 5,
                };
                _area = rectangle;
                var result = _area.Area();
                logging.LogToDb("Request", id);
                TestService testService = new TestService();
                var recipes = testService.Get5Recipies("pizza").GetAwaiter().GetResult();
                logging.LogToDb("Result", id);

                return Ok(recipes);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                logging.SavetoDB();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string st)
        {

            try
            {
                var id = "1";
                var requestBody = "1";
                //using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true))
                //{
                //    requestBody = await reader.ReadToEndAsync();
                //    Console.WriteLine($"Request Body: {requestBody}");
                //    // Reset the stream position so that the model binder can read it
                //    Request.Body.Position = 0;
                //}

                 requestBody = HttpContext.Items["RequestBody"] as string;
                Console.WriteLine($"Request Body: {requestBody}");
                logging.LogToDb("Get", id);
                Rectangle rectangle = new Rectangle()
                {
                    length = 10,
                    breadth = 2
                };
                logging.LogToDb("Geting", id);
                Circle cir = new Circle()
                {
                    radius = 5,
                };
                _area = rectangle;
                var result = _area.Area();
                logging.LogToDb("Request", id);
                TestService testService = new TestService();
                var recipes = testService.Get5Recipies("pizza").GetAwaiter().GetResult();
                logging.LogToDb("Result", id);

                return Ok(recipes);
            }
            catch (Exception)
            {

                return BadRequest(); 
            }
            finally
            {
                logging.SavetoDB();
            }
        }


        [HttpGet("GetGoing")]
        public async Task<IActionResult> GetGoing()
        {

            try
            {
                TestService testService1 = new TestService();
                await testService1.Dogames("games");

               //await  testService1.Dowines("wine");

               //testService1.Docoffee("coffee");
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                logging.SavetoDB();
            }
        }


    }

    public static class RequestExtensions
    {
        public static async Task<string> ReadAsStringAsync(this Stream requestBody, bool leaveOpen = false)
        {
            using StreamReader reader = new(requestBody, leaveOpen: leaveOpen);
            var bodyAsString = await reader.ReadToEndAsync();
            return bodyAsString;
        }
    }

}
