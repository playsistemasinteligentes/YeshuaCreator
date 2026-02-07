using Newtonsoft.Json;
using Shered.Configuration;


public sealed class GS
{
    private static readonly Lazy<GS> instance = new(() => new GS());

    public MyConfig MYC { get; private set; }

    private GS()
    {
        try
        {
            // 1️⃣ Carrega appsettings.json (fallback)
            var jsonPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "appsettings.json"
            );

            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
                MYC = jsonObject.MyConfig.ToObject<MyConfig>();
            }
            else
            {
                Console.WriteLine("appsettings.json não encontrado, usando defaults.");
                MYC = new MyConfig();
            }

            // 2️⃣ Override manual por variáveis de ambiente (se existirem)
            OverrideIfExists("MYCONFIG__READCONECTIONSTRING", v => MYC.ReadConectionString = v);
            OverrideIfExists("MYCONFIG__WRITECONECTIONSTRING", v => MYC.WriteConectionString = v);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
            MYC = new MyConfig();
        }
    }

    private void OverrideIfExists(string envKey, Action<string> setter)
    {
        var value = Environment.GetEnvironmentVariable(envKey);
        if (!string.IsNullOrWhiteSpace(value))
            setter(value);
    }

    public static GS I => instance.Value;
}
