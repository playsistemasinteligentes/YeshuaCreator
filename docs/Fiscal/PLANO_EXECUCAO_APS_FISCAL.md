# Plano De Execucao APS -> Fiscal

Este arquivo e a regua curta de execucao. O documento grande permanece como
memoria e justificativa; aqui fica apenas o que sera construido, adaptado ou
limpo em cada step.

## Regra De Trabalho

- Nao mudar DSL/Engine neste ciclo sem decisao explicita.
- Trabalhar sempre por step, fechando uma evidencia antes de avancar.
- APS nao emite CT-e nem MDF-e.
- Fiscal nao consulta tabelas internas do APS.
- ERP externo e mockado, mas o contrato de entrada deve parecer real.
- SOAP/REST legado fica fora deste fluxo; aqui e comunicacao oficial entre
  modulos Yeshua.

## Estados De Implementacao

- `Pendente`: ainda nao atende o desenho.
- `Prototipo`: fluxo existe, mas ainda pode ter dado fixo/mock.
- `Integrado`: conversa com outro modulo pelo caminho oficial.
- `Homologado`: testado com API, worker, banco e evidencia real.
- `Producao`: sem mock obrigatorio e com pendencias criticas resolvidas.

## APS / CargaStandard

| Ordem | Step | Tipo | Construir | Adaptar | Mover ou limpar | Evidencia |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | `AguardarDadosTransporte` | `IntencaoWait` | Comando/endpoint para informar motorista, veiculo, placa, RNTRC, ANTT e dados minimos de transporte. | O teste pode preencher dados minimos automaticamente ate existir tela real. | Remover qualquer dependencia de CT-e/MDF-e deste step. | Step concluido e snapshot da carga com dados de transporte. |
| 2 | `AguardarAgendamento` | `IntencaoWait` | Comando/endpoint para confirmar agenda ou liberar sem agenda quando a carga nao exigir. | Permitir default no smoke para nao travar. | Nao misturar regra fiscal aqui. | Step concluido com data/hora ou motivo de dispensa. |
| 3 | `AguardarInicioCarregamento` | `IntencaoWait` | Comando/endpoint para registrar inicio do carregamento. | O teste deve chamar o fluxo real, nao pular direto para fiscal. | Limpar handlers antigos que tratem criacao de carga como inicio da saga. | Step concluido com data de inicio. |
| 4 | `AguardarFinalizacaoCarregamento` | `IntencaoWait` | Comando/endpoint para finalizar carregamento/romaneio. | Validar que a carga esta pronta para virar snapshot fiscal. | Nao receber NF-e aqui. | Step concluido com carga fechada. |
| 5 | `PrepararCargaParaModuloFiscal` | `Intencao` | Montar snapshot canonico para Fiscal: carga, emitente, tomador, remetente/destinatario, veiculo, condutor, percurso e preferencias fiscais. | Trocar dados fixos por dados persistidos quando os cadastros existirem. | Mover regras de CT-e/MDF-e para Fiscal; APS so prepara o contrato. | Payload `CargaProntaParaEmissaoFiscal` completo. |
| 6 | `PublicarCargaProntaParaEmissaoFiscal` | `Intencao` | Gravar outbox para Fiscal usando contrato versionado `CargaProntaParaEmissaoFiscal.v1`. | Garantir `sagaCorrelationId` de origem no payload. | Remover simulacao direta de retorno fiscal no teste APS. | Outbox APS entregue no Inbox Fiscal. |
| 7 | `AguardarFinalizacaoFiscal` | `IntencaoWait` | Acordar APS ao receber `DocumentosFiscaisDaCargaConcluidos.v1`. | Corrigir ponte APS para esperar este step, nao `PrepararCargaParaModuloFiscal`. | Remover `Fiscal-MOCK` como caminho principal do teste E2E. | Step concluido apos retorno real do Fiscal. |
| 8 | `LiberarCargaParaExpedicao` | `Intencao` | Marcar carga pronta para expedicao/saida. | Consumir evidencias fiscais retornadas: chaves, protocolos, status e XML storage refs. | Nao consultar Fiscal por banco. | Saga APS concluida. |

## APS Step 1 - `AguardarDadosTransporte`

Objetivo: garantir que a carga tenha os dados minimos de transporte antes de
seguir para agendamento, carregamento e snapshot fiscal. Este step nao chama
Fiscal, nao monta CT-e e nao monta MDF-e.

### Microdominios Do Step

| Microdominio | O que precisa para CT-e/MDF-e | O que ja existe hoje | O que falta | Como faremos neste ciclo |
| --- | --- | --- | --- | --- |
| Carga | `CargaId`, numero operacional, status, datas basicas, peso, volume e vinculo com transporte. | `Carga` ja possui `CAR_ID`, `CAR_STATUS`, pesos, volumes, `VEI_PLACA`, `TIP_ID`, `TRA_ID`, `ROT_ID`, datas de entrada/saida e romaneio. | Definir claramente qual status significa transporte informado e qual status libera o proximo step. | Usar a propria `Carga` como fonte principal. Neste step, apenas confirmar ou complementar transporte; no step 5, o builder monta o snapshot fiscal. |
| Transportador | Codigo, CNPJ, razao social, inscricao estadual e RNTRC. | `Transportadora` ja possui `TRA_ID`, `TRA_NOME`, `TRA_CNPJ`, `TRA_INSCRICAO_ESTADUAL`, `TRA_RNTRC`. `CargaFiscalSnapshotBuilder` ja busca por `TRA_ID`. | Garantir que a carga sempre tenha `TRA_ID` quando o fluxo chegar aqui. Validar RNTRC/CNPJ/IE sem misturar regra fiscal pesada no APS. | Se `TRA_ID` faltar, o step continua aguardando. Se existir, registrar confirmacao. Pendencias fiscais finas seguem no payload do step 5. |
| Veiculo | Placa, UF da placa, tipo/categoria operacional e dados que ajudem MDF-e rodoviario. | `Carga` possui `VEI_PLACA` e `TIP_ID`. `Veiculo` possui `VEI_PLACA`, `VEI_UF`, `TIP_ID`, `VEI_MODELO`, capacidade e status. | Confirmar se `TCA_ID` representa categoria/carroceria util ao MDF-e. Validar placa/UF minima. | Buscar veiculo por placa. Neste ciclo, placa e UF sao obrigatorias para concluir o step; demais dados viram pendencia nao bloqueante ate sabermos a regra fiscal completa. |
| Motorista/condutor | Nome e CPF do condutor para MDF-e. | `Veiculo` possui `VEI_NOME_MOTORISTA` e `VEI_CPF_MOTORISTA`. | Pode haver mais de um condutor ou condutor fora do cadastro do veiculo. Ainda nao ha modelo especifico de condutor da carga. | Usar motorista do veiculo como fonte inicial. Se CPF faltar, manter step aguardando ou registrar pendencia conforme decisao do teste. Evoluir depois para condutor vinculado a carga se o caso real exigir. |
| Rota | Municipio/UF origem, municipio/UF destino, codigo IBGE e possivel percurso. | `Carga` possui `ROT_ID`. Existem `RotaPontosMapa`, `PontosMapa` e `Municipio` com `MUN_CODIGO_IBGE`, `UF_COD`, latitude e longitude. | O builder do snapshot ainda nao preenche rota. Falta definir como resolver origem/destino a partir de `ROT_ID`. | Neste step a rota nao bloqueia. `PontosMapa` passa a guardar `MUN_ID`; UF e codigo IBGE continuam vindo de `Municipio`. A montagem detalhada da rota entra no step 5, usando repository/read especifico ou helper custom. |
| Agendamento/janela | Data de agendamento e janela de embarque quando houver. | `Carga` possui `CAR_INICIO_JANELA_EMBARQUE`, `CAR_FIM_JANELA_EMBARQUE`, `CAR_EMBARQUE_ALVO` e `CAR_DATA_AGENCIAMENTO`. | Separar o que pertence ao step 1 do que pertence ao step 2 `AguardarAgendamento`. | Step 1 nao decide agenda. Apenas preserva dados ja existentes. Confirmacao/dispensa de agenda fica no step 2. |
| Preferencias fiscais | Sinais simples: gera CT-e, gera MDF-e, agrupamento, ambiente. | `CargaFiscalSnapshotBuilder` ja tem `PreferenciasFiscais`, mas nao carrega valores reais. | Definir fonte no APS ou configuracao por cliente/carga. | Nao bloquear step 1. No step 5, se faltar, registrar pendencia no payload. |
| Documentos originarios | Nenhum XML/NF-e obrigatorio neste step. Pode haver apenas expectativa de documentos. | `ItenCarga` possui `NOT_ID` e `NOT_EMISSAO`, mas o desenho atual diz que NF-e deve ser tratada pelo Fiscal/ERP. | Decidir futuramente se o APS envia uma lista esperada ou se o ERP manda a ordem completa ao Fiscal. | Nao colocar NF-e no step 1. A espera oficial sera `Fiscal.AguardarDocumentosOriginariosDaCarga`. |

### Alteracoes Previstas No Step

1. Ler a carga por `saga.EntityId`.
2. Validar microdominios bloqueantes para transporte:
   `TRA_ID`, `VEI_PLACA`, veiculo localizado, `VEI_UF`, condutor/CPF quando
   o teste fiscal exigir.
3. Se faltar dado bloqueante, manter o step em espera com payload de pendencias.
4. Se os dados minimos existirem, gravar inbox tecnico de confirmacao para a
   propria saga seguir.
5. Nao criar endpoint novo neste primeiro corte se conseguirmos alimentar os
   dados via CRUD/use case existente da carga.

### Fechamento Do Step

Consideramos `AguardarDadosTransporte` fechado quando:

- a carga possui transportadora, veiculo, placa, UF e condutor minimo;
- o step sai de espera por fluxo real da saga;
- o proximo step `AguardarAgendamento` e alcançado;
- o step 5 consegue montar snapshot fiscal sem pendencia bloqueante de
  transporte.

## APS Step 2 - `AguardarAgendamento`

Objetivo: confirmar que a carga possui uma referencia operacional de
agendamento ou janela de embarque antes de iniciar o ciclo de carregamento.
Este step nao trata Fiscal, NF-e, CT-e nem MDF-e.

### Regra Inicial Implementada

- Ler a carga por `saga.EntityId`.
- Considerar agendamento confirmado quando existir pelo menos uma data valida:
  `CAR_DATA_AGENCIAMENTO`, `CAR_INICIO_JANELA_EMBARQUE`,
  `CAR_FIM_JANELA_EMBARQUE` ou `CAR_EMBARQUE_ALVO`.
- Se nenhuma data existir, manter o step aguardando com payload de pendencias.
- Se existir, gravar inbox tecnico `aps.carga.agendamento-confirmado` para a
  saga seguir.

### Pendencias Do Step

- Criar fluxo real de tela/API para confirmar ou dispensar agendamento.
- Definir quando uma carga pode seguir sem agenda formal.
- Separar agenda operacional simples de regras futuras de doca, janela,
  calendario e capacidade.

## Fiscal / EmissaoFiscalCargaStandard

| Ordem | Step | Tipo | Construir | Adaptar | Mover ou limpar | Evidencia |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | `ReceberCargaProntaParaEmissaoFiscal` | `Intencao` | Consumir Inbox vindo do APS e iniciar/continuar a saga Fiscal pela correlacao de negocio. | Persistir snapshot fiscal minimo da carga. | Nao depender de tabelas internas do APS. | Saga Fiscal criada com payload da carga. |
| 2 | `AguardarDocumentosOriginariosDaCarga` | `IntencaoWait` | Endpoint/command oficial para receber a ordem: carga X usa documentos A, B, C. | ERP externo fica mockado no teste, mas chamando endpoint real. | Nao transformar Fiscal em buscador/correlacionador automatico de NF-e. | Step conclui apenas quando os documentos informados existirem e forem validos. |
| 3 | `PrepararEntradaFiscalDaCarga` | `Intencao` | Consolidar entrada fiscal: carga + documentos originarios + participantes + parametros fiscais. | Substituir mocks por persistencia minima. | Limpar `NormalizarDocumentosOriginarios` se ele virou sobra conceitual; normalizacao pertence aqui ou ao step 2. | Entrada fiscal pronta para CT-e. |
| 4 | `MontarSolicitacoesCTe` | `Intencao` | Definir quantos CT-es serao gerados e por qual regra: normal, complementar, redespacho, globalizado, por nota, por destinatario etc. | Comecar com regra simples homologavel. | Nao misturar XML SEFAZ aqui. | Solicitacoes de CT-e persistidas. |
| 5 | `PrepararCTe` | `Intencao` | Montar dados fiscais do CT-e, numeracao, chave, impostos, totais e XML assinavel. | Usar dados fixos apenas onde ainda nao houver cadastro. | Separar calculo fiscal, rateio e XML em helpers internos do Fiscal. | XML CT-e preparado e armazenado. |
| 6 | `AutorizarCTeNaSefaz` | `Intencao` | Assinar, validar XSD, enviar para SEFAZ homologacao e interpretar retorno. | Usar certificado/config homologacao do Fiscal. | Nao levar codigo SEFAZ para Engine. | CT-e autorizado ou rejeicao fiscal persistida. |
| 7 | `PublicarCTeAutorizadoParaMDFe` | `Intencao` | Publicar snapshot interno para MDF-e com chaves/protocolos dos CT-es autorizados. | Pode ser intra-saga enquanto CT-e e MDF-e estao no mesmo Studio Fiscal. | Nao usar SOAP/REST externo entre CT-e e MDF-e. | Payload pronto para montagem do MDF-e. |
| 8 | `MontarSolicitacaoMDFe` | `Intencao` | Definir solicitacao MDF-e a partir da carga, CT-es, veiculo, condutor, percurso e UF. | Comecar com um MDF-e por carga, salvo regra que exija quebrar. | Nao consultar APS. | Solicitacao MDF-e persistida. |
| 9 | `PrepararMDFe` | `Intencao` | Montar XML MDF-e, chave, totalizadores, modal rodoviario, seguro quando exigido e assinatura. | Reaproveitar prova ja feita no Fiscal/Playground. | Tirar mocks de chave/protocolo. | XML MDF-e preparado e armazenado. |
| 10 | `AutorizarMDFeNaSefaz` | `Intencao` | Enviar MDF-e para SEFAZ homologacao e interpretar retorno. | Usar codigo ja provado de autorizacao MDF-e em homologacao. | Nao misturar encerramento de MDF-e com emissao. | MDF-e autorizado ou rejeicao persistida. |
| 11 | `PublicarDocumentosFiscaisDaCargaConcluidos` | `Intencao` | Publicar retorno para APS com CT-es, MDF-e, protocolos, status e referencias de XML. | Garantir `sagaCorrelationId` original. | Remover retorno mockado do APS. | Inbox APS recebido e APS liberado para expedicao. |

## Fora Da Saga, Mas Necessario

| Item | Onde fica | Por que existe | Situacao |
| --- | --- | --- | --- |
| Recebimento bruto de NF-e/XML | Fiscal | Permite ERP enviar documentos antes ou depois da carga. | Construir minimo persistido. |
| Ordem de vinculo de documentos a carga | Fiscal | Acorda `AguardarDocumentosOriginariosDaCarga`. | Construir/chamar no teste E2E. |
| Storage de XML | Fiscal | Guardar XML enviado/retornado, CT-e e MDF-e. | Construir minimo. |
| Config SEFAZ/certificado | Fiscal | Homologacao CT-e/MDF-e. | Parametros ainda podem ficar simples/fixos neste ciclo. |

## Ordem Pratica Da Proxima Rodada

1. Corrigir a ponte APS para acordar `AguardarFinalizacaoFiscal`.
2. Adaptar o teste `CargaStandard_saga_should_run_with_real_api_and_infrastructure`
   para iniciar no APS e estimular o Fiscal pelo endpoint real.
3. Garantir que `AguardarDocumentosOriginariosDaCarga` seja o unico ponto de
   espera por NF-e/documentos originarios.
4. Persistir o minimo fiscal necessario para CT-e e MDF-e.
5. Trocar mocks fiscais por chamadas SEFAZ de homologacao.
6. Somente depois validar ponta a ponta: APS cria/fecha carga, Fiscal autoriza
   CT-e/MDF-e, APS recebe retorno e libera expedicao.

## Pendencias Que Nao Devem Bloquear O Primeiro Fechamento

- Parametrizacao completa de certificado, endpoint e ambiente.
- Regras avancadas de quebra de MDF-e.
- CT-e complementar, anulacao, substituicao, carta de correcao e cancelamento.
- ERP real; neste ciclo ele sera mockado por chamada HTTP real.
- UI final para todos os steps.
