from __future__ import annotations

from pathlib import Path
from typing import Iterable

from reportlab.lib import colors
from reportlab.lib.enums import TA_CENTER, TA_LEFT
from reportlab.lib.pagesizes import A4
from reportlab.lib.styles import ParagraphStyle, getSampleStyleSheet
from reportlab.lib.units import mm
from reportlab.platypus import (
    BaseDocTemplate,
    Frame,
    KeepTogether,
    PageBreak,
    PageTemplate,
    Paragraph,
    Spacer,
    Table,
    TableStyle,
)
from pypdf import PdfReader, PdfWriter


ROOT = Path(__file__).resolve().parents[2]
OUTPUT = ROOT / "output" / "pdf"
OUTPUT.mkdir(parents=True, exist_ok=True)

PAGE_W, PAGE_H = A4
INK = colors.HexColor("#172126")
MUTED = colors.HexColor("#5F6B70")
GREEN = colors.HexColor("#0B7A3E")
GREEN_LIGHT = colors.HexColor("#E8F4ED")
BLUE = colors.HexColor("#246BCE")
BLUE_LIGHT = colors.HexColor("#EAF2FD")
PANEL = colors.HexColor("#F2F4F5")
RULE = colors.HexColor("#CBD2D6")
WHITE = colors.white
RED = colors.HexColor("#B33232")
AMBER = colors.HexColor("#B46A00")


def styles():
    sample = getSampleStyleSheet()
    return {
        "title": ParagraphStyle(
            "Title",
            parent=sample["Title"],
            fontName="Helvetica-Bold",
            fontSize=29,
            leading=34,
            textColor=INK,
            alignment=TA_LEFT,
            spaceAfter=8 * mm,
        ),
        "subtitle": ParagraphStyle(
            "Subtitle",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=13,
            leading=18,
            textColor=MUTED,
            spaceAfter=5 * mm,
        ),
        "h1": ParagraphStyle(
            "H1",
            parent=sample["Heading1"],
            fontName="Helvetica-Bold",
            fontSize=20,
            leading=25,
            textColor=INK,
            spaceBefore=7 * mm,
            spaceAfter=4 * mm,
            keepWithNext=True,
        ),
        "h2": ParagraphStyle(
            "H2",
            parent=sample["Heading2"],
            fontName="Helvetica-Bold",
            fontSize=14,
            leading=18,
            textColor=GREEN,
            spaceBefore=5 * mm,
            spaceAfter=2.5 * mm,
            keepWithNext=True,
        ),
        "body": ParagraphStyle(
            "Body",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=9.5,
            leading=14,
            textColor=INK,
            spaceAfter=2.5 * mm,
        ),
        "small": ParagraphStyle(
            "Small",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=8,
            leading=11,
            textColor=MUTED,
        ),
        "bullet": ParagraphStyle(
            "Bullet",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=9.2,
            leading=13.2,
            textColor=INK,
            leftIndent=5 * mm,
            firstLineIndent=-3.5 * mm,
            bulletIndent=0,
            spaceAfter=1.4 * mm,
        ),
        "callout": ParagraphStyle(
            "Callout",
            parent=sample["BodyText"],
            fontName="Helvetica-Bold",
            fontSize=11,
            leading=16,
            textColor=INK,
            leftIndent=5 * mm,
            rightIndent=5 * mm,
            spaceBefore=3 * mm,
            spaceAfter=3 * mm,
        ),
        "table_head": ParagraphStyle(
            "TableHead",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=8.3,
            leading=10.5,
            textColor=WHITE,
            alignment=TA_LEFT,
        ),
        "table": ParagraphStyle(
            "Table",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=7.8,
            leading=10.2,
            textColor=INK,
        ),
        "mono": ParagraphStyle(
            "Mono",
            parent=sample["Code"],
            fontName="Courier",
            fontSize=7.5,
            leading=10.5,
            textColor=INK,
            leftIndent=3 * mm,
            rightIndent=3 * mm,
            spaceBefore=2 * mm,
            spaceAfter=3 * mm,
        ),
        "cover_mark": ParagraphStyle(
            "CoverMark",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=11,
            leading=14,
            textColor=GREEN,
            spaceAfter=28 * mm,
        ),
        "cover_footer": ParagraphStyle(
            "CoverFooter",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=9,
            leading=13,
            textColor=MUTED,
            alignment=TA_CENTER,
        ),
    }


S = styles()


class SupportDocTemplate(BaseDocTemplate):
    def __init__(self, filename: str, short_title: str):
        super().__init__(
            filename,
            pagesize=A4,
            leftMargin=20 * mm,
            rightMargin=20 * mm,
            topMargin=19 * mm,
            bottomMargin=18 * mm,
            title=short_title,
            author="Play Sistemas Inteligentes",
            subject="Observabilidade, diagnostico e inteligencia operacional",
        )
        self.short_title = short_title
        frame = Frame(
            self.leftMargin,
            self.bottomMargin,
            self.width,
            self.height,
            id="main",
        )
        self.addPageTemplates(
            [
                PageTemplate(id="cover", frames=frame, onPage=self._cover_page),
                PageTemplate(id="body", frames=frame, onPage=self._body_page),
            ]
        )

    def _cover_page(self, canvas, doc):
        canvas.saveState()
        canvas.setFillColor(GREEN)
        canvas.rect(0, PAGE_H - 16 * mm, PAGE_W, 16 * mm, stroke=0, fill=1)
        canvas.setFillColor(BLUE)
        canvas.rect(0, 0, PAGE_W, 5 * mm, stroke=0, fill=1)
        canvas.restoreState()

    def _body_page(self, canvas, doc):
        canvas.saveState()
        canvas.setStrokeColor(RULE)
        canvas.setLineWidth(0.5)
        canvas.line(20 * mm, PAGE_H - 13 * mm, PAGE_W - 20 * mm, PAGE_H - 13 * mm)
        canvas.setFont("Helvetica", 7.5)
        canvas.setFillColor(MUTED)
        canvas.drawString(20 * mm, PAGE_H - 10 * mm, self.short_title)
        canvas.drawRightString(PAGE_W - 20 * mm, 9 * mm, f"Pagina {doc.page}")
        canvas.drawString(20 * mm, 9 * mm, "Play Sistemas Inteligentes")
        canvas.restoreState()

    def afterPage(self):
        if self.page == 1:
            self.handle_nextPageTemplate("body")


def p(text: str, style: str = "body"):
    return Paragraph(text, S[style])


def bullets(items: Iterable[str]):
    return [Paragraph(f"• {item}", S["bullet"]) for item in items]


def callout(text: str, color=GREEN_LIGHT):
    table = Table([[p(text, "callout")]], colWidths=[166 * mm])
    table.setStyle(
        TableStyle(
            [
                ("BACKGROUND", (0, 0), (-1, -1), color),
                ("BOX", (0, 0), (-1, -1), 0.7, GREEN),
                ("LEFTPADDING", (0, 0), (-1, -1), 4 * mm),
                ("RIGHTPADDING", (0, 0), (-1, -1), 4 * mm),
                ("TOPPADDING", (0, 0), (-1, -1), 2.5 * mm),
                ("BOTTOMPADDING", (0, 0), (-1, -1), 2.5 * mm),
            ]
        )
    )
    return KeepTogether([Spacer(1, 2 * mm), table, Spacer(1, 2 * mm)])


def data_table(headers, rows, widths=None, header_color=INK):
    data = [[p(h, "table_head") for h in headers]]
    for row in rows:
        data.append([p(str(value), "table") for value in row])
    table = Table(data, colWidths=widths, repeatRows=1, hAlign="LEFT")
    style = [
        ("BACKGROUND", (0, 0), (-1, 0), header_color),
        ("GRID", (0, 0), (-1, -1), 0.35, RULE),
        ("VALIGN", (0, 0), (-1, -1), "TOP"),
        ("LEFTPADDING", (0, 0), (-1, -1), 2.2 * mm),
        ("RIGHTPADDING", (0, 0), (-1, -1), 2.2 * mm),
        ("TOPPADDING", (0, 0), (-1, -1), 1.8 * mm),
        ("BOTTOMPADDING", (0, 0), (-1, -1), 1.8 * mm),
    ]
    for index in range(1, len(data)):
        if index % 2 == 0:
            style.append(("BACKGROUND", (0, index), (-1, index), PANEL))
    table.setStyle(TableStyle(style))
    return table


def cover(title: str, subtitle: str, audience: str):
    return [
        p("PADRAO DE SUPORTABILIDADE OPERACIONAL", "cover_mark"),
        Spacer(1, 13 * mm),
        p(title, "title"),
        p(subtitle, "subtitle"),
        Spacer(1, 18 * mm),
        callout(
            "Objetivo: permitir diagnostico baseado em fatos, localizar a versao e o codigo corretos e reproduzir problemas com risco controlado.",
            BLUE_LIGHT,
        ),
        Spacer(1, 45 * mm),
        p(f"Publico: {audience}", "cover_footer"),
        p("Versao 1.0 - 21 de agosto de 2026", "cover_footer"),
        p("by Play Sistemas Inteligentes", "cover_footer"),
        PageBreak(),
    ]


IDENTITIES = [
    ("RootOperationId", "Relaciona uma operacao principal e suas filhas."),
    ("OperationId", "Identifica a intencao de negocio do inicio ao fim."),
    ("ExecutionId", "Identifica uma etapa ou tentativa tecnica."),
    ("CausationId", "Identifica a execucao que provocou a atual."),
    ("Application", "Identifica o aplicativo ou sistema."),
    ("Environment", "Identifica o ambiente executado."),
    ("Version", "Identifica o commit ou build confirmado."),
]

DEPTHS = [
    ("D0", "Essential", "Identidade, versao, inicio, fim, resultado e erro resumido."),
    ("D1", "Narrative", "Etapas, duracoes, causalidade, retries e dependencias."),
    ("D2", "Diagnostic", "Decisoes, funcoes, queries, parametros e stack trace."),
    ("D3", "Forensic", "Commands, snapshots, diferencas e artefatos sanitizados."),
    ("D4", "Replayable", "Estado, leituras, relogio, IDs e respostas externas."),
]

GATES = [
    ("G1", "Governanca", "Escopo por operacao, responsaveis, acessos e runbook."),
    ("G2", "Fonte e versao", "Codigo confirmado, manifesto, snapshot indexado e versao runtime."),
    ("G3", "Identidade operacional", "OperationId, ExecutionId, causalidade e propagacao."),
    ("G4", "Evidencia minima", "D0 no escopo, D1 prioritario, erro util e dados classificados."),
    ("G5", "Consulta operacional", "Busca centralizada, retencao e acesso auditado."),
    ("G6", "Diagnostico direcionado", "D2 ativavel por alvo, com prazo, limites e auditoria."),
    ("G7", "Demonstracao", "Sucesso, rejeicao e falha investigados ate o codigo correto."),
]

PHASES = [
    ("0", "Definir escopo e responsaveis", "Delimitar as operacoes cobertas, donos, ambientes, restricoes e criterios de sucesso."),
    ("1", "Confirmar fonte e versao", "Vincular cada execucao a commit ou build confirmado; working tree nao e versao operacional."),
    ("2", "Catalogar operacoes", "Nomear entradas, saidas, dependencias, resultados de negocio e pontos assincronos."),
    ("3", "Definir eventos e dados", "Padronizar eventos, campos obrigatorios e classificacao SafeMetadata, OperationalData, Sensitive e NeverCapture."),
    ("4", "Implementar D0 e D1", "Registrar identidade, narrativa, duracoes, resultados, retries e erros sem depender de debug global."),
    ("5", "Disponibilizar evidencias", "Centralizar ou expor por coletor; permitir busca por OperationId sem acesso administrativo ao servidor."),
    ("6", "Integrar codigo e runtime", "Usar o erro e a versao para selecionar snapshot, simbolos, referencias e fontes relevantes."),
    ("7", "Implementar D2 direcionado", "Ativar diagnostico temporario por alvo, ambiente, operacao ou registro, com expiracao e limites."),
    ("8", "Implementar D3 forense", "Capturar snapshots sanitizados e diferencas suficientes para analisar estado complexo."),
    ("9", "Implementar D4 e reproducao", "Reproduzir versao, leituras, tempo e respostas externas sem efeitos reais por padrao."),
    ("10", "Saude preventiva", "Monitorar cobertura, falhas de propagacao, filas, retries, indisponibilidade e evidencias incompletas."),
    ("11", "Capacidade preditiva", "Detectar degradacao e recorrencia com base em sinais confirmados, sem confundir hipotese com fato."),
    ("12", "Inteligencia assistida", "Consolidar evidencias para IA, exigir citacao das fontes e validacao humana para efeitos operacionais."),
]


def common_foundation(story):
    story += [
        p("1. Regra de entrada no suporte", "h1"),
        p(
            "Um sistema nao e aceito porque possui logs ou porque sua equipe conhece o codigo. Ele e aceito quando consegue provar, para um escopo declarado, qual operacao ocorreu, em qual versao, com quais resultados e onde estao as evidencias necessarias para investigar.",
        ),
        callout(
            "Um fluxo somente e elegivel para suporte normal quando comprova G1 a G7. Fluxos nao homologados permanecem explicitamente fora do escopo."
        ),
        p("Linguagem normativa", "h2"),
        data_table(
            ["Classificacao", "Efeito"],
            [
                ("OBRIGATORIO", "Condicao necessaria para homologar o fluxo."),
                ("RECOMENDADO", "Deve ser adotado, salvo justificativa registrada."),
                ("EVOLUTIVO", "Capacidade posterior ao gate minimo."),
            ],
            [38 * mm, 128 * mm],
        ),
        p("2. Modelo conceitual comum", "h1"),
        p(
            "Yeshua e legados usam tecnologias diferentes, mas devem produzir evidencias equivalentes. Os contratos abaixo formam a lingua comum entre aplicacao, operacao e suporte.",
        ),
        p("Identidades universais", "h2"),
        data_table(["Identidade", "Finalidade"], IDENTITIES, [42 * mm, 124 * mm], GREEN),
        p("Resultado tecnico e resultado de negocio", "h2"),
        p(
            "TechnicalOutcome descreve a execucao tecnica: Success, Failure, Timeout ou Unavailable. BusinessOutcome descreve o negocio: Approved, Rejected, Completed ou Cancelled. Uma resposta HTTP 200 pode conter rejeicao de negocio e nao deve ser classificada como sucesso completo.",
        ),
        p("Profundidade de evidencia", "h2"),
        data_table(["Nivel", "Nome", "Evidencia"], DEPTHS, [15 * mm, 32 * mm, 119 * mm], INK),
        p(
            "D0 e D1 sustentam o baseline. D2 e ativado de forma direcionada. D3 e D4 ampliam capacidade forense e reproducao, mas nao bloqueiam a homologacao inicial.",
        ),
    ]


def phases(story, track_rows):
    story += [p("Passo a passo de implantacao", "h1")]
    for number, name, objective in PHASES:
        details = track_rows[number]
        block = [
            p(f"Fase {number} - {name}", "h2"),
            p(objective),
            *bullets(details),
        ]
        story.append(KeepTogether(block))


def gate_section(story):
    story += [
        p("Gate minimo de suportabilidade", "h1"),
        p(
            "A avaliacao e feita por sistema e por conjunto fechado de operacoes. A existencia de uma ferramenta nao comprova o gate; e preciso apresentar evidencia executada e verificavel.",
        ),
        data_table(["Gate", "Tema", "Comprovacao minima"], GATES, [18 * mm, 42 * mm, 106 * mm], GREEN),
        p("Classificacao", "h2"),
        data_table(
            ["Estado", "Significado"],
            [
                ("NAO ELEGIVEL", "Falha em requisito obrigatorio."),
                ("EM ADEQUACAO", "Possui plano, mas ainda nao recebe SLA normal de diagnostico."),
                ("ELEGIVEL", "Atende G1 a G7 para o escopo declarado."),
                ("AVANCADO", "Possui D3/D4, replay, regressao ou prevencao adicional."),
            ],
            [42 * mm, 124 * mm],
        ),
        p("Ficha de homologacao", "h2"),
        data_table(
            ["Gate", "Estado", "Evidencia", "Responsavel", "Prazo"],
            [(gate, "Pendente", "", "", "") for gate, _, _ in GATES],
            [18 * mm, 30 * mm, 58 * mm, 35 * mm, 25 * mm],
            INK,
        ),
        p("Estados permitidos: Pendente, Nao conforme, Conforme com ressalva e Conforme.", "small"),
        p("Demonstracao obrigatoria", "h2"),
        *bullets(
            [
                "reconstruir um fluxo de sucesso;",
                "distinguir uma rejeicao de negocio de sucesso tecnico;",
                "investigar uma falha real ou controlada;",
                "usar a versao para chegar ao snapshot e aos fontes corretos;",
                "produzir um bundle com pergunta, fatos, versao e evidencias;",
                "registrar tempo, conclusao e lacunas.",
            ]
        ),
    ]


YESHUA_TRACK = {
    "0": [
        "Selecionar o aplicativo Studio e as operacoes iniciais.",
        "Definir donos para DSL, Engine, aplicativo, infraestrutura e suporte.",
        "Registrar o que e gerado, regeneravel e customizado.",
    ],
    "1": [
        "Executar engenharia reversa por manifesto com lista fechada de projetos.",
        "Indexar somente commit confirmado; nunca armazenar working tree.",
        "Emitir Application, Environment e Version em API, Worker e jobs.",
    ],
    "2": [
        "Fazer a DSL nomear operacoes, Commands, Receivers, filas, Sagas e integracoes.",
        "Gerar catalogo operacional sem transformar a DSL em linguagem de infraestrutura.",
        "Associar endpoints e consumidores aos nomes de negocio.",
    ],
    "3": [
        "Criar contratos Shared para OperationalEvent e ExecutionContext.",
        "Declarar classificacao dos campos na DSL quando for padronizavel.",
        "Reservar regras especiais de mascaramento aos miolos customizados.",
    ],
    "4": [
        "Gerar D0/D1 nas bordas de endpoint, Command, Receiver, repositorio e Worker.",
        "Propagar IDs por HTTP, mensagens, Saga, Outbox e Retry.",
        "Permitir que IA/dev acrescente eventos de decisao nos miolos.",
    ],
    "5": [
        "Adicionar coletor runtime na Operational Intelligence API.",
        "Expor consultas por OperationId, versao, componente e resultado.",
        "Manter provider e armazenamento substituiveis.",
    ],
    "6": [
        "Correlacionar eventos com snapshots do AIContextBuilder.",
        "Usar marcadores GENERATED_REGENERABLE, DSL_SPECIFICATION e DSL_SEEDED_CUSTOM_OWNED_BY_DEV.",
        "Selecionar DSL quando a mudanca for estrutural e custom quando for regra especifica.",
    ],
    "7": [
        "Gerar verificacao de DiagnosticPolicy nas bordas.",
        "Permitir alvo por operacao, entidade, registro ou correlation ID.",
        "Exigir expiracao, limite de volume e auditoria.",
    ],
    "8": [
        "Definir pontos de snapshot pela DSL somente quando padronizaveis.",
        "IA/dev escolhe dados de negocio adicionais e sanitizacao especifica.",
        "Separar snapshots de fatos e interpretacoes posteriores.",
    ],
    "9": [
        "Gerar contratos para relogio, IDs, respostas externas e modos Replay/Simulation.",
        "IA/dev implementa adaptadores de integracoes especificas.",
        "Bloquear efeitos reais no replay por padrao.",
    ],
    "10": [
        "Medir cobertura de instrumentacao gerada e falhas de propagacao.",
        "Verificar filas, retries, Sagas e evidencias incompletas.",
        "Transformar checks padronizaveis em templates da Engine.",
    ],
    "11": [
        "Correlacionar sinais somente depois de consolidar baseline e historico.",
        "Manter previsao como hipotese ate confirmacao operacional.",
    ],
    "12": [
        "OperationalContextOrchestrator consolida coletores e fonte versionado.",
        "Codex recebe bundle compacto, cita evidencias e declara insuficiencia.",
        "Qualquer alteracao respeita a propriedade Engine, DSL, gerado e custom.",
    ],
}


LEGACY_TRACK = {
    "0": [
        "Definir lista fechada de operacoes aceitas no suporte.",
        "Nomear responsavel tecnico, responsavel de negocio e aprovador.",
        "Documentar restricoes de acesso, horario e dados.",
    ],
    "1": [
        "Fornecer repositorio, solucao, projetos e procedimento de build.",
        "Criar manifesto de engenharia reversa com commit confirmado.",
        "Expor a mesma versao no runtime e no pacote implantado.",
    ],
    "2": [
        "Mapear entradas HTTP, filas, jobs, telas, bancos e integracoes.",
        "Nomear cada operacao com linguagem de negocio.",
        "Identificar resultados tecnicos e de negocio.",
    ],
    "3": [
        "Adotar um envelope de evento equivalente ao contrato universal.",
        "Classificar dados antes de aumentar a profundidade.",
        "Proibir senhas, tokens, certificados privados e chaves.",
    ],
    "4": [
        "Instrumentar entradas e saidas com D0.",
        "Adicionar narrativa D1 nos fluxos prioritarios.",
        "Propagar IDs por chamadas sincronas, filas e jobs.",
    ],
    "5": [
        "Centralizar logs ou implementar coletor consultavel.",
        "Permitir busca por OperationId sem login administrativo no servidor.",
        "Definir retencao e auditoria de acesso.",
    ],
    "6": [
        "Enviar stack, componente e versao para o indice estatico.",
        "Usar Roslyn para C# e indice textual para JS, HTML, SQL e arquivos equivalentes.",
        "Validar se os fontes selecionados cobrem o fluxo real.",
    ],
    "7": [
        "Criar mecanismo de ativacao D2 por alvo limitado.",
        "Definir prazo, volume, campos autorizados e responsavel.",
        "Auditar ativacao e encerramento.",
    ],
    "8": [
        "Escolher pontos de captura de Commands, DTOs ou estado relevante.",
        "Sanitizar antes de persistir.",
        "Definir retencao menor para dados mais profundos.",
    ],
    "9": [
        "Isolar efeitos externos e banco de producao.",
        "Capturar dependencias nao deterministicas.",
        "Converter incidentes reproduzidos em testes de regressao.",
    ],
    "10": [
        "Monitorar falhas sem OperationId, versoes ausentes e evidencias truncadas.",
        "Criar checks de filas, jobs, dependencias e retencao.",
    ],
    "11": [
        "Construir baseline antes de alertas preditivos.",
        "Registrar precisao, falso positivo e falso negativo.",
    ],
    "12": [
        "Entregar contexto por API padronizada.",
        "Separar fatos, hipoteses e recomendacoes.",
        "Exigir citacao de evidencias e validacao humana.",
    ],
}


def build_yeshua():
    story = cover(
        "Implantacao no ecossistema Yeshua",
        "Guia detalhado para gerar observabilidade nas bordas, preservar os miolos e homologar aplicativos para suporte.",
        "arquitetos da Engine, times de Studio, desenvolvedores, IA, operacao e suporte",
    )
    common_foundation(story)
    story += [
        p("3. Divisao de responsabilidade no Yeshua", "h1"),
        data_table(
            ["Camada", "Responsabilidade operacional"],
            [
                ("Engine", "Gera contratos, IDs, propagacao, eventos de borda, pontos de extensao e testes base."),
                ("DSL", "Declara operacoes, significado, classificacao padronizavel e topologia conhecida."),
                ("Shared", "Mantem contratos genericos de contexto, evento, politica e coletores."),
                ("Aplicativo", "Contem todo codigo gerado e customizado especifico do dominio."),
                ("IA/dev", "Instrumenta decisoes de negocio, mascaramento especial, integracoes e replay especifico."),
                ("Operacao", "Controla ambiente, acesso, retencao, ativacao D2 e resposta a incidentes."),
            ],
            [35 * mm, 131 * mm],
            GREEN,
        ),
        callout(
            "A Engine gera o mecanismo; a DSL declara o significado; IA/dev registra a decisao especifica. Nenhuma regra de Clinica, MDF-e ou outro aplicativo pertence ao Shared global."
        ),
        p("Marcadores de propriedade", "h2"),
        data_table(
            ["Marcador", "Como o agente deve agir"],
            [
                ("DSL_SPECIFICATION", "Alterar a especificacao quando a mudanca for estrutural e regenerar."),
                ("GENERATED_REGENERABLE", "Nao editar como fonte da verdade; corrigir o template ou DSL."),
                ("DSL_SEEDED_CUSTOM_OWNED_BY_DEV", "Miolo pertence a IA/dev e nunca deve ser sobrescrito."),
            ],
            [58 * mm, 108 * mm],
        ),
        p("Arquitetura alvo", "h2"),
        *bullets(
            [
                "API, Worker e jobs iniciam ou propagam ExecutionContext.",
                "Command, Receiver, repositorios e integracoes emitem OperationalEvent.",
                "AIContextBuilder indexa somente commits confirmados.",
                "Operational Intelligence API correlaciona runtime e codigo.",
                "OperationalContextOrchestrator consolida coletores sem chamar IA dentro de cada coletor.",
                "Replay e simulacao usam adaptadores sem efeito real por padrao.",
            ]
        ),
    ]
    phases(story, YESHUA_TRACK)
    story += [
        p("Artefatos que a Engine deve gerar", "h1"),
        data_table(
            ["Area", "Borda padronizavel"],
            [
                ("HTTP", "Leitura/geracao de IDs, versao, duracao, resultado e propagacao."),
                ("Command/Receiver", "Inicio/fim, causalidade, resultado e ponto para evento custom."),
                ("Fila/Worker", "MessageId, OperationId, tentativa, retry, dead letter e latencia."),
                ("Saga/Outbox", "SagaId, etapa, transicao, persistencia, entrega e compensacao."),
                ("Repositorio", "Componente, operacao, duracao e erro; parametros somente em D2 autorizado."),
                ("Integracao", "Dependencia, endpoint logico, duracao, resultado e resposta sanitizada."),
                ("Testes", "Validacao de IDs, versao, resultados e ausencia de NeverCapture."),
            ],
            [38 * mm, 128 * mm],
            GREEN,
        ),
        p("Miolos sob responsabilidade de IA/dev", "h2"),
        *bullets(
            [
                "decisoes de negocio e motivos;",
                "dados adicionais permitidos para diagnostico;",
                "sanitizacao especifica do dominio;",
                "adaptadores de SEFAZ e outras bibliotecas;",
                "snapshots D3 especificos;",
                "replay de integracoes e dependencias nao deterministicas.",
            ]
        ),
        p("Contrato minimo de evento", "h2"),
        p(
            "{\n  eventName, occurredAtUtc, application, environment, version,\n  rootOperationId, operationId, executionId, causationId,\n  component, operation, technicalOutcome, businessOutcome,\n  severity, depth, durationMs, errorCode, errorSummary\n}",
            "mono",
        ),
    ]
    gate_section(story)
    story += [
        p("Plano inicial recomendado", "h1"),
        data_table(
            ["Ordem", "Entrega", "Validacao"],
            [
                ("1", "ExecutionContext e OperationalEvent no Shared", "Compilacao e contrato revisado."),
                ("2", "Application, Environment e Version nos hosts", "Runtime corresponde ao commit."),
                ("3", "Propagacao em API e Worker", "Teste sincrono e assincrono."),
                ("4", "D0/D1 em Command e Receiver", "Fluxo de sucesso reconstruido."),
                ("5", "Fila, Saga, Outbox e Retry", "Falha e nova tentativa correlacionadas."),
                ("6", "Coletor runtime", "Busca por OperationId sem servidor."),
                ("7", "DiagnosticPolicy", "D2 dirigido e expiravel."),
                ("8", "Gate na Clinica", "G1 a G7 aprovados."),
                ("9", "Gate no MDF-e", "Mesmo contrato, dominio diferente."),
            ],
            [18 * mm, 84 * mm, 64 * mm],
            BLUE,
        ),
        p("Definicao de pronto", "h2"),
        *bullets(
            [
                "o suporte reconstrui uma operacao sem acesso manual extenso;",
                "o runtime leva ao snapshot e aos fontes corretos;",
                "a mudanca encontra DSL, gerados e custom corretos;",
                "uma falha produz fatos suficientes para diagnostico;",
                "incidentes relevantes podem virar especificacao e regressao.",
            ]
        ),
    ]
    path = OUTPUT / "Yeshua_Guia_Implantacao_Observabilidade_Suporte.pdf"
    SupportDocTemplate(str(path), "Yeshua - Guia de implantacao operacional").build(story)
    return path


def build_legacy():
    story = cover(
        "Requisitos para sistemas legados",
        "Guia de adequacao e homologacao para fabricantes e equipes que desejam suporte operacional da Play Sistemas Inteligentes.",
        "fabricantes de software, gestores tecnicos, desenvolvedores, operacao e suporte",
    )
    common_foundation(story)
    story += [
        p("3. O requisito e tecnologicamente neutro", "h1"),
        p(
            "O fabricante nao precisa adotar a arquitetura Yeshua. Pode manter seu framework, linguagem, provider de logs e infraestrutura. A obrigacao e produzir evidencias equivalentes e permitir que o suporte correlacione operacao, versao, erro e codigo-fonte.",
        ),
        callout(
            "Logs soltos nao bastam. O sistema deve permitir partir de uma operacao real, encontrar todas as etapas relacionadas e chegar ao codigo da versao implantada."
        ),
        p("Entregas do fabricante", "h2"),
        data_table(
            ["Entrega", "Requisito minimo"],
            [
                ("Fonte", "Repositorio acessivel, commit confirmado, solucao/projetos e build documentado."),
                ("Versao", "Mesmo identificador no runtime, artefato implantado e indice estatico."),
                ("Operacoes", "Catalogo de fluxos cobertos, entradas, saidas, dependencias e resultados."),
                ("Instrumentacao", "IDs, D0 no escopo e D1 nos fluxos prioritarios."),
                ("Consulta", "Evidencias centralizadas ou coletor com busca por OperationId."),
                ("Diagnostico", "D2 dirigido por alvo, prazo e limites."),
                ("Seguranca", "Classificacao de dados e comprovacao de NeverCapture."),
                ("Demonstracao", "Sucesso, rejeicao e falha investigados ate o codigo correto."),
            ],
            [42 * mm, 124 * mm],
            GREEN,
        ),
        p("O que nao e exigido para entrada", "h2"),
        *bullets(
            [
                "migrar o sistema para Yeshua;",
                "substituir imediatamente o provider de observabilidade;",
                "implementar replay completo antes do primeiro suporte;",
                "capturar dados sensiveis para aumentar o detalhe;",
                "instrumentar de uma vez todos os modulos fora do escopo contratado.",
            ]
        ),
    ]
    phases(story, LEGACY_TRACK)
    story += [
        p("Manifesto de engenharia reversa", "h1"),
        p(
            "Cada carga representa um snapshot completo de commit confirmado. O historico Git pode enriquecer a investigacao, mas nao substitui a carga nem funciona como mecanismo incremental obrigatorio.",
        ),
        data_table(
            ["Campo", "Conteudo"],
            [
                ("system", "Nome estavel do sistema."),
                ("type", "Legacy."),
                ("version", "Commit ou build confirmado."),
                ("solution", "Caminho da solucao quando aplicavel."),
                ("projects", "Lista fechada de projetos e diretorios."),
                ("repository", "Repositorio e branch de referencia."),
                ("include/exclude", "Extensoes, fontes e artefatos excluidos."),
            ],
            [42 * mm, 124 * mm],
            GREEN,
        ),
        p("Indexacao esperada", "h2"),
        *bullets(
            [
                "analise semantica quando a linguagem permitir;",
                "indice textual para JavaScript, TypeScript, HTML, Razor, Vue, SQL e configuracoes;",
                "conteudo integral comprimido e deduplicado;",
                "arquivos, simbolos, referencias, linhas e historico confirmado;",
                "filtros para regra de negocio, bordas, contratos, classes-base e testes.",
            ]
        ),
        p("Contrato minimo de evento", "h2"),
        p(
            "{\n  eventName, occurredAtUtc, application, environment, version,\n  rootOperationId, operationId, executionId, causationId,\n  component, operation, technicalOutcome, businessOutcome,\n  severity, depth, durationMs, errorCode, errorSummary\n}",
            "mono",
        ),
        p("Politica para dados", "h2"),
        data_table(
            ["Classe", "Tratamento"],
            [
                ("SafeMetadata", "Permitido no baseline."),
                ("OperationalData", "Permitido conforme politica e necessidade."),
                ("Sensitive", "Somente captura explicita, mascarada e temporaria."),
                ("NeverCapture", "Proibido: senhas, tokens, chaves e certificados privados."),
            ],
            [42 * mm, 124 * mm],
            RED,
        ),
    ]
    gate_section(story)
    story += [
        p("Processo de onboarding", "h1"),
        data_table(
            ["Etapa", "Acao", "Saida"],
            [
                ("1", "Solicitacao e definicao do escopo", "Lista de operacoes."),
                ("2", "Avaliacao G1 a G7", "Lacunas classificadas."),
                ("3", "Plano de adequacao", "Responsaveis e prazos."),
                ("4", "Engenharia reversa", "Snapshot indexado."),
                ("5", "Instrumentacao D0/D1", "Narrativa consultavel."),
                ("6", "D2 direcionado", "Politica ativavel e auditada."),
                ("7", "Demonstracoes", "Bundles de sucesso e falha."),
                ("8", "Revisao de seguranca", "NeverCapture aprovado."),
                ("9", "Homologacao", "Estado e validade registrados."),
            ],
            [18 * mm, 84 * mm, 64 * mm],
            BLUE,
        ),
        p("Pacote de homologacao", "h2"),
        *bullets(
            [
                "ficha, escopo e operacoes excluidas;",
                "manifestos, repositorios e projetos;",
                "catalogos de operacoes e eventos;",
                "procedimentos de build e deploy;",
                "identificacao da versao runtime;",
                "mapa de propagacao e fontes de evidencia;",
                "politicas de profundidade, acesso e retencao;",
                "runbook e bundles de demonstracao;",
                "relatorio NeverCapture e aprovadores.",
            ]
        ),
        callout(
            "Mudanca de repositorio, pipeline, arquitetura, identificacao de versao ou fonte de evidencia exige reavaliar o gate afetado."
        ),
        p("Responsabilidades", "h2"),
        data_table(
            ["Parte", "Responsabilidade"],
            [
                ("Fabricante", "Fonte, versao, instrumentacao, catalogo, correcoes e documentacao."),
                ("Operacao", "Acessos, ambiente, retencao, ativacao D2 e disponibilidade das evidencias."),
                ("Play Sistemas Inteligentes", "Padrao, homologacao, investigacao e recomendacoes baseadas em fatos."),
                ("Dono dos dados", "Autorizar politica, classificacao e capturas profundas."),
                ("Criterio de aceite", "Uma equipe externa reconstrui a operacao, localiza a versao e os fontes e explica a falha com evidencias verificaveis."),
            ],
            [45 * mm, 121 * mm],
        ),
        p("Recertificacao", "h2"),
        *bullets(
            [
                "mudanca de repositorio, pipeline, arquitetura, identificacao de versao ou fonte de evidencia reabre os gates afetados;",
                "a validade da homologacao deve possuir data ou criterio objetivo de renovacao;",
                "incidente que revele lacuna obrigatoria move o fluxo para EM ADEQUACAO ate a correcao.",
            ]
        ),
        p("Indicadores minimos", "h2"),
        data_table(
            ["Indicador", "Uso"],
            [
                ("Cobertura das operacoes", "Comprovar quais fluxos permanecem homologados."),
                ("Falhas sem OperationId", "Detectar perda de identidade operacional."),
                ("Runtime sem versao", "Detectar implantacao sem fonte correlacionavel."),
                ("Tempo para localizar causa", "Medir a efetividade real do suporte."),
                ("D2 fora do limite", "Detectar diagnostico profundo sem controle."),
                ("Evidencia proibida", "Interromper e corrigir qualquer NeverCapture."),
            ],
            [60 * mm, 106 * mm],
            BLUE,
        ),
    ]
    path = OUTPUT / "Legados_Requisitos_Minimos_Para_Suporte.pdf"
    SupportDocTemplate(str(path), "Legados - Requisitos minimos para suporte").build(story)
    return path


def trim_trailing_blank_pages(path: Path):
    reader = PdfReader(path)
    keep = len(reader.pages)
    while keep > 1 and not (reader.pages[keep - 1].extract_text() or "").strip():
        keep -= 1
    if keep == len(reader.pages):
        return

    writer = PdfWriter()
    for page in reader.pages[:keep]:
        writer.add_page(page)
    writer.add_metadata(reader.metadata or {})
    temporary = path.with_suffix(".trimmed.pdf")
    with temporary.open("wb") as stream:
        writer.write(stream)
    temporary.replace(path)


if __name__ == "__main__":
    for generated in (build_yeshua(), build_legacy()):
        trim_trailing_blank_pages(generated)
        print(generated)
