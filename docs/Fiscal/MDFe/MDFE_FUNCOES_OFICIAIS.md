# MDF-e - Mapa De Funcoes Oficiais

Pesquisa consolidada em 2026-08-28.

Este documento separa servicos oficiais da SEFAZ das capacidades internas que
o modulo Fiscal.MDFe precisa oferecer. O webservice oficial e borda tecnica; o
modulo deve organizar os fluxos por capacidade: encerramento, emissao, eventos,
consulta, nao encerrados, distribuicao, DAMDFE e reconciliacao.

Fontes oficiais usadas:

- Portal MDF-e - Documentos:
  https://dfe-portal.svrs.rs.gov.br/Mdfe/Documentos
- Portal MDF-e - Servicos Web:
  https://dfe-portal.svrs.rs.gov.br/Mdfe/Servicos
- Portal MDF-e - Sobre:
  https://dfe-portal.svrs.rs.gov.br/Mdfe/Sobre
- Portal MDF-e - Legislacao:
  https://dfe-portal.svrs.rs.gov.br/Mdfe/Legislacao

## Leitura Correta

O MDF-e precisa ser dividido em duas camadas:

- Funcoes oficiais: servicos web, eventos, schemas, QR Code, DAMDFE, regras de
  validacao e notas tecnicas.
- Capacidades internas: aquilo que o Yeshua oferece como produto fiscal
  vendavel, operavel e rastreavel.

Exemplo:

- `MDFeRecepcaoEvento` recebe muitos eventos oficiais.
- Internamente, `EncerrarMDFe`, `CancelarMDFe` e `IncluirCondutorMDFe` nao
  devem ser um mesmo miolo com `switch` gigante.

## Servicos Web Oficiais

| Servico oficial | Versao | Papel | Prioridade | Fronteira interna sugerida |
| --- | --- | --- | --- | --- |
| `MDFeRecepcaoEvento` | 3.00 | Recebe eventos como encerramento e cancelamento. | P0/P1 | Eventos isolados |
| `MDFeConsulta` | 3.00 | Consulta situacao por chave. | P0 | Consulta e reconciliacao |
| `MDFeStatusServico` | 3.00 | Consulta disponibilidade do autorizador. | P0 | Diagnostico SEFAZ |
| `MDFeConsNaoEnc` | 3.00 | Consulta MDF-e nao encerrados. | P0/P1 | Operacao de encerramento |
| `MDFeDistribuicaoDFe` | 1.00 | Distribui documentos para atores interessados. | P2 | Distribuicao e reconciliacao |
| `MDFeRecepcaoSinc` | 3.00 | Autoriza MDF-e em fluxo sincrono. | P1 | Emissao normal |
| QR Code MDF-e | - | Consulta publica usada no DAMDFE. | P1 | DAMDFE e consulta publica |

Observacoes:

- A relacao oficial de servicos do Portal MDF-e/SVRS lista SVRS Ambiente
  Nacional como autorizador de producao e homologacao.
- WSDL deve ser obtido adicionando `?wsdl` a URL oficial.
- O primeiro recorte do Yeshua usa `MDFeRecepcaoEvento` para encerramento.

## Matriz Tecnica Inicial Dos Webservices

Antes de codificar cliente definitivo, confirmar cada contrato no WSDL e no
pacote de schemas vigente.

| Servico | Metodo provavel/observado | XML de entrada | XML de retorno | Uso interno |
| --- | --- | --- | --- | --- |
| `MDFeRecepcaoEvento` | `mdfeRecepcaoEvento` | `eventoMDFe` / `evEncMDFe` para encerramento | `retEventoMDFe` | Cancelamento, encerramento e demais eventos. |
| `MDFeConsulta` | pendencia | `consSitMDFe` | `retConsSitMDFe` | Consulta situacao por chave. |
| `MDFeStatusServico` | pendencia | `consStatServMDFe` | `retConsStatServMDFe` | Checar disponibilidade. |
| `MDFeConsNaoEnc` | pendencia | `consMDFeNaoEnc` | `retConsMDFeNaoEnc` | Listar MDF-e pendentes de encerramento. |
| `MDFeDistribuicaoDFe` | pendencia | Schema de distribuicao vigente | Schema de retorno vigente | Distribuicao a atores interessados. |
| `MDFeRecepcaoSinc` | pendencia | `MDFe` | `retMDFe` | Autorizar MDF-e. |

Pendencias:

- pendencia: confirmar nomes de metodos e schemas no WSDL vigente de cada
  servico.
- pendencia: substituir nomes provaveis por nomes extraidos do ZIP de schemas
  oficial baixado.

## Eventos Do MDF-e

Eventos oficiais devem virar commands/receivers separados por capacidade.

| Evento | Codigo conhecido | Papel de negocio | Prioridade | Observacao |
| --- | --- | --- | --- | --- |
| Cancelamento | `110111` | Cancela MDF-e autorizado quando regra permitir. | P1 | Requer protocolo e regra de prazo. |
| Encerramento | `110112` | Informa fim da vigencia/viagem do MDF-e. | P0 | Ja provado no playground. |
| Inclusao de Condutor | `110114` | Inclui condutor no MDF-e autorizado. | P1 | Importante para operacao rodoviaria. |
| Inclusao de Documento Fiscal Eletronico | pendencia | Acrescenta documento fiscal eletronico quando permitido. | P2 | Confirmar codigo e regra vigente. |
| Registro de Passagem | pendencia | Evento fiscal/automatico de passagem. | P2 | Normalmente recebido/consultado, nao gerado pelo emissor comum. |
| Encerramento pelo transportador | pendencia | Encerramento por transportador conforme NT 2024.001. | P1/P2 | Pode ser variacao de encerramento ou fluxo proprio. |
| Confirmacao do Servico de Transporte | pendencia | Confirmacao do contratante. | P2 | Vem da familia MDF-e Integrado/pagamento. |
| Alteracao do Pagamento do Servico | pendencia | Ajusta pagamento declarado. | P2 | Separar de emissao e encerramento. |
| Pagamento da Operacao MDF-e | pendencia | Informacoes de pagamento/contrato. | P2 | Confirmar schema vigente. |
| Eventos SVBA | pendencia | Eventos especificos de acordo de cooperacao. | P3 | Isolar ate haver caso real. |

Os codigos marcados como pendencia nao devem virar constantes ate confirmacao
no schema vigente.

## Familias Oficiais Por Nota Tecnica

| Fonte | Impacto para o modulo | Prioridade |
| --- | --- | --- |
| MOC MDFe 3.00b | Base de servicos, leiaute, eventos, QR Code, DAMDFE e regras gerais. | P0 |
| Anexo I MOC 3.00b | Leiaute e regras de validacao. | P0 |
| Anexo II MOC 3.00b | DAMDFE. | P1 |
| NT 2026.001 | CIOT obrigatorio em determinadas prestacoes rodoviarias. | P1 |
| NT 2025.001 | Ajustes de leiaute, QR Code/CNPJ Alfa, PAA e eventos/pagamentos. | P1/P2 |
| NT DFe CNPJ Alfanumerico | Adequacao transversal de identificadores. | P1/P2 |
| NT 2024.002 | Suporte ao CT-e Simplificado no MDF-e. | P2 |
| NT 2024.001 | Encerramento pelo transportador, documentos por municipio e regras ANTT. | P1/P2 |
| NT 2023.002 | Dados InfraSA no retorno de consulta situacao. | P2 |
| NT 2023.001 | Regras de rejeicao 203 em encerramento e nao encerrados. | P1 |
| NT 2022.002 | PAA. | P3 |
| NT 2022.001 | Contrato, adiantamento e eventos de pagamento/servico. | P2 |
| NT 2020.001 | MDF-e Integrado. | P2/P3 |
| NT 2020.002 | NFF. | P3 |
| NT 2015.002 | Distribuicao aos atores interessados. | P2 |

## Prioridades De Implementacao

### P0 - Encerramento Operavel

Objetivo: encerrar MDF-e autorizado com trilha suficiente para diagnosticar
erro e repetir a operacao com seguranca.

Inclui:

- Resolver endpoint por ambiente.
- Montar evento `110112`.
- Assinar evento.
- Validar XSD.
- Enviar para `MDFeRecepcaoEvento`.
- Interpretar retorno.
- Persistir XML enviado, retorno bruto, protocolo do evento e status.
- Consultar situacao por chave.
- Consultar nao encerrados.

### P1 - Operacao Minima

Objetivo: operar MDF-e rodoviario basico.

Inclui:

- Status do servico.
- Cancelamento.
- Inclusao de condutor.
- DAMDFE basico.
- QR Code.
- Persistencia de manifesto/documentos/veiculos/condutores.
- Configuracao de certificado e ambiente.

### P2 - Emissao Completa E MDF-e Integrado

Objetivo: emitir MDF-e e lidar com exigencias de contrato, CIOT, pagamento,
documentos e reconciliacao.

Inclui:

- `MDFeRecepcaoSinc`.
- Documentos originarios CT-e/NF-e.
- CIOT.
- Vale pedagio.
- Seguro.
- Contratante.
- Pagamentos e confirmacao de servico.
- Distribuicao DF-e.
- InfraSA/DTe.

### P3 - Recortes Especiais

Objetivo: expandir sem acoplar tudo ao rodoviario comum.

Inclui:

- PAA.
- NFF.
- Eventos SVBA.
- Modais especiais pouco usados no primeiro cliente.

## Componentes Internos Esperados

- Entrada fiscal e conectores.
- Normalizacao de payload externo.
- Orquestracao de encerramento.
- Orquestracao de emissao.
- Documentos originarios.
- Modal rodoviario.
- Modal ferroviario.
- Modal aquaviario.
- Modal aereo.
- CIOT, contrato e pagamento.
- Veiculos e condutores.
- Percurso e municipios.
- XML SEFAZ.
- Assinatura digital.
- Validacao XSD.
- Cliente SEFAZ.
- Interpretacao de retorno.
- Eventos.
- DAMDFE e QR Code.
- Consulta e nao encerrados.
- Distribuicao.
- Observabilidade fiscal.

## Regra Anti-Monolito

Nao criar uma classe central `MDFeService` que faz tudo.

Cada capacidade deve ter contrato, command/receiver e miolo proprio quando
precisar de comportamento customizado. O motor gera bordas. O aplicativo fiscal
implementa o miolo.

