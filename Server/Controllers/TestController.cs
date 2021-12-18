using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public TestController(ApplicationDBContext context)
        {
            this.context = context;
        }
        
        [HttpGet("{Id}")]
        public async Task<ActionResult<TestEntity>> Get(int Id)
        {
            var userInfo = await context.TestEntities.FirstOrDefaultAsync(x => x.Id == Id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestEntity>>> Get()
        {
            return await context.TestEntities.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TestEntity testEntity)
        {
            context.Add(testEntity);
            await context.SaveChangesAsync();
            return testEntity.Id;
        }
    }
}
