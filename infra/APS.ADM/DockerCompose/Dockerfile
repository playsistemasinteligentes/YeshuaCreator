FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

ARG YESHUA_COMMIT_SHA=UNSET

COPY . .

RUN dotnet publish src/Studio/Yeshua.Studio.APS.ADM/Yeshua.Studio.APS.ADM.csproj -c Release -o /app/publish/migration
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.APS.ADM.CQRS.Infrastructure.Api/Yeshua.APS.ADM.CQRS.Infrastructure.Api.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/api
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.APS.ADM.CQRS.Infrastructure.Worker/Yeshua.APS.ADM.CQRS.Infrastructure.Worker.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/worker

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet-health
WORKDIR /app
RUN apt-get update \
  && apt-get install -y --no-install-recommends curl \
  && rm -rf /var/lib/apt/lists/*

FROM aspnet-health AS api
COPY --from=publish /app/publish/api .
ENV ASPNETCORE_URLS=http://0.0.0.0:7214
EXPOSE 7214
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7214/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.APS.ADM.CQRS.Infrastructure.Api.dll"]

FROM aspnet-health AS worker
COPY --from=publish /app/publish/worker .
ENV ASPNETCORE_URLS=http://0.0.0.0:7215
EXPOSE 7215
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7215/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.APS.ADM.CQRS.Infrastructure.Worker.dll"]

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS migration
WORKDIR /app
COPY --from=publish /app/publish/migration .
ENTRYPOINT ["dotnet", "Yeshua.Studio.APS.ADM.dll", "--database-only"]
