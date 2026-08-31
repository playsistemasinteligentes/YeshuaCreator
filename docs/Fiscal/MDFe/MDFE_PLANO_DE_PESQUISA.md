# MDF-e - Plano De Pesquisa Por Subassunto

Pesquisa organizada em 2026-08-28.

Este plano define como vamos aprofundar MDF-e sem transformar o modulo em um
monstro. Cada subassunto deve gerar uma decisao pequena, rastreavel e util para
implementacao.

## Objetivo

Criar conhecimento suficiente para implementar um modulo Fiscal.MDFe capaz de:

- encerrar MDF-e autorizado;
- consultar situacao, status e documentos nao encerrados;
- tratar eventos essenciais;
- emitir MDF-e rodoviario quando o recorte estiver maduro;
- operar em homologacao e producao;
- evoluir para DAMDFE, distribuicao, CIOT, pagamentos, InfraSA e modais;
- permanecer modular, vendavel e desacoplado de CT-e, NF-e, carga, pedido e APS.

## Formato De Cada Pesquisa

Cada rodada de pesquisa deve responder:

- Fonte oficial: manual, schema, nota tecnica ou pagina do Portal MDF-e.
- Pergunta objetiva: o que precisamos decidir.
- Resultado esperado: decisao, tabela, contrato, fluxo ou pendencia.
- Impacto na DSL: o que a Engine deve gerar como borda.
- Impacto no miolo: o que IA/dev precisa implementar no aplicativo.
- Evidencia minima: como saberemos que a implementacao funcionou.

## Trilha De Pesquisa

| Ordem | Subassunto | Pergunta principal | Entrega esperada | Prioridade |
| --- | --- | --- | --- | --- |
| MDF-P00 | Inventario oficial | Quais manuais, schemas, NTs e tabelas estao vigentes? | Lista versionada de fontes oficiais. | P0 |
| MDF-P01 | Webservices 3.00 | Como cada servico MDF-e deve ser chamado? | Mapa de servicos, SOAP, namespaces e endpoints. | P0 |
| MDF-P02 | Certificado e assinatura | Como assinar MDF-e/eventos e autenticar no SVRS? | Contratos de assinatura, carga de certificado e validacao. | P0 |
| MDF-P03 | Encerramento | Como encerrar MDF-e autorizado? | Fluxo P0 com evento `110112`. | P0 |
| MDF-P04 | Consulta e nao encerrados | Como consultar situacao e pendencias de encerramento? | Playground de consulta/status/nao encerrados. | P0 |
| MDF-P05 | Retornos SEFAZ | Como interpretar `cStat`, protocolo, rejeicoes e falhas tecnicas? | Tabela de resultados e status internos. | P0/P1 |
| MDF-P06 | Cancelamento | Como cancelar MDF-e autorizado? | Command e fluxo separado. | P1 |
| MDF-P07 | Inclusao de condutor | Como incluir condutor em MDF-e autorizado? | Command e fluxo separado. | P1 |
| MDF-P08 | DAMDFE e QR Code | O que precisa para imprimir e consultar publicamente? | DAMDFE minimo e politica de QR Code. | P1 |
| MDF-P09 | Emissao rodoviaria | Qual o fluxo minimo para autorizar MDF-e rodoviario? | Contrato `MDFeEmissionRequest`. | P1/P2 |
| MDF-P10 | Documentos originarios | Como receber CT-e, NF-e e outros documentos sem acoplar modulos? | Modelo de snapshots. | P1/P2 |
| MDF-P11 | Veiculos, condutores e percurso | Quais dados do transporte entram no MDF-e? | Modelo operacional por modal. | P1 |
| MDF-P12 | CIOT, contrato e vale pedagio | Quando CIOT/ANTT/vale pedagio entram e como validar? | Regras P1/P2 e pendencias por cenario. | P1/P2 |
| MDF-P13 | Pagamento e MDF-e Integrado | Como tratar contrato, adiantamento e pagamento? | Fluxos isolados de pagamento/confirmacao. | P2 |
| MDF-P14 | Distribuicao DF-e | Como buscar MDF-e para atores interessados? | Pesquisa de NSU e persistencia. | P2 |
| MDF-P15 | InfraSA/DTe | Como usar dados de consulta para DTe/InfraSA? | Mapa do retorno e persistencia. | P2 |
| MDF-P16 | CT-e Simplificado no MDF-e | O que muda quando o MDF-e referencia CT-e Simplificado? | Decisao de modelagem e regras. | P2 |
| MDF-P17 | PAA, NFF e CNPJ Alfa | Quais impactos transversais precisam entrar? | Plano de compatibilidade futura. | P3 |
| MDF-P18 | Bibliotecas C# | O que vale aproveitar de bibliotecas existentes? | Comparativo tecnico sem acoplar arquitetura. | P0/P1 |
| MDF-P19 | Conectores legados | Como receber carga/pedido/documentos sem acoplar dominio? | Casca de conector e normalizacao. | P1 |
| MDF-P20 | Observabilidade fiscal | Que logs, metricas e replay ajudam suporte? | Trilha por tentativa/evento. | P1 |
| MDF-P21 | Modularizacao interna | Como separar encerramento, emissao, eventos, modais e distribuicao? | Revisao do documento de modularizacao. | P0 |

## Referencias Open Source

O subassunto MDF-P18 usa o catalogo
[REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md) como evidencia
tecnica auxiliar.

O snapshot local atual de DFe.NET e Unimake.DFe ainda nao contem as pastas
MDF-e completas. Ate ampliar esses clones, as conclusoes sobre MDF-e nessas
bibliotecas ficam limitadas as camadas comuns, aos READMEs, aos WSDLs comuns,
aos testes comuns e aos arquivos que citam MDF-e.

Regra:

- usar bibliotecas como comparacao tecnica;
- validar regra fiscal sempre no MOC/schema/WSDL oficial;
- nao colocar dependencia fiscal dentro da Engine;
- se uma biblioteca for adotada, ela pertence ao aplicativo Fiscal.MDFe ou a
  uma biblioteca fiscal especifica do aplicativo.

## Ordem Recomendada De Execucao

1. Fechar MDF-P00 e baixar pacote de schemas vigente.
2. Confirmar WSDLs dos servicos P0.
3. Revalidar playground de MDF-P03 em homologacao/ambiente controlado.
4. Implementar consulta situacao e nao encerrados.
5. Migrar encerramento para miolo customizado do app Fiscal.MDFe.
6. Persistir XML, protocolo, status fiscal e retorno bruto.
7. Implementar cancelamento e inclusao de condutor.
8. Ligar DAMDFE/QR Code.
9. So depois implementar emissao completa rodoviaria.
10. Expandir para CIOT, pagamentos, distribuicao e InfraSA por demanda real.

## Saida Para DSL E Engine

A DSL deve declarar:

- modulo Fiscal.MDFe;
- entidades operacionais;
- use cases;
- conectores;
- policies de execucao;
- filas/inbox quando necessario;
- telas basicas;
- permissoes.

A DSL nao deve declarar:

- cada tag XML;
- cada codigo de rejeicao;
- cada detalhe de SOAP;
- cada regra ANTT;
- DAMDFE pixel a pixel;
- implementacao de biblioteca fiscal.

O motor deve gerar:

- commands;
- receivers;
- endpoints;
- contratos;
- repositorios;
- workers quando declarados;
- pontos `Custon` para XML, assinatura, SEFAZ, eventos e DAMDFE.

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

- Fiscal.MDFe;
- Fiscal.CTe;
- Fiscal.NFe;
- Planejamento de transporte;
- Faturamento;
- Conector externo;
- Shared generico;
- Engine.

Regra:

- Se e regra oficial do MDF-e, fica no aplicativo Fiscal.MDFe.
- Se e borda repetivel, a Engine gera.
- Se e contrato generico independente de dominio, pode ir para Shared.
- Se e detalhe de fabricante/cliente/legado, fica em conector customizado.

## Criterio De Pronto Para Implementar

Um subassunto so deve ir para codigo quando tivermos:

- fonte oficial identificada;
- contrato de entrada definido;
- persistencia minima definida;
- comportamento esperado para sucesso, rejeicao e falha tecnica;
- impacto claro na DSL ou confirmacao de que sera apenas miolo custom;
- evidencia de teste ou playground planejada.

## Pendencias Da Pesquisa Atual

- Baixar e versionar schemas XML vigentes do MDF-e.
- Confirmar nomes de metodos nos WSDLs oficiais.
- Confirmar codigos de todos os eventos diretamente no XSD vigente.
- Decidir biblioteca C# de apoio ou implementacao propria.
- Revalidar status/consulta/nao encerrados em homologacao.
- Definir contrato interno `MDFeEncerramentoRequest`.
- Definir contrato interno `MDFeEmissionRequest`.
- Definir o primeiro conector legado que alimentara MDF-e.
