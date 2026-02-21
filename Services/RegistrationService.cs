using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _registrationRepository;

    public RegistrationService(IRegistrationRepository registrationRepository)
    {
        _registrationRepository = registrationRepository;
    }

    public List<Registration> GetRegistrations()
    {
        return _registrationRepository.GetRegistrations();
    }

    public Registration? GetRegistrationById(Guid id)
    {
        return _registrationRepository.GetRegistrationById(id);
    }

    public Registration CreateRegistration(Registration input)
    {
        return _registrationRepository.CreateRegistration(input);
    }
}
