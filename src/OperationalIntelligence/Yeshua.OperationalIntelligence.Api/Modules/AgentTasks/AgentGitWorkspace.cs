using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class AgentGitWorkspace(IOptions<AgentTaskOptions> options, AgentGitHubClient github)
{
    private AgentGitOptions Settings => options.Value.Git;
    public static string Branch(Guid taskId) => "codex/task-" + taskId.ToString("N");

    public string TaskPath(Guid taskId)
    {
        if (!Path.IsPathFullyQualified(Settings.WorkspacesRoot))
            throw new ArgumentException("O diretorio de workspaces do agente deve ser absoluto.");
        return Path.Combine(Settings.WorkspacesRoot, taskId.ToString("N"));
    }

    private string RepositoryUrl()
    {
        if (!Regex.IsMatch(Settings.Owner, "^[A-Za-z0-9][A-Za-z0-9-]{0,38}$")
            || !Regex.IsMatch(Settings.Repository, "^[A-Za-z0-9][A-Za-z0-9_.-]{0,99}$")
            || !Regex.IsMatch(Settings.BaseBranch, "^[A-Za-z0-9][A-Za-z0-9_./-]{0,99}$")
            || Settings.BaseBranch.Contains("..", StringComparison.Ordinal))
            throw new ArgumentException("Repositorio Git do agente invalido.");
        return $"https://github.com/{Settings.Owner}/{Settings.Repository}.git";
    }

    public async Task<string> PrepareAsync(AgentTaskWorkItem item, CancellationToken token)
    {
        if (!Settings.Enabled) return options.Value.WorkspacePath;
        var path = TaskPath(item.TaskId);
        if (item.Mode != "workspace-write")
            return Directory.Exists(Path.Combine(path, ".git")) ? path : options.Value.WorkspacePath;
        var remote = RepositoryUrl();
        if (Settings.PublishPullRequests && !github.Configured)
            throw new ArgumentException("A publicacao de PRs exige configurar o usuario e o token GitHub do agente no cofre privado.");
        if (!Directory.Exists(Path.Combine(path, ".git")))
        {
            if (item.IsContinuation)
                throw new ArgumentException("O workspace de desenvolvimento desta task nao esta disponivel. Historico preservado; inicie outra task para desenvolver.");
            Directory.CreateDirectory(Settings.WorkspacesRoot);
            if (Directory.Exists(path) || File.Exists(path))
                throw new ArgumentException("O destino da task ja existe sem um repositorio valido; nenhum arquivo foi substituido.");
            var stage = Path.Combine(Settings.WorkspacesRoot, ".prepare-" + Guid.NewGuid().ToString("N"));
            var identity = github.Configured ? await github.AuthenticateAsync(token) : null;
            await RunAsync(Settings.WorkspacesRoot, identity, token,
                "clone", "--no-hardlinks", "--single-branch", "--branch", Settings.BaseBranch, "--",
                identity is null ? options.Value.WorkspacePath : remote, stage);
            await RunAsync(stage, null, token, "remote", "set-url", "origin", remote);
            await RunAsync(stage, null, token, "checkout", "-b", Branch(item.TaskId));
            Directory.Move(stage, path);
        }
        await ValidateAsync(item.TaskId, path, remote, token);
        return path;
    }

    public async Task<string> PublishAsync(AgentTaskWorkItem item, string path, string summary, CancellationToken token)
    {
        if (!Settings.Enabled || item.Mode != "workspace-write") return "";
        var remote = RepositoryUrl();
        await ValidateAsync(item.TaskId, path, remote, token);
        var changes = await RunAsync(path, null, token, "status", "--porcelain=v1", "--untracked-files=all");
        if (!Settings.PublishPullRequests)
            return changes.Length == 0 ? "Workspace sem alteracoes." : $"Alteracoes preservadas em {Branch(item.TaskId)}. O envio de PRs ainda nao esta habilitado.";
        var identity = await github.AuthenticateAsync(token);
        var branch = Branch(item.TaskId);
        var title = "Agent: " + item.Message.Split('\n')[0].Trim();
        title = title[..Math.Min(title.Length, 120)];
        if (changes.Length > 0)
        {
            await RunAsync(path, null, token, "add", "--all", "--", ".");
            await RunAsync(path, identity, token, "commit", "-m", title);
        }
        var commits = await RunAsync(path, null, token, "rev-list", "--count", "origin/" + Settings.BaseBranch + "..HEAD");
        if (commits.Trim() == "0") return "Nenhuma alteracao para publicar.";
        await RunAsync(path, identity, token, "push", "origin", "HEAD:refs/heads/" + branch);
        var body = "Alteracao preparada pelo agente operacional.\n\nTask: `" + item.TaskId + "`\n\n"
            + summary[..Math.Min(summary.Length, 16000)] + "\n\nRevisao e deploy permanecem com o operador.";
        var url = await github.OpenDraftPullRequestAsync(identity, branch, title, body, token);
        return "PR em rascunho: " + url + "\nBranch: " + branch + "\nAguardando revisao. Nenhum merge ou deploy foi executado.";
    }

    private async Task ValidateAsync(Guid taskId, string path, string remote, CancellationToken token)
    {
        if (new DirectoryInfo(path).LinkTarget is not null || new DirectoryInfo(Path.Combine(path, ".git")).LinkTarget is not null)
            throw new ArgumentException("Workspace Git nao pode ser um link simbolico.");
        var branch = await RunAsync(path, null, token, "symbolic-ref", "--short", "HEAD");
        var origin = await RunAsync(path, null, token, "remote", "get-url", "origin");
        var push = await RunAsync(path, null, token, "remote", "get-url", "--push", "origin");
        if (branch.Trim() != Branch(taskId) || origin.Trim() != remote || push.Trim() != remote)
            throw new ArgumentException("A branch ou o repositorio da task foi alterado; publicacao bloqueada.");
    }

    private async Task<string> RunAsync(string directory, AgentGitIdentity? identity, CancellationToken token, params string[] arguments)
    {
        var start = new ProcessStartInfo("git")
        {
            WorkingDirectory = directory, UseShellExecute = false, CreateNoWindow = true,
            RedirectStandardOutput = true, RedirectStandardError = true
        };
        CodexProcessEnvironment.Apply(start, options.Value);
        start.Environment["GIT_TERMINAL_PROMPT"] = "0";
        start.Environment["GIT_CONFIG_NOSYSTEM"] = "1";
        start.ArgumentList.Add("-c"); start.ArgumentList.Add("core.hooksPath=/dev/null");
        if (identity is not null)
        {
            start.Environment["GIT_CONFIG_COUNT"] = "1";
            start.Environment["GIT_CONFIG_KEY_0"] = "http.https://github.com/.extraheader";
            start.Environment["GIT_CONFIG_VALUE_0"] = "AUTHORIZATION: basic " + Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(identity.Name + ":" + identity.Token));
            start.Environment["GIT_AUTHOR_NAME"] = start.Environment["GIT_COMMITTER_NAME"] = identity.Name;
            start.Environment["GIT_AUTHOR_EMAIL"] = start.Environment["GIT_COMMITTER_EMAIL"] = identity.Email;
        }
        foreach (var argument in arguments) start.ArgumentList.Add(argument);
        using var process = Process.Start(start) ?? throw new ArgumentException("Git do agente indisponivel.");
        var output = process.StandardOutput.ReadToEndAsync(token);
        var errors = process.StandardError.ReadToEndAsync(token);
        try
        {
            await process.WaitForExitAsync(token);
            await errors;
            if (process.ExitCode != 0)
                throw new ArgumentException("A operacao Git da task nao concluiu. Confira o acesso ao repositorio e o estado do workspace; nenhum erro com credenciais foi publicado.");
            return await output;
        }
        finally
        {
            if (!process.HasExited) process.Kill(entireProcessTree: true);
        }
    }
}
