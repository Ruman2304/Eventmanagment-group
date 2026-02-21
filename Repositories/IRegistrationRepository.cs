using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public interface IRegistrationRepository
{
    List<Registration> GetRegistrations();
    Registration? GetRegistrationById(Guid id);
    Registration CreateRegistration(Registration input);
}
