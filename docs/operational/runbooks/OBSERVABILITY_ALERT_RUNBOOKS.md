# Runbooks De Alertas De Observabilidade

Estes runbooks tratam os limites fixos iniciais. A linha de base operacional
versionada deve complementar, e nao substituir, os limites de seguranca.

## YeshuaOperationalErrorRateHigh

1. Confirmar servico, ambiente, versao e inicio da degradacao.
2. Separar falha tecnica de rejeicao de negocio.
3. Abrir os traces lentos ou falhos e correlacionar os logs pelo `TraceId`.
4. Verificar dependencia, deploy e recurso de host no mesmo periodo.
5. Corrigir ou reverter somente depois de identificar a borda causadora.

## YeshuaWorkerFailureDetected

1. Identificar Worker, operacao e janela da falha.
2. Consultar logs e traces dos itens falhos sem transformar IDs em labels.
3. Distinguir falha transitoria, rejeicao de negocio e falha definitiva.
4. Usar o retry oficial do fluxo; nao executar handler diretamente.

## YeshuaWorkerBatchPressureHigh

1. Confirmar se a saturacao do lote permanece por varias janelas.
2. Comparar itens capturados, processados, falhos e duracao dos ciclos.
3. Quando houver gauge de backlog do fluxo, confirmar a contagem global.
4. Correlacionar com CPU, memoria, banco e dependencias.
5. Recomendar concorrencia ou hardware somente depois de excluir bloqueio,
   erro repetitivo e dependencia lenta.

## YeshuaWorkerLoopStale

1. Confirmar se a instancia e o container continuam ativos.
2. Verificar `cycle_in_progress` e a idade do ultimo ciclo iniciado.
3. Se o ciclo nao esta em andamento, investigar encerramento do `BackgroundService`.
4. Se o ciclo esta em andamento, seguir o runbook de ciclo travado.

## YeshuaWorkerCycleStuck

1. Correlacionar o inicio do ciclo com trace, dependencia SQL ou chamada externa.
2. Confirmar timeout, lock e cancelamento antes de reiniciar o Worker.
3. Preservar stack, trace e consulta ativa quando o diagnostico estiver autorizado.
4. Corrigir a dependencia ou o limite; nao aumentar concorrencia cegamente.

## YeshuaQueueBlocked

1. Confirmar backlog elegivel positivo e snapshot recente.
2. Confirmar que a vazao agregada de todas as instancias ficou em zero.
3. Verificar Workers indisponiveis, ciclos travados, locks e predicado de elegibilidade.
4. Comparar o metodo diagnostico com o metodo operacional do mesmo repositorio.
5. Nao reprocessar itens manualmente antes de identificar por que nao avancam.

## YeshuaQueueWorkersUnavailable

1. Confirmar que o ultimo snapshot conhecido, preservado por ate quinze minutos,
   ainda registrava backlog elegivel.
2. Verificar estado, reinicios e healthcheck de todas as instancias do Worker.
3. Confirmar configuracao de escopo e se alguma instancia foi removida do deploy.
4. Restaurar pelo menos uma instancia antes de investigar desempenho da fila.

## YeshuaQueueOldestItemHigh

1. Confirmar se o item mais antigo permanece elegivel no snapshot seguinte.
2. Comparar idade, backlog, vazao e taxa de falha do mesmo periodo.
3. Verificar se poucos itens estao doentes ou se toda a fila esta degradada.
4. Evoluir o limite fixo para a linha de base aprovada da fila.

## YeshuaQueueItemCritical

1. Identificar a doenca agregada: processamento travado ou falha terminal.
2. Consultar somente os piores itens pelo metodo diagnostico limitado do mesmo
   repository da fila; nao transformar identificadores em labels Prometheus.
3. Correlacionar `OperationalEntityId`, `RootOperationId` ou `ExecutionId` com
   o trace preservado no Tempo e os logs no Loki.
4. Em falha terminal, distinguir natureza, transiencia, origem e assinatura.
5. Em processamento travado, confirmar lock, dependencia e timeout antes de
   liberar ou reprocessar o item.

## YeshuaQueueItemDegraded

1. Identificar a doenca agregada: espera excessiva, execucao recorrente ou
   falha repetida.
2. Confirmar que o snapshot e recente e que a fila continua com vazao.
3. Consultar uma lista limitada dos piores itens e comparar tentativas, retries
   e idade; nao varrer toda a tabela pelo painel.
4. Abrir o trace preservado quando houver retry, erro ou recuperacao.
5. Ajustar os limites somente depois de formar uma linha de base saudavel.

## YeshuaQueueHealthProbeFailed

1. Verificar conectividade e permissao de leitura do repositorio.
2. Confirmar que a consulta diagnostica usa o mesmo predicado da captura operacional.
3. Medir duracao e plano da consulta antes de reduzir o intervalo de coleta.
4. Ausencia de snapshot nao significa fila saudavel.

## YeshuaQueueHealthSnapshotStale

1. Verificar se o Worker continua vivo e exportando metricas.
2. Confirmar se o probe foi registrado para a fila e se o Collector esta recebendo.
3. Verificar falha de consulta, timeout e indisponibilidade do banco.
4. Tratar a saude da fila como desconhecida ate a coleta voltar.

## YeshuaTelemetryExporterFailure

1. Verificar readiness do Collector, Prometheus, Loki e Tempo.
2. Conferir recusas, fila interna, memoria e falhas por exporter.
3. Validar armazenamento e retencao antes de reiniciar o pacote.
4. Nao interpretar ausencia de sinal como saude da aplicacao.

## YeshuaContainerUnhealthy

1. Confirmar o healthcheck que falhou e o primeiro horario da falha.
2. Correlacionar com logs, traces, consumo de recursos e dependencia externa.
3. Preservar a evidencia antes de reiniciar o container.
4. Tratar o healthcheck como sintoma; corrigir a causa antes de ampliar recursos.

## YeshuaContainerRestartLoop

1. Identificar codigo de saida, motivo e intervalo entre reinicios.
2. Correlacionar o primeiro reinicio com deploy, limite de memoria e dependencia.
3. Verificar se a politica de restart esta mascarando uma falha permanente.
4. Nao aumentar o limite nem desabilitar o healthcheck sem confirmar a causa.

## YeshuaHostCpuSaturated

1. Correlacionar CPU com latencia, vazao e backlog.
2. Identificar servico ou processo que cresceu no mesmo periodo.
3. Verificar deploy recente e dependencia em espera ativa.
4. Aumento de hardware e recomendacao valida somente com saturacao sustentada
   e demanda util comprovada.

## YeshuaHostMemorySaturated

1. Verificar tendencia, paginacao e reinicios.
2. Correlacionar com crescimento de carga e versao implantada.
3. Distinguir cache esperado, vazamento e limite incorreto.
4. Preservar evidencias antes de reiniciar processos.

## YeshuaHostDiskAlmostFull

1. Identificar filesystem e crescimento recente.
2. Conferir retencao dos backends e logs do Docker.
3. Executar somente rotinas de limpeza previamente classificadas como volateis.
4. Nunca remover dados persistentes ou backups para liberar espaco sem
   autorizacao explicita.
