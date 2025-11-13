 using DataCore;
using DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.DesignationServices.queries
{
    public class GetAllDesignations : IRequest<IEnumerable<DesignationModel>>
    {

    }
    public class GetDesignationHandler : IRequestHandler<GetAllDesignations, IEnumerable<DesignationModel>>
    {
      private readonly ITestProUnitOfWork _context;
      public GetDesignationHandler(ITestProUnitOfWork context)
      {
        _context = context;
      }
      public async Task<IEnumerable<DesignationModel>> Handle(GetAllDesignations request, CancellationToken cancellationToken)
      {
        try
        {
          var query = _context.Repository<DataEntities.Designation>().Get();
          return query.Select(c => new DesignationModel
          {
             Id = c.Id,
             Title = c.Title,
             Description = c.Description,
          }).ToList();
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
  }
