using DataModels;
using MediatR;
using DataCore;

namespace DataServices.DepartmentServices.queries
{
  public class GetDepartmentById : IRequest<DepartmentModel>
  {
    public int Id { get; set; }
  }
  public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentById, DepartmentModel>
  {
    private readonly ITestProUnitOfWork _context;
    public GetDepartmentByIdHandler(ITestProUnitOfWork context)
    {
      _context = context;
    }
    public async Task<DepartmentModel> Handle(GetDepartmentById request, CancellationToken cancellationToken)
    {
      try
      {
        var data = _context.Repository<DataEntities.Department>()
            .Get()
            .Where(c => c.Id == request.Id)
            .FirstOrDefault();

        if (data != null)
        {
          return new DepartmentModel
          {
            Id = data.Id,
            Title = data.Title,
          };
        }
        return null;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
