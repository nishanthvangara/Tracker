using System.Data.Common;

namespace Tracker
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyContext : DbContext
    {
        public MyContext() : base("name=DatabaseContext")
        {
        }
        public virtual DbSet<Candidate> Candidates { get; set; }

        public virtual DbSet<Consultancy> Consultancies { get; set; }
    }
}