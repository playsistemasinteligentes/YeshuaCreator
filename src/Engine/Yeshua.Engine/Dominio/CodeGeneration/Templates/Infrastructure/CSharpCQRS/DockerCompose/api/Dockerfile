# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o repositório
COPY . .

# Publica APENAS a API (explícito)
RUN dotnet publish \
  {{API_PROJECT_PATH}} \
  -c Release \
  -o /app/publish


# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY infra/Shared/Certificates/icp-brasil/*.crt /usr/local/share/ca-certificates/icp-brasil/
RUN set -eu; \
  apt-get update \
  && apt-get install -y --no-install-recommends ca-certificates curl \
  && update-ca-certificates \
  && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:7214
EXPOSE 7214

ENTRYPOINT ["dotnet", "{{API_ASSEMBLY}}"]
