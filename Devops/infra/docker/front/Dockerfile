# =========================
# STAGE 1 - BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os projetos primeiro (cache de restore)
COPY APPInfraEstructure/Shered/Shered.csproj APPInfraEstructure/Shered/
COPY APPInfraEstructure/Front/Front.csproj APPInfraEstructure/Front/

RUN dotnet restore APPInfraEstructure/Front/Front.csproj

# Copia todo o repositório
COPY . .

# Publish do Front
RUN dotnet publish APPInfraEstructure/Front/Front.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# =========================
# STAGE 2 - RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Front.dll"]
