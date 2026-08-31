# CT-e - Plano De Pesquisa Por Subassunto

Pesquisa organizada em 2026-08-28.

Este plano define como vamos aprofundar CT-e sem transformar o modulo em um
monstro. Cada subassunto deve gerar uma decisao pequena, rastreavel e util para
implementacao.

## Objetivo

Criar conhecimento suficiente para implementar um modulo Fiscal.CTe capaz de:

- emitir CT-e modelo 57;
- consultar servico e situacao;
- tratar eventos essenciais;
- operar em homologacao e producao;
- evoluir para contingencia, distribuicao e documentos auxiliares;
- permanecer modular, vendavel e desacoplado dos demais modulos APS/Yeshua.

## Formato De Cada Pesquisa

Cada rodada de pesquisa deve responder:

- Fonte oficial: manual, schema, nota tecnica ou pagina do Portal CT-e.
- Pergunta objetiva: o que precisamos decidir.
- Resultado esperado: decisao, tabela, contrato, fluxo ou pendencia.
- Impacto na DSL: o que a Engine deve gerar como borda.
- Impacto no miolo: o que IA/dev precisa implementar no aplicativo.
- Evidencia minima: como saberemos que a implementacao funcionou.

## Trilha De Pesquisa

| Ordem | Subassunto | Pergunta principal | Entrega esperada | Prioridade |
| --- | --- | --- | --- | --- |
| CT-P00 | Inventario oficial | Quais manuais, schemas e NTs estao vigentes? | Lista versionada de fontes oficiais. | P0 |
| CT-P01 | Webservices 4.00 | Como cada servico CT-e 4.00 deve ser chamado? | Mapa de servicos, SOAP/HTTP, namespaces e endpoints. | P0 |
| CT-P02 | Certificado e assinatura | Como assinar XML e usar certificado cliente? | Contratos de assinatura, carga de certificado e validacao. | P0 |
| CT-P03 | Status e consulta | Como consultar disponibilidade e situacao? | Playground de status/consulta e parser de retorno. | P0 |
| CT-P04 | Emissao modelo 57 | Qual o fluxo minimo para autorizar CT-e normal? | Fluxo P0 de emissao e contrato `CTeEmissionRequest`. | P0 |
| CT-P05 | Participantes e documentos | Quais dados de emitente, tomador, remetente, destinatario, NF e carga sao obrigatorios? | Modelo interno de snapshots e validacoes estruturais. | P0 |
| CT-P06 | Valores e rateio | Como distribuir frete e valores entre documentos/carga? | Contrato de rateio e regras iniciais. | P1 |
| CT-P07 | Impostos e RTC | Quais regras fiscais afetam ICMS, CST, CFOP e alteracoes RTC? | Motor fiscal inicial e pendencias por UF/cenario. | P1 |
| CT-P08 | Retornos SEFAZ | Como interpretar `cStat`, protocolo, rejeicoes e falhas tecnicas? | Tabela de resultados fiscais e status internos. | P0/P1 |
| CT-P09 | Eventos essenciais | Como cancelar, corrigir e registrar eventos operacionais? | Commands por evento e ordem de implementacao. | P1/P2 |
| CT-P10 | DACTE e QR Code | O que precisa para imprimir ou disponibilizar DACTE? | DACTE minimo e politica de QR Code. | P1/P2 |
| CT-P11 | Contingencia | Quando usar SVC/EPEC e como recuperar? | Fluxo isolado de contingencia. | P2 |
| CT-P12 | Distribuicao DF-e | Como buscar documentos distribuidos pela AN? | Pesquisa de NSU, ultNSU, maxNSU e persistencia. | P2 |
| CT-P13 | CT-e Simplificado | Quando usar e o que muda pela NT 2024.002? | Decisao se vira produto separado ou variacao. | P2/P3 |
| CT-P14 | CT-e OS e GTV-e | O que muda em CT-e OS e GTV-e? | Recorte futuro separado do modelo 57. | P3 |
| CT-P15 | Bibliotecas C# | O que vale aproveitar de bibliotecas existentes? | Comparativo tecnico sem acoplar arquitetura ao fornecedor. | P0/P1 |
| CT-P16 | Adapters externos posteriores | Como receber contratos SOAP/REST/arquivo sem acoplar o Fiscal.CTe? | Adapter anterior ao fiscal, payload bruto e normalizacao para mensagem oficial. | P1 |
| CT-P17 | Observabilidade fiscal | Que logs, metricas e replay ajudam suporte? | Trilha operacional por tentativa/evento. | P1 |
| CT-P18 | Modularizacao interna | Como separar produtos CT-e, CT-e OS, GTV-e, simplificado, eventos e distribuicao? | Revisao do documento de modularizacao. | P0 |

## Ordem Recomendada De Execucao

1. Fechar CT-P00 e baixar o pacote de schemas vigente.
2. Fazer playground de CT-P03 com `CTeStatusServicoV4` e `CTeConsultaV4`.
3. Fazer playground de CT-P02 com assinatura e validacao XSD.
4. Implementar CT-P04 somente para CT-e normal modelo 57 em homologacao.
5. Persistir XML, protocolo, status fiscal e retorno bruto.
6. Implementar cancelamento e carta de correcao como eventos separados.
7. Ligar DACTE/QR Code depois que autorizacao estiver estavel.
8. Expandir para contingencia e distribuicao apenas quando houver demanda real.
9. Reavaliar modularizacao depois de cada familia oficial pesquisada.

## Saida Para A DSL E Engine

A DSL deve ficar pequena.

Ela deve declarar:

- modulo Fiscal.CTe;
- entidades operacionais;
- use cases;
- mensagens oficiais de entrada e saida;
- policies de execucao;
- filas/inbox quando necessario;
- telas basicas;
- permissoes.

Ela nao deve declarar:

- cada tag XML;
- cada codigo de rejeicao;
- cada detalhe de SOAP;
- regras completas de imposto;
- DACTE pixel a pixel;
- implementacao de biblioteca fiscal.

O motor deve gerar:

- commands;
- receivers;
- endpoints;
- contratos;
- repositorios;
- workers quando declarados;
- pontos `Custon` para XML, assinatura, SEFAZ, eventos e DACTE.

IA/dev deve implementar:

- regra fiscal especifica;
- composicao de XML;
- assinatura;
- validacao de schema;
- interpretacao detalhada de retorno;
- decisao de retry/reprocessamento;
- integracoes especificas.

## Saida Para Modularizacao

Cada pesquisa deve indicar se o assunto pertence a:

- Fiscal.CTe;
- Fiscal.MDFe;
- Fiscal.NFe;
- Planejamento de transporte;
- Faturamento;
- Adapter externo anterior, quando houver;
- Shared generico;
- Engine.

Regra de decisao:

- Se e regra oficial do CT-e, fica no aplicativo Fiscal.CTe.
- Se e borda repetivel, a Engine gera.
- Se e contrato generico independente de dominio, pode ir para Shared.
- Se e detalhe de fabricante/cliente/legado, fica em adapter externo fora do Fiscal.CTe.

## Criterio De Pronto Para Implementar

Um subassunto so deve ir para codigo quando tivermos:

- fonte oficial identificada;
- contrato de entrada definido;
- persistencia minima definida;
- comportamento esperado para sucesso, rejeicao e falha tecnica;
- impacto claro na DSL ou confirmacao de que sera apenas miolo custom;
- evidencia de teste ou playground planejada.

## Pendencias Da Pesquisa Atual

- Baixar e versionar os schemas XML vigentes do CT-e.
- Confirmar codigos numericos de todos os eventos diretamente no XSD vigente.
- Escolher biblioteca C# de apoio ou confirmar implementacao propria.
- Validar primeira chamada de status CT-e em homologacao para PE/SVSP.
- Definir o primeiro contrato de entrada nativo: `CTeEmissionRequest`.
- Deixar adapters externos para depois; o primeiro recorte do Fiscal.CTe recebe mensagem oficial.
- Confirmar por XSD vigente todos os codigos de evento antes de transformar em
  constantes de fonte.
