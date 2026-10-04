FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

ARG YESHUA_COMMIT_SHA=UNSET

COPY . .

RUN dotnet publish src/Studio/Yeshua.Studio.Fiscal/Yeshua.Studio.Fiscal.csproj -c Release -o /app/publish/migration
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Fiscal.CQRS.Infrastructure.Api/Yeshua.Fiscal.CQRS.Infrastructure.Api.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/api
RUN dotnet publish src/CQRS/Infrastructure/Yeshua.Fiscal.CQRS.Infrastructure.Worker/Yeshua.Fiscal.CQRS.Infrastructure.Worker.csproj -c Release -p:YeshuaCommitSha="$YESHUA_COMMIT_SHA" -o /app/publish/worker

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet-health
WORKDIR /app
RUN apt-get update \
  && apt-get install -y --no-install-recommends ca-certificates curl openssl \
  && mkdir -p /usr/local/share/ca-certificates/icp-brasil \
  && download_cert() { \
       url="$1"; \
       dest="$2"; \
       tmp="/tmp/$(basename "$dest")"; \
       curl -fsSL "$url" -o "$tmp"; \
       if grep -q "BEGIN CERTIFICATE" "$tmp"; then \
         cp "$tmp" "$dest"; \
       else \
         openssl x509 -inform DER -in "$tmp" -out "$dest"; \
       fi; \
       chmod 0644 "$dest"; \
       rm -f "$tmp"; \
     } \
  && download_cert "https://acraiz.icpbrasil.gov.br/credenciadas/RAIZ/ICP-Brasilv10.crt" "/usr/local/share/ca-certificates/icp-brasil/icp-brasil-v10.crt" \
  && download_cert "https://acraiz.icpbrasil.gov.br/credenciadas/SOLUTI/v10/p/AC-SOLUTI-SSL-EV-G4.crt" "/usr/local/share/ca-certificates/icp-brasil/ac-soluti-ssl-ev-g4.crt" \
  && update-ca-certificates \
  && rm -rf /var/lib/apt/lists/*

FROM aspnet-health AS api
COPY --from=publish /app/publish/api .
ENV ASPNETCORE_URLS=http://0.0.0.0:7214
EXPOSE 7214
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7214/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.Fiscal.CQRS.Infrastructure.Api.dll"]

FROM aspnet-health AS worker
COPY --from=publish /app/publish/worker .
ENV ASPNETCORE_URLS=http://0.0.0.0:7215
EXPOSE 7215
HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=5 \
  CMD curl -fsS http://127.0.0.1:7215/yapi/health/live || exit 1
ENTRYPOINT ["dotnet", "Yeshua.Fiscal.CQRS.Infrastructure.Worker.dll"]

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS migration
WORKDIR /app
COPY --from=publish /app/publish/migration .
ENTRYPOINT ["dotnet", "Yeshua.Studio.Fiscal.dll", "--database-only"]
