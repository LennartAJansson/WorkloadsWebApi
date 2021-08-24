using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WorkloadsDb.Abstract;
using WorkloadsDb.Model;

namespace WorkloadsDb.Core
{
    public class WorkloadService : IWorkloadService
    {
        private readonly ILogger<WorkloadService> logger;
        private readonly IUnitOfWork unitOfWork;

        public WorkloadService(ILogger<WorkloadService> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Assignment> AddAssignmentAsync(Assignment assignment)
        {
            await unitOfWork.Repository<Assignment>().InsertAsync(assignment);
            await unitOfWork.SaveChangesAsync();
            return assignment;
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            await unitOfWork.Repository<Person>().InsertAsync(person);
            await unitOfWork.SaveChangesAsync();
            return person;
        }

        public async Task<Workload> AddWorkloadAsync(Workload workload)
        {
            await unitOfWork.Repository<Workload>().InsertAsync(workload);
            await unitOfWork.SaveChangesAsync();
            return workload;
        }

        public Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            var assignments = unitOfWork.Repository<Assignment>().Get(includeProperties: "Workloads,Workloads.Person");
            //var assignments = unitOfWork.Repository<Assignment>().Get(includeProperties: "Workloads");
            return Task.FromResult(assignments);
        }

        public Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            var people = unitOfWork.Repository<Person>().Get(includeProperties: "Workloads,Workloads.Assignment");
            //var people = unitOfWork.Repository<Person>().Get(includeProperties: "Workloads");
            return Task.FromResult(people);
        }

        public Task<IEnumerable<Workload>> GetAllWorkloadsAsync()
        {
            var workloads = unitOfWork.Repository<Workload>().Get(includeProperties: "Person,Assignment");
            return Task.FromResult(workloads);
        }

        public Task<Assignment> GetAssignmentAsync(int Id)
        {
            var assignment = unitOfWork.Repository<Assignment>().Get(filter: a => a.Id == Id, includeProperties: "Workloads,Workloads.Person").FirstOrDefault();
            //var assignment = unitOfWork.Repository<Assignment>().Get(filter: a => a.Id == Id, includeProperties: "Workloads").FirstOrDefault();
            return Task.FromResult(assignment);
        }

        public Task<Person> GetPersonAsync(int Id)
        {
            var person = unitOfWork.Repository<Person>().Get(filter: p => p.Id == Id, includeProperties: "Workloads,Workloads.Assignment").FirstOrDefault();
            //var person = unitOfWork.Repository<Person>().Get(filter: p => p.Id == Id, includeProperties: "Workloads").FirstOrDefault();
            return Task.FromResult(person);
        }

        public Task<Workload> GetWorkloadAsync(int Id)
        {
            var workload = unitOfWork.Repository<Workload>().Get(filter: a => a.Id == Id, includeProperties: "Person,Assignment").FirstOrDefault();
            return Task.FromResult(workload);
        }

        public Task UpdateWorkload(int id, DateTimeOffset stopped)
        {
            //unitOfWork.Repository<Workload>().Update(workload);
            var workload = unitOfWork.Repository<Workload>().GetById(id);
            workload.Stopped = stopped;
            unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
