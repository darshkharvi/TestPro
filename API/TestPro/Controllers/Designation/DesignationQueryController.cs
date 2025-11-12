using DataModels;
using DataServices.DesignationServices.queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TestPro.Controllers.Designation
{
  [ApiController]
  [Route("api/[controller]")]
  public class DesignationQueryController : ControllerBase
  {
    private readonly IMediator _mediator;
    public DesignationQueryController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet("getalldesignations")]
    [ProducesResponseType(typeof(IEnumerable<DesignationModel>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "Designations" })]
    public async Task<IActionResult> GetAllDesignations()
    {
      var designation = await _mediator.Send(new GetAllDesignations { } );

      return Ok(designation);
    }

    [HttpGet("getdesignationbyid/{id}")]
    [ProducesResponseType(typeof(IEnumerable<DesignationModel>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "Designations" })]
    public async Task<IActionResult> GetDesignationById(int id)
    {
      var designation = await _mediator.Send(new GetDesignationById
      {
        Id = id
      });

      return Ok(designation);
    }
  }
}
