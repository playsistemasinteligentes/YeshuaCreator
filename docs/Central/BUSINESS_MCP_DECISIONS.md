# Decisões do MCP de negócio e OAuth

2026-11-27, base `eb20c50ad50be21b2bc6d36825df2953f98fa616`, branch preparada
`codex/task-85374af22c2449068d7c25b90bb3122e`.

1. **OpenAPI é a fonte dos schemas.** A Engine continua produzindo endpoints e
   tipos; acrescenta nome estável app/grupo/subgrupo/Command, descrição e resposta
   tipada 200. O adapter converte formato, não gera DTOs nem outro catálogo DSL.
   Snapshots reais ainda precisam ser regenerados/validados; nenhum app foi
   regenerado em massa nesta tarefa. Código Custon permanece preservado.
2. **Visibilidade HTTP não significa exposição a agentes.** Grants existentes da
   Central são a fonte de autorização; a relação com operações delegáveis ainda
   não existe de forma suficiente. A composição exige adaptadores de repository,
   auditoria e envio delegado. Não registrar adapters permissivos/in-memory em
   produção. Sem eles o mapeamento do módulo falha antes de expor rota.
3. **MCP administrativo continua isolado.** Reutilizar SDK oficial e transporte
   adotado, sem registry comum, credencial operacional, nova porta/container ou
   túnel público para negócio. O módulo opt-in pertence à API Central existente.
4. **Resource server não é authorization server.** Implementar validação dedicada
   e RFC 9728 primeiro. Não ativar JWT legado para agentes nem construir um
   emissor OAuth parcial. Authorization code/PKCE, consentimento e stores são
   impedimentos de integração documentados, não funcionalidades concluídas.
5. **Delegação humana não é identidade de máquina.** Aceitar apenas tipo delegado
   com usuário, tenant, client e consentimento coincidentes. Autonomia exige
   contrato próprio. Scope é interseção com consentimento e permissão atual.
6. **A API destino mantém a autoridade.** O token recebido no MCP não cruza a
   fronteira. A integração sintética valida uma segunda assinatura/audience e
   permissões; não comprova integração das APIs legadas. Não usar `getMenu` como
   troca implícita de credencial nem ampliar permissões por conveniência.
7. **Execução tem resultado incerto.** Intenção e resultado auditados na borda,
   sem payload; timeout não prova falha e não gera retry. 202 não prova conclusão.
   Acompanhamento de saga usa futuramente projeção/Command já existentes, não
   um runner paralelo. Persistência/retomada de auditoria ainda exige adapter.

Os descritores separados contêm critérios e impedimentos:
[MCP central](tarefas/MCP_CENTRAL_NEGOCIO.md) e
[OAuth externo](tarefas/OAUTH_AGENTES_EXTERNOS.md). A entrega global permanece
incompleta enquanto esses critérios de integração estiverem pendentes.
