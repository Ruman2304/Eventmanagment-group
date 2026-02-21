using EventManagement.Api.Models;
using System.Linq;

namespace EventManagement.Api.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly List<Registration> _registrations = new();

        public List<Registration> GetRegistrations()
        {
            return _registrations;
        }

        public Registration? GetRegistrationById(Guid id)
        {
            return _registrations.FirstOrDefault(r => r.Id == id);
        }

        public Registration CreateRegistration(Registration input)
        {
            var reg = new Registration
            {
                Id = input.Id == Guid.Empty ? Guid.NewGuid() : input.Id,
                EventId = input.EventId,
                UserId = input.UserId,
                RegisteredAt = input.RegisteredAt == default ? DateTime.UtcNow : input.RegisteredAt,
                Status = string.IsNullOrWhiteSpace(input.Status) ? "Registered" : input.Status
            };

            _registrations.Add(reg);
            return reg;
        }
    }
}
