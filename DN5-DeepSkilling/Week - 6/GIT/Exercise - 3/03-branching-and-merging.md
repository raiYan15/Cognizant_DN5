# Git Hand-On 03: Branching and Merging

## Objectives

- Explain branching and merging in Git.
- Create a branch request in GitLab.
- Create a merge request in GitLab.

## What You Will Learn

- Create a new branch.
- Make changes in that branch.
- Merge the branch back into the main branch.

## Prerequisites

- Git environment set up.
- P4Merge tool installed for Windows (optional but useful for visual diffing).

## Steps

### 1. Create a new branch

```bash
git checkout -b GitNewBranch
```

### 2. List branches

```bash
git branch -a
```

### 3. Make changes in the branch

Create a new file and commit it:

```bash
echo "Branch-specific content" > branch-file.txt
git add branch-file.txt
git commit -m "Add branch file"
```

### 4. Switch back to the main branch

```bash
git checkout master
```

### 5. Compare branch and main

```bash
git diff master..GitNewBranch
```

### 6. Merge the branch

```bash
git merge GitNewBranch
```

### 7. Review the commit history

```bash
git log --oneline --graph --decorate
```

### 8. Delete the branch after merge

```bash
git branch -d GitNewBranch
```

---

## Summary

You created a feature branch, added changes, merged it into the main branch, and cleaned up the branch.
