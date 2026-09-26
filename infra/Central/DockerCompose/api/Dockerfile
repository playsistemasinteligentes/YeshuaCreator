FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

ARG YESHUA_COMMIT_SHA=UNSET
ARG YESHUA_BUILD_TIMESTAMP_UTC=UNSET

COPY . .
RUN dotnet publish \
  src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Yeshua.Central.CQRS.Infrastructure.Api.csproj \
  -c Release \
  -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" \
  -p:YeshuaBuildTimestampUtc="$YESHUA_BUILD_TIMESTAMP_UTC" \
  -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

RUN apt-get update \
  && apt-get install -y --no-install-recommends curl \
  && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:7214
EXPOSE 7214

HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7214/yapi/health/live || exit 1

ENTRYPOINT ["dotnet", "Yeshua.Central.CQRS.Infrastructure.Api.dll"]
