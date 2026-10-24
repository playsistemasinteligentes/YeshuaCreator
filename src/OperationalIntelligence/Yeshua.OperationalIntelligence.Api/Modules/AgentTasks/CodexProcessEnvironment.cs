using System.Diagnostics;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public static class CodexProcessEnvironment
{
    private static readonly string[] Allowed =
    [
        "PATH", "HOME", "USERPROFILE", "SYSTEMROOT", "WINDIR", "COMSPEC", "PATHEXT", "TEMP", "TMP",
        "LANG", "LC_ALL", "CODEX_HOME", "CODEX_BINARY_PATH", "OPERATIONAL_INTELLIGENCE_MCP_URL"
    ];

    public static void Apply(ProcessStartInfo start, AgentTaskOptions options)
    {
        start.Environment.Clear();
        foreach (var key in Allowed)
        {
            var value = Environment.GetEnvironmentVariable(key);
            if (value is not null) start.Environment[key] = value;
        }
        if (options.ChatGptAuthentication)
            start.Environment["CODEX_HOME"] = options.CodexHomePath;
        else
            foreach (var key in new[] { "OPENAI_API_KEY", "OPENAI_BASE_URL" })
            {
                var value = Environment.GetEnvironmentVariable(key);
                if (value is not null) start.Environment[key] = value;
            }
    }
}
