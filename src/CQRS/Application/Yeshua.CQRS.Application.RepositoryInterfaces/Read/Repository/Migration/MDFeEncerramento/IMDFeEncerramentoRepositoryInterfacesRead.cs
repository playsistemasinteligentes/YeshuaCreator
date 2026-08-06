using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IMDFeEncerramentoReadRepository
    {
        public DataPagination<MDFeEncerramentoDTO> getMDFeEncerramento(ICommandRead command );
        public IEnumerable<MDFeEncerramentoMDFeIdDTO> getMDFeEncerramentoReadFKMDFeId(object command );
        public IEnumerable<MDFeEncerramentoTenantIDDTO> getMDFeEncerramentoReadFKTenantID(object command );
        public IEnumerable<MDFeEncerramentoUserIdDTO> getMDFeEncerramentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeId(int value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByUfCarregamento(string value );
        public bool ExistsByUfDescarregamento(string value );
        public bool ExistsByPlacaVeiculo(string value );
        public bool ExistsBySolicitadoEm(DateTime value );
        public bool ExistsByAutorizadoEm(DateTime value );
        public bool ExistsByProtocolo(string value );
        public bool ExistsByCodigoRetorno(string value );
        public bool ExistsByMensagemRetorno(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeEncerramentoDTO FirstById(int value );
        public MDFeEncerramentoDTO FirstByMDFeId(int value );
        public MDFeEncerramentoDTO FirstByChaveAcesso(string value );
        public MDFeEncerramentoDTO FirstByUfCarregamento(string value );
        public MDFeEncerramentoDTO FirstByUfDescarregamento(string value );
        public MDFeEncerramentoDTO FirstByPlacaVeiculo(string value );
        public MDFeEncerramentoDTO FirstBySolicitadoEm(DateTime value );
        public MDFeEncerramentoDTO FirstByAutorizadoEm(DateTime value );
        public MDFeEncerramentoDTO FirstByProtocolo(string value );
        public MDFeEncerramentoDTO FirstByCodigoRetorno(string value );
        public MDFeEncerramentoDTO FirstByMensagemRetorno(string value );
        public MDFeEncerramentoDTO FirstByTenantID(int value );
        public MDFeEncerramentoDTO FirstByDeleted(bool value );
        public MDFeEncerramentoDTO FirstByChanged(DateTime value );
        public MDFeEncerramentoDTO FirstByUserId(int value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllById(int value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByMDFeId(int value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByUfCarregamento(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByUfDescarregamento(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByPlacaVeiculo(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllBySolicitadoEm(DateTime value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByAutorizadoEm(DateTime value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByProtocolo(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByCodigoRetorno(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByMensagemRetorno(string value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeEncerramentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration