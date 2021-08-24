using System.Collections.Generic;

namespace WorkloadsDb.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }

        //Browsing property
        public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
    }
}
