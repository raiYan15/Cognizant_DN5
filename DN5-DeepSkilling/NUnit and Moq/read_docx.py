import zipfile
import xml.etree.ElementTree as ET
import sys

if len(sys.argv) != 2:
    raise SystemExit('Usage: python read_docx.py <docx-file>')

path = sys.argv[1]
with zipfile.ZipFile(path) as z:
    data = z.read('word/document.xml')
root = ET.fromstring(data)
ns = {'w': 'http://schemas.openxmlformats.org/wordprocessingml/2006/main'}
lines = []
for para in root.findall('.//w:p', ns):
    texts = [t.text for t in para.findall('.//w:t', ns) if t.text]
    if texts:
        lines.append(''.join(texts))
print('\n'.join(lines))
