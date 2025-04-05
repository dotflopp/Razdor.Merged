FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /Razdor.Backend

COPY . .
RUN dotnet restore

#Miqrations
RUN dotnet tool install --global dotnet-ef
RUN dotnet ef migrations add --project ./Source/Razdor.Kernel/Razdor.DataAccess.Sqlite/Razdor.DataAccess.EntityFramework.csproj --startup-project ./Source/Razdor.StartApp/Razdor.StartApp.csproj --context Razdor.DataAccess.EntityFramework.RazdorDataContext --configuration Debug Initial --output-dir Migrations
RUN dotnet ef database update --project ./Source/Razdor.Kernel/Razdor.DataAccess.Sqlite/Razdor.DataAccess.EntityFramework.csproj --startup-project ./Source/Razdor.StartApp/Razdor.StartApp.csproj --context Razdor.DataAccess.EntityFramework.RazdorDataContext --configuration Debug 20250405121523_Initial

WORKDIR /Razdor.Backend/Source/Razdor.StartApp

RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "Razdor.StartApp.dll"]