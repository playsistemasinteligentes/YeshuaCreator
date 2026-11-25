using System.Text.Json;
using Presenca.Editorial;
namespace Presenca.Tests;
public sealed class FactoryContractTests
{
 [Fact] public void Four_python_producer_fixtures_pass_the_real_csharp_ingress_validator()
 {
  using var fixtures=JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory,"Fixtures","factory-inputs.json")));
  var types=new HashSet<string>();
  foreach(var json in fixtures.RootElement.EnumerateArray())
  {
   var validated=ContratosEditoriais.Validar("MovimentoFabricaDisponivel.v1",json.GetRawText());
   Assert.False(validated.AprovadaNaOrigem);Assert.Equal("Fabrica",validated.Conteudo.ClassificacaoPrincipal);
   Assert.InRange(validated.MovimentoId.Length,1,120);types.Add(validated.Tipo);
  }
  Assert.Equal(4,types.Count);
 }
}
