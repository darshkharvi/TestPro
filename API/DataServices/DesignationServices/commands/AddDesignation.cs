using DataCore;
using DataModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataServices.DesignationServices.commands
{
  public class AddDesignation : IRequest<DesignationModel>
  {
    public DesignationModel DesignationModel { get; set; }
  }
  public class AddDesignationHandler : IRequestHandler<AddDesignation, DesignationModel>
  {
    private readonly ITestProUnitOfWork _context;
    public AddDesignationHandler(ITestProUnitOfWork context)
    {
      _context = context;
    }
    public async Task<DesignationModel> Handle(AddDesignation request, CancellationToken cancellationToken)
    {
      try
      {
        if (request.DesignationModel.Id > 0)
        {
          var existingDesignation = await _context.Repository<DataEntities.Designation>()
              .Get()
              .Where(d => d.Id == request.DesignationModel.Id)
              .FirstOrDefaultAsync(cancellationToken);
          if (existingDesignation != null)
          {
            existingDesignation.Title = request.DesignationModel.Title;
            existingDesignation.Description = request.DesignationModel.Description;
            existingDesignation.UpdatedDate = DateTime.Now;
            await _context.SaveAsync(cancellationToken);
          }
          else
          {
            throw new Exception($"Designation with ID {request.DesignationModel.Id} not found.");
          }
        }
        else
        {
          var designation = new DataEntities.Designation
          {
            Id = request.DesignationModel.Id,
            Title = request.DesignationModel.Title,
            Description = request.DesignationModel.Description,
            CreatedDate = DateTime.Now
          };
          var addedDesignation = _context.Repository<DataEntities.Designation>().Add(designation);
          if (addedDesignation is DataEntities.Designation designationEntity)
          {
            await _context.SaveAsync();
            request.DesignationModel.Id = designationEntity.Id;

          }
          else
          {
            throw new InvalidCastException("Unable to cast added department to department");
          }
        }
        return request.DesignationModel;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message, ex);
      }
    }
  }
}
