# Git notes

## Task 15 — Basic git

### Commands
- git init
- git checkout -b feature/git-basics
- git merge feature/git-basics
- git merge conflict-branch

### Output (git log --graph --oneline --all)
* 5fdf515 * ccd5f5e Add git-notes.md with history graph
* ccd5f5e Add git-notes.md with history graph
*   bb2a5d0 Merge branch 'conflict-branch' and resolve conflict
|\  
| * 0baebed Update status for conflict branch v2
* | 1ba62fb Update status for conflict v2
|/  
* 1e54165 Update Status line in conflict-branch
* c20caf0 Update Status line in main
* 55ab90d Add Installation section
* d6382af Add Requirements section
* 2e1a86c Add Features section
* a2dae00 Initial commit: add README with base info
# Git notes
## Task 46 — Git stash / stash pop

### Commands
- git stash
- git stash list
- git checkout -b test-branch
- git checkout main
- git stash pop
- git stash list

### Output before (git stash list)
```text
stash@{0}: WIP on main: 76299a4 task part done

### What I learned
я научился создавать ветки, сливать их через merge и вручную разрешать конфликты в редакторе Visual Studio 2026.

## Task 48 — Git tags (v1.0.0)

### Commands
- git checkout main
- git tag -a v1.0.0 -m "Release v1.0.0"
- git tag
- git show v1.0.0
- git push origin v1.0.0

### Output (git show v1.0.0)
```text
tag v1.0.0
Tagger: Igumnov <sigumnov2@outlook.com>
Date:   Thu Oct 29 16:50:00 2026 +0300

Release v1.0.0

commit b1b622268
Author: Igumnov <sigumnov2@outlook.com>
Date:   Thu Oct 29 16:08:11 2026 +0300

    Complete Task 46 notes: git stash

## Task 49 — Git reflog

### Commands
- git reflog
- git reset --hard 3bb70f5

### Output
```text
dc64f52 (HEAD -> main) HEAD@{0}: reset: moving to HEAD~1
3bb70f5 HEAD@{1}: commit: Важный коммит, который нельзя терять
dc64f52 (HEAD -> main) HEAD@{2}: commit: Add Task 48 notes: git tags

## Task 50 — Git bisect

### Commands
- git bisect start
- git bisect bad
- git bisect good HEAD~9
- git bisect bad / git bisect good
- git bisect reset

### Output
```text
Bisecting: 1 revision left to test after this (roughly 1 step)
[c2cb867d42b44866dd78e5b3e1d04d6ad4c564c] Commit 3 - OK
Bisecting: 0 revisions left to test after this (roughly 0 steps)
[5cc5080aabb35c14b61b607084cc653804d020a] Commit 4 - BUG

5cc5080aabb35c14b61b607084cc653804d020a is the first bad commit
commit 5cc5080aabb35c14b61b607084cc653804d020a
Author: Igumnov
Date: ...

    Commit 4 - BUG