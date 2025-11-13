using DataModels;
using DataServices.DepartmentServices.commands;
using DataServices.DesignationServices.commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestPro.Controllers.Designation
{
  [ApiController]
  [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
  public class DesignationCommandController : ControllerBase
  {
    private readonly IMediator _mediator;
    public DesignationCommandController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("adddesignation")]
    [ProducesResponseType(typeof(DesignationModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateNewDepartment([FromBody] DesignationModel department)
    {
      var data = await _mediator.Send(new AddDesignation
      {
        DesignationModel = department
      });
      return Ok(data);
    }

  }
}
