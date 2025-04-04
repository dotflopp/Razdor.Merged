FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /Razdor.Backend

COPY . .
RUN dotnet restore


WORKDIR /Razdor.Backend/Source/Razdor.StartApp
RUN dotnet publish -c release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "Razdor.StartApp.dll"]