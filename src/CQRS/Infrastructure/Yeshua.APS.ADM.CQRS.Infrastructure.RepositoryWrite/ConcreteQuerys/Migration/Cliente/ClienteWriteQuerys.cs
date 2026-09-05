// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class ClienteQueryWrite : QueryBase, IClienteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ClienteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirClienteQuery(IClienteEntity Cliente)
        {
            this.Query = $@" INSERT INTO [Cliente] ([CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@CLI_ID, @CLI_NOME, @CLI_FONE, @CLI_OBS, @CLI_ENDERECO_ENTREGA, @CLI_CPF_CNPJ, @CLI_BAIRRO_ENTREGA, @CLI_CEP_ENTREGA, @CLI_EMAIL, @CLI_INTEGRACAO, @MUN_ID_ENTREGA, @CLI_TRANSLADO, @CLI_REGIAO_ENTREGA, @CLI_EXIGENTE_NA_IMPRESSAO, @CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO, @CLI_TEMPO_DESCARREGAMENTO_UNITARIO, @CLI_PERCENTUAL_JANELA_EMBARQUE, @REP_ID, @CLI_RAZAO_SOCIAL, @CLI_EMAIL_MONITORAMENTO_TRANSPORTE, @CLI_CONTATO, @CLI_SETOR, @SEG_ID, @CLI_TIPO, @CLI_INTEGRACAO_ERP, @CLI_LATITUDE_ENTREGA, @CLI_LONGITUDE_ENTREGA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CLI_ID = Cliente.CLI_ID,
                CLI_NOME = Cliente.CLI_NOME,
                CLI_FONE = Cliente.CLI_FONE,
                CLI_OBS = Cliente.CLI_OBS,
                CLI_ENDERECO_ENTREGA = Cliente.CLI_ENDERECO_ENTREGA,
                CLI_CPF_CNPJ = Cliente.CLI_CPF_CNPJ,
                CLI_BAIRRO_ENTREGA = Cliente.CLI_BAIRRO_ENTREGA,
                CLI_CEP_ENTREGA = Cliente.CLI_CEP_ENTREGA,
                CLI_EMAIL = Cliente.CLI_EMAIL,
                CLI_INTEGRACAO = Cliente.CLI_INTEGRACAO,
                MUN_ID_ENTREGA = Cliente.MUN_ID_ENTREGA,
                CLI_TRANSLADO = Cliente.CLI_TRANSLADO,
                CLI_REGIAO_ENTREGA = Cliente.CLI_REGIAO_ENTREGA,
                CLI_EXIGENTE_NA_IMPRESSAO = Cliente.CLI_EXIGENTE_NA_IMPRESSAO,
                CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = Cliente.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO,
                CLI_TEMPO_DESCARREGAMENTO_UNITARIO = Cliente.CLI_TEMPO_DESCARREGAMENTO_UNITARIO,
                CLI_PERCENTUAL_JANELA_EMBARQUE = Cliente.CLI_PERCENTUAL_JANELA_EMBARQUE,
                REP_ID = Cliente.REP_ID,
                CLI_RAZAO_SOCIAL = Cliente.CLI_RAZAO_SOCIAL,
                CLI_EMAIL_MONITORAMENTO_TRANSPORTE = Cliente.CLI_EMAIL_MONITORAMENTO_TRANSPORTE,
                CLI_CONTATO = Cliente.CLI_CONTATO,
                CLI_SETOR = Cliente.CLI_SETOR,
                SEG_ID = Cliente.SEG_ID,
                CLI_TIPO = Cliente.CLI_TIPO,
                CLI_INTEGRACAO_ERP = Cliente.CLI_INTEGRACAO_ERP,
                CLI_LATITUDE_ENTREGA = Cliente.CLI_LATITUDE_ENTREGA,
                CLI_LONGITUDE_ENTREGA = Cliente.CLI_LONGITUDE_ENTREGA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteQuery(IClienteEntity Cliente)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_NOME] = @CLI_NOME, [CLI_FONE] = @CLI_FONE, [CLI_OBS] = @CLI_OBS, [CLI_ENDERECO_ENTREGA] = @CLI_ENDERECO_ENTREGA, [CLI_CPF_CNPJ] = @CLI_CPF_CNPJ, [CLI_BAIRRO_ENTREGA] = @CLI_BAIRRO_ENTREGA, [CLI_CEP_ENTREGA] = @CLI_CEP_ENTREGA, [CLI_EMAIL] = @CLI_EMAIL, [CLI_INTEGRACAO] = @CLI_INTEGRACAO, [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA, [CLI_TRANSLADO] = @CLI_TRANSLADO, [CLI_REGIAO_ENTREGA] = @CLI_REGIAO_ENTREGA, [CLI_EXIGENTE_NA_IMPRESSAO] = @CLI_EXIGENTE_NA_IMPRESSAO, [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO] = @CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO, [CLI_TEMPO_DESCARREGAMENTO_UNITARIO] = @CLI_TEMPO_DESCARREGAMENTO_UNITARIO, [CLI_PERCENTUAL_JANELA_EMBARQUE] = @CLI_PERCENTUAL_JANELA_EMBARQUE, [REP_ID] = @REP_ID, [CLI_RAZAO_SOCIAL] = @CLI_RAZAO_SOCIAL, [CLI_EMAIL_MONITORAMENTO_TRANSPORTE] = @CLI_EMAIL_MONITORAMENTO_TRANSPORTE, [CLI_CONTATO] = @CLI_CONTATO, [CLI_SETOR] = @CLI_SETOR, [SEG_ID] = @SEG_ID, [CLI_TIPO] = @CLI_TIPO, [CLI_INTEGRACAO_ERP] = @CLI_INTEGRACAO_ERP, [CLI_LATITUDE_ENTREGA] = @CLI_LATITUDE_ENTREGA, [CLI_LONGITUDE_ENTREGA] = @CLI_LONGITUDE_ENTREGA, [Changed] = @Changed, [UserId] = @UserId WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_NOME = Cliente.CLI_NOME,
                CLI_FONE = Cliente.CLI_FONE,
                CLI_OBS = Cliente.CLI_OBS,
                CLI_ENDERECO_ENTREGA = Cliente.CLI_ENDERECO_ENTREGA,
                CLI_CPF_CNPJ = Cliente.CLI_CPF_CNPJ,
                CLI_BAIRRO_ENTREGA = Cliente.CLI_BAIRRO_ENTREGA,
                CLI_CEP_ENTREGA = Cliente.CLI_CEP_ENTREGA,
                CLI_EMAIL = Cliente.CLI_EMAIL,
                CLI_INTEGRACAO = Cliente.CLI_INTEGRACAO,
                MUN_ID_ENTREGA = Cliente.MUN_ID_ENTREGA,
                CLI_TRANSLADO = Cliente.CLI_TRANSLADO,
                CLI_REGIAO_ENTREGA = Cliente.CLI_REGIAO_ENTREGA,
                CLI_EXIGENTE_NA_IMPRESSAO = Cliente.CLI_EXIGENTE_NA_IMPRESSAO,
                CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = Cliente.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO,
                CLI_TEMPO_DESCARREGAMENTO_UNITARIO = Cliente.CLI_TEMPO_DESCARREGAMENTO_UNITARIO,
                CLI_PERCENTUAL_JANELA_EMBARQUE = Cliente.CLI_PERCENTUAL_JANELA_EMBARQUE,
                REP_ID = Cliente.REP_ID,
                CLI_RAZAO_SOCIAL = Cliente.CLI_RAZAO_SOCIAL,
                CLI_EMAIL_MONITORAMENTO_TRANSPORTE = Cliente.CLI_EMAIL_MONITORAMENTO_TRANSPORTE,
                CLI_CONTATO = Cliente.CLI_CONTATO,
                CLI_SETOR = Cliente.CLI_SETOR,
                SEG_ID = Cliente.SEG_ID,
                CLI_TIPO = Cliente.CLI_TIPO,
                CLI_INTEGRACAO_ERP = Cliente.CLI_INTEGRACAO_ERP,
                CLI_LATITUDE_ENTREGA = Cliente.CLI_LATITUDE_ENTREGA,
                CLI_LONGITUDE_ENTREGA = Cliente.CLI_LONGITUDE_ENTREGA,
                Changed = Cliente.Changed,
                UserId = _executionContext.UserId,
                CLI_ID = Cliente.CLI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_NOME(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_NOME] = @CLI_NOME WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_NOME = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_FONE(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_FONE] = @CLI_FONE WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_FONE = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_OBS(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_OBS] = @CLI_OBS WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_OBS = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ENDERECO_ENTREGA(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_ENDERECO_ENTREGA] = @CLI_ENDERECO_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_ENDERECO_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_CPF_CNPJ(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_CPF_CNPJ] = @CLI_CPF_CNPJ WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_CPF_CNPJ = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_BAIRRO_ENTREGA(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_BAIRRO_ENTREGA] = @CLI_BAIRRO_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_BAIRRO_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_CEP_ENTREGA(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_CEP_ENTREGA] = @CLI_CEP_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_CEP_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_EMAIL(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_EMAIL] = @CLI_EMAIL WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_EMAIL = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_INTEGRACAO(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_INTEGRACAO] = @CLI_INTEGRACAO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_INTEGRACAO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_ID_ENTREGA(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                MUN_ID_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_TRANSLADO(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_TRANSLADO] = @CLI_TRANSLADO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_TRANSLADO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_REGIAO_ENTREGA(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_REGIAO_ENTREGA] = @CLI_REGIAO_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_REGIAO_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_EXIGENTE_NA_IMPRESSAO(string cli_id, int value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_EXIGENTE_NA_IMPRESSAO] = @CLI_EXIGENTE_NA_IMPRESSAO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_EXIGENTE_NA_IMPRESSAO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO] = @CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_TEMPO_DESCARREGAMENTO_UNITARIO(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_TEMPO_DESCARREGAMENTO_UNITARIO] = @CLI_TEMPO_DESCARREGAMENTO_UNITARIO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_TEMPO_DESCARREGAMENTO_UNITARIO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_PERCENTUAL_JANELA_EMBARQUE(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_PERCENTUAL_JANELA_EMBARQUE] = @CLI_PERCENTUAL_JANELA_EMBARQUE WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_PERCENTUAL_JANELA_EMBARQUE = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_ID(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [REP_ID] = @REP_ID WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                REP_ID = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_RAZAO_SOCIAL(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_RAZAO_SOCIAL] = @CLI_RAZAO_SOCIAL WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_RAZAO_SOCIAL = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_EMAIL_MONITORAMENTO_TRANSPORTE] = @CLI_EMAIL_MONITORAMENTO_TRANSPORTE WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_EMAIL_MONITORAMENTO_TRANSPORTE = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_CONTATO(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_CONTATO] = @CLI_CONTATO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_CONTATO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_SETOR(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_SETOR] = @CLI_SETOR WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_SETOR = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_ID(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [SEG_ID] = @SEG_ID WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                SEG_ID = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_TIPO(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_TIPO] = @CLI_TIPO WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_TIPO = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_INTEGRACAO_ERP(string cli_id, string value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_INTEGRACAO_ERP] = @CLI_INTEGRACAO_ERP WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_INTEGRACAO_ERP = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_LATITUDE_ENTREGA(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_LATITUDE_ENTREGA] = @CLI_LATITUDE_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_LATITUDE_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_LONGITUDE_ENTREGA(string cli_id, Decimal value)
        {
            this.Query = $@" UPDATE [Cliente] SET [CLI_LONGITUDE_ENTREGA] = @CLI_LONGITUDE_ENTREGA WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_LONGITUDE_ENTREGA = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string cli_id, int value)
        {
            this.Query = $@" UPDATE [Cliente] SET [TenantID] = @TenantID WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string cli_id, bool value)
        {
            this.Query = $@" UPDATE [Cliente] SET [Deleted] = @Deleted WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string cli_id, DateTime value)
        {
            this.Query = $@" UPDATE [Cliente] SET [Changed] = @Changed WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                Changed = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string cli_id, int value)
        {
            this.Query = $@" UPDATE [Cliente] SET [UserId] = @UserId WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                UserId = value,
                CLI_ID = cli_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteClienteQuery(IClienteEntity Cliente)
        {
            this.Query = $@" DELETE FROM [Cliente] WHERE [CLI_ID] = @CLI_ID ";
            this.Parameters = new
            {
                CLI_ID = Cliente.CLI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration