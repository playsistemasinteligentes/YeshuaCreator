# MCP central de negócio

Data: 2026-11-27. Descritor local de desenvolvimento, no formato de escopo,
reconhecimento, decisões, critérios e evidências usado pelos planos em `docs`.
Não foi encontrado um formato estruturado único de descritor de tarefa no repositório.
Nenhuma issue ou PR foi criada pelo terminal.

Estado: **incremento implementado; tarefa completa pendente**. Dependência:
[OAuth para agentes externos](OAUTH_AGENTES_EXTERNOS.md).

## Objetivo e limites

Descobrir aplicativos e Commands autorizados e executar por aplicativo,
identificador estável e objeto JSON. Sem SQL livre, URL fornecida pelo agente,
operações internas, concessões administrativas ou modificação do MCP operacional.
Nenhuma operação real ou publicação em produção está autorizada por este descritor.

## Reconhecimento

| Caminho existente | Conclusão e reutilização |
| --- | --- |
| `src/Engine/Yeshua.Engine/Dominio/UseCaseCommand.cs` | `Scopes`, `IsInternal`, descrição e tipos de entrada/saída já existem. Não criar outro gerador de contratos. |
| `src/Engine/Yeshua.Engine/Dominio/Schemas/CentralAuthorizationSchema.cs` | Projeta aplicativos/módulos/grants com histórico, exclui Commands internos; não registra a relação operação HTTP/grant delegável. |
| `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/SourceCodeInfraestructureAPIEndpointsMigration.cs` | É a fonte das rotas e verbos. Passa a emitir nome estável, descrição e tipo da resposta 200 nos Commands públicos. |
| `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Program.cs` | Swagger existente fornece schemas; a policy padrão não constitui autorização por operação. |
| `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Migration/EndPoints.cs` | `getMenu` troca sessão e pode provisionar identidade local. Não usá-lo como token exchange silencioso para agentes. |
| `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Modules/Mcp` | SDK oficial e Streamable HTTP já adotados. Reutilizar SDK; preservar registry, túnel, porta e credenciais administrativos. |

## Incremento entregue

`Custon/BusinessMcp` na API Central contém transporte MCP opt-in, catálogo em
memória derivado de snapshots OpenAPI confiáveis, receiver e contratos de adaptação.
O `Program.cs` atual não registra nem mapeia essa funcionalidade. Nenhum aplicativo
real está cadastrado para agentes. Não há fonte alternativa de segredo.

- `yeshua_business_applications`: aplicativos com ao menos uma operação permitida.
- `yeshua_business_operations`: ID, descrição e schemas completos da entrada e
  resposta 200 das operações elegíveis; referências locais são preservadas em `$defs`.
- `yeshua_business_execute`: app/operação/parâmetros. Resolve somente POST/rota
  exata do snapshot aprovado. Não segue links de resposta nem repete Commands.
- Scope OAuth, delegação ativa e permissão atual do usuário/tenant devem coincidir;
  descoberta não concede execução. As consultas são repetidas por chamada.
- Intenção auditada antes do envio; falha desse registro impede o envio.
  Resultado e correlação são auditados sem parâmetros, payload, token ou PII textual.
- Destino usa interface obrigatória de delegação, sem acesso ao bearer de entrada.
  A prova de integração usa uma segunda API com validação JWT e permissão próprias.
- Respostas de falha são classificadas sem devolver exceções ou corpo bruto.
  `202` significa somente aceite, sem confirmar conclusão ou seguir `Location`.
  Timeout resulta em `outcome_unknown`; não há retry automático.
- Entrada limitada a 64 KiB, saída JSON a 1 MiB e chamada a 30 s; argumentos de
  ferramenta são validados. Origem de navegador diferente é recusada.

O adaptador aceita OpenAPI 3.0.1/2/3, Commands JSON com input objeto, sem parâmetros
HTTP adicionais, uploads, callbacks, `discriminator` ou XML. Fecha propriedades
desconhecidas na raiz do input. Não aceita contratos que peçam TenantId/UserId/
ClientId/DelegationId como parâmetros. Casos fora desse recorte exigem evolução
explícita do adaptador, sem aceitar parcialmente um contrato desconhecido.

## Impedimentos antes de expor

1. Projetar a relação dos `Scopes` atuais com ID estável, classificação de exposição
   e grant **efetivo** do usuário/tenant; revisar operações administrativas mesmo
   quando públicas no HTTP. O `BusinessExposure` usado nos testes não é uma segunda
   base de permissões nem autorização para cadastrar produção manualmente.
2. Implementar `IBusinessPermissionReader` sobre os repositories existentes da
   Central; não confiar só em claims nem no papel Admin. Nenhuma implementação
   permissiva é registrada por padrão.
3. Implementar delegação de destino e verificação de audience/scope em cada API
   pelo gerador/policy compartilhada; preservar mapeamento explícito de identidade
   Central/local, períodos de uso e regras de domínio. O JWT legado não serve.
4. Registrar segurança por operação no Swagger a partir das policies reais.
   O `AddSecurityDefinition` atual, sozinho, não emite `security` por operação;
   o catálogo recusa entradas sem essa evidência. Regenerar apps sob controle,
   validar snapshots e confirmar estabilidade dos IDs em renomes/versionamentos.
5. Adaptadores persistentes de delegação e auditoria; retenção e recuperação de
   resultados incertos. Corridas com revogação no meio de chamada devem ser
   verificadas também no destino, antes da mutação.
6. Contrato de acompanhamento assíncrono por Command/projeção existente, com
   recibo/schema explícito e reautorização. Este incremento devolve apenas aceite
   e correlação, sem job tracker, polling ou protocolo MCP Tasks novo.
7. Paginação/limites do catálogo, rate limiting por cliente/tenant, desafios HTTP
   de step-up por scope e homologação com perfis reais de teste ainda pendentes.

## Critérios de aceite

| Critério | Estado |
| --- | --- |
| Descoberta e execução MCP com schemas, grant e identidade simulados | Testado localmente |
| Negativos de tenant, identidade, scope, revogação, operação interna e JSON | Testados localmente |
| API de destino reautoriza e usa credencial distinta | Testado com API sintética |
| Catálogo, grants e auditoria ligados à Central real | Pendente |
| OAuth de ponta a ponta com consentimento/PKCE/revogação persistente | Pendente na tarefa integrada |
| Assíncrono com acompanhamento autorizado | Pendente |
| Homologação disponibilizada e autorizada | Não executada |

Evidências e comandos: [VALIDATION.md](../evidencias/business-mcp/VALIDATION.md).
