# syntax=docker/dockerfile:1.20.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

ENV DOTNET_PROCESSOR_COUNT=1
COPY Directory.Build.props ./
COPY --parents src/**/*.csproj src/**/Directory.Build.targets ./
RUN --mount=type=cache,id=yeshua-nuget,target=/root/.nuget/packages,sharing=locked \
    dotnet restore src/Studio/Yeshua.Studio.Memorias/Yeshua.Studio.Memorias.csproj --disable-parallel \
    && dotnet restore src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Api/Yeshua.Memorias.CQRS.Infrastructure.Api.csproj --disable-parallel \
    && dotnet restore src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Worker/Yeshua.Memorias.CQRS.Infrastructure.Worker.csproj --disable-parallel

COPY --parents src/Engine/Yeshua.Engine/ src/Studio/Yeshua.Studio.Memorias/ src/CQRS/*/Yeshua.Memorias.CQRS.*/ \
    src/CQRS/Application/Yeshua.CQRS.Application.Command/ src/CQRS/Application/Yeshua.CQRS.Application.RepositoryInterfaces/ \
    src/CQRS/Domain/Yeshua.CQRS.Domain/ src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Shared/ ./

RUN --mount=type=cache,id=yeshua-nuget,target=/root/.nuget/packages,sharing=locked dotnet publish src/Studio/Yeshua.Studio.Memorias/Yeshua.Studio.Memorias.csproj -p:RestoreForce=true -p:RestoreDisableParallel=true -c Release -m:1 -p:UseSharedCompilation=false -o /app/publish/migration
ARG YESHUA_COMMIT_SHA=UNSET
RUN --mount=type=cache,id=yeshua-nuget,target=/root/.nuget/packages,sharing=locked dotnet publish src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Api/Yeshua.Memorias.CQRS.Infrastructure.Api.csproj -p:RestoreForce=true -p:RestoreDisableParallel=true -c Release -m:1 -p:UseSharedCompilation=false -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/api
RUN --mount=type=cache,id=yeshua-nuget,target=/root/.nuget/packages,sharing=locked dotnet publish src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Worker/Yeshua.Memorias.CQRS.Infrastructure.Worker.csproj -p:RestoreForce=true -p:RestoreDisableParallel=true -c Release -m:1 -p:UseSharedCompilation=false -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/worker

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
ENTRYPOINT ["dotnet", "Yeshua.Memorias.CQRS.Infrastructure.Api.dll"]

FROM aspnet-health AS worker
COPY --from=publish /app/publish/worker .
ENV ASPNETCORE_URLS=http://0.0.0.0:7215
EXPOSE 7215
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7215/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.Memorias.CQRS.Infrastructure.Worker.dll"]

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS migration
WORKDIR /app
COPY --from=publish /app/publish/migration .
ENTRYPOINT ["dotnet", "Yeshua.Studio.Memorias.dll", "--database-only"]
