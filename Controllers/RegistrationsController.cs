using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/registrations")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Registration>> GetRegistrations()
    {
        var regs = _registrationService.GetRegistrations();
        return Ok(regs);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Registration> GetRegistrationById(Guid id)
    {
        var reg = _registrationService.GetRegistrationById(id);
        if (reg is null)
            return NotFound();
        return Ok(reg);
    }

    [HttpPost]
    public ActionResult<Registration> CreateRegistration([FromBody] Registration input)
    {
        if (input.EventId == Guid.Empty || input.UserId == Guid.Empty)
            return BadRequest("EventId and UserId are required.");

        var created = _registrationService.CreateRegistration(input);
        return CreatedAtAction(nameof(GetRegistrationById), new { id = created.Id }, created);
    }
}
