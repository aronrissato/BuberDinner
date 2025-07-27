namespace BuberDinner.Application.Services.Authentication.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}