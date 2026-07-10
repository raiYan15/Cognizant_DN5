from pathlib import Path
from PyPDF2 import PdfReader

path = Path(__file__).resolve().parent
out = path / 'exercise_texts.txt'
with out.open('w', encoding='utf-8') as f:
    for pdf_name in sorted(path.glob('*.pdf')):
        f.write(f'=== {pdf_name.name} ===\n')
        reader = PdfReader(str(pdf_name))
        for i, page in enumerate(reader.pages, start=1):
            text = page.extract_text() or ''
            f.write(f'--- page {i} ---\n')
            f.write(text + '\n')
print('wrote', out)
