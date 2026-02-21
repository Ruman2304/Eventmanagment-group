using EventManagement.Api.Models;

namespace EventManagement.Api.Services;

public interface IRegistrationService
{
    List<Registration> GetRegistrations();
    Registration? GetRegistrationById(Guid id);
    Registration CreateRegistration(Registration input);
}
