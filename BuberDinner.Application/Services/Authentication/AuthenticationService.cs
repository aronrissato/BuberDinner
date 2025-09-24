using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Entities;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtGen;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtGen, IUserRepository userRepository)
    {
        _jwtGen = jwtGen;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new[]
            {
                new DuplicateEmailError()
            });
        }

        // Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtGen.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user does not exist
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("Email does not exist");

        // Validate the password is correctly
        if (user.Password != password)
            throw new Exception("Password does not match");

        // Create JWT token
        var token = _jwtGen.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}