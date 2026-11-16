using System.Text.Json.Serialization;
namespace Clinica.Atendimentos;

[JsonSerializable(typeof(PlanoConsultas))]
[JsonSerializable(typeof(ResultadoRecorrencia))]
[JsonSerializable(typeof(List<EscolhaRecorrencia>))]
public partial class RecorrenciaJsonContext : JsonSerializerContext { }
