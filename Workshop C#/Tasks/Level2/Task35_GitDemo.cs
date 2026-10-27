using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task35_GitDemo : ITask
    {
        public string Title => "Git: .gitignore, .editorconfig, PR, Conventional Commits, rebase";
        public string Description => "Пройти продвинутый git-сценарий.";
        public string[] Requirements => new[]
        {
            "Добавить .gitignore (bin/, obj/, .vs/, .user) и .editorconfig отдельным коммитом chore: add gitignore and editorconfig.",
            "Создать ветку feature/task-35, сделать 2–3 коммита по Conventional Commits.",
            "Запушить ветку на GitHub/GitLab.",
            "Открыть Pull Request в main с описанием: что сделано, что проверял.",
            "Смержить PR (можно squash-merge).",
            "Создать ветку feature/rebase-demo, 3 маленьких коммита.",
            "Объединить их через git rebase -i HEAD~3 (squash).",
            "Сохранить вывод git log --oneline после rebase в git-notes.md."
        };
        public void Run()
        {
            Console.WriteLine("ПРИВЕТ МИР!");
        }
    }
}
