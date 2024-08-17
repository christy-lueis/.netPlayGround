using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace middleware.Services
{
    public class AppservicesMiddleware : RequestCultureMiddleware
    {
        private readonly RequestDelegate _appnext;
        public AppservicesMiddleware(RequestDelegate next) : base(next)
        {
            _appnext = next;
        }

        public override async Task InvokeAsync(HttpContext context)
        {


            // string requestBody = string.Empty;

            //context.Request.EnableBuffering();


            //if (Convert.ToString(requestBody).Contains("age"))
            //{
            //    string jsonString = Convert.ToString(requestBody);
            //    string key = "\"age\"";
            //    int startIndex = jsonString.IndexOf(key) + key.Length;

            //    // Find the position of the colon and the comma
            //    int colonIndex = jsonString.IndexOf(':', startIndex) + 1;
            //    int commaIndex = jsonString.IndexOf(',', colonIndex);

            //    // Extract the value of age
            //    string ageString = jsonString.Substring(colonIndex, commaIndex - colonIndex).Trim();
            //    int age = int.Parse(ageString);

            //    Console.WriteLine($"Age: {age}");
            //}
            //await _appnext(context);

            //request.Body.Position = 0;  //rewinding the stream to 0 again
            //var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            //await request.Body.ReadAsync(buffer, 0, buffer.Length);
            //var requestContentAfterNext = Encoding.UTF8.GetString(buffer);

            //var statusCode = context.Response.StatusCode;


            var request = context.Request;
            if (request.Method == HttpMethods.Post && request.ContentLength > 0)
            {
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var requestContent = Encoding.UTF8.GetString(buffer);

                request.Body.Position = 0;  //rewinding the stream to 0
            }

            await _appnext(context);

            // Reading the request body again after the next middleware
            if (request.Method == HttpMethods.Post && request.ContentLength > 0)
            {
                request.Body.Position = 0;  //rewinding the stream to 0 again
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var requestContentAfterNext = Encoding.UTF8.GetString(buffer);

                if (Convert.ToString(requestContentAfterNext).Contains("price"))
                {
                    string jsonString = Convert.ToString(requestContentAfterNext);
                    string key = "\"price\"";
                    int startIndex = jsonString.IndexOf(key) + key.Length;

                    // Find the position of the colon and the comma
                    int colonIndex = jsonString.IndexOf(':', startIndex) + 1;
                    int commaIndex = jsonString.IndexOf(',', colonIndex);

                    // Extract the value of age
                    string ageString = jsonString.Substring(colonIndex, commaIndex - colonIndex).Trim();
                    int age = int.Parse(ageString);

                    Console.WriteLine($"Age: {age}");
                }
            }

        }
    }
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AppservicesMiddleware>();
        }
    }
}
