// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkloadsWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class WorkloadsController : ControllerBase
    {
        private readonly ILogger<WorkloadsController> logger;
        private readonly IWorkloadService workloadService;

        public WorkloadsController(ILogger<WorkloadsController> logger, IWorkloadService workloadService)
        {
            this.logger = logger;
            this.workloadService = workloadService;
        }

        // GET: api/<WorkloadsController>
        [HttpGet]
        public async Task<IEnumerable<Workload>> Get()
        {
            return await workloadService.GetAllWorkloadsAsync();
        }

        // GET api/<WorkloadsController>/5
        [HttpGet("{id}")]
        public async Task<Workload> Get(int id)
        {
            return await workloadService.GetWorkloadAsync(id);
        }

        // POST api/<WorkloadsController>
        [HttpPost]
        public async Task<Workload> Post([FromBody] Workload workload)
        {
            return await workloadService.AddWorkloadAsync(workload);
        }

        // PUT api/<WorkloadsController>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DateTimeOffset stopped)
        {
            workloadService.UpdateWorkload(id, stopped);
        }
    }
}
