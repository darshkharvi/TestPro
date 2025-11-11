using Microsoft.EntityFrameworkCore;

namespace DataCore
{
  public class TestProContext : DbContext
  {
    public TestProContext(DbContextOptions<TestProContext> options) : base(options)
    {

    }
  }
}
