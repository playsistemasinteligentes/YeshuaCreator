from pathlib import Path

import pypdfium2 as pdfium
from PIL import Image, ImageDraw


ROOT = Path(__file__).resolve().parents[2]
RENDERED = ROOT / "tmp" / "pdfs" / "rendered"
FILES = {
    "sre-fabricantes": ROOT / "output" / "pdf" / "Especificacao_Observabilidade_Suporte_SRE_Para_Fabricantes.pdf",
}


for key, pdf_path in FILES.items():
    target = RENDERED / key
    target.mkdir(parents=True, exist_ok=True)
    pdf = pdfium.PdfDocument(pdf_path)
    thumbs = []
    for index in range(len(pdf)):
        page = pdf[index]
        image = page.render(scale=1.35).to_pil().convert("RGB")
        image.save(target / f"page-{index + 1:02d}.png")
        thumb = image.copy()
        thumb.thumbnail((245, 346))
        thumbs.append((index + 1, thumb))

    columns = 4
    cell_w, cell_h = 265, 382
    rows = (len(thumbs) + columns - 1) // columns
    sheet = Image.new("RGB", (columns * cell_w, rows * cell_h), "#DDE2E4")
    draw = ImageDraw.Draw(sheet)
    for item_index, (page_number, thumb) in enumerate(thumbs):
        col = item_index % columns
        row = item_index // columns
        x = col * cell_w + (cell_w - thumb.width) // 2
        y = row * cell_h + 24
        sheet.paste(thumb, (x, y))
        draw.text((col * cell_w + 10, row * cell_h + 6), f"Pagina {page_number}", fill="#172126")
    sheet.save(RENDERED / f"{key}-contact-sheet.png")
    print(f"{pdf_path.name}: {len(pdf)} paginas")
