using Microsoft.EntityFrameworkCore;
using SubpagesMVCArchitecture.Models;

namespace SubpagesMVCArchitecture.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<SubpagesMVCArchitecture.Models.employeeMasters> employeeMasters { get; set; } = default!;
        public DbSet<SubpagesMVCArchitecture.Models.departmentMaster> departmentMaster { get; set; } = default!;
      
    }
}
