# Git Hand-On 04: Resolve Merge Conflicts

## Objectives

- Learn how to resolve merge conflicts when two branches modify the same file.

## What You Will Learn

- Create a conflict between two branches.
- Use Git diff tools and merge tools to resolve it.
- Commit the resolved changes.

## Prerequisites

- A Git repository with a main branch.
- A merge tool such as P4Merge installed.

## Steps

### 1. Start from a clean main branch

```bash
git status
git checkout master
```

### 2. Create a branch and modify a file

```bash
git checkout -b GitWork
echo "Version from branch" > hello.xml
git add hello.xml
git commit -m "Add hello.xml on branch"
```

### 3. Switch back to master and change the same file

```bash
git checkout master
echo "Version from master" > hello.xml
git add hello.xml
git commit -m "Add hello.xml on master"
```

### 4. Merge the branch into master

```bash
git merge GitWork
```

A conflict will occur because both branches changed `hello.xml`.

### 5. Resolve the conflict

Open the conflicted file and edit it to keep the correct content.

Then stage and commit the result:

```bash
git add hello.xml
git commit -m "Resolve merge conflict"
```

### 6. Review the status and branches

```bash
git status
git branch
```

### 7. Clean up

```bash
git branch -d GitWork
```

---

## Summary

You created a merge conflict, resolved it using Git conflict tools, and completed the merge.
