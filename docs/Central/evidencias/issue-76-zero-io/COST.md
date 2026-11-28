# Custo local observado

Execução final: .NET 8.0.34, Debug, 2 processadores.
Medianas de 5 lotes de 1000 operações, após 100 warmups.

| Caminho | CPU local por operação | JWT da fixture |
| --- | ---: | ---: |
| Convencional Central: HMAC e claims | 53.08 µs | 405 bytes |
| MCP anterior, controle com cache aquecido: RSA e claims | 169.06 µs | 775 bytes |
| MCP autocontido: RSA, claims e abertura da credencial protegida | 805.81 µs | 3099 bytes |

Custo adicional local observado contra o controle MCP aquecido:
636.75 µs por operação. **Há custo de CPU
adicional e token maior**; a eliminação de I/O não é anunciada como redução de CPU.

O teste mede criptografia/claims locais, não latência total de requisição nem
SLO de produção. A validação convencional usa HMAC e o recurso MCP usa RSA;
a comparação não atribui toda a diferença à parte protegida. O controle anterior
é somente aquecido e não representa sua consulta/troca de sessão no primeiro
acesso. As amostras completas e a descrição exata estão no
[JSON medido](local-authorization-cost.json). A escrita desta evidência ocorre
fora da região medida.

A prova independente com backends bloqueados está em
[zero-authorization-io.json](zero-authorization-io.json), com zero SQL/conexão/
leitura Central/sessão durante descoberta e entrega, desde a primeira chamada.
