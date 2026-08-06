using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IMDFeEncerramentoWriteRepository
    {
        void Insert(IMDFeEncerramentoEntity mdfeencerramento);
        void Update(IMDFeEncerramentoEntity mdfeencerramento);
        void Delete(IMDFeEncerramentoEntity mdfeencerramento);
        void UpdateMDFeId(int id, int value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateUfCarregamento(int id, string value);
        void UpdateUfDescarregamento(int id, string value);
        void UpdatePlacaVeiculo(int id, string value);
        void UpdateSolicitadoEm(int id, DateTime value);
        void UpdateAutorizadoEm(int id, DateTime value);
        void UpdateProtocolo(int id, string value);
        void UpdateCodigoRetorno(int id, string value);
        void UpdateMensagemRetorno(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration