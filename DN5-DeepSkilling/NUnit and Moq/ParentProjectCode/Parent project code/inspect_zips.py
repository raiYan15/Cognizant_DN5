import os, zipfile
root = os.getcwd()
print(root)
files = [f for f in os.listdir(root) if f.endswith('.zip')]
print(files)
for name in sorted(files):
    print('ZIP', name)
    with zipfile.ZipFile(name) as z:
        members = [m for m in z.namelist() if m.endswith('.cs') or m.endswith('.csproj') or m.endswith('.sln')]
        print('  members', len(members))
        for m in members[:20]:
            print('   ', m)
        print()
