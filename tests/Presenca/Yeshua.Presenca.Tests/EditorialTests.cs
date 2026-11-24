using System.Text.Json;
using Presenca.Editorial;
using Dominio.Migration;
using Dominio.Schemas;
using Yeshua.Studio.Presenca;
namespace Presenca.Tests;
public class EditorialTests
{
 internal static DadosEditorial Example()=>new(){Manchete="Novidades do Yeshua",Corpo="Conteúdo público revisável.",ClassificacaoPrincipal="Produto",AutorPublico="Play Sistemas",Fontes=["https://example.org/fonte"]};
 [Theory][InlineData(0,1,127)][InlineData(1,0,127)][InlineData(1,1,0)][InlineData(1,1,1)]
 public void Missing_identity_or_permission_denies(int tenant,int actor,int grant)=>Assert.Equal(403,Assert.Throws<EditorialException>(()=>RegrasEditoriais.Autorizar(tenant,actor,grant,PermissaoEditorial.Publicar)).Status);
 [Fact] public void Grants_do_not_imply_other_roles()=>Assert.Throws<EditorialException>(()=>RegrasEditoriais.Autorizar(1,2,(int)PermissaoEditorial.Administrar,PermissaoEditorial.Aprovar));
 [Fact] public void Scope_hash_is_not_ambiguous_and_is_tenant_specific()
 {Assert.NotEqual(RegrasEditoriais.Id("a:b","c"),RegrasEditoriais.Id("a","b:c"));Assert.NotEqual(RegrasEditoriais.Id("1","same"),RegrasEditoriais.Id("2","same"));}
 [Fact] public void Canonical_input_ignores_json_property_order()
 {var a=new PedidoEditorial("CriarPautaManual",new string('A',64),"","request",0,"{\"Nome\":\"A\",\"UsuarioId\":2}");var b=a with {Dados="{\"UsuarioId\":2,\"Nome\":\"A\"}"};Assert.Equal(RegrasEditoriais.Canonico(a,RegrasEditoriais.Dados(a.Dados)),RegrasEditoriais.Canonico(b,RegrasEditoriais.Dados(b.Dados)));}
 [Theory][InlineData("{\"Canais\":null}")][InlineData("{\"Manchete\":null}")][InlineData("{\"Materiais\":null}")]
 public void Explicit_json_nulls_are_rejected(string json)=>Assert.Throws<EditorialException>(()=>RegrasEditoriais.Dados(json));
 [Fact] public void Private_or_unknown_properties_are_not_silently_ingested()=>Assert.Throws<EditorialException>(()=>RegrasEditoriais.Dados("{\"token\":\"secret\"}"));
 [Theory][InlineData("Rascunho","AprovarVersao")][InlineData("Aprovada","SubmeterRevisao")][InlineData("Rejeitada","AprovarVersao")]
 public void Invalid_transitions_fail(string state,string operation)=>Assert.Throws<EditorialException>(()=>RegrasEditoriais.Transicao(state,operation,1,2,true));
 [Fact] public void Approval_is_explicit_and_separates_author_and_reviewer()
 {Assert.Throws<EditorialException>(()=>RegrasEditoriais.Transicao("EmRevisao","AprovarVersao",1,1,true));Assert.Throws<EditorialException>(()=>RegrasEditoriais.Transicao("EmRevisao","AprovarVersao",1,2,false));Assert.Equal("Aprovada",RegrasEditoriais.Transicao("EmRevisao","AprovarVersao",1,2,true));}
 [Fact] public void Stale_revision_fails()=>Assert.Equal(409,Assert.Throws<EditorialException>(()=>RegrasEditoriais.Concorrencia(2,1)).Status);
 [Theory][InlineData("javascript:alert(1)")][InlineData("http://example.org")][InlineData("https://user:password@example.org")][InlineData("https://localhost/file")]
 public void Unsafe_sources_fail(string url){var d=Example();d.Fontes=[url];Assert.Throws<EditorialException>(()=>RegrasEditoriais.Conteudo(d));}
 [Fact] public void Material_traversal_fails()
 {var d=Example();d.Materiais=[new("../private",new string('a',64),12,"image/png","autor","licença","imagem")];Assert.Throws<EditorialException>(()=>RegrasEditoriais.Conteudo(d));}
 [Fact] public void Public_snapshot_excludes_administration_and_receipts()
 {var d=Example();d.Conexao="private-reference";d.UsuarioId=22;d.ReciboExterno="private-receipt";var json=JsonSerializer.Serialize(RegrasEditoriais.Conteudo(d),EditorialJson.Default.ConteudoPublico);Assert.DoesNotContain("private",json);Assert.DoesNotContain("UsuarioId",json);}
 [Fact] public void Dsl_is_tenant_scoped_and_has_no_public_entity_crud()
 {var migration=new M000001();migration.Up();MigrationBuilder.ValidateInternalEntities([migration]);Assert.Equal(14,migration.Entitys.Count);Assert.All(migration.Entitys,e=>{Assert.True(e.IsInternal);Assert.False(e.IsGlobal);});var schema=new SqlServerSchema(null!,"Presenca");foreach(var e in migration.Entitys){var sql=schema.CreateTable(e).Query;Assert.Contains("PRIMARY KEY",sql,StringComparison.OrdinalIgnoreCase);if(e.AddColumns.Any(c=>c.Name=="IdentidadeId"))Assert.Matches(@"(?i)\[IdentidadeId\] varchar\(64\)",sql);}}
}
