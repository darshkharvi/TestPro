using DataCore;
using DataEntities;
using DataModels;
using DataServices.DesignationServices.commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.DepartmentServices.commands
{
  public class Adddepartment : IRequest<DepartmentModel>
  {
    public DepartmentModel DepartmentModel;
  }
  public class AdddepartmentHandler : IRequestHandler<Adddepartment, DepartmentModel>
  {
    private readonly ITestProUnitOfWork _context;

    public AdddepartmentHandler(ITestProUnitOfWork context)
    {
      _context = context;
    }
    public async Task<DepartmentModel> Handle(Adddepartment request, CancellationToken cancellationToken)
    {
      try
      {
        if (request.DepartmentModel.Id > 0)
        {
          var existingDesignation = await _context.Repository<DataEntities.Designation>()
              .Get()
              .Where(d => d.Id == request.DepartmentModel.Id)
              .FirstOrDefaultAsync(cancellationToken);
          if (existingDesignation != null)
          {
            existingDesignation.Title = request.DepartmentModel.Title;
            existingDesignation.UpdatedDate = DateTime.Now;
            await _context.SaveAsync(cancellationToken);
          }
          else
          {
            throw new Exception($"Department with ID {request.DepartmentModel.Id} not found.");
          }
        }
        else
        {
          var department = new DataEntities.Department
          {
            Id = request.DepartmentModel.Id,
            Title = request.DepartmentModel.Title,
            CreatedDate = DateTime.Now
          };

          var addeddepartment = _context.Repository<DataEntities.Department>().Add(department);
          if (addeddepartment is DataEntities.Department DepartmentEntity)
          {
            await _context.SaveAsync();
            request.DepartmentModel.Id = DepartmentEntity.Id;

          }
          else
          {
            throw new InvalidCastException("Unable to cast added department to department");
          }
        }
        return request.DepartmentModel;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message, ex);
      }
    }
  }
}
