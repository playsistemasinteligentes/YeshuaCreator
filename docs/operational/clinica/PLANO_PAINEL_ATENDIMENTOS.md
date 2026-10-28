> Revisão de gravação e estabilidade em 28/10/2026: o núcleo do gravador original
> `spa/components/recording/audio.html` é compartilhado em `session-recorder.js`.
> O áudio é persistido por parte e enviado durante a captura, com fila, backoff e
> pausa quando a fila enche. Não acumular a consulta inteira nem regravar todos
> os Blobs a cada parte. Preservar uma cauda confirmada para a finalização e
> recuperação; limpar a pendência completa somente com IsFinalized + SagaId.
> Falhas de envio não descartam partes. A versão acumuladora anterior tem
> recuperação explícita compatível, sem apagar a origem antes da conversão local.
> Agenda e resultados são consultados somente pelos botões Atualizar: sem polling,
> consulta ao voltar à janela ou ao concluir o upload. A atualização preserva o
> editor, a seleção, a rolagem e os detalhes abertos. Mensagens e controles têm
> espaço estável; os resultados usam uma área de leitura com rolagem própria.
> Validação desta revisão: 12 testes do gravador e ensaio de navegador com captura
> real sintética, envio antes de parar, pausa/retomada, atualização manual e layout
> móvel. Simulação acelerada de 360 partes de 64 KiB (uma hora em partes de 10 s)
> reteve no máximo duas partes no IndexedDB com envio confirmado. Não representa
> uma hora de captura física em celular. Evidência local:
> `.artifacts/clinica-streaming-manual-refresh-result.json`.
>
> Homologação inicial concluída em 28/10/2026: navegador → MediaRecorder (voz sintética,
> pausa e retomada) → chunks C# → OpenAI → resumo Codex → incorporação humana →
> encerramento → finalização → correção → próxima consulta com plano anterior.
> A consulta fictícia #4 manteve o texto humano enquanto o resultado técnico
> chegava; a saga #3 concluiu sem finalizar o prontuário. A incorporação foi
> explícita. Foram verificadas duas revisões, conflito HTTP 409, acesso recusado
> a consulta indisponível e bloqueio de escrita pelo CRUD legado. Nenhum erro
> JavaScript no percurso final; layout conferido em desktop e 1024 px.
> Há 101 verificações automatizadas aprovadas: Engine 52, integração/contratos
> Clínica 38, persistência 3 e gravador 8. A prova no navegador é adicional.
> Dados de demonstração são fictícios: profissional/usuário de homologação #1;
> pacientes #1–#3; consulta anterior #3, consultas do dia #4–#6 e próxima #7.
> A agenda de 28/10 e a próxima consulta de 04/11 estão disponíveis para mostrar.
> Evidências locais: `.artifacts/clinica-live-result.json` e capturas
> `.artifacts/clinica-live-*.png`. Recibo privado e logs de implantação na VPS:
> `/root/YeshuaPrivate/production/operations/clinica-panel-20261027`.
> Commits do painel enviados ao GitHub em 28/10/2026. A implantação descrita acima
> usou transferência direta de commits para a VPS e não comprova o deploy padrão.
> Esse desvio foi rejeitado pelo usuário. O roteiro obrigatório permanece:
> commit local → envio ao GitHub → deploy padrão por `infra/docker/deploy.sh`.
> IDs operacionais persistidos usam N/32 caracteres; a correlação Guid da saga
> usa D/36 e é normalizada no vínculo de leitura ao upload. Não trocar o contrato.
> Front, API, Worker e migration têm alvos de compilação independentes, mantendo
> os mesmos hosts e serviços; uma correção de tela não recompila APIs da Central.

> Versão funcional implementada em 27/10/2026 e homologada na VPS em 28/10/2026.
> Front Central: `Custon/Apps/Clinica/pages/atendimentos.*`. M000005 declara os
> vínculos, horários reais, versão, revisão e Commands do painel. A saga continua
> exclusivamente técnica. O resultado de IA é sugestão; não conclui o prontuário.
> A primeira versão inclui agenda, preparo, histórico/plano anterior, gravação real
> WebM com pausa/retomada e recuperação local, revisão e correção com motivo.
> O vínculo usuário/profissional é configurado pelo Command administrativo
> `VincularProfissional`; não é inferido do usuário criador do cadastro.
> A revisão preserva os campos editáveis deste painel e não copia o diagnóstico
> criptografado para JSON. Os demais campos existentes não são alterados.
> Consultas legadas realizadas admitem revisão sem inventar horários reais.
> Ações de falta usam StatusAgendamento=4; valores 0–3 mantêm seus significados.
> O CRUD de sessões/revisões não pode contornar o painel; consultas clínicas e
> revisões são filtradas por tenant e profissional vinculado.
> O gravador mantém as partes pendentes e uma cauda confirmada no IndexedDB;
> os metadados e a cauda final permanecem até receber IsFinalized e SagaId do C#.
> A recuperação exige o mesmo usuário, tenant e consulta no mesmo navegador.
> O teste automatizado de navegador usa voz sintética como fonte do microfone;
> a validação do dispositivo físico e da autorização do navegador é um ensaio manual.

# Plano do painel de atendimentos do psicólogo

Registrado em 2026-10-27 a pedido do usuário.
Estado: planejamento retomado em 2026-10-27, depois da publicação e homologação
da transcrição OpenAI e do resumo separado pelo Codex. Implementação da tela não
iniciada. A retomada detalha a experiência e a menor sequência de mudanças; não
altera o comportamento publicado do aplicativo.

O detalhamento do ciclo completo, dos campos e das transições está em
[Fluxo alinhado ao banco e à saga](#fluxo-alinhado-ao-banco-e-à-saga).

Decisão confirmada em 2026-10-27: manter o fluxo deste plano, com ações normais
de agendamento, início, encerramento e fechamento. A alternativa de uma saga para
todo o ciclo do atendimento foi discutida e deixada de lado pelo usuário. Isso
não altera a saga técnica de transcrição/resumo existente. O foco volta à tela
customizada e à continuidade clínica descritas abaixo.

A prévia interativa consolidada contempla agenda por data e registros pendentes,
agendamento simples, paciente atual, preparo com origem/data do histórico,
planos anteriores consultáveis ao lado das anotações, modo foco/discreto,
gravação simulada com pausa/retomada, transcrição e sugestão separadas, rascunho,
plano terapêutico, lembrete da próxima sessão e fechamento explícito. Todos os
dados e interações da prévia são demonstrativos; não é a aplicação publicada.
Na navegação demonstrativa foi conferida também a continuidade: fechar um registro
com objetivo, exercício e lembrete e agendar a próxima consulta faz esses dados
aparecerem na preparação seguinte, com a sessão de origem preservada.

## Objetivo e experiência

Criar uma tela customizada chamada **Atendimentos**, orientada à rotina do psicólogo:
preparar a consulta, atender com pouco esforço de interação e fechar o registro.
A tela deve responder rapidamente: quem vou atender, onde paramos, o que combinamos
e o que preciso registrar hoje.

## Composição

| Área | Conteúdo |
| --- | --- |
| Lateral esquerda | Agenda do dia, horários, pacientes e situação das consultas; pode ser recolhida durante o atendimento. |
| Cabeçalho | Paciente selecionado, idade, profissional, horário e identificação da sessão atual. |
| Área central | Preparação, histórico e registro do atendimento. |
| Apoio | Objetivos em acompanhamento, combinados anteriores e lembretes para hoje. |
| Ações da sessão | Salvar rascunho, gravar relato, revisar resultado e fechar consulta. |

Paciente e sessão em edição permanecem identificados. O horário seguinte nunca
troca o paciente automaticamente. Informações cadastrais, contato e financeiro
ficam acessíveis como apoio, sem ocupar o centro do atendimento.

## Preparação antes da consulta

- Último atendimento e intervalo desde aquela sessão.
- Bloco **Onde paramos**, com registro breve deixado pelo psicólogo.
- Objetivos atuais, assuntos a retomar e tarefas/exercícios combinados.
- Encaminhamentos e acompanhamentos pendentes.
- Observações relevantes destacadas pelo profissional.
- Data e acesso à sessão de origem de cada informação.

A primeira versão aproveita os campos existentes de Sesoes, declarados em
`src/Studio/Yeshua.Studio.AppClinicas/Migrations/M000002.cs`: objetivos de curto e
longo prazo, tarefas sugeridas, encaminhamentos e informações para futuras consultas.
A preparação inicial é uma projeção desses registros; não depende de uma chamada
à IA a cada abertura. Para a primeira consulta, mostrar os dados disponíveis e a
ausência de histórico sem inventar informações.

## Histórico e continuidade

Exibir linha do tempo com as sessões mais recentes primeiro, prévias curtas e
abertura de detalhes sem perder o rascunho atual. Diferenciar o registro histórico
de uma sessão dos assuntos que continuam em acompanhamento.

Além da consulta dos textos existentes, propõe-se um pequeno registro de combinado,
vinculado ao paciente e à sessão de origem:

- Descrição do que foi combinado.
- Situação: em acompanhamento, concluído ou interrompido.
- Data para retomar, quando aplicável.
- Observação sobre o resultado.

Esse registro permite acompanhar uma tarefa por várias sessões preservando sua
origem. Sua atualização não reescreve o registro da sessão anterior. O fechamento
inclui **Lembrar na próxima consulta**, usado na preparação seguinte. O modelo de
combinados ainda é proposta e deve ser detalhado antes de implementar.

## Durante o atendimento

- Registro livre com salvamento automático no servidor e indicação de salvo,
  salvando ou falha ao salvar.
- Campos detalhados em seções expansíveis, evitando um formulário longo na entrada.
- Consulta ao histórico ao lado das anotações atuais.
- Proteção contra troca de paciente com alterações ainda não salvas.
- Tratamento de conflito de edição entre abas ou usuários.
- Modo discreto para ocultar detalhes clínicos; a agenda não exibe conteúdo clínico.

Áudio é opcional: gravar um relato do atendimento ou anexar um arquivo, sempre
associado à sessão selecionada. Se houver gravação da conversa com o paciente,
essa modalidade terá identificação e fluxo de autorização próprios. Gravação ativa,
duração e controles de interrupção devem estar visíveis.

## Transcrição, resumo e revisão

Manter transcrição e resumo como duas tarefas independentes:

`Áudio -> transcrição -> resumo sugerido -> revisão do psicólogo`.

Mostrar os resultados separadamente e permitir consultar a transcrição e editar ou
aproveitar o resumo. Falhas de processamento não impedem o registro manual.
Identificar texto do profissional, sugestão da IA e conteúdo revisado.

Adaptações propostas, ainda não implementadas neste planejamento:

- O resumo da IA passa a ser sugestão disponível para revisão. Atualmente,
  `SesoesWriteRepository.ApplyInsight` aplica os três campos e marca
  StatusProntuario como 3 Concluido.
- A finalização clínica depende de ação explícita do profissional.
- Um resultado atrasado não pode sobrescrever rascunho editado ou registro fechado.
- Separar a sugestão recebida do registro aceito pelo profissional, com referência
  à sessão, ao processamento e à versão utilizada.

Isso complementa o executor descrito em [CODEX_EXECUTOR.md](CODEX_EXECUTOR.md).
Não confundir a conclusão técnica da saga com a finalização do registro clínico.

## Fechamento

Permitir revisar o registro, atualizar combinados e deixar o lembrete para a próxima
consulta. Separar três aspectos:

| Aspecto | Situações conceituais |
| --- | --- |
| Consulta | Agendada, realizada, cancelada ou não comparecimento. |
| Registro | Rascunho, pendente de revisão ou finalizado. |
| Áudio/IA | Aguardando, transcrevendo, resumindo, concluído ou falhou. |

Esses nomes descrevem a experiência proposta, não novas enumerações já aprovadas.
O mapeamento proposto dos status existentes está detalhado abaixo, preservando os
valores persistidos e separando o estado técnico da saga. Ainda não foi aplicado.

É possível encerrar o atendimento e finalizar sua documentação depois. Consultas
realizadas com registro pendente aparecem em uma lista própria. Correções depois
da finalização preservam a versão anterior, autor e data. As mesmas regras de
negócio devem valer nos commands e nas demais bordas de escrita do aplicativo.

## Acesso e arquitetura

- Definir vínculo explícito entre usuário autenticado e profissional. Não inferir
  o psicólogo responsável pelo usuário que criou o cadastro.
- Restringir agenda, paciente e histórico pelas permissões validadas no servidor.
- Página customizada no Front Central, declarada por AddCustomPage no módulo PSI,
  seguindo o mecanismo já usado pelo Estúdio Memórias.
- Consultas por repositories; ações por Command + Receiver.
- Salvar e fechar consulta são comandos normais. A saga existente coordena somente
  o processamento assíncrono de transcrição e resumo.
- Alterações da DSL em nova migration; bordas geradas na Engine e miolos protegidos
  em Custon, respeitando a separação atual.
- Não criar outro Front, motor de workflow ou transporte para esse painel.

## Sequência de entrega proposta

1. Agenda e preparação: vínculo profissional/usuário, consultas autorizadas,
   contexto do paciente, histórico e planos já registrados.
2. Registro e fechamento: rascunho no servidor, conflitos, combinados, lembrete
   para a próxima sessão, finalização explícita e revisões preservadas.
3. Áudio e revisão assistida: gravação/upload padrão, consulta dos dois resultados,
   sugestão separada do registro e proteção contra retorno atrasado.

## Retomada: primeira versão da tela

A entrada **Atendimentos**, no módulo PSI, abre o dia do profissional autenticado.
O conteúdo principal muda entre **Preparar**, **Atender** e **Fechar registro**,
mantendo paciente e sessão no cabeçalho. São modos de apresentação da mesma sessão,
sem criar três telas ou três sagas.

| Momento | O que fica visível | Ação principal |
| --- | --- | --- |
| Preparar | Última sessão, onde paramos, último plano registrado, exercícios e pontos para retomar, sempre com a data de origem. | Abrir atendimento. |
| Atender | Anotações atuais e histórico consultável ao lado; objetivos e combinados recolhíveis. | Salvar rascunho. |
| Fechar registro | Revisão do texto, plano para a próxima sessão, situação da consulta e eventual sugestão da IA. | Finalizar registro, por decisão explícita do profissional. |

Agenda à esquerda; paciente e trabalho atual no centro; continuidade à direita.
O modo **Foco na sessão** recolhe a agenda. Em telas estreitas, agenda e apoio
ficam recolhíveis, preservando as ações e a identificação da sessão.
Pendências de documentação ficam acessíveis ao lado da agenda do dia.

Na primeira versão, **Onde paramos**, objetivos e tarefas são leituras dos campos
existentes das sessões anteriores. Um objetivo antigo não recebe automaticamente
o rótulo "ativo": mostrar "último plano registrado" e sua origem. A linha do tempo
exclui a sessão atual e distingue sessão anterior de agendamento futuro. Ausência
de histórico, plano ou vínculo com paciente tem estado vazio explícito.

O lembrete para a próxima sessão usa `InformacoesRelevantesFuturasConsultas`;
objetivos, exercícios e encaminhamentos usam os campos já declarados em M000002.
O cadastro independente de combinados fica para a entrega seguinte, quando haverá
acompanhamento de situação entre sessões. A primeira entrega não promete marcar
um item como concluído por várias sessões usando apenas textos antigos.

### O que a conferência do código confirmou

- A página customizada ainda não existe: a extensão do Clínica está vazia.
- `AddCustomPage` já atende ao menu e à permissão; Memórias fornece um exemplo
  representativo. A página pertence ao Front Central.
- M000002 já declara paciente, agenda, profissional, registro e plano terapêutico.
  `Profissional` não possui vínculo explícito de acesso; `UserId` standard não
  deve ser interpretado como o profissional responsável.
- M000004 já declara os dois processamentos assíncronos. A tela deve consumir
  essa infraestrutura homologada.
- A transcrição e o resultado de resumo já passam pelo payload dos respectivos
  steps. Uma consulta autorizada do aplicativo pode projetar esses resultados;
  não é necessário outro serviço ou repositório de documentos para mostrá-los.
- `SesoesWriteRepository.ApplyInsight` escreve os três campos e define
  `StatusProntuario=3`. `MarkInsightPending` também muda esse status quando começa
  outro processamento. Ambos precisam ser adaptados antes de ligar a IA à nova
  edição humana: processar áudio não deve alterar a finalização clínica.

### Menor adaptação de domínio proposta

1. Vínculo de acesso explícito em `Profissional`, por usuário e tenant, provisionado
   conscientemente. Não preencher a partir do criador do cadastro. Sem vínculo,
   orientar a configuração; não liberar a agenda inteira como alternativa.
2. Versão de edição do registro e identificação da finalização pelo profissional
   (autor e data), declaradas em nova migration. Salvar e finalizar exigem a versão
   esperada. Divergência devolve conflito e conserva o texto local para comparação.
3. Preservação de uma revisão identificada ao finalizar. Correção de registro
   finalizado exige ação própria, motivo e nova revisão, mantendo a anterior.
   Não criar um motor de versionamento ou event sourcing para esse caso.
4. Sugestão da IA consultada pelo processamento associado à sessão. Recebê-la
   conclui somente o step técnico. O profissional pode inserir trechos no rascunho,
   mantendo a referência ao processamento utilizado, e então revisá-los.

Não alterar o significado dos números já persistidos de `StatusAgendamento` e
`StatusProntuario`. Para novos registros, 2 Pendente e 3 Concluido continuam úteis;
o fechamento humano ganha autor/data e é a única operação que o confirma. Um 3
legado sem essa identificação não comprova revisão humana: mostrar a origem antiga
sem fabricar autor ou data. "Não compareceu" já existe em `StatusProntuario=1`;
a proposta abaixo acrescenta 4 no agendamento e mantém esse valor legado de
prontuário, sem renumerar dados. A proposta detalhada abaixo resolve "em
atendimento" pelos novos horários reais de início e encerramento, preservando
os horários agendados. Esses campos ainda não existem no aplicativo publicado.

Essas regras precisam cobrir também CRUD e demais bordas de escrita. Um Update
genérico não pode sobrescrever um registro finalizado nem ignorar a versão. O
primeiro incremento de leitura pode sair antes; a edição só entra junto das
proteções, inclusive nos retornos da IA já publicados por outras telas. Adaptar
`ApplyInsight` e `MarkInsightPending` antes de habilitar a edição humana: não deixar
uma janela em que o painel protege o rascunho, mas um processamento antigo ainda
consegue substituí-lo por SQL direto. Não adicionar um StepWait humano à saga de IA.

### Contratos e pontos de implementação

Os nomes abaixo são propostas para Commands/Receivers normais do módulo PSI,
não endpoints manuais novos nem serviços separados:

| Intenção | Dados/retorno mínimos |
| --- | --- |
| ConsultarAgendaAtendimentos | Data e pendências; servidor resolve o profissional e retorna somente sessões autorizadas, sem textos clínicos na lista. |
| ConsultarAtendimento | Sessão; devolve paciente, rascunho e versão, preparação, histórico paginado e resultados de IA permitidos. |
| IniciarAtendimento | Sessão e versão esperada; valida o vínculo e o agendamento, registra início real uma única vez. |
| EncerrarAtendimento | Sessão e versão esperada; registra fim real e consulta realizada, mantendo a documentação pendente. |
| SalvarRegistroAtendimento | Sessão, versão esperada e campos editáveis; devolve nova versão e confirmação de salvamento. |
| IncorporarSugestaoAtendimento | Sessão, processamento/resultado escolhido, campos e versão esperada; aplica a escolha explícita ao rascunho e registra sua origem. |
| FinalizarRegistroAtendimento | Sessão, versão esperada e confirmação humana; valida e persiste a revisão e a finalização atomicamente. |
| CorrigirRegistroAtendimento | Sessão, versão e motivo; inicia correção preservando o registro final anterior. |

Leituras passam pelo repository do aplicativo; escritas, pelos repositories e
behavior do domínio. Servidor valida tenant, vínculo profissional, sessão e acesso
ao paciente/histórico em cada operação. Não basta esconder a página ou filtrar a
agenda no navegador. Abrir um atendimento não deve criar consulta automaticamente.

Página prevista em `wwwroot/Custon/Apps/Clinica/pages/atendimentos.{html,css,js}`, com
registro em `Apps/Clinica/extensions.js` e âncora `AddCustomPage` em nova migration.
Os arquivos reais só serão criados na implementação. O componente genérico de áudio
continua responsável pela captura/upload; a nova página fornece o contexto da sessão.

O rascunho é salvo no servidor após pausa na edição, com no máximo um salvamento
em voo por sessão e ordenação das respostas. Não persistir textos clínicos em
`localStorage`. Erro ou expiração de login conserva o texto em memória e impede
anunciar "salvo". Troca de paciente com falha pendente exige escolha explícita.
Resultados de IA atualizam a área de sugestões, sem substituir o editor. A leitura
de status usa o mecanismo existente de acompanhamento; não criar outra fila ou
infraestrutura de notificações para a página.

### Ordem concreta de execução quando a implementação for iniciada

1. Declarar acesso/página e o vínculo profissional; entregar agenda, preparação e
   histórico somente leitura com estados vazios e restrição no servidor.
2. Introduzir edição com versão, regras nas bordas, revisão e fechamento humano;
   adaptar também as escritas atuais de `ApplyInsight`/`MarkInsightPending` para
   preservar o registro. Validar o atendimento manual completo e respostas antigas
   em voo antes de habilitar a edição.
3. Conectar gravação/upload existentes e a projeção dos dois resultados; adaptar
   a apresentação do fluxo antigo à conclusão técnica separada da revisão humana.
   Repetir a homologação da saga publicada e os cenários de retorno atrasado.
4. Evoluir combinados estruturados e seu acompanhamento entre sessões.

Os cenários de aceitação adicionais são duas abas editando a mesma sessão, resposta
de salvamento atrasada, retorno da IA após edição/finalização, novo áudio na mesma
sessão, sessão com paciente ausente, agenda sem consultas, data na fronteira do dia
e troca indevida de identificadores. Todos preservam o registro humano e o isolamento
de acesso. A hora/data da agenda deve usar o fuso configurado para a clínica.

O conjunto inicial de agenda, registro e fechamento deve permitir atender e
documentar uma consulta inteira manualmente.

## Fluxo alinhado ao banco e à saga

Este é o detalhamento de planejamento solicitado após a prévia da tela. As
mudanças de banco e de comportamento descritas nesta seção ainda não foram
implementadas. O fluxo publicado continua sendo o registrado em
[OPENAI_TRANSCRIPTION.md](OPENAI_TRANSCRIPTION.md).

### Uma sessão, três acompanhamentos diferentes

`Sesoes` continua sendo a entidade da consulta desde o agendamento. A tela não
cria outra Consulta, outra SessaoAtendimento ou uma saga de agendamento.

- A consulta acompanha horário reservado, início real e encerramento real.
- O registro acompanha rascunho, revisão e finalização pelo profissional.
- Cada áudio acompanha upload e sua saga de transcrição/resumo.

Abrir a ficha não inicia o atendimento. Iniciar atendimento não liga o microfone.
Parar a gravação não encerra a consulta. Encerrar a consulta não finaliza o
registro. Concluir a saga não executa nenhuma dessas decisões humanas.

### Do agendamento ao fechamento

| Etapa / ação na tela | Persistência e regra proposta | Relação com a saga |
| --- | --- | --- |
| Agendar | Inserir `Sesoes` com paciente, profissional, serviço quando aplicável e intervalo previsto. `StatusAgendamento=0` em conciliação, ou 1 quando já confirmado; `StatusProntuario=2`. Validar intervalo e conflito de agenda atomicamente no repository. | Não cria saga. |
| Confirmar ou reagendar | Usar a escrita normal de `Sesoes`, com behavior e versão esperada. Confirmar define 1; reagendar altera somente os horários previstos antes do início. | Não cria saga. |
| Abrir / Preparar | Consultar a mesma sessão e o histórico autorizado. Não gravar início nem marcar presença por navegação. | Pode consultar processamentos existentes. |
| Iniciar atendimento | Command explícito valida paciente, profissional e confirmação. Persiste `AtendimentoIniciadoEm`, mantém `AtendimentoEncerradoEm=NULL` e incrementa a versão. Repetir o mesmo início devolve o início existente, sem trocar a hora. | Não cria saga. |
| Gravar | Ação opcional abre upload para essa sessão e inicia a captura existente. Pausar/retomar conserva o mesmo upload. A autorização da modalidade de gravação segue o fluxo funcional previsto neste plano. | Ainda não cria saga. |
| Parar gravação / concluir envio | Componente termina a captura; C# recebe todas as partes, recompõe o áudio e confirma a finalização do upload. A confirmação devolve `SagaId` e `SagaCorrelationId`. | Cria uma `PsychologySessionInsight` para esse upload. Repetição do último chunk devolve a mesma saga. |
| Encerrar atendimento | Após salvar as anotações pendentes e parar a captura local, Command persiste `AtendimentoEncerradoEm` e `StatusAgendamento=2`. O envio de partes e a IA podem continuar depois. `StatusProntuario` continua 2 até o fechamento humano. | Não espera terminar e não encerra a saga. |
| Revisar resultados | Transcrição e sugestão aparecem separadas. Incorporar uma sugestão exige escolher resultado/campos e confirmar a versão atual; não substitui texto silenciosamente. | Consulta resultados dos dois steps já persistidos. |
| Finalizar registro | Command exige consulta encerrada, versão atual e revisão explícita. Salva a revisão, autor e data e define `StatusProntuario=3` na mesma transação. Pode ser feito manualmente sem áudio/IA. | Não chama o executor nem reabre steps. |

Agendar/confirmar/reagendar aproveitam o CRUD quando ele expressar a intenção e
executar as mesmas regras. Os Commands específicos de iniciar, encerrar e
finalizar existem porque essas intenções mudam comportamento, e não por serem
novos nomes para Update. Paciente e profissional não podem ser trocados depois
do início pelo Update genérico. `DisponibilidadeAgenda` continua sendo a indicação
de disponibilidade; sua existência não substitui a reserva/conferência do intervalo
em `Sesoes`, inclusive quando dois usuários agendam ao mesmo tempo.

O profissional pode encerrar a conversa e terminar a documentação posteriormente.
A lista **Registros pendentes** considera consultas realizadas, não canceladas,
com documentação ainda pendente; não inclui todo agendamento futuro que recebeu
`StatusProntuario=2`. Finalizar enquanto houver processamento pendente exige
revisão do que já foi escrito e indicação clara de que o resultado posterior não
será incorporado automaticamente. Falha de upload ou IA permite concluir o registro
manual. Um relato complementar depois do atendimento utiliza outro upload vinculado
à mesma sessão; não reabre os horários reais nem o registro já finalizado.

### Campos de banco: aproveitar e acrescentar somente o necessário

Os nomes novos abaixo são a proposta para a próxima migration da DSL. Não editar
M000002 ou renumerar M000004 já aplicadas. `Changed` guarda data/hora de alteração;
não existe hoje um contrato de concorrência otimista para o painel baseado nesse
campo. A versão inteira proposta torna a condição de atualização explícita.

| Local | Campo / estrutura | Uso |
| --- | --- | --- |
| `Sesoes` — existentes | `PacienteId`, `ProfissionalId`, `ServicoId`, `DataInicio`, `DataFim` | Identidade e horário previsto; não substituir pelo horário real. |
| `Sesoes` — existentes | `StatusAgendamento`, `StatusProntuario` e campos clínicos/terapêuticos | Manter valores e textos existentes; rascunho/manual permanece nesses campos. |
| `Profissional` — novo | `UsuarioAcessoId`, opcional, FK `yUser` | Vínculo explícito, único por usuário/tenant entre profissionais não excluídos; configurado, não inferido do `UserId` criador. |
| `Sesoes` — novos | `AtendimentoIniciadoEm`, `AtendimentoEncerradoEm`, opcionais | Horários reais; o intervalo agendado permanece preservado. |
| `Sesoes` — novo | `VersaoAtendimento`, inteiro, inicial 0 | Uma única versão para mudanças da sessão, incluindo agenda, início/fim, rascunho e finalização. Commands recebem `versaoEsperada`; atualização é condicional e incrementa a versão. |
| `Sesoes` — novos | `RegistroFinalizadoEm`, `RegistroFinalizadoPorUserId`, opcionais | Evidência da finalização humana, sem inferi-la de `StatusProntuario=3` legado. |
| `Sesoes` — novo | `SugestoesIncorporadas`, metadata opcional de formato fixo | Referências dos resultados expressamente incorporados: saga, step, tentativa, requestId quando disponível e campos escolhidos. Não armazena credenciais, áudio nem outra cópia de toda a resposta. |
| `RevisaoRegistroSessao` — nova, específica do Clínica | Sessão, número/versão, autor, data, motivo de correção quando houver e snapshot clínico versionado | Preservar cada fechamento e suas origens. Snapshot com contrato estático, respeitando proteção dos campos, inclusive `UserEncryptedField`; nunca copiar diagnóstico protegido para JSON em claro. |

Os horários reais e metadados novos usam UTC do servidor. A agenda usa o fuso
configurado para a clínica. O significado de `DataInicio`/`DataFim` legado deve ser
conferido antes de converter dados; não deslocar horários existentes em lote.
Versão, autor e datas de finalização são controlados pelo servidor, inclusive no
CRUD; o navegador não pode preenchê-los para simular um fechamento.

A revisão é imutável e sua escrita pertence aos Commands de fechamento/correção;
não oferecer edição/exclusão genérica desse histórico. Consultas legadas já
realizadas, mas sem horários reais, precisam de uma ação identificada de revisão
do legado para concluir documentação pendente. Não inventar início/fim a partir
do horário agendado. Os novos atendimentos seguem a sequência explícita de
início e encerramento; o CRUD não pode produzir uma realizada sem esses fatos.

Não criar tabela de Transcricao ou de Resumo para esta entrega: os resultados
técnicos já pertencem aos steps. Texto aceito continua em `Sesoes`; o snapshot de
fechamento fica em `RevisaoRegistroSessao`. Assim, preservar o registro clínico não
depende da retenção dos payloads técnicos ou do áudio volátil. Não duplicar os
campos de plano/tarefas; combinados estruturados continuam na evolução posterior.

### Mapeamento de situações para os dados

| Situação apresentada | `StatusAgendamento` | `StatusProntuario` | Identificação complementar |
| --- | --- | --- | --- |
| Aguardando confirmação | 0 | 2 | Sem horários reais. |
| Agendada / confirmada | 1 | 2 | Sem início real. |
| Em atendimento | 1 | 2 | Início real preenchido e fim real ausente. Não acrescentar enum para esse estado derivado. |
| Consulta realizada, registro pendente | 2 | 2 | Início/fim reais preenchidos nos novos atendimentos. |
| Registro finalizado | 2 | 3 | Autor/data de finalização e revisão correspondente. |
| Cancelada antes de iniciar | 3 | 0 | Não é consulta realizada e não exige transcrição. |
| Não compareceu | **4 — extensão aditiva proposta** | 1 | Mantém o valor legado de prontuário por compatibilidade; a nova situação da consulta passa a ser explícita. |
| Concluído no fluxo antigo | Valor preservado | 3 | Sem autor/data novos: mostrar origem legada, sem afirmar revisão humana. |

Os valores existentes 0–3 de agendamento e 0–3 de prontuário não mudam de sentido.
A proposta de adicionar 4 em agendamento evita representar ausência como consulta
confirmada ou cancelamento. Não migrar registros antigos por simples coincidência
de um status: conferir as combinações e tratar inconsistências em transição
explícita. Cancelamento e não comparecimento aplicam-se antes do início; depois
dele é necessário registrar o encerramento do atendimento efetivamente ocorrido.

**Pendente de revisão da IA** é uma apresentação derivada: existe sugestão
concluída ainda não incorporada/revisada. Não é novo número de `StatusProntuario`.
Gravando/pausado descrevem a captura no navegador; `yFileUpload.Status=0` significa
upload pendente e não comprova que algum microfone está ativo.

### Vínculos e caminho exato da saga

```text
Paciente + Profissional
          |
          v
        Sesoes 1 -------- N yFileUpload
          |                  EntityType = "Sesoes"
          |                  EntityId   = Sesoes.Id
          |                  OperationalEntityId identifica o upload
          |
          +------------- N ySaga (uma por upload finalizado)
                             EntityType = "Sesoes"
                             EntityId   = Sesoes.Id
                             CorrelationId = OperationalEntityId do upload
                             ProcessingScope = escopo atual
                             |
                             +-- step 1: transcrição
                             +-- step 2: resumo
```

Não adicionar um `SagaId` único em `Sesoes` como se toda a consulta tivesse apenas
um processamento. Pausar/retomar um áudio conserva o upload; parar e iniciar outro
produz outro upload e outra saga. A tela lista os resultados com sua origem. Dois
áudios não têm seus textos combinados automaticamente nesta versão, e o retorno
mais recente não ganha permissão para substituir o registro.

```text
Áudio completo confirmado pelo C#
  -> PsychologySessionInsight
  -> step audioTranscriptRequested
  -> Outbox "audio.transcribe"
  -> Strategy do transporte -> API OpenAI
  -> Inbox -> transcrição no payload do primeiro step
  -> step reportEndProntuaryRequested
  -> Outbox "session.summarize" -> fila text.summarize.outbox
  -> Codex -> Inbox -> sugestão validada no payload do segundo step
  -> saga tecnicamente concluída
  -> profissional pode consultar, incorporar e revisar a sugestão
```

Os dois steps permanecem `IntencaoWait`. Suas intenções são solicitar transcrição
e resumo; os fatos recebidos são `audio.transcription.completed` e
`text.summarize.completed`. A espera corresponde ao retorno externo por Inbox.
As publicações na Outbox são pedidos ao executor, não o fato de que uma consulta
ou registro foi finalizado. Não renomear chaves/steps já persistidos nem acrescentar
um wait humano ao fim dessa saga. O fechamento é um Command normal da sessão.

A transação existente de conclusão do upload conserva os metadados finalizados e
a criação da saga. O arquivo é recomposto no storage; não afirmar que o sistema
de arquivos e o banco formam uma transação única. Repetir finalização já confirmada
reutiliza a mesma associação. Retries do resumo retomam apenas o segundo step;
áudio volátil ausente exige reenvio explícito, sem simular retomada bem-sucedida.

### Projeção da tela e contrato dos resultados

`ConsultarAtendimento` devolve situação da consulta, situação do registro e uma
coleção de uploads/processamentos autorizados. Cada item identifica a origem,
situação do upload, os dois steps e os resultados já disponíveis. Não devolver
Outbox/Inbox inteiras ou um `ySaga.Payload` arbitrário para o navegador interpretar.
Não inferir conclusão pelo último horário de gravação nem por `StatusProntuario`.

| Indicação na tela | Fonte da informação |
| --- | --- |
| Gravando / pausado | Estado real do componente de captura local. |
| Envio pendente | Partes locais/confirmadas e `yFileUpload.Status=0`; sem afirmar microfone ativo. |
| Transcrevendo / aguardando resultado | Situação do primeiro step e de sua entrega externa. |
| Transcrição pronta; resumo pendente | Primeiro step concluído; segundo ainda não concluído. Permitir consultar a transcrição mesmo se o resumo falhar. |
| Sugestão disponível para revisão | Segundo step concluído com resultado válido. |
| Falha e opção de retomada | Saga/step em falha; retomar pelo Command de retry existente, com as restrições de acesso/escopo já implementadas. |

O contrato externo continua limitado a `Prontuario` (8000), `QueixaPrincipal`
(1000) e `RegistroDocumental` (8000). Objetivos, tarefas, encaminhamentos e lembrete
da próxima sessão usam os campos existentes e a edição do profissional; esta
entrega não promete que o resumo preencha todo o plano terapêutico automaticamente.

### Ajustes necessários para esse fluxo funcionar na tela

O componente atualmente aberto por `crudActions.js` é `components/recording/audio.html`.
A conferência encontrou pontos concretos de integração, não uma necessidade de
substituir a captura ou a junção:

1. `startUploadSession()` envia `{}` para uma URL raiz. Deve receber o contexto
   explícito `entityType="Sesoes"`, `entityId` salvo e a base lógica do Clínica
   fornecida pelo Front Central. Não enviar dados clínicos pela query string de
   `loadActionContent`, nem passar o formulário inteiro como contexto da gravação.
2. `sendChunk()` hoje devolve somente `res.ok`. Deve ler a resposta, confirmar
   `Success`, e na finalização exigir `IsFinalized`, `SagaId` e
   `SagaCorrelationId`. Mostrar "áudio recebido/processando" nesse ponto.
   HTTP 200 ou fila local vazia não significam transcrição concluída.
3. O último chunk deve ser marcado final somente após `MediaRecorder.stop` e a
   persistência dos blobs finais. Se o último já tiver sido enviado sem a marca,
   conservar/reenviar essa parte com `IsFinalChunk=true` no contrato existente,
   aguardando a confirmação do servidor. Não criar endpoint de finalização à parte.
4. O estado de recuperação precisa conservar associação à sessão, usuário/tenant
   e upload original. Recuperar envio não troca o paciente selecionado nem inicia
   outro processamento. Exaurir tentativas não pode descartar uma parte e anunciar
   upload completo; informar a falha e permitir recuperação explícita.
5. A página recebe a confirmação para acompanhar essa saga e projetar seus
   resultados pela consulta autorizada. A captura continua genérica; C# continua
   juntando as partes. Não enviar os chunks individuais à OpenAI.
6. Abertura/fechamento do componente deve ter ciclo controlado, sem repetir
   listeners ou iniciar outro envio ao renderizar o painel. Reutilizar o componente
   com contexto e descarte definidos, mantendo seus controles de pausa e retomada.

### Ajustes de escrita antes de liberar edição humana

- `SendFileHandler` hoje chama `MarkInsightPending`, que define
  `StatusProntuario=2`. A finalização de um novo áudio deve apenas criar o
  processamento; não reabrir registro clínico finalizado.
- `ReportEndProntuaryRequestedHandler.CustomApplyResponse` hoje chama
  `ApplyInsight`, que substitui três campos e define `StatusProntuario=3`.
  Passa a validar/conservar a sugestão no step, sem atualizar esses campos.
- `IncorporarSugestaoAtendimento` verifica sessão/tenant/acesso, resultado
  concluído escolhido e versão atual. O padrão é adicionar a seleção; substituição
  de campo exige escolha explícita. Repetir a mesma incorporação não duplica texto.
- `FinalizarRegistroAtendimento` faz atualização condicional e grava snapshot e
  metadados no mesmo commit. Repetição do fechamento confirmado devolve o resultado
  existente, sem criar outra revisão. Edição de finalizado exige correção explícita.
- Sugestões atrasadas ou de outro upload permanecem consultáveis, sem tocar no
  registro. Nenhuma borda genérica pode contornar essas regras.

A mudança alcança o comportamento do fluxo de áudio antigo; não criar uma exceção
que continue preenchendo/finalizando automaticamente só porque o áudio veio de
outra tela. Na publicação, adaptar os handlers e as telas que apresentam esse
resultado juntos. Pedidos/retornos em voo mantêm seus contratos e terminam
tecnicamente; a conclusão humana segue o modelo novo.

### Ordem de implementação e verificação desse alinhamento

1. Nova migration do Clínica declara página/acesso, vínculo profissional, campos
   reais/versão/finalização, revisão e a extensão aditiva de não comparecimento.
   Inspecionar registros legados antes de qualquer backfill. Engine gera as bordas;
   SQL e concorrência ficam nos repositories; miolos em `Custon`.
2. Implementar as regras únicas de escrita e as proteções aos retornos de IA antes
   de liberar o editor. Entregar agendamento, preparação, início, encerramento e
   fechamento manual.
3. Integrar o componente de gravação ao contexto e à confirmação já existentes,
   depois projeção dos dois resultados e incorporação por decisão humana.
4. Reexecutar a homologação real da saga e acrescentar a jornada pela tela. O smoke
   atual que espera `StatusProntuario=3` imediatamente após a saga deverá passar a
   esperar 2, e somente depois do Command humano verificar 3 e a revisão persistida.

Cenários centrais: reagendamento concorrente, duplo início/encerramento,
gravação pausada, último blob chegando depois de stop, último chunk repetido,
recuperação de upload, dois áudios na mesma sessão, falha só no resumo, falha na IA
com fechamento manual, finalização antes do resultado e duas abas editando. O
isolamento por tenant/profissional e a versão são verificados no servidor em toda
ação; o menu e o estado do navegador não concedem acesso.

## Critérios para validar quando a implementação começar

- Identificar a próxima consulta e recuperar contexto sem abrir vários cadastros.
- Consultar sessão anterior mantendo o rascunho atual.
- Manter combinados pendentes entre sessões com origem identificável.
- Tratar falha de salvamento e conflito sem sobrescrita silenciosa.
- Impedir acesso indevido ao trocar identificadores enviados pelo navegador.
- Fechar uma consulta manualmente sem depender da IA.
- Receber a transcrição e o resumo separadamente; o resumo não finaliza sozinho.
- Preservar edição humana e registro final quando chegar um resultado atrasado.

## Modelos e serviço habitual — implementação de 28/10/2026

`M000006` acrescenta o modelo ao serviço e o serviço habitual opcional ao
profissional. Os modelos implementados são Psicologia completa (ID 1, versão 1)
e Registro simplificado (ID 2, versão 1). O segundo apresenta registro da sessão
e próximos passos; a finalização exige registro preenchido, atendimento encerrado
e revisão humana. Consultas legadas sem modelo preservam o comportamento 1/1.

O modelo não é perguntado no agendamento. `ConsultarAtendimentos` traz ID/nome do
serviço habitual e modelo/versão pela consulta existente do profissional. Abrir
o agendamento com esse contexto não chama APIs nem conta serviços. Sem habitual,
ou ao solicitar Alterar serviço, `ConsultarServicosAgendamento` consulta as opções
uma vez e o painel as mantém em memória. Uma opção é escolhida automaticamente;
várias exigem seleção. Catálogo vazio impede confirmação e orienta o cadastro.

Usar como habitual chama `DefinirServicoHabitual`, limitado ao profissional do
usuário autenticado no mesmo tenant. Escolher a cada agendamento remove essa
preferência. O vínculo é protegido no CRUD; não pertence ao token nem a uma
configuração genérica do login. O botão Atualizar renova o habitual e invalida
as opções sem recriar o editor. Troca de identidade exige reabrir o painel.

`AgendarAtendimento` recebe serviço e modelo/versão apresentados pela tela. Um
único INSERT/SELECT valida tenant, paciente, profissional, serviço, modelo e
conflito de horário e captura o nome e o modelo da consulta. Serviço excluído ou
modelo alterado entre leitura e confirmação exige atualizar; não há substituição
silenciosa. Alterações posteriores no serviço não reinterpretam a consulta.

Gravação em partes, transcrição, resumo e saga continuam pelo mecanismo existente.
O resumo mantém o contrato canônico das três sugestões; no modelo simples, sua
incorporação explícita reúne o texto no registro da sessão, respeitando o limite
do campo e preservando o texto humano. A IA não finaliza o registro.

Esta entrega usa os cadastros existentes e a configuração do habitual no painel.
A saga de configuração inicial discutida anteriormente foi implementada em M000007;
o detalhamento abaixo substitui a pendência registrada na entrega dos modelos.

## Configuração inicial — correção de 28/10/2026

O painel identifica na leitura existente a falta de profissional vinculado,
clínica ou serviço e apresenta o assistente, sem tratar esse estado de cadastro
como falha de abertura do aplicativo. Mais de um profissional para o mesmo acesso
exige correção administrativa, sem escolha automática ou troca de tenant.

`ConfiguracaoInicialClinica` tem três intenções com espera por confirmação humana:

1. Confirmar o estabelecimento e estrutura individual/equipe.
2. Confirmar/criar o profissional e vinculá-lo ao próprio usuário autenticado.
3. Confirmar/criar o serviço, seu modelo e o habitual; validar os vínculos antes
   de concluir e abrir a agenda.

Cada fase é um `StepWait.HttpApi.Immediate`, usa Command normal e o invocador
compartilhado. O fato `clinica.configuracao.confirmada.v1` fica na Inbox na mesma
transação do cadastro. A saga continua pelo executor existente; nenhum novo
worker, transporte, cache no login ou runner foi criado. Reabertura retoma a saga
do tenant/usuário/escopo. Repetir o mesmo input da etapa não duplica cadastro/fato;
alterar uma etapa já confirmada exige voltar aos cadastros normais.

O assistente reaproveita escolhas existentes e não adivinha qual profissional é
do usuário. O escopo administrativo `clinica.atendimentos.configurar` controla
as confirmações. Quem não o possui recebe orientação para pedir o vínculo ao
administrador, sem falhar todo o aplicativo. Especialidade e grupo de serviço
são opcionais. Psicologia é a modalidade disponível; odontologia e medicina não
ganham formulários fictícios nesta entrega. A expansão da equipe usa os cadastros
existentes; uma saga específica de expansão continua uma evolução futura.

Validação: 62 testes de backend, navegador com três fases e retomada após reload,
reuso dos cadastros, atualização preservando campos, isolamento de contexto e
orientação sem autorização. A regressão do painel e da gravação em partes passou.


