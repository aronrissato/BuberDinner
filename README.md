dotnet new sln -o BuberDinner 
dotnet new webapi -o BuberDinner.Api

dotnet new classlib -o BuberDinner.Contracts
dotnet new classlib -o BuberDinner.Infrastructure
dotnet new classlib -o BuberDinner.Application
dotnet new classlib -o BuberDinner.Domain

dotnet sln add .\BuberDinner.Api\BuberDinner.Api.csproj
dotnet sln add .\BuberDinner.Application\BuberDinner.Application.csproj
dotnet sln add .\BuberDinner.Contracts\BuberDinner.Contracts.csproj
dotnet sln add .\BuberDinner.Domain\BuberDinner.Domain.csproj
dotnet sln add .\BuberDinner.Infrastructure\BuberDinner.Infrastructure.csproj

dotnet build

git init
git add . 
git commit -m "Starting..."
git remote add origin https://github.com/aronrissato/BuberDinner
git push -u origin main
git push -u origin master
git add .gitignore
git commit -m "Add .gitignore"
git rm -r --cached bin obj 
git commit -m "Remove bin and obj from tracking"

dotnet add BuberDinner.Api reference BuberDinner.Contracts BuberDinner.Application
dotnet add BuberDinner.Infrastructure reference BuberDinner.Application
dotnet add BuberDinner.Application reference BuberDinner.Domain
dotnet add BuberDinner.Api reference BuberDinner.Infrastructure