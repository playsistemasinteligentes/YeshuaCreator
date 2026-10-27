# Docker Compose Da Clinica

Esta infraestrutura pertence ao aplicativo Clinica. Ela foi restaurada a partir
do backup funcional `infra/legacy/pre-deployment-v1-2026-08-09` e ajustada para
os projetos `Yeshua.Clinica.CQRS.*`.

Os arquivos deste diretorio sao customizados e nao devem ser sobrescritos pela
Engine. O template de origem fica em:

`src/Engine/Yeshua.Engine/Dominio/CodeGeneration/Templates/Infrastructure/CSharpCQRS/DockerCompose`

O SQL Server, Redis, RabbitMQ, nginx e o Front compartilhado pertencem ao
servidor/Central. Este Compose contem somente API, Worker e Migration da
Clinica e usa a rede externa `yeshua-net`.

Deploy isolado:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica
```

O deploy nao executa `down` e nao altera containers dos demais aplicativos.

## Transcricao OpenAI

O Worker usa `OpenAI` como provider padrao. O FFmpeg e instalado e conferido
durante a construcao da imagem; o Compose define seu executavel em
`/usr/bin/ffmpeg`. Ele prepara somente audios que exigem ajuste de formato/tamanho.

A chave vem do arquivo geral privado `credentials.json`, no bloco
`Apps.Clinica.Transcription`, junto das conexoes de banco e demais chaves.
O modelo publico sem chave esta em
[clinica-transcription.example.json](../../private/clinica-transcription.example.json).
Ao usar um arquivo existente, preservar os outros campos e preencher somente o
bloco `Transcription`. O deploy carrega esse bloco pelo leitor privado atual.

Configuracao preparada no repositorio nao atualiza um container que ja esta em
execucao. Publicado e validado na VPS em 27/10/2026, com a chave no arquivo geral.
O resumo e outra tarefa pela fila; Apps.Clinica.Codex.Enabled ativa seu
consumidor no Docker operacional existente. A pasta temporaria e montada no
alias /clinica-work, preservando o storage original somente leitura. Ver
[executor Codex](../../../docs/operational/clinica/CODEX_EXECUTOR.md).
