using DataEntities;
using Microsoft.EntityFrameworkCore;

namespace DataCore
{
  public class TestProContext : DbContext
  {
    public TestProContext(DbContextOptions<TestProContext> options) : base(options)
    {

    }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<Department> Departments { get; set; }
  }
}
