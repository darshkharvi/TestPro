using DataModels;
using DataServices.DepartmentServices.commands;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestPro.Controllers.Department
{
  [ApiController]
  [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
  public class DepartmentCommandController : ControllerBase
  {
    private readonly IMediator _mediator;
    public DepartmentCommandController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("adddepartment")]
    [ProducesResponseType(typeof(DepartmentModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateNewDepartment([FromBody] DepartmentModel department)
    {
      var data = await _mediator.Send(new Adddepartment
      {
        DepartmentModel = department
      });
      return Ok(data);
    }

  }
}
