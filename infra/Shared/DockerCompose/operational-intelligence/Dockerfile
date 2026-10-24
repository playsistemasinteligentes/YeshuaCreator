FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/ src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/
RUN dotnet publish src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Yeshua.OperationalIntelligence.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG NODE_MAJOR=22
ARG TUNNEL_CLIENT_VERSION=v0.0.18

ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        curl \
        dnsutils \
        git \
        iputils-ping \
        jq \
        openssh-client \
        procps \
        python3 \
        python3-pip \
        ripgrep \
        rsync \
        unzip \
        zip \
    && curl -fsSL "https://deb.nodesource.com/setup_${NODE_MAJOR}.x" | bash - \
    && apt-get install -y --no-install-recommends nodejs \
    && rm -rf /var/lib/apt/lists/*

RUN archive="tunnel-client-${TUNNEL_CLIENT_VERSION}-linux-$(dpkg --print-architecture).zip" \
    && release="https://github.com/openai/tunnel-client/releases/download/${TUNNEL_CLIENT_VERSION}" \
    && curl -fsSL "$release/$archive" -o "/tmp/$archive" \
    && curl -fsSL "$release/SHA256SUMS.txt" -o /tmp/tunnel-checksums \
    && cd /tmp \
    && grep -F "$archive" tunnel-checksums | sha256sum -c - \
    && mkdir -p /opt/yeshua-mcp-tunnel \
    && unzip -q "$archive" -d /opt/yeshua-mcp-tunnel \
    && chmod +x /opt/yeshua-mcp-tunnel/tunnel-client /opt/yeshua-mcp-tunnel/cloudflared \
    && rm -f "/tmp/$archive" /tmp/tunnel-checksums

RUN useradd --create-home --shell /bin/bash agent \
    && mkdir -p /workspace /app/agent \
    && chown -R agent:agent /workspace /app

COPY --from=build --chown=agent:agent /app/publish /app/
COPY --chown=agent:agent infra/Shared/DockerCompose/operational-intelligence/agent/ /app/agent/

USER agent
WORKDIR /app

ENV HOME=/home/agent \
    NPM_CONFIG_PREFIX=/home/agent/.npm-global \
    CODEX_HOME=/home/agent/.codex \
    CODEX_INSTALL_DIR=/home/agent/.local/bin \
    CODEX_NON_INTERACTIVE=1 \
    PATH=/opt/yeshua-mcp-tunnel:/home/agent/.local/bin:/home/agent/.npm-global/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin

RUN mkdir -p "$NPM_CONFIG_PREFIX" "$CODEX_INSTALL_DIR" "$CODEX_HOME" \
    && npm install -g @anthropic-ai/claude-code @openai/codex@0.164.0 \
    && npm ci --prefix /app/agent --omit=dev

USER root
COPY infra/Shared/DockerCompose/operational-intelligence/entrypoint.sh /usr/local/bin/yeshua-agent-entrypoint
COPY infra/Shared/DockerCompose/operational-intelligence/yeshua-agent-health.sh /usr/local/bin/yeshua-agent-health
COPY infra/Shared/DockerCompose/operational-intelligence/yeshua-agent-sync.sh /usr/local/bin/yeshua-agent-sync
RUN chmod +x \
      /usr/local/bin/yeshua-agent-entrypoint \
      /usr/local/bin/yeshua-agent-health \
      /usr/local/bin/yeshua-agent-sync

USER agent
ENV ASPNETCORE_URLS="http://0.0.0.0:5728;http://127.0.0.1:5729"
EXPOSE 5728
HEALTHCHECK --interval=30s --timeout=5s --start-period=30s CMD curl -fsS http://127.0.0.1:5728/api/health || exit 1
ENTRYPOINT ["yeshua-agent-entrypoint"]
CMD ["dotnet", "Yeshua.OperationalIntelligence.Api.dll"]
