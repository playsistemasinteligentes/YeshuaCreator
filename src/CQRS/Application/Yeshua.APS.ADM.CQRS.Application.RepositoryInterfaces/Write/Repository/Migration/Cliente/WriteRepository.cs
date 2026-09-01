// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IClienteWriteRepository
    {
        void Insert(IClienteEntity cliente);
        void Update(IClienteEntity cliente);
        void Delete(IClienteEntity cliente);
        void UpdateCLI_NOME(string cli_id, string value);
        void UpdateCLI_FONE(string cli_id, string value);
        void UpdateCLI_OBS(string cli_id, string value);
        void UpdateCLI_ENDERECO_ENTREGA(string cli_id, string value);
        void UpdateCLI_CPF_CNPJ(string cli_id, string value);
        void UpdateCLI_BAIRRO_ENTREGA(string cli_id, string value);
        void UpdateCLI_CEP_ENTREGA(string cli_id, string value);
        void UpdateCLI_EMAIL(string cli_id, string value);
        void UpdateCLI_INTEGRACAO(string cli_id, string value);
        void UpdateMUN_ID_ENTREGA(string cli_id, string value);
        void UpdateCLI_TRANSLADO(string cli_id, Decimal value);
        void UpdateCLI_REGIAO_ENTREGA(string cli_id, string value);
        void UpdateCLI_EXIGENTE_NA_IMPRESSAO(string cli_id, int value);
        void UpdateCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(string cli_id, Decimal value);
        void UpdateCLI_TEMPO_DESCARREGAMENTO_UNITARIO(string cli_id, Decimal value);
        void UpdateCLI_PERCENTUAL_JANELA_EMBARQUE(string cli_id, Decimal value);
        void UpdateREP_ID(string cli_id, string value);
        void UpdateCLI_RAZAO_SOCIAL(string cli_id, string value);
        void UpdateCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string cli_id, string value);
        void UpdateCLI_CONTATO(string cli_id, string value);
        void UpdateCLI_SETOR(string cli_id, string value);
        void UpdateSEG_ID(string cli_id, string value);
        void UpdateCLI_TIPO(string cli_id, string value);
        void UpdateCLI_INTEGRACAO_ERP(string cli_id, string value);
        void UpdateCLI_LATITUDE_ENTREGA(string cli_id, Decimal value);
        void UpdateCLI_LONGITUDE_ENTREGA(string cli_id, Decimal value);
        void UpdateTenantID(string cli_id, int value);
        void UpdateDeleted(string cli_id, bool value);
        void UpdateChanged(string cli_id, DateTime value);
        void UpdateUserId(string cli_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration