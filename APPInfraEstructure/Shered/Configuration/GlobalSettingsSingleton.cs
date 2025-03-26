using DominioDeTestes.config;
using Newtonsoft.Json;
using Shered.Configuration;
using Shered.DB.Connection;
using System;
using System.Data;
using System.IO;

public sealed class GS
{
    private static readonly Lazy<GS> instance = new(() => new GS());

    public MyConfig MYC { get; private set; } // Agora será corretamente inicializado

    private GS()
    {
        try
        {
            var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);

                // Agora a configuração é atribuída corretamente à propriedade MYC
                MYC = jsonObject.MyConfig.ToObject<MyConfig>();
            }
            else
            {
                Console.WriteLine("Erro: Arquivo appsettings.json não encontrado.");
                MYC = new MyConfig(); // Evita NullReferenceException
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
            MYC = new MyConfig(); // Evita falha na instância
        }
    }
    public static GS I => instance.Value;
}
