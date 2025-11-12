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
  public class GetDesignationById : IRequest<DesignationModel>
  {
    public int Id { get; set; }
  }
  public class GetDesignationByIdHandler : IRequestHandler<GetDesignationById, DesignationModel>
  {
    private readonly ITestProUnitOfWork _context;
    public GetDesignationByIdHandler(ITestProUnitOfWork context)
    {
      _context = context;
    }
    public async Task<DesignationModel> Handle(GetDesignationById request, CancellationToken cancellationToken)
    {
      try
      {
        var data = _context.Repository<DataEntities.Designation>()
            .Get()
            .Where(c => c.Id == request.Id)
            .FirstOrDefault();

        if (data != null)
        {
          return new DesignationModel
          {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
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
