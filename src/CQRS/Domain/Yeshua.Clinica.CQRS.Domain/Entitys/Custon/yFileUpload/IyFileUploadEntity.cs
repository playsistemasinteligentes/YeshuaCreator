
namespace Dominio.Entitys
{
    public partial class yFileUploadEntity
    {
        public yFileUploadEntity()
        {
        }

        public yFileUploadEntity getProxy(int id)
        {
            return new yFileUploadEntity() { Id = id };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeEntityMigration
