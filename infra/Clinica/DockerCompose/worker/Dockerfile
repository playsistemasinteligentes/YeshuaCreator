# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o repositório
COPY . .

# Publica APENAS a API (explícito)
RUN dotnet publish \
  src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Yeshua.Clinica.CQRS.Infrastructure.Worker.csproj \
  -c Release \
  -o /app/publish

# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:7215
EXPOSE 7215

ENTRYPOINT ["dotnet", "Yeshua.Clinica.CQRS.Infrastructure.Worker.dll"]
