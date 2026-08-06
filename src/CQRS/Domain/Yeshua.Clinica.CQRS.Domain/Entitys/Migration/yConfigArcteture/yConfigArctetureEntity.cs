
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yConfigArctetureEntity : IyConfigArctetureEntity
{
    public int? Id { get; set; }
    public int? AuditTrackerActived { get; set; }
    public int? AuditCRUDActived { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yConfigArctetureEntity(int? id, int? audittrackeractived, int? auditcrudactived ){
 Id = id; 
 AuditTrackerActived = audittrackeractived; 
 AuditCRUDActived = auditcrudactived; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration