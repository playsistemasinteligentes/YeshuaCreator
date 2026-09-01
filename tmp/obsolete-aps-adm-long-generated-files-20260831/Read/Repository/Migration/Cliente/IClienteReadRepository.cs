// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

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
    public partial interface IClienteReadRepository
    {
        public DataPagination<ClienteDTO> getCliente(ICommandRead command );
        public IEnumerable<ClienteMUN_ID_ENTREGADTO> getClienteReadFKMUN_ID_ENTREGA(object command );
        public IEnumerable<ClienteTenantIDDTO> getClienteReadFKTenantID(object command );
        public IEnumerable<ClienteUserIdDTO> getClienteReadFKUserId(object command );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByCLI_NOME(string value );
        public bool ExistsByCLI_FONE(string value );
        public bool ExistsByCLI_OBS(string value );
        public bool ExistsByCLI_ENDERECO_ENTREGA(string value );
        public bool ExistsByCLI_CPF_CNPJ(string value );
        public bool ExistsByCLI_BAIRRO_ENTREGA(string value );
        public bool ExistsByCLI_CEP_ENTREGA(string value );
        public bool ExistsByCLI_EMAIL(string value );
        public bool ExistsByCLI_INTEGRACAO(string value );
        public bool ExistsByMUN_ID_ENTREGA(string value );
        public bool ExistsByCLI_TRANSLADO(Decimal value );
        public bool ExistsByCLI_REGIAO_ENTREGA(string value );
        public bool ExistsByCLI_EXIGENTE_NA_IMPRESSAO(int value );
        public bool ExistsByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value );
        public bool ExistsByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value );
        public bool ExistsByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value );
        public bool ExistsByREP_ID(string value );
        public bool ExistsByCLI_RAZAO_SOCIAL(string value );
        public bool ExistsByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value );
        public bool ExistsByCLI_CONTATO(string value );
        public bool ExistsByCLI_SETOR(string value );
        public bool ExistsBySEG_ID(string value );
        public bool ExistsByCLI_TIPO(string value );
        public bool ExistsByCLI_INTEGRACAO_ERP(string value );
        public bool ExistsByCLI_LATITUDE_ENTREGA(Decimal value );
        public bool ExistsByCLI_LONGITUDE_ENTREGA(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ClienteDTO FirstByCLI_ID(string value );
        public ClienteDTO FirstByCLI_NOME(string value );
        public ClienteDTO FirstByCLI_FONE(string value );
        public ClienteDTO FirstByCLI_OBS(string value );
        public ClienteDTO FirstByCLI_ENDERECO_ENTREGA(string value );
        public ClienteDTO FirstByCLI_CPF_CNPJ(string value );
        public ClienteDTO FirstByCLI_BAIRRO_ENTREGA(string value );
        public ClienteDTO FirstByCLI_CEP_ENTREGA(string value );
        public ClienteDTO FirstByCLI_EMAIL(string value );
        public ClienteDTO FirstByCLI_INTEGRACAO(string value );
        public ClienteDTO FirstByMUN_ID_ENTREGA(string value );
        public ClienteDTO FirstByCLI_TRANSLADO(Decimal value );
        public ClienteDTO FirstByCLI_REGIAO_ENTREGA(string value );
        public ClienteDTO FirstByCLI_EXIGENTE_NA_IMPRESSAO(int value );
        public ClienteDTO FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value );
        public ClienteDTO FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value );
        public ClienteDTO FirstByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value );
        public ClienteDTO FirstByREP_ID(string value );
        public ClienteDTO FirstByCLI_RAZAO_SOCIAL(string value );
        public ClienteDTO FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value );
        public ClienteDTO FirstByCLI_CONTATO(string value );
        public ClienteDTO FirstByCLI_SETOR(string value );
        public ClienteDTO FirstBySEG_ID(string value );
        public ClienteDTO FirstByCLI_TIPO(string value );
        public ClienteDTO FirstByCLI_INTEGRACAO_ERP(string value );
        public ClienteDTO FirstByCLI_LATITUDE_ENTREGA(Decimal value );
        public ClienteDTO FirstByCLI_LONGITUDE_ENTREGA(Decimal value );
        public ClienteDTO FirstByTenantID(int value );
        public ClienteDTO FirstByDeleted(bool value );
        public ClienteDTO FirstByChanged(DateTime value );
        public ClienteDTO FirstByUserId(int value );
        public IEnumerable<ClienteDTO> GetAllByCLI_ID(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_NOME(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_FONE(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_OBS(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_ENDERECO_ENTREGA(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_CPF_CNPJ(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_BAIRRO_ENTREGA(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_CEP_ENTREGA(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_EMAIL(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_INTEGRACAO(string value );
        public IEnumerable<ClienteDTO> GetAllByMUN_ID_ENTREGA(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_TRANSLADO(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByCLI_REGIAO_ENTREGA(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_EXIGENTE_NA_IMPRESSAO(int value );
        public IEnumerable<ClienteDTO> GetAllByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByREP_ID(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_RAZAO_SOCIAL(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_CONTATO(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_SETOR(string value );
        public IEnumerable<ClienteDTO> GetAllBySEG_ID(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_TIPO(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_INTEGRACAO_ERP(string value );
        public IEnumerable<ClienteDTO> GetAllByCLI_LATITUDE_ENTREGA(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByCLI_LONGITUDE_ENTREGA(Decimal value );
        public IEnumerable<ClienteDTO> GetAllByTenantID(int value );
        public IEnumerable<ClienteDTO> GetAllByDeleted(bool value );
        public IEnumerable<ClienteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ClienteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration