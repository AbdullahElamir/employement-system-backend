using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebServerAPI.Models;

namespace WebServerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}

