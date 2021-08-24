namespace WorkloadsWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IWorkloadService workloadService;

        public PersonController(ILogger<PersonController> logger, IWorkloadService workloadService)
        {
            this.logger = logger;
            this.workloadService = workloadService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await workloadService.GetAllPeopleAsync();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await workloadService.GetPersonAsync(id);
        }


        // POST api/<PeopleController>
        [HttpPost]
        public async Task<Person> Post([FromBody] Person person)
        {
            return await workloadService.AddPersonAsync(person);
        }
    }
}
