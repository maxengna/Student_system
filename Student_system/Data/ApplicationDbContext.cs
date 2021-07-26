using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_system.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_system.Data
{
    
    
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student_info> student_Infos { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
