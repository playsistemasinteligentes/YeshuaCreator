# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o repositório (context já é a raiz)
COPY . .

# Publica o Front
RUN dotnet publish \
  YeshuaCreator/APPInfraEstructure/Front/Front.csproj \
  -c Release \
  -o /app/publish \
  --no-restore

# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Front.dll"]
