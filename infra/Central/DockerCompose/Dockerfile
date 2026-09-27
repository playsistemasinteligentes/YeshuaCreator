FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

ARG YESHUA_COMMIT_SHA=UNSET

COPY . .

RUN dotnet publish src/Studio/Yeshua.Studio.Central/Yeshua.Studio.Central.csproj -c Release -o /app/publish/migration
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Yeshua.Central.CQRS.Infrastructure.Api.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/api
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Worker/Yeshua.Central.CQRS.Infrastructure.Worker.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/worker
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/Yeshua.Central.CQRS.Infrastructure.Front.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/front

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
ENTRYPOINT ["dotnet", "Yeshua.Central.CQRS.Infrastructure.Api.dll"]

FROM aspnet-health AS worker
COPY --from=publish /app/publish/worker .
ENV ASPNETCORE_URLS=http://0.0.0.0:7215
EXPOSE 7215
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7215/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.Central.CQRS.Infrastructure.Worker.dll"]

FROM aspnet-health AS front
COPY --from=publish /app/publish/front .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:8080/ || exit 1
ENTRYPOINT ["dotnet", "Yeshua.Central.CQRS.Infrastructure.Front.dll"]

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS migration
WORKDIR /app
COPY --from=publish /app/publish/migration .
ENTRYPOINT ["dotnet", "Yeshua.Studio.Central.dll", "--database-only"]
