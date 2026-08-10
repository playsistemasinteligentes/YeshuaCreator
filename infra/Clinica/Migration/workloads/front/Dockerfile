# generated: Dominio.Schemas.DeploymentSchema
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Front/Yeshua.Clinica.CQRS.Infrastructure.Front.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Yeshua.Clinica.CQRS.Infrastructure.Front.dll"]