// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkloadsWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ILogger<AssignmentsController> logger;
        private readonly IWorkloadService workloadService;

        public AssignmentsController(ILogger<AssignmentsController> logger, IWorkloadService workloadService)
        {
            this.logger = logger;
            this.workloadService = workloadService;
        }

        // GET: api/<AssignmentsController>
        [HttpGet]
        public async Task<IEnumerable<Assignment>> Get()
        {
            return await workloadService.GetAllAssignmentsAsync();
        }

        // GET api/<AssignmentsController>/5
        [HttpGet("{id}")]
        public async Task<Assignment> Get(int id)
        {
            return await workloadService.GetAssignmentAsync(id);
        }

        // POST api/<AssignmentsController>
        [HttpPost]
        public async Task<Assignment> Post([FromBody] Assignment assignment)
        {
            return await workloadService.AddAssignmentAsync(assignment);
        }
    }
}
