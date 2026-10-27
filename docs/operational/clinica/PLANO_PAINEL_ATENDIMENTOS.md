# Plano do painel de atendimentos do psicólogo

Registrado em 2026-10-27 a pedido do usuário.
Estado: proposta de planejamento preservada; implementação da tela não iniciada.
O trabalho atual volta à transcrição. Este plano não autoriza alterações de domínio,
da saga ou da interface nesta etapa.

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
  `SessionInsightWriteRepository.ApplyInsight` aplica os três campos e marca
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
O mapeamento dos status existentes será definido na modelagem, preservando os
valores persistidos e separando o estado técnico da saga.

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

O conjunto inicial de agenda, registro e fechamento deve permitir atender e
documentar uma consulta inteira manualmente.

## Critérios para validar quando a implementação começar

- Identificar a próxima consulta e recuperar contexto sem abrir vários cadastros.
- Consultar sessão anterior mantendo o rascunho atual.
- Manter combinados pendentes entre sessões com origem identificável.
- Tratar falha de salvamento e conflito sem sobrescrita silenciosa.
- Impedir acesso indevido ao trocar identificadores enviados pelo navegador.
- Fechar uma consulta manualmente sem depender da IA.
- Receber a transcrição e o resumo separadamente; o resumo não finaliza sozinho.
- Preservar edição humana e registro final quando chegar um resultado atrasado.

