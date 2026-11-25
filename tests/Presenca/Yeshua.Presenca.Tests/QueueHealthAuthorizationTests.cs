using Aplication.Interfaces.Services;
using Moq;
using Presenca.Editorial;
using Read.Repository;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Presenca.Tests;
public sealed class QueueHealthAuthorizationTests
{
 [Theory][InlineData(1,"health-tests",403)][InlineData(32,"",503)]
 public void Queue_counts_require_operator_authorization_and_a_real_processing_scope_before_reading_data(int grant,string scope,int status)
 {
  var work=new Mock<IUnitOfWork>(MockBehavior.Strict);
  work.Setup(w=>w.ExecuteScalar<int>(It.IsAny<string>(),It.IsAny<object?>())).Returns(grant);
  var context=new Mock<IExecutionContext>();context.SetupGet(c=>c.ProcessingScope).Returns(scope);
  var repository=new IdentidadePublicadoraReadRepository(work.Object,context.Object);
  var request=new PedidoEditorial("ConsultarOperacao",RegrasEditoriais.Id("publisher"),"","",0,"{}");
  var error=Assert.Throws<EditorialException>(()=>repository.Consultar(1,10,request));Assert.Equal(status,error.Status);
  work.Verify(w=>w.Query<SaudeFilaEditorial>(It.IsAny<string>(),It.IsAny<object?>()),Times.Never);
  work.Verify(w=>w.Query<EntregaEditorial>(It.IsAny<string>(),It.IsAny<object?>()),Times.Never);
 }
}
