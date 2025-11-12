using DataModels;
using DataServices.DepartmentServices.queries;
using DataServices.DesignationServices.queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TestPro.Controllers.Department
{
  public class DepartmentQueryController : ControllerBase
  {
    private readonly IMediator _mediator;
    public DepartmentQueryController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("getalldepartment")]
    [ProducesResponseType(typeof(IEnumerable<DepartmentModel>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "Department" })]
    public async Task<IActionResult> GetAllDepartment()
    {
      var department = await _mediator.Send(new GetAllDepartments { });

      return Ok(department);
    }

    [HttpGet("getDepartmentbyid/{id}")]
    [ProducesResponseType(typeof(IEnumerable<DepartmentModel>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "Department" })]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
      var designation = await _mediator.Send(new GetDepartmentById
      {
        Id = id
      });

      return Ok(designation);

    }
  }
}
