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

        [TestMethod]
        public void ImmutableColumnMetadataSurvivesStandardFieldCopy()
        {
            var standardFields = new Dominio.Entity("yStandardFields");
            standardFields
                .AddColumn("OperationalEntityId", "Identificador operacional")
                .Varchar(32)
                .DefaultValue("#Guid.NewGuid().ToString(\"N\")")
                .Immutable();
            var target = new Dominio.Entity("Carga");

            var copy = standardFields.AddColumns.Single().DeepCopy(target);

            Assert.IsTrue(copy.IsImmutable);
            Assert.AreEqual("OperationalEntityId", copy.Name);
            Assert.AreEqual("#Guid.NewGuid().ToString(\"N\")", copy.ValueDefault);
        }

        [TestMethod]
        public void TenantUsesCentralGlobalIdentityInsteadOfLocalIncrement()
        {
            var migration = new global::Migration.Dominio.Migration.S000001();
            migration.Up();

            var tenant = migration.Entitys.Single(entity => entity.EntityName == "yTenant");
            var id = tenant.AddColumns.Single(column => column.Name == "Id");

            Assert.IsTrue(id.IsGlobalIdentity);
            Assert.AreEqual("Central", id.GlobalIdentityAuthority);
            Assert.IsTrue(id.IsImmutable);
            Assert.IsTrue(id.IsNotNull);
            Assert.IsFalse(id.AutoIncremento);
        }

        [TestMethod]
        public void UserUsesCentralGlobalIdentityInsteadOfLocalIncrement()
        {
            var migration = new global::Migration.Dominio.Migration.S000001();
            migration.Up();

            var user = migration.Entitys.Single(entity => entity.EntityName == "yUser");
            var id = user.AddColumns.Single(column => column.Name == "Id");

            Assert.IsTrue(id.IsGlobalIdentity);
            Assert.AreEqual("Central", id.GlobalIdentityAuthority);
            Assert.IsTrue(id.IsImmutable);
            Assert.IsTrue(id.IsNotNull);
            Assert.IsFalse(id.AutoIncremento);
        }

        [TestMethod]
        public void GlobalIdentityMetadataSurvivesCopy()
        {
            var source = new Dominio.Entity("Authority");
            source.AddColumn("Id", "ID").Int().Key().GlobalIdentity("Central");
            var target = new Dominio.Entity("Projection");

            var copy = source.AddColumns.Single().DeepCopy(target);

            Assert.IsTrue(copy.IsGlobalIdentity);
            Assert.AreEqual("Central", copy.GlobalIdentityAuthority);
            Assert.IsFalse(copy.AutoIncremento);
        }
    }
}
