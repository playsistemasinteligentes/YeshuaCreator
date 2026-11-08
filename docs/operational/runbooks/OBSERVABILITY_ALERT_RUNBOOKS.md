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
