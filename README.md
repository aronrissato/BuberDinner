dotnet new sln -o BuberDinner 
dotnet new webapi -o BoberDinner.Api

dotnet new classlib -o BuberDinner.Contracts
dotnet new classlib -o BuberDinner.Infrastructure
dotnet new classlib -o BuberDinner.Application
dotnet new classlib -o BuberDinner.Domain

dotnet sln add .\BoberDinner.Api\BoberDinner.Api.csproj
dotnet sln add .\BuberDinner.Application\BuberDinner.Application.csproj
dotnet sln add .\BuberDinner.Contracts\BuberDinner.Contracts.csproj
dotnet sln add .\BuberDinner.Domain\BuberDinner.Domain.csproj
dotnet sln add .\BuberDinner.Infrastructure\BuberDinner.Infrastructure.csproj

dotnet build