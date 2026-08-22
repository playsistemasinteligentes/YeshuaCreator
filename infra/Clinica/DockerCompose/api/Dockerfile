# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

ARG YESHUA_COMMIT_SHA=UNSET
ARG YESHUA_BUILD_TIMESTAMP_UTC=UNSET

# Copia todo o repositório
COPY . .

# Publica APENAS a API (explícito)
RUN dotnet publish \
  src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Yeshua.Clinica.CQRS.Infrastructure.Api.csproj \
  -c Release \
  -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" \
  -p:YeshuaBuildTimestampUtc="$YESHUA_BUILD_TIMESTAMP_UTC" \
  -o /app/publish


# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:7214
EXPOSE 7214

ENTRYPOINT ["dotnet", "Yeshua.Clinica.CQRS.Infrastructure.Api.dll"]
