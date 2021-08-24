using System.Collections.Generic;

namespace WorkloadsDb.Model
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }

        //Browsing property
        public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
    }
}
