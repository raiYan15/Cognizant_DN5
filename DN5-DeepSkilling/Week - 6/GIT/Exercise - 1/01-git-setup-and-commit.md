# Git Hand-On 01: Setup Git and Add a File

## Objectives

- Become familiar with basic Git commands such as `git init`, `git status`, `git add`, `git commit`, `git push`, and `git pull`.

## What You Will Learn

- Set up Git configuration on your machine.
- Integrate Notepad++ as the default editor for Git.
- Add a file to a local Git repository and push it to a remote repository.

## Prerequisites

- Install the Git Bash client.
- Create a GitHub or GitLab account.

## Steps

### 1. Configure Git

Run the following commands in Git Bash:

```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
```

Verify the configuration:

```bash
git config --list
```

### 2. Set Notepad++ as the default editor

If Notepad++ is installed, add its path to the system environment variables.

Then test it from Git Bash:

```bash
notepad++
```

Set Git to use it as the default editor:

```bash
git config --global core.editor "notepad++"
```

### 3. Create a repository

```bash
mkdir GitDemo
cd GitDemo
git init
```

Verify the repository:

```bash
ls -la
```

### 4. Create a file and track it

```bash
echo "Welcome to Git Hands-On" > welcome.txt
cat welcome.txt
git status
git add welcome.txt
git commit -m "Add welcome file"
```

### 5. Connect to a remote repository

Create a remote repository named `GitDemo` on GitLab or GitHub.

Then link it:

```bash
git remote add origin <repository-url>
git pull origin master
git push origin master
```

---

## Summary

You created a local Git repository, committed a file, and pushed it to a remote repository.
