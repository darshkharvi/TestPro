using DataCore;
using DataModels;
using DataServices.DesignationServices.queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.DepartmentServices.queries
{
  public class GetAllDepartments : IRequest<IEnumerable<DepartmentModel>>
  {

  }
  public class GetDepartmentHandler : IRequestHandler<GetAllDepartments, IEnumerable<DepartmentModel>>
  {
    private readonly ITestProUnitOfWork _context;
    public GetDepartmentHandler(ITestProUnitOfWork context)
    {
      _context = context;
    }
    public async Task<IEnumerable<DepartmentModel>> Handle(GetAllDepartments request, CancellationToken cancellationToken)
    {
      try
      {
        var query = _context.Repository<DataEntities.Department>().Get();
        return query.Select(c => new DepartmentModel
        {
          Id = c.Id,
          Title = c.Title,
        }).ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
