From mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WorkDir /app

Copy  *csproj ./
Run dotnet restore

Copy . ./
Run dotnet publish -c Release -o out

From mcr.microsoft.com/dotnet/core/sdk:3.0
WorkDir /app

Copy --from=build-env /app/out .
EntryPoint ["dotnet", "myweb.dll"]
