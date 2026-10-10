FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG NODE_MAJOR=22

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

RUN useradd --create-home --shell /bin/bash agent \
    && mkdir -p /workspace \
    && chown -R agent:agent /workspace

USER agent
WORKDIR /workspace

ENV HOME=/home/agent \
    NPM_CONFIG_PREFIX=/home/agent/.npm-global \
    CODEX_HOME=/home/agent/.codex \
    CODEX_INSTALL_DIR=/home/agent/.local/bin \
    CODEX_NON_INTERACTIVE=1 \
    PATH=/home/agent/.local/bin:/home/agent/.npm-global/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin

RUN mkdir -p "$NPM_CONFIG_PREFIX" "$CODEX_INSTALL_DIR" "$CODEX_HOME" \
    && npm install -g @anthropic-ai/claude-code \
    && curl -fsSL https://chatgpt.com/codex/install.sh | sh

USER root
COPY entrypoint.sh /usr/local/bin/yeshua-agent-entrypoint
COPY yeshua-agent-health.sh /usr/local/bin/yeshua-agent-health
COPY yeshua-agent-sync.sh /usr/local/bin/yeshua-agent-sync
RUN chmod +x \
      /usr/local/bin/yeshua-agent-entrypoint \
      /usr/local/bin/yeshua-agent-health \
      /usr/local/bin/yeshua-agent-sync

USER agent
ENTRYPOINT ["yeshua-agent-entrypoint"]
CMD ["sleep", "infinity"]
