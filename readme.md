What does the dotnet nuget list source command returns? If it's empty, it might be an issue with your NuGet sources.

You can try dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org to fix if it's empty.

dotnet new sln
dotnet new webapi -n API -controllers
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classlib -n Persistence

dotnet sln add API
dotnet sln add Domain
dotnet sln add Application
dotnet sln add Persistence

In Solution Explorer
API -> right click -> Add Project Reference to Application
Application -> Add Domain and Persistence
Persistence -> Add Domain

dotnet watch

NUGET on bottom tab
Install Microsoft.EntityFramework.Sqlite to Persistence (Make sure version matches)
Install Microsoft.EntityFramework.Design to API (Make sure version matches)

Migrations
https://www.nuget.org/packages/dotnet-ef
### Create migrations
dotnet ef migrations add InitialCreate -p Persistence -s API
### Create the db, or update it
dotnet ef database update -p Persistence -s API
### Drop the db
dotnet ef database drop -p Persistence -s API

Source Control
git branch -M main