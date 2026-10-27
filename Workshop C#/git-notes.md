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
## Task 35 — Git: .gitignore, .editorconfig, PR, Conventional Commits, rebase

### Что было сделано:
1. Добавлены `.gitignore` и `.editorconfig` (коммит `chore: add gitignore and editorconfig`).
2. Создана ветка `feature/task-35`, сделаны коммиты по Conventional Commits.
3. Создан и смержен Pull Request (Squash merge) в ветку `main`.
4. Создана ветка `feature/rebase-demo`, сделано 3 коммита.
5. Выполнен интерактивный rebase: `git rebase -i HEAD~3`, три коммита объединены в один через `squash`.

### Output (git log --oneline после rebase)
### What I learned
я научился создавать ветки, сливать их через merge и вручную разрешать конфликты в редакторе Visual Studio 2026.