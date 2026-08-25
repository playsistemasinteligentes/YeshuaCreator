namespace TestMigration
{
    [TestClass]
    public class MigrationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ValidateCompositeKeysAreNotImplementedRejectsWritableEntity()
        {
            var entity = new Dominio.Entity("Roteiro");
            entity
                .AddColumn("MaquinaId", "Maquina").Varchar(30).Key()
                .AddColumn("ProdutoId", "Produto").Varchar(30).Key();

            var exception = Assert.ThrowsException<NotSupportedException>(
                () => Dominio.Migration.MigrationBuilder.ValidateCompositeKeysAreNotImplemented(new[] { entity }));

            StringAssert.Contains(exception.Message, "Chave composta ainda nao esta implementada");
            StringAssert.Contains(exception.Message, "Roteiro");
            StringAssert.Contains(exception.Message, "MaquinaId, ProdutoId");
        }

        [TestMethod]
        public void ValidateCompositeKeysAreNotImplementedAllowsViewEntity()
        {
            var entity = new Dominio.Entity("RoteiroPedido");
            entity
                .FromView("VW_ROTEIRO_PEDIDO")
                .AddColumn("PedidoId", "Pedido").Varchar(30).Key()
                .AddColumn("SequenciaTransformacao", "Sequencia").Int().Key();

            Dominio.Migration.MigrationBuilder.ValidateCompositeKeysAreNotImplemented(new[] { entity });
        }
    }
}
