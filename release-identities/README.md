Identidades locais versionadas por componente (`<componente>.json`).

Ausencia significa versao desconhecida. Nenhuma versao historica e presumida.
Para declarar desenvolvimento explicitamente, o arquivo pode conter somente:

```json
{"schema":"yeshua.release/v2","component":"central","state":"development"}
```

Esse marcador nao representa release e e recusado pelo publicador. A preparacao
substitui o marcador pela identidade completa na branch da PR antes da tag.
Build/publish somente copiam os arquivos locais. Nao editar para simular release.
Ver docs/operational/COMPONENT_RELEASES.md.
