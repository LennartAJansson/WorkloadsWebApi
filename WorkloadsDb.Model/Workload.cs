using System;

namespace WorkloadsDb.Model
{
    public class Workload
    {
        public int Id { get; set; }
        public DateTimeOffset Started { get; set; }
        public DateTimeOffset? Stopped { get; set; }

        //Browsing properties
        public Person Person { get; set; }
        public Assignment Assignment { get; set; }

        //Will be created automatically if not defined here
        public int PersonId { get; set; }
        public int AssignmentId { get; set; }
    }
}
