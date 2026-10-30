using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Configuration;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Database;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class SourceRepositorySqlTests
{
    [TestMethod]
    [TestCategory("SqlIntegration")]
    public async Task SqlDiscoveryPinsBuildsReadsStoredCodeAndBoundsCyclicRelations()
    {
        var server = Environment.GetEnvironmentVariable("YESHUA_OI_TEST_SQL_CONNECTION");
        if (string.IsNullOrWhiteSpace(server)) Assert.Inconclusive("Optional SQL integration: set YESHUA_OI_TEST_SQL_CONNECTION to a disposable local test server.");
        var name = "YeshuaSourceSearchTests_" + Guid.NewGuid().ToString("N");
        var connectionString = new SqlConnectionStringBuilder(server) { InitialCatalog = name }.ConnectionString;
        var options = Options.Create(new OperationalIntelligenceOptions());
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["ConnectionStrings:OperationalIntelligence"] = connectionString
        }).Build();
        var database = new OperationalIntelligenceDatabase(configuration, options, NullLogger<OperationalIntelligenceDatabase>.Instance);
        try
        {
            await database.InitializeAsync();
            await using var connection = await database.OpenConnectionAsync();
            var application = Guid.NewGuid();
            var build = Guid.NewGuid();
            var newerBuild = Guid.NewGuid();
            var project = Guid.NewGuid();
            var file = Guid.NewGuid();
            var secondDsl = Guid.NewGuid();
            var newerFile = Guid.NewGuid();
            var codeFile = Guid.NewGuid();
            var screenFile = Guid.NewGuid();
            var metadataFile = Guid.NewGuid();
            var ids = Enumerable.Range(0, 28).Select(_ => Guid.NewGuid()).ToArray();
            const string source = "AddEntity(\"Album\");\nAddCommand(\"Publicar\");\n// versão original";
            await connection.ExecuteAsync("""
                INSERT OI_Applications(ApplicationId,Name,SystemType) VALUES (@application,'Memorias','YESHUA');
                INSERT OI_Builds(BuildId,ApplicationId,Version,CommitSha,SourceSolution,GeneratedAtUtc)
                VALUES (@build,@application,'v1','a','Test.sln', '2026-10-29'),(@newerBuild,@application,'v1','b','Test.sln', '2026-10-30');
                INSERT OI_Files(FileId,BuildId,ProjectId,RelativePath,HashSha256,ArtifactKind,SourceRole)
                VALUES (@file,@build,@project,'src/Studio/Migrations/M000001.cs',REPLICATE('a',64),'DSL_SPECIFICATION','DSL_SPECIFICATION'),
                    (@secondDsl,@build,@project,'src/Studio/Migrations/M000003.cs',REPLICATE('a',64),'DSL_SPECIFICATION','DSL_SPECIFICATION'),
                    (@newerFile,@newerBuild,@project,'src/Studio/Migrations/M000002.cs',REPLICATE('b',64),'DSL_SPECIFICATION','DSL_SPECIFICATION'),
                    (@codeFile,@build,@project,'src/Receivers/PublicarHandler.cs',REPLICATE('a',64),'APPLICATION_SOURCE','USE_CASE'),
                    (@screenFile,@build,@project,'src/Front/register.html',REPLICATE('a',64),'APPLICATION_SOURCE','FRONTEND_SOURCE'),
                    (@metadataFile,@build,@project,'src/Api/Migration/EndPoints.cs',REPLICATE('a',64),'GENERATED_REGENERABLE','ARCHITECTURE_BORDER');
                INSERT OI_SourceContents(HashSha256,Compression,Content,OriginalByteLength,StoredByteLength,CreatedAtUtc)
                VALUES (REPLICATE('a',64),'NONE',@content,@length,@length,SYSUTCDATETIME());
                INSERT OI_TextReferences(TextReferenceId,BuildId,FileId,Token,ReferenceKind,Line,ColumnNumber,ContextSnippet)
                VALUES (NEWID(),@build,@file,'Publicar','CSHARP_STRING',2,1,'AddCommand("Publicar")'),
                    (NEWID(),@build,@screenFile,'cadastro','MARKUP_TOKEN',1,1,'Criação de conta'),
                    (NEWID(),@build,@metadataFile,'Album','CSHARP_STRING',1,1,'getMetaDataAlbum');
                """, new { application, build, newerBuild, project, file, secondDsl, newerFile, codeFile, screenFile, metadataFile, content = Encoding.UTF8.GetBytes(source), length = Encoding.UTF8.GetByteCount(source) });
            foreach (var (id, index) in ids.Select((id, index) => (id, index)))
            {
                await connection.ExecuteAsync("""
                    INSERT OI_Symbols(SymbolId,BuildId,ProjectId,Kind,Name,QualifiedName,SymbolKey)
                    VALUES (@id,@build,@project,'METHOD',@symbol,@qualified,@qualified);
                    INSERT OI_Declarations(DeclarationId,BuildId,SymbolId,FileId,StartLine,StartColumn,EndLine,EndColumn)
                    VALUES (NEWID(),@build,@id,@codeFile,1,1,3,1);
                    """, new { id, build, project, codeFile, symbol = index == 0 ? "Publicar" : "Step" + index, qualified = "App." + (index == 0 ? "Publicar" : "Step" + index) });
            }
            var fieldSymbol = Guid.NewGuid();
            var classSymbol = Guid.NewGuid();
            await connection.ExecuteAsync("""
                INSERT OI_Symbols(SymbolId,BuildId,ProjectId,Kind,Name,QualifiedName,SymbolKey)
                VALUES (@fieldSymbol,@build,@project,'PROPERTY','Titulo','App.Album.Titulo','field'),
                    (@classSymbol,@build,@project,'CLASS','Album','App.Album','class');
                INSERT OI_Declarations(DeclarationId,BuildId,SymbolId,FileId,StartLine,StartColumn,EndLine,EndColumn)
                VALUES (NEWID(),@build,@fieldSymbol,@codeFile,1,1,1,1),
                    (NEWID(),@build,@classSymbol,@codeFile,1,1,3,1);
                """, new { fieldSymbol, classSymbol, build, project, codeFile });
            for (var reference = 0; reference < 12; reference++)
                await connection.ExecuteAsync("""
                    INSERT OI_FieldReferences(FieldReferenceId,BuildId,FieldSymbolId,ContainingFunctionId,FileId,AccessKind,Line,ColumnNumber,ResolutionKind)
                    VALUES (NEWID(),@build,@fieldSymbol,@function,@codeFile,'READ',1,1,'SEMANTIC');
                    INSERT OI_ClassInstantiations(InstantiationId,BuildId,ClassSymbolId,ContainingFunctionId,FileId,Line,ColumnNumber,ResolutionKind)
                    VALUES (NEWID(),@build,@classSymbol,@function,@codeFile,1,1,'SEMANTIC');
                    """, new { fieldSymbol, classSymbol, build, codeFile, function = ids[0] });
            // Dense shared dependencies, duplicate call sites and a cycle must not enumerate every path.
            foreach (var caller in ids.Take(7))
                foreach (var called in ids.Skip(1))
                    await connection.ExecuteAsync("INSERT OI_FunctionCalls(FunctionCallId,BuildId,CallerFunctionId,CalledFunctionId,ResolutionKind) VALUES (NEWID(),@build,@caller,@called,'SEMANTIC');", new { build, caller, called });
            await connection.ExecuteAsync("INSERT OI_FunctionCalls(FunctionCallId,BuildId,CallerFunctionId,CalledFunctionId,ResolutionKind) VALUES (NEWID(),@build,@caller,@called,'SEMANTIC');", new { build, caller = ids[1], called = ids[0] });

            var repository = new SourceContextRepository(database, options);
            var search = new SourceSearch(repository);
            var request = new SourceExplorationRequest { Application = "Memorias", Kind = "dsl", BuildId = build, Version = "v1", IncludeContent = true, MaxResults = 1 };
            var dsl = await search.SearchAsync(request, default);
            Assert.AreEqual(build, dsl.Build!.BuildId);
            StringAssert.Contains(dsl.Snippets.Single().Content, "versão original");
            Assert.IsTrue(dsl.Next.All(next => next.Arguments.BuildId == build));
            var page = await search.SearchAsync(dsl.Next.Single(next => next.Arguments.Offset == 1).Arguments, default);
            Assert.AreEqual(build, page.Build!.BuildId);
            Assert.AreEqual("src/Studio/Migrations/M000003.cs", page.SourceFiles.Single().File);
            var latest = await search.SearchAsync(request with { BuildId = null, IncludeContent = false }, default);
            Assert.AreEqual(newerBuild, latest.Build!.BuildId);
            Assert.AreEqual("src/Studio/Migrations/M000002.cs", latest.SourceFiles.Single().File);
            foreach (var (kind, query, expectedPath) in new[]
            {
                ("action", "Publicar", "src/Studio/Migrations/M000001.cs"),
                ("screen", "criacao", "src/Front/register.html"),
                ("metadata", "Album", "src/Api/Migration/EndPoints.cs")
            })
            {
                var result = await search.SearchAsync(request with { Kind = kind, Query = query, IncludeContent = false }, default);
                Assert.IsTrue(result.SourceFiles.Any(item => item.File == expectedPath), kind);
                Assert.IsTrue(result.References.All(reference => reference.Kind == "TEXT_REFERENCE"));
            }
            var functions = await search.SearchAsync(request with { Kind = "function", Query = "App.Publicar", MaxDepth = 3, MaxResults = 5, IncludeContent = false }, default);
            Assert.AreEqual(1, functions.Matches.Count);
            Assert.IsTrue(functions.Chains.Count <= 5);
            Assert.AreEqual(functions.Chains.Count, functions.Chains.DistinctBy(chain => (chain.Direction,
                chain.Direction == "UPSTREAM" ? chain.Path.Split(" -> ").First() : chain.Path.Split(" -> ").Last())).Count());
            var upstream = await search.SearchAsync(request with { Kind = "function", Query = "App.Publicar", MaxDepth = 3, MaxResults = 5, Direction = "upstream", IncludeContent = false }, default);
            Assert.IsTrue(upstream.Chains.All(chain => chain.Direction == "UPSTREAM"));
            foreach (var (kind, symbol) in new[] { ("field", "App.Album.Titulo"), ("class", "App.Album") })
            {
                var result = await search.SearchAsync(request with { Kind = kind, Query = symbol, MaxDepth = 3, MaxResults = 5, IncludeContent = false }, default);
                Assert.AreEqual(1, result.Matches.Count, kind);
                Assert.IsTrue(result.Chains.Count <= 5, kind);
                Assert.AreEqual(result.Chains.Count, result.Chains.Select(chain => chain.Path.Split(" -> ").First()).Distinct().Count(), kind);
            }
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() => search.SearchAsync(request with { Version = "wrong" }, default));
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() => search.SearchAsync(request with { Application = "Other" }, default));
        }
        finally
        {
            // Only this unique test catalog may be removed; never use the caller's InitialCatalog.
            if (name.StartsWith("YeshuaSourceSearchTests_", StringComparison.Ordinal) && Guid.TryParseExact(name[24..], "N", out _))
            {
                using var pool = new SqlConnection(connectionString);
                SqlConnection.ClearPool(pool);
                var master = new SqlConnectionStringBuilder(server) { InitialCatalog = "master" };
                await using var cleanup = new SqlConnection(master.ConnectionString);
                await cleanup.OpenAsync();
                await cleanup.ExecuteAsync($"IF DB_ID(@name) IS NOT NULL BEGIN ALTER DATABASE [{name}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{name}]; END;", new { name });
            }
        }
    }
}
