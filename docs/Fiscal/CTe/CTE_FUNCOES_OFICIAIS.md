# CT-e - Mapa De Funcoes Oficiais

Pesquisa consolidada em 2026-08-28.

Este documento separa os servicos oficiais da SEFAZ das capacidades de negocio
que o modulo Fiscal.CTe precisa oferecer. A regra e simples: servico web oficial
nao vira arquitetura interna sozinho. Ele e uma borda tecnica. O modulo deve
organizar os fluxos por capacidade: emissao, eventos, consultas, contingencia,
documentos auxiliares e distribuicao.

Fontes oficiais usadas nesta consolidacao:

- Portal CT-e - Manuais:
  https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=YIi%2BH8VETH0%3D
- Portal CT-e - Esquemas XML:
  https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=0xlG1bdBass%3D
- Portal CT-e - Notas Tecnicas:
  https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=Y0nErnoZpsg%3D
- Portal CT-e - Servicos Web de Producao:
  https://www.cte.fazenda.gov.br/portal/webServices.aspx?tipoConteudo=wpdBtfbTMrw%3D
- Portal CT-e - Servicos Web de Homologacao:
  https://hom.cte.fazenda.gov.br/portal/webServices.aspx?tipoConteudo=wpdBtfbTMrw%3D

## Leitura Correta

O CT-e precisa ser dividido em duas camadas de pensamento:

- Funcoes oficiais: aquilo que a SEFAZ disponibiliza como webservice, schema,
  evento, leiaute, regra de validacao ou documento auxiliar.
- Capacidades internas: aquilo que o Yeshua oferece como modulo vendavel e
  operavel, com commands, receivers, persistencia, observabilidade e miolos
  customizados.

Exemplo:

- `CTeRecepcaoEventoV4` e um unico webservice oficial.
- Internamente ele nao deve virar um receiver gigante.
- Cada evento importante deve ter command e receiver proprio.

## Servicos Web Oficiais

| Servico oficial | Papel | Prioridade | Fronteira interna sugerida |
| --- | --- | --- | --- |
| `CTeRecepcaoSincV4` | Autoriza CT-e modelo 57 em fluxo sincrono. | P0 | Emissao normal |
| `CTeStatusServicoV4` | Consulta disponibilidade do autorizador. | P0 | Diagnostico SEFAZ |
| `CTeConsultaV4` | Consulta situacao de um CT-e por chave. | P0/P1 | Consulta e reconciliacao |
| `CTeRecepcaoEventoV4` | Recebe eventos do CT-e. | P1/P2 | Eventos isolados |
| `CTeRecepcaoOSV4` | Autoriza CT-e OS. | P3 | Produto/recorte separado |
| `CTeRecepcaoGTVeV4` | Autoriza GTV-e. | P3 | Produto/recorte separado |
| `CTeRecepcaoSimpV4` | Autoriza CT-e Simplificado. | P2/P3 | Emissao simplificada |
| `CTeDistribuicaoDFe` | Distribui documentos fiscais eletronicos para envolvidos. | P2 | Distribuicao e reconciliacao |
| QR Code CT-e | Consulta publica usada principalmente no DACTE. | P1/P2 | DACTE e consulta publica |

Observacoes:

- Em CT-e 4.00, o fluxo principal de autorizacao e sincrono.
- O MOC CT-e 4.00 registra a eliminacao do SOAP Header nos webservices.
- A autorizacao assincrona antiga nao deve ser usada como base para novos
  clientes CT-e 4.00.
- O Portal CT-e deve continuar sendo a fonte primaria para URLs, autorizadores,
  schemas e notas tecnicas.

## Matriz Tecnica Inicial Dos Webservices

Esta matriz vem dos MOCs locais e da relacao oficial de servicos. Antes de
codificar cliente definitivo, confirmar cada contrato no WSDL e no pacote de
schemas vigente.

| Servico | Metodo oficial | XML de entrada | XML de retorno | Uso interno |
| --- | --- | --- | --- | --- |
| `CTeRecepcaoSincV4` | `cteRecepcao` | `CTe_v9.99.xsd` | `retCTe_v9.99.xsd` | Autorizar CT-e modelo 57. |
| `CTeConsultaV4` | `cteConsultaCT` | `consSitCTe_v9.99.xsd` | `retConsSitCTe_v9.99.xsd` | Consultar situacao por chave. |
| `CTeStatusServicoV4` | `cteStatusServicoCT` | `consStatServCTe_v9.99.xsd` | `retConsStatServCTe_v9.99.xsd` | Checar disponibilidade. |
| `CTeRecepcaoEventoV4` | `cteRecepcaoEvento` | `eventoCTe_v9.99.xsd` | `retEventoCTe_v9.99.xsd` | Enviar cancelamento, CC-e e demais eventos. |
| `CTeRecepcaoOSV4` | `cteRecepcaoOS` | `CTeOS_v9.99.xsd` | `retCTeOS_v9.99.xsd` | Autorizar CT-e OS. |
| `CTeRecepcaoGTVeV4` | `cteRecepcaoGTVe` | `GTVe_v9.99.xsd` | `retGTVe_v9.99.xsd` | Autorizar GTV-e. |
| `CTeRecepcaoSimpV4` | pendencia | Schema do CT-e Simplificado vigente. | Schema de retorno vigente. | Autorizar CT-e Simplificado. |
| `CTeDistribuicaoDFe` | pendencia | Schema de distribuicao vigente. | Schema de retorno vigente. | Distribuir DF-e de interesse. |

Pendencias:

- pendencia: confirmar metodo oficial de `CTeRecepcaoSimpV4` no WSDL vigente.
- pendencia: confirmar metodo oficial e schemas da distribuicao CT-e no WSDL e
  na NT 2015.002 vigente.
- pendencia: substituir `v9.99` pela versao real do pacote de schema adotado no
  modulo quando o ZIP oficial for baixado.

## Autorizadores E Ambientes

Endpoints nao pertencem a regra de negocio. Eles devem ser resolvidos por:

- UF do emitente.
- Ambiente: homologacao ou producao.
- Tipo de documento: CT-e, CT-e OS, GTV-e ou CT-e Simplificado.
- Servico oficial solicitado.
- Politica de contingencia vigente.

Para Pernambuco no recorte atual, o autorizador CT-e e a SVSP.

## Eventos Do CT-e

O MOC e as notas tecnicas organizam eventos em um webservice comum. O modulo
deve tratar cada evento relevante como fluxo proprio.

| Evento | Codigo | Papel de negocio | Prioridade | Observacao de implementacao |
| --- | --- | --- | --- | --- |
| Carta de Correcao | `110110` | Corrige informacoes permitidas sem cancelar o documento. | P1 | Bloquear campos vedados pela regra oficial e NTs posteriores. |
| Cancelamento | `110111` | Cancela CT-e autorizado dentro das regras aplicaveis. | P1 | Validar prazo, situacao e protocolo. |
| EPEC | `110113` | Permite contingencia com evento previo de emissao. | P2 | Fica isolado de emissao normal. |
| Registro Multimodal | `110160` | Vincula informacoes dos servicos prestados ao CT-e multimodal. | P3 | Implementar somente quando houver caso real. |
| Informacoes Da GTV | `110170` | Relaciona informacoes de GTV ao CT-e OS de transporte de valores. | P3 | Produto/recorte separado. |
| Comprovante De Entrega | `110180` | Registra efetivacao da entrega da carga. | P2 | Importante para logistica e SLA. |
| Cancelamento Do Comprovante De Entrega | `110181` | Cancela comprovante de entrega registrado. | P2 | Deve manter trilha fiscal. |
| Insucesso Na Entrega | `110190` | Registra tentativa de entrega sem sucesso. | P2 | Vem da NT 2023.002 e e exclusivo da versao 4.00. |
| Cancelamento Do Insucesso Na Entrega | `110191` | Cancela evento de insucesso na entrega. | P2 | Pesquisar regras da NT antes de modelar. |
| Vinculacao De Pagamento | `110300` | Vincula transacao financeira ao DFe para split payment. | P3 | Vem da NT 2026.001; preparatorio para 2027. |
| Cancelamento Da Vinculacao De Pagamento | `110301` | Cancela evento de vinculacao de pagamento. | P3 | Confirmar par de schemas vigente antes de implementar. |
| Prestacao em Desacordo | `610110` | Tomador informa que o CT-e esta em desacordo com a prestacao. | P2 | Tambem influencia CT-e de substituicao. |
| Cancelamento Da Prestacao em Desacordo | `610111` | Cancela desacordo registrado. | P2 | Acoplar ao fluxo anterior, nao a emissao normal. |

Os codigos acima foram extraidos dos manuais/notas disponiveis em
`docs/Fiscal/CTe/oficial`. Antes de codificar constantes, confirmar no pacote
de schemas vigente baixado do Portal CT-e.

## Familias Oficiais Por Nota Tecnica

| Fonte | Impacto para o modulo | Prioridade |
| --- | --- | --- |
| MOC CT-e 4.00 | Base de webservices, eventos, contingencia, chave, DACTE e regras gerais. | P0 |
| Anexo I MOC 4.00 | Leiaute e regras de validacao. | P0 |
| Anexo II MOC 4.00 | DACTE. | P1/P2 |
| NT 2023.002 | Insucesso na entrega e cancelamento do insucesso. | P2 |
| NT 2024.002 | CT-e Simplificado. | P2/P3 |
| NT 2025.001 | Reforma Tributaria do Consumo para CT-e, CT-e OS e GTV-e. | P1/P2 |
| NT 2026.001 | Grupo/eventos de vinculacao de pagamento. | P3 |
| NT 2026.002 | Evolucoes RTC, antecipacao de pagamento, IBS/CBS, cashback e ajustes. | P1/P2 |
| NT 2015.002 | Distribuicao DF-e para atores interessados. | P2 |

## Prioridades De Implementacao

### P0 - Romper A Primeira Emissao

Objetivo: conseguir emitir CT-e modelo 57 em homologacao com trilha suficiente
para diagnosticar erro.

Inclui:

- Resolver autorizador por UF e ambiente.
- Consultar status do servico.
- Montar XML de CT-e normal.
- Assinar XML.
- Validar XML contra XSD.
- Enviar para `CTeRecepcaoSincV4`.
- Interpretar retorno.
- Persistir XML enviado, retorno bruto, protocolo e status fiscal.
- Consultar situacao por chave quando necessario.

### P1 - Operacao Minima

Objetivo: tornar o modulo util para operacao real basica.

Inclui:

- Cancelamento.
- Carta de correcao.
- DACTE basico.
- QR Code.
- Consulta de situacao operacional.
- Rateio de frete inicial.
- Calculo fiscal inicial para os cenarios reais.
- Observabilidade por tentativa de emissao.

### P2 - Robustez Fiscal E Logistica

Objetivo: lidar com recuperacao, entrega e reconciliacao.

Inclui:

- Distribuicao DF-e.
- Contingencia por SVC/EPEC.
- Comprovante de entrega.
- Insucesso na entrega.
- Prestacao em desacordo.
- Reprocessamento controlado.
- Diagnostico de divergencias entre estado interno e SEFAZ.

### P3 - Produtos Fiscais Adicionais

Objetivo: expandir o portfolio fiscal sem acoplar tudo ao CT-e modelo 57.

Inclui:

- CT-e OS.
- GTV-e.
- CT-e Simplificado.
- Modais especiais que nao existirem no primeiro cliente.

## Componentes Internos Esperados

O mapa oficial acima deve virar componentes pequenos:

- Entrada fiscal e conectores.
- Normalizacao de payload externo.
- Orquestracao de emissao.
- Rateio de frete.
- Calculo fiscal.
- Composicao do documento.
- Numeracao e chave.
- XML SEFAZ.
- Assinatura digital.
- Validacao XSD.
- Cliente SEFAZ.
- Interpretacao de retorno.
- Eventos.
- DACTE e QR Code.
- Consulta e distribuicao.
- Contingencia.

## Regra Anti-Monolito

Nao criar uma classe central que faca tudo de CT-e.

Cada funcao oficial deve ser mapeada para uma capacidade interna, e cada
capacidade interna deve ter contrato, command/receiver e miolo proprio quando
precisar de comportamento customizado.

O motor gera bordas. O aplicativo fiscal implementa o miolo.
