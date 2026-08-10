using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IMDFeWriteRepository
    {
        void Insert(IMDFeEntity mdfe);
        void Update(IMDFeEntity mdfe);
        void Delete(IMDFeEntity mdfe);
        void UpdateChaveAcesso(int id, string value);
        void UpdateSerie(int id, int value);
        void UpdateNumero(int id, int value);
        void UpdateUfCarregamento(int id, string value);
        void UpdateUfDescarregamento(int id, string value);
        void UpdatePlacaVeiculo(int id, string value);
        void UpdateEmitidoEm(int id, DateTime value);
        void UpdateAutorizadoEm(int id, DateTime value);
        void UpdateIniciadoEm(int id, DateTime value);
        void UpdateEncerradoEm(int id, DateTime value);
        void UpdateCanceladoEm(int id, DateTime value);
        void UpdateSituacao(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration