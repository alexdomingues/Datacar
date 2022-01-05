using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpPost("save")]
        public async Task Save(Datacar.Shared.Log log)
        {
            Console.WriteLine($"({log.Level}): {log.Data}");
        }
    }
}
