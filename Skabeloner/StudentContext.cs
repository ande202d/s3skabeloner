using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rest
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
