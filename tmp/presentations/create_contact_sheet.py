from pathlib import Path

from PIL import Image, ImageDraw


folder = Path(__file__).resolve().parent / "rendered"
files = sorted(folder.glob("slide-*.png"))
columns = 3
cell_w, cell_h = 430, 275
rows = (len(files) + columns - 1) // columns
sheet = Image.new("RGB", (columns * cell_w, rows * cell_h), "#DDE2E4")
draw = ImageDraw.Draw(sheet)

for index, path in enumerate(files):
    image = Image.open(path).convert("RGB")
    image.thumbnail((400, 225))
    col, row = index % columns, index // columns
    x = col * cell_w + 15
    y = row * cell_h + 34
    sheet.paste(image, (x, y))
    draw.text((x, row * cell_h + 10), f"Slide {index + 1}", fill="#172126")

sheet.save(folder / "contact-sheet.png")
