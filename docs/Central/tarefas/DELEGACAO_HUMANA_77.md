# Issue #77 — delegação entre usuários humanos (somente projeto)

[Issue #77](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/77).
Nenhum endpoint, schema, token humano delegado ou regra de concessão entre usuários
foi implementado. Prioridade posterior à #76; a decisão deve ser submetida antes
de implementar. Este documento não autoriza ativação ou mudança de permissões.

## Compatibilidade com agentes externos

A #76 identifica concessões como `kind=external_agent`, cliente executor e
usuário titular, sem usuário artificial. O futuro humano deve autenticar com
suas próprias credenciais. `sub` deve identificar o ator humano real; concedente
e origem da autoridade precisam de campos distintos e inequívocos. Não reutilizar
`client_id` como usuário e não mudar o significado de `owner_sub` silenciosamente.
Os fluxos da #76 recusam outros tipos de concessão; não há delegação transitiva.

O store oficial de autorizações pode ser reaproveitado como artefato de consentimento,
com tipo/versão explícitos. Repositories/perfis/grants de negócio continuam sendo
a única fonte de direitos. Os scopes de protocolo somente limitam esses direitos.
Não criar perfis, saldos de permissões ou usuários intermediários no OAuth.

## Alternativas para decisão futura

| Modelo | Benefício | Risco / condição para aceitar |
| --- | --- | --- |
| Concatenar permissões na emissão | Verificação local rápida e compatível com tokens curtos | Uma união simples apaga a origem e pode combinar partes de permissões de pessoas/tenants diferentes para permitir uma operação que nenhuma autorizou. Não adotar união simples. |
| Contexto de concessão separado | Mantém ator, concedente, tenant, origem, restrições e versão da delegação; facilita auditoria e revogação | Precisa definir como a operação seleciona uma autoridade válida sem compor pedaços de contextos. Evitar lookup adicional por operação quando um snapshot curto for suficiente. |

Proposta para avaliação: contexto separado, ligado a uma concessão não transitiva,
com restrição de tenant e de operação/finalidade. Cada operação deve ser autorizada
inteiramente por um contexto elegível, sem elevar direitos por composição.
Não há decisão final nem implementação dessa proposta nesta tarefa.

## Ciclo de vida, desempenho e UX a especificar

- Solicitação identifica concedente, beneficiário autenticado, tenant, finalidade,
  apps/operações, prazo e restrições. Concedente não oferece direitos que não possui.
- Aceite explícito, consulta e revogação por envolvidos autorizados; nunca inferir
  consentimento do papel Admin ou de vínculo de tenant.
- Token preserva origem de cada concessão e ator real. Auditar quem executou e
  de quem veio a autoridade, sem capturar token/payload.
- Comparar snapshot na emissão/renovação com consulta/introspecção quando for
  necessária revogação imediata. Documentar a janela residual; não herdar os
  cinco minutos da #76 por acidente se a regra humana exigir mais rigor.
- Interface deve mostrar claramente "atuando como/delegado por", tenant, prazo
  e escopo, com saída explícita do contexto. Não trocar credenciais do usuário.

## Testes necessários antes de implementar/aceitar

Isolamento entre tenants e usuários, origem preservada, concessão expirada/revogada,
redução de permissões do concedente, beneficiário sem acesso, dois contextos que
não podem ser unidos, proibição de delegação transitiva, corrida com revogação,
auditoria de ator/concedente/cliente e custo por operação. Autenticação convencional
e #76 devem permanecer compatíveis. Nenhuma dessas capacidades humanas é declarada
entregue pelos testes de agentes.
