from pathlib import Path
from PyPDF2 import PdfReader
path = Path(r'C:\Users\dashi\OneDrive\Desktop\3-2\Cognizent\Cognizant-DN5\DN5-DeepSkilling\AdvancedSQL\Assignments')
for pdf_name in sorted(path.glob('*.pdf')):
    print('\n===', pdf_name.name, '===')
    reader = PdfReader(str(pdf_name))
    pages = min(5, len(reader.pages))
    for i in range(pages):
        page = reader.pages[i]
        text = page.extract_text() or ''
        print('--- page', i+1, '---')
        print(text[:2000])
