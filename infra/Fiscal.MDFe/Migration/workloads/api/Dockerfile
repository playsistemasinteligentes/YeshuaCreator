# generated: Dominio.Schemas.DeploymentSchema
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.dll"]