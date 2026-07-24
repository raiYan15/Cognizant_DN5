# Git Hand-On 02: Use .gitignore

## Objectives

- Explain what `.gitignore` is.
- Learn how to ignore unwanted files and folders in Git.

## What You Will Learn

- Create files and folders that should not be committed.
- Update `.gitignore` so those files are ignored.

## Prerequisites

- Git environment already set up.
- A Git repository available locally and remotely.

## Steps

### 1. Create ignored files

In your repository, create a log file and a log folder:

```bash
echo "sample log" > app.log
mkdir log
echo "more logs" > log/app.log
```

### 2. Add a .gitignore file

Create a file named `.gitignore`:

```bash
notepad .gitignore
```

Add the following entries:

```gitignore
*.log
log/
```

### 3. Check Git status

```bash
git status
```

The files and folder listed in `.gitignore` should no longer appear as untracked files.

### 4. Commit the changes

```bash
git add .gitignore
git commit -m "Add gitignore rules"
git push origin master
```

---

## Summary

You learned how to keep unwanted files out of version control using `.gitignore`.
