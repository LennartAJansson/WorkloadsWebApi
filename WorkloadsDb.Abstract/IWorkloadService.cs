using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WorkloadsDb.Model;

namespace WorkloadsDb.Abstract
{
    public interface IWorkloadService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonAsync(int Id);
        Task<Person> AddPersonAsync(Person person);
        Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment> GetAssignmentAsync(int Id);
        Task<Assignment> AddAssignmentAsync(Assignment assignment);

        Task<IEnumerable<Workload>> GetAllWorkloadsAsync();
        Task<Workload> GetWorkloadAsync(int Id);
        Task<Workload> AddWorkloadAsync(Workload workload);
        Task UpdateWorkload(int id, DateTimeOffset stopped);
        //Task<IEnumerable<Person>> GetPeopleByLastname(string lastname);
        //Task<IEnumerable<Person>> GetPeopleByFirstname(string firstname);
    }
}
