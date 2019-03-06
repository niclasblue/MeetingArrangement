using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingArrangement
{
    class LeadersContext : DbContext
    {
        public DbSet<Leader> Leaders { get; set; }
    }
}
