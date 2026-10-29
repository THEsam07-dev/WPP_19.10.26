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
Tagger: Igumno <igumno@example.com>
Date:   Thu Oct 29 16:50:00 2026 +0300

Release v1.0.0

commit b1b622268
Author: Igumnov <sigumnov2@outlook.com>
Date:   Thu Oct 29 16:08:11 2026 +0300

    Complete Task 46 notes: git stash