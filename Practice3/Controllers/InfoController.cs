using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Practice3.Controllers
{
[ApiController]
    [Route("/api/info")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public InfoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string GetInfo()
        {
            string projectTitle = _config.GetSection("ProjectTitle").Value;
            string environmentName = _config.GetSection("EnvironmentName").Value;

            string dbConnection = _config.GetConnectionString("Database");

            Console.Out.WriteLine($"Connection String: {dbConnection}");

            return $"Project Title: {projectTitle} \n" +
                $"Environment Name: {environmentName}";
        }
    }
}
