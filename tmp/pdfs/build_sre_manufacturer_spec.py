from __future__ import annotations

import html
import re
from pathlib import Path

from pypdf import PdfReader, PdfWriter
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


ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md"
OUTPUT_DIR = ROOT / "output" / "pdf"
OUTPUT = OUTPUT_DIR / "Especificacao_Observabilidade_Suporte_SRE_Para_Fabricantes.pdf"

PAGE_W, PAGE_H = A4
INK = colors.HexColor("#172126")
MUTED = colors.HexColor("#5F6B70")
GREEN = colors.HexColor("#0B7A3E")
GREEN_LIGHT = colors.HexColor("#E8F4ED")
BLUE = colors.HexColor("#246BCE")
BLUE_LIGHT = colors.HexColor("#EAF2FD")
AMBER = colors.HexColor("#B46A00")
AMBER_LIGHT = colors.HexColor("#FAF0E2")
RED = colors.HexColor("#B33232")
PANEL = colors.HexColor("#F2F4F5")
RULE = colors.HexColor("#CBD2D6")
WHITE = colors.white


def build_styles():
    sample = getSampleStyleSheet()
    return {
        "cover_title": ParagraphStyle(
            "CoverTitle",
            parent=sample["Title"],
            fontName="Helvetica-Bold",
            fontSize=28,
            leading=34,
            textColor=INK,
            alignment=TA_LEFT,
            spaceAfter=7 * mm,
        ),
        "cover_subtitle": ParagraphStyle(
            "CoverSubtitle",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=13,
            leading=18,
            textColor=MUTED,
            spaceAfter=6 * mm,
        ),
        "cover_mark": ParagraphStyle(
            "CoverMark",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=10.5,
            leading=14,
            textColor=GREEN,
            spaceAfter=26 * mm,
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
        "h1": ParagraphStyle(
            "H1",
            parent=sample["Heading1"],
            fontName="Helvetica-Bold",
            fontSize=19,
            leading=24,
            textColor=INK,
            spaceBefore=7 * mm,
            spaceAfter=3.5 * mm,
            keepWithNext=True,
        ),
        "h2": ParagraphStyle(
            "H2",
            parent=sample["Heading2"],
            fontName="Helvetica-Bold",
            fontSize=13.5,
            leading=17,
            textColor=GREEN,
            spaceBefore=5 * mm,
            spaceAfter=2.5 * mm,
            keepWithNext=True,
        ),
        "h3": ParagraphStyle(
            "H3",
            parent=sample["Heading3"],
            fontName="Helvetica-Bold",
            fontSize=10.5,
            leading=14,
            textColor=BLUE,
            spaceBefore=3.5 * mm,
            spaceAfter=1.8 * mm,
            keepWithNext=True,
        ),
        "body": ParagraphStyle(
            "Body",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=9.2,
            leading=13.5,
            textColor=INK,
            spaceAfter=2.3 * mm,
        ),
        "bullet": ParagraphStyle(
            "Bullet",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=9.1,
            leading=13,
            textColor=INK,
            leftIndent=5 * mm,
            firstLineIndent=-3.5 * mm,
            spaceAfter=1.2 * mm,
        ),
        "number": ParagraphStyle(
            "Number",
            parent=sample["BodyText"],
            fontName="Helvetica",
            fontSize=9.1,
            leading=13,
            textColor=INK,
            leftIndent=7 * mm,
            firstLineIndent=-5 * mm,
            spaceAfter=1.2 * mm,
        ),
        "small": ParagraphStyle(
            "Small",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=7.6,
            leading=10,
            textColor=MUTED,
        ),
        "table_head": ParagraphStyle(
            "TableHead",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=7.8,
            leading=10,
            textColor=WHITE,
        ),
        "table": ParagraphStyle(
            "Table",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=7.4,
            leading=9.7,
            textColor=INK,
        ),
        "code": ParagraphStyle(
            "Code",
            parent=sample["Code"],
            fontName="Courier",
            fontSize=7.4,
            leading=10.2,
            textColor=INK,
            leftIndent=4 * mm,
            rightIndent=4 * mm,
            spaceBefore=2 * mm,
            spaceAfter=3 * mm,
        ),
        "axis_title": ParagraphStyle(
            "AxisTitle",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=11,
            leading=14,
            textColor=WHITE,
            alignment=TA_CENTER,
        ),
        "axis_body": ParagraphStyle(
            "AxisBody",
            parent=sample["Normal"],
            fontName="Helvetica",
            fontSize=8.3,
            leading=11,
            textColor=INK,
            alignment=TA_CENTER,
        ),
        "callout": ParagraphStyle(
            "Callout",
            parent=sample["Normal"],
            fontName="Helvetica-Bold",
            fontSize=10.2,
            leading=14.5,
            textColor=INK,
            alignment=TA_LEFT,
        ),
    }


S = build_styles()


class SpecificationTemplate(BaseDocTemplate):
    def __init__(self, filename: Path):
        super().__init__(
            str(filename),
            pagesize=A4,
            leftMargin=20 * mm,
            rightMargin=20 * mm,
            topMargin=19 * mm,
            bottomMargin=18 * mm,
            title="Especificacao de Observabilidade para Suporte SRE",
            author="Play Sistemas Inteligentes",
            subject="Requisitos para fabricantes de software",
        )
        frame = Frame(self.leftMargin, self.bottomMargin, self.width, self.height, id="main")
        self.addPageTemplates(
            [
                PageTemplate(id="cover", frames=frame, onPage=self._cover),
                PageTemplate(id="body", frames=frame, onPage=self._body),
            ]
        )

    def _cover(self, canvas, doc):
        canvas.saveState()
        canvas.setFillColor(GREEN)
        canvas.rect(0, PAGE_H - 16 * mm, PAGE_W, 16 * mm, stroke=0, fill=1)
        canvas.setFillColor(BLUE)
        canvas.rect(0, 0, PAGE_W, 5 * mm, stroke=0, fill=1)
        canvas.restoreState()

    def _body(self, canvas, doc):
        canvas.saveState()
        canvas.setStrokeColor(RULE)
        canvas.setLineWidth(0.5)
        canvas.line(20 * mm, PAGE_H - 13 * mm, PAGE_W - 20 * mm, PAGE_H - 13 * mm)
        canvas.setFont("Helvetica", 7.5)
        canvas.setFillColor(MUTED)
        canvas.drawString(20 * mm, PAGE_H - 10 * mm, "Especificacao de Observabilidade para Suporte SRE")
        canvas.drawString(20 * mm, 9 * mm, "Play Sistemas Inteligentes")
        canvas.drawRightString(PAGE_W - 20 * mm, 9 * mm, f"Pagina {doc.page}")
        canvas.restoreState()

    def afterPage(self):
        if self.page == 1:
            self.handle_nextPageTemplate("body")


def safe_text(value: str) -> str:
    escaped = html.escape(value, quote=False)
    escaped = re.sub(r"\*\*(.+?)\*\*", r"<b>\1</b>", escaped)
    escaped = re.sub(r"`(.+?)`", r'<font name="Courier">\1</font>', escaped)
    return escaped


def paragraph(text: str, style="body"):
    return Paragraph(safe_text(text), S[style])


def callout(text: str):
    table = Table([[paragraph(text, "callout")]], colWidths=[166 * mm])
    table.setStyle(
        TableStyle(
            [
                ("BACKGROUND", (0, 0), (-1, -1), GREEN_LIGHT),
                ("BOX", (0, 0), (-1, -1), 0.8, GREEN),
                ("LEFTPADDING", (0, 0), (-1, -1), 5 * mm),
                ("RIGHTPADDING", (0, 0), (-1, -1), 5 * mm),
                ("TOPPADDING", (0, 0), (-1, -1), 3 * mm),
                ("BOTTOMPADDING", (0, 0), (-1, -1), 3 * mm),
            ]
        )
    )
    return KeepTogether([Spacer(1, 2 * mm), table, Spacer(1, 2 * mm)])


def axis_visual():
    header = [
        Paragraph("SEVERIDADE", S["axis_title"]),
        Paragraph("PROFUNDIDADE", S["axis_title"]),
        Paragraph("MODO", S["axis_title"]),
    ]
    body = [
        Paragraph("Quao grave e o fato?<br/>Information a Critical", S["axis_body"]),
        Paragraph("Quanto contexto foi capturado?<br/>D0 a D4", S["axis_body"]),
        Paragraph("Em qual tipo de execucao ocorreu?<br/>Live, Replay, Simulation ou Regression", S["axis_body"]),
    ]
    table = Table([header, body], colWidths=[55.3 * mm] * 3)
    table.setStyle(
        TableStyle(
            [
                ("BACKGROUND", (0, 0), (0, 0), GREEN),
                ("BACKGROUND", (1, 0), (1, 0), BLUE),
                ("BACKGROUND", (2, 0), (2, 0), AMBER),
                ("BACKGROUND", (0, 1), (0, 1), GREEN_LIGHT),
                ("BACKGROUND", (1, 1), (1, 1), BLUE_LIGHT),
                ("BACKGROUND", (2, 1), (2, 1), AMBER_LIGHT),
                ("BOX", (0, 0), (-1, -1), 0.6, RULE),
                ("INNERGRID", (0, 0), (-1, -1), 0.4, WHITE),
                ("VALIGN", (0, 0), (-1, -1), "MIDDLE"),
                ("TOPPADDING", (0, 0), (-1, 0), 3 * mm),
                ("BOTTOMPADDING", (0, 0), (-1, 0), 3 * mm),
                ("TOPPADDING", (0, 1), (-1, 1), 4 * mm),
                ("BOTTOMPADDING", (0, 1), (-1, 1), 4 * mm),
                ("LEFTPADDING", (0, 0), (-1, -1), 3 * mm),
                ("RIGHTPADDING", (0, 0), (-1, -1), 3 * mm),
            ]
        )
    )
    independence = Table(
        [[paragraph("Os tres valores coexistem. Alterar um eixo nao pode alterar automaticamente os outros dois.", "callout")]],
        colWidths=[166 * mm],
    )
    independence.setStyle(
        TableStyle(
            [
                ("BACKGROUND", (0, 0), (-1, -1), GREEN_LIGHT),
                ("BOX", (0, 0), (-1, -1), 0.8, GREEN),
                ("LEFTPADDING", (0, 0), (-1, -1), 5 * mm),
                ("RIGHTPADDING", (0, 0), (-1, -1), 5 * mm),
                ("TOPPADDING", (0, 0), (-1, -1), 3 * mm),
                ("BOTTOMPADDING", (0, 0), (-1, -1), 3 * mm),
            ]
        )
    )
    return KeepTogether(
        [
            Spacer(1, 2 * mm),
            table,
            Spacer(1, 3 * mm),
            independence,
            Spacer(1, 2 * mm),
        ]
    )


def markdown_table(lines: list[str]):
    rows = []
    for line in lines:
        cells = [cell.strip() for cell in line.strip().strip("|").split("|")]
        if all(re.fullmatch(r":?-{3,}:?", cell or "") for cell in cells):
            continue
        rows.append(cells)
    if not rows:
        return Spacer(1, 1)

    columns = max(len(row) for row in rows)
    for row in rows:
        row.extend([""] * (columns - len(row)))
    widths = [166 * mm / columns] * columns
    data = []
    for row_index, row in enumerate(rows):
        style = "table_head" if row_index == 0 else "table"
        data.append([paragraph(cell, style) for cell in row])

    table = Table(data, colWidths=widths, repeatRows=1, hAlign="LEFT")
    commands = [
        ("BACKGROUND", (0, 0), (-1, 0), INK),
        ("GRID", (0, 0), (-1, -1), 0.35, RULE),
        ("VALIGN", (0, 0), (-1, -1), "TOP"),
        ("LEFTPADDING", (0, 0), (-1, -1), 2 * mm),
        ("RIGHTPADDING", (0, 0), (-1, -1), 2 * mm),
        ("TOPPADDING", (0, 0), (-1, -1), 1.6 * mm),
        ("BOTTOMPADDING", (0, 0), (-1, -1), 1.6 * mm),
    ]
    for row_index in range(2, len(data), 2):
        commands.append(("BACKGROUND", (0, row_index), (-1, row_index), PANEL))
    table.setStyle(TableStyle(commands))
    return table


def cover_story():
    return [
        Paragraph("SUPORTE SRE • ESPECIFICACAO PARA FABRICANTES", S["cover_mark"]),
        Spacer(1, 12 * mm),
        Paragraph("Especificação de Observabilidade para Suporte SRE", S["cover_title"]),
        Paragraph(
            "Requisitos mínimos, entregáveis e critérios de homologação para fabricantes de software.",
            S["cover_subtitle"],
        ),
        Spacer(1, 28 * mm),
        callout("O fabricante escolhe a tecnologia. O servico exige evidencias equivalentes e verificaveis."),
        Spacer(1, 55 * mm),
        Paragraph("Versão 2.0 - 21 de agosto de 2026", S["cover_footer"]),
        Paragraph("by Play Sistemas Inteligentes", S["cover_footer"]),
        PageBreak(),
    ]


def parse_markdown(path: Path):
    lines = path.read_text(encoding="utf-8").splitlines()
    story = cover_story()
    index = 0
    paragraph_lines: list[str] = []
    first_title_skipped = False

    def flush_paragraph():
        if paragraph_lines:
            text = " ".join(part.strip() for part in paragraph_lines).strip()
            if text:
                story.append(paragraph(text))
            paragraph_lines.clear()

    while index < len(lines):
        line = lines[index]
        stripped = line.strip()

        if not stripped:
            flush_paragraph()
            index += 1
            continue

        if stripped.startswith("```"):
            flush_paragraph()
            code_lines = []
            index += 1
            while index < len(lines) and not lines[index].strip().startswith("```"):
                code_lines.append(lines[index])
                index += 1
            story.append(Paragraph("<br/>".join(html.escape(value) for value in code_lines), S["code"]))
            index += 1
            continue

        if stripped.startswith("|"):
            flush_paragraph()
            table_lines = []
            while index < len(lines) and lines[index].strip().startswith("|"):
                table_lines.append(lines[index])
                index += 1
            story.append(markdown_table(table_lines))
            story.append(Spacer(1, 2 * mm))
            continue

        heading = re.match(r"^(#{1,4})\s+(.+)$", stripped)
        if heading:
            flush_paragraph()
            level = len(heading.group(1))
            text = heading.group(2)
            if level == 1 and not first_title_skipped:
                first_title_skipped = True
                index += 1
                continue
            if text.startswith("11. Gate"):
                story.append(PageBreak())
            style = "h1" if level <= 2 else "h2" if level == 3 else "h3"
            story.append(paragraph(text, style))
            if text.startswith("5. Tres Eixos"):
                story.append(axis_visual())
            index += 1
            continue

        bullet = re.match(r"^-\s+(.+)$", stripped)
        if bullet:
            flush_paragraph()
            story.append(Paragraph("• " + safe_text(bullet.group(1)), S["bullet"]))
            index += 1
            continue

        numbered = re.match(r"^(\d+)\.\s+(.+)$", stripped)
        if numbered:
            flush_paragraph()
            story.append(Paragraph(f"{numbered.group(1)}. " + safe_text(numbered.group(2)), S["number"]))
            index += 1
            continue

        paragraph_lines.append(stripped)
        index += 1

    flush_paragraph()
    return story


def trim_empty_trailing_page(path: Path):
    reader = PdfReader(path)
    if len(reader.pages) <= 1:
        return
    last_text = (reader.pages[-1].extract_text() or "").strip()
    boilerplate = {
        "Especificacao de Observabilidade para Suporte SRE",
        f"Pagina {len(reader.pages)}",
        "Play Sistemas Inteligentes",
    }
    remaining = [line.strip() for line in last_text.splitlines() if line.strip() not in boilerplate]
    if remaining:
        return
    writer = PdfWriter()
    for page in reader.pages[:-1]:
        writer.add_page(page)
    writer.add_metadata(reader.metadata or {})
    temporary = path.with_suffix(".trimmed.pdf")
    with temporary.open("wb") as stream:
        writer.write(stream)
    temporary.replace(path)


if __name__ == "__main__":
    OUTPUT_DIR.mkdir(parents=True, exist_ok=True)
    SpecificationTemplate(OUTPUT).build(parse_markdown(SOURCE))
    trim_empty_trailing_page(OUTPUT)
    print(OUTPUT)
