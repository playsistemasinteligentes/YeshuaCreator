using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Receivers.UseCase;
using Command.UseCase;
using Memorias.YouTube;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class YouTubeApplicationConfigurationTests
{
    private const string ClientId = "123-test.apps.googleusercontent.com";
    private const string Secret = "GOCSPX-test-secret-only";
    private static readonly YouTubeOwner Admin = new(7, 9);

    [Theory]
    [InlineData(7, 10)]
    [InlineData(8, 9)]
    public async Task AnotherUserOrTenantCannotReadOrSaveGlobalConfiguration(int tenant, int user)
    {
        using var rig = new Rig();
        await rig.Service.SaveAsync(Admin, ClientId, Secret, default);
        var owner = new YouTubeOwner(tenant,user);
        Assert.Equal(new(false,false),rig.Service.Read(owner));
        await Assert.ThrowsAsync<YouTubeConfigurationAccessException>(()=>rig.Service.SaveAsync(owner,ClientId,Secret,default));
    }

    [Fact]
    public async Task LegacyAdminRoleDoesNotAuthorizeConfigurationAndInputSecretIsCleared()
    {
        using var rig = new Rig();
        var context = TestProxy.For<IExecutionContext>((method,_)=>method switch
        {
            "get_TenantID"=>7, "get_UserId"=>10,
            "get_Claims"=>new[]{new Claim(ClaimTypes.Role,"Admin")}, _=>null
        });
        var input=new SalvarConfiguracaoYouTubeInputCommand{ClientId=ClientId,ClientSecret=Secret};
        var result=await new SalvarConfiguracaoYouTubeHandler(TestProxy.For<Dominio.Interfaces.ILogger>(),context,rig.Service).ExecuteAsync(input);
        Assert.Equal(403,result.StatusCode);Assert.Empty(input.ClientSecret);Assert.Null(rig.Repository.Read());
        Assert.DoesNotContain(Secret,JsonSerializer.Serialize(result));
    }

    [Fact]
    public async Task NoConfiguredAdministratorFailsClosed()
    {
        using var rig=new Rig();rig.Baseline.ConfigurationAdminUserId=0;
        Assert.False(rig.Service.Read(Admin).PodeConfigurar);
        await Assert.ThrowsAsync<YouTubeConfigurationAccessException>(()=>rig.Service.SaveAsync(Admin,ClientId,Secret,default));
    }

    [Fact]
    public async Task ConfigurationIsEncryptedAndSurvivesRestartWithoutEnvironmentCredentials()
    {
        using var rig=new Rig();
        var status=await rig.Service.SaveAsync(Admin,ClientId,Secret,default);
        Assert.True(status.Configurado);Assert.True(status.SegredoSalvo);
        var safe=JsonSerializer.Serialize(status);Assert.DoesNotContain(Secret,safe);Assert.DoesNotContain("EncryptionKey",safe);Assert.DoesNotContain("ClientSecret",safe);
        var binary=Directory.GetFiles(rig.Root,"oauth.bin",SearchOption.AllDirectories).Single();
        Assert.DoesNotContain(Secret,Encoding.UTF8.GetString(File.ReadAllBytes(binary)));
        var restarted=new EncryptedYouTubeApplicationConfigurationRepository(rig.Baseline.Snapshot(null));
        var loaded=restarted.Read()!;Assert.Equal(Secret,loaded.ClientSecret);Assert.Equal(32,Convert.FromBase64String(loaded.EncryptionKey).Length);
        Assert.True(rig.Baseline.Snapshot(loaded).Configured);
        if(!OperatingSystem.IsWindows())Assert.Equal(UnixFileMode.UserRead|UnixFileMode.UserWrite,File.GetUnixFileMode(binary));
    }

    [Fact]
    public async Task ApiAndWorkerLoadNewConfigurationWithoutMutatingActiveScopes()
    {
        using var rig=new Rig();
        var configuration=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["MemoriasYouTube:CredentialsDirectory"]=rig.Root,["MemoriasYouTube:RedirectUri"]=rig.Baseline.RedirectUri,
            ["MemoriasYouTube:ConfigurationAdminTenantId"]="7",["MemoriasYouTube:ConfigurationAdminUserId"]="9",
            ["YeshuaProcessing:Scope"]="test"
        }).Build();
        using var api=new ServiceCollection().AddMemoriasYouTube(configuration).BuildServiceProvider();
        using var worker=new ServiceCollection().AddMemoriasYouTube(configuration).BuildServiceProvider();
        using var previous=api.CreateScope();var old=previous.ServiceProvider.GetRequiredService<YouTubeOptions>();Assert.False(old.Configured);
        await api.GetRequiredService<IYouTubeApplicationConfigurationService>().SaveAsync(Admin,ClientId,Secret,default);
        using var next=api.CreateScope();using var background=worker.CreateScope();
        var current=next.ServiceProvider.GetRequiredService<YouTubeOptions>();
        Assert.True(current.Configured);Assert.Equal(current.ClientSecret,background.ServiceProvider.GetRequiredService<YouTubeOptions>().ClientSecret);
        Assert.False(old.Configured);Assert.NotSame(old,current);
    }

    [Fact]
    public async Task SecretUpdateKeepsProtectionKeyAndExistingChannelAndUploadReceipt()
    {
        using var rig=new Rig();
        await rig.Service.SaveAsync(Admin,ClientId,Secret,default);
        var initial=rig.Repository.Read()!;var options=rig.Baseline.Snapshot(initial);
        var connection=Guid.NewGuid().ToString("N");var repository=new EncryptedYouTubeAccountRepository(options);
        using(var lease=await repository.AcquireAsync(Admin,default))
        {
            lease.SaveAccount(new(ClientId,"access","refresh",DateTime.UtcNow.AddHours(1),"channel-a","Channel",connection));
            lease.SaveUpload(new(123,connection,"channel-a","video.mp4",10,"hash","https://www.googleapis.com/upload/session","video-id"));
        }
        await rig.Service.SaveAsync(Admin,ClientId,"GOCSPX-rotated-secret",default);
        await rig.Service.SaveAsync(Admin,ClientId,"",default);
        var updated=rig.Repository.Read()!;Assert.Equal(initial.EncryptionKey,updated.EncryptionKey);Assert.Equal("GOCSPX-rotated-secret",updated.ClientSecret);
        using var next=await new EncryptedYouTubeAccountRepository(rig.Baseline.Snapshot(updated)).AcquireAsync(Admin,default);
        Assert.Equal("refresh",next.ReadAccount(connection)!.RefreshToken);Assert.Equal("video-id",next.ReadUpload(123)!.VideoId);
    }

    [Fact]
    public async Task LegacyEnvironmentKeyIsPreservedAndClientIdCannotChange()
    {
        using var rig=new Rig();rig.Baseline.ClientId=ClientId;rig.Baseline.ClientSecret=Secret;
        rig.Baseline.EncryptionKey=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        await rig.Service.SaveAsync(Admin,ClientId,"",default);
        Assert.Equal(rig.Baseline.EncryptionKey,rig.Repository.Read()!.EncryptionKey);
        await Assert.ThrowsAsync<YouTubeConnectionException>(()=>rig.Service.SaveAsync(Admin,"other-test.apps.googleusercontent.com",Secret,default));
        Assert.Equal(ClientId,rig.Repository.Read()!.ClientId);
    }

    [Fact]
    public async Task MissingKeyCannotSilentlyReplaceExistingProtection()
    {
        using var rig=new Rig();await rig.Service.SaveAsync(Admin,ClientId,Secret,default);
        var path=Directory.GetFiles(rig.Root,"key.bin",SearchOption.AllDirectories).Single();File.Delete(path);
        Assert.Throws<YouTubeConnectionException>(()=>rig.Repository.Read());
        await Assert.ThrowsAsync<YouTubeConnectionException>(()=>rig.Repository.SaveAsync(ClientId,Secret,default));Assert.False(File.Exists(path));
    }

    [Theory]
    [InlineData("https://evil.example",Secret)]
    [InlineData(ClientId,"bad\nsecret")]
    [InlineData(ClientId,"")]
    public async Task InvalidConfigurationIsRejectedWithoutPersisting(string clientId,string secret)
    {
        using var rig=new Rig();await Assert.ThrowsAsync<YouTubeConnectionException>(()=>rig.Service.SaveAsync(Admin,clientId,secret,default));
        Assert.Null(rig.Repository.Read());Assert.Empty(Directory.GetFiles(rig.Root,"*",SearchOption.AllDirectories));
    }

    [Fact]
    public async Task ConcurrentSavesAcrossHostsRemainDecryptableAndKeepSameKey()
    {
        using var rig=new Rig();var other=new EncryptedYouTubeApplicationConfigurationRepository(rig.Baseline);
        await Task.WhenAll(Task.Run(()=>rig.Repository.SaveAsync(ClientId,Secret,default)),Task.Run(()=>other.SaveAsync(ClientId,"GOCSPX-another-secret",default)));
        Assert.Equal(rig.Repository.Read()!.EncryptionKey,other.Read()!.EncryptionKey);
        Assert.Contains(rig.Repository.Read()!.ClientSecret,new[]{Secret,"GOCSPX-another-secret"});
    }

    [Fact]
    public async Task ConfigurationDoesNotCrossProcessingScopes()
    {
        using var rig=new Rig();await rig.Service.SaveAsync(Admin,ClientId,Secret,default);
        var other=rig.Baseline.Snapshot(null);other.ProcessingScope="other";
        Assert.Null(new EncryptedYouTubeApplicationConfigurationRepository(other).Read());
    }

    private sealed class Rig : IDisposable
    {
        public string Root { get; }=Path.Combine(Path.GetTempPath(),"memorias-config-"+Guid.NewGuid().ToString("N"));
        public YouTubeOptions Baseline { get; }
        public EncryptedYouTubeApplicationConfigurationRepository Repository { get; }
        public YouTubeApplicationConfigurationService Service { get; }
        public Rig()
        {
            Directory.CreateDirectory(Root);
            Baseline=new(){CredentialsDirectory=Root,ProcessingScope="test",RedirectUri="https://playsis.com.br/spa/youtube-callback.html",ConfigurationAdminTenantId=7,ConfigurationAdminUserId=9};
            Repository=new(Baseline);Service=new(Baseline,Repository);
        }
        public void Dispose()=>Directory.Delete(Root,true);
    }
}
