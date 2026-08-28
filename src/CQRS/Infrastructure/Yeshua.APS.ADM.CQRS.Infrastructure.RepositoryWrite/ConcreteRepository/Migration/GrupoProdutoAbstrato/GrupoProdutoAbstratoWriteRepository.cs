// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.GrupoProdutoAbstrato
{
    public partial class GrupoProdutoAbstratoWriteRepository : IGrupoProdutoAbstratoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IGrupoProdutoAbstratoQueryWrite _query; 

        public GrupoProdutoAbstratoWriteRepository(IUnitOfWork unitOfWork,IGrupoProdutoAbstratoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            var query = _query.InserirGrupoProdutoAbstratoQuery(GrupoProdutoAbstrato);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            var query = _query.UpdateGrupoProdutoAbstratoQuery(GrupoProdutoAbstrato);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            var query = _query.DeleteGrupoProdutoAbstratoQuery(GrupoProdutoAbstrato);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_DESCRICAO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_DESCRICAO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(string grp_id, int value)
        {
            var query = _query.UpdateTEM_ID(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TIPO(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_TIPO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAP_ONDA(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAP_ONDA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAP_GRAMATURA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_PAP_GRAMATURA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAP_ALTURA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_PAP_ALTURA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAP_NOME_COMERCIAL(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAP_NOME_COMERCIAL(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ATIVO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_ATIVO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_DT_CRIACAO(string grp_id, DateTime value)
        {
            var query = _query.UpdateGRP_DT_CRIACAO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL1(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAPEL1(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL2(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAPEL2(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL3(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAPEL3(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL4(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAPEL4(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL5(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PAPEL5(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID_INTEGRACAO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_ID_INTEGRACAO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID_INTEGRACAO_ERP(string grp_id, string value)
        {
            var query = _query.UpdateGRP_ID_INTEGRACAO_ERP(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TYPE(string grp_id, int value)
        {
            var query = _query.UpdateGRP_TYPE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PERFORMANCE(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_PERFORMANCE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_RESINA(string grp_id, string value)
        {
            var query = _query.UpdateGRP_RESINA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ENDURECEDOR_MIOLO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_ENDURECEDOR_MIOLO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIN_ID(string grp_id, int value)
        {
            var query = _query.UpdateVIN_ID(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_COLUNA_DE(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_COLUNA_DE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_COLUNA_ATE(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_COLUNA_ATE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_CRUSH(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_CRUSH(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID_FAMILIA(string grp_id, string value)
        {
            var query = _query.UpdateGRP_ID_FAMILIA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_REFILE_LARGURA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_REFILE_LARGURA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_REFILE_COMPRIMENTO(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_REFILE_COMPRIMENTO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TIPO_LAP(string grp_id, string value)
        {
            var query = _query.UpdateGRP_TIPO_LAP(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_LAP_PROLONGADO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_LAP_PROLONGADO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TAMANHO_LAP_OND_SIMPLES(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_TAMANHO_LAP_OND_SIMPLES(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TAMANHO_LAP_OND_DUPLA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_TAMANHO_LAP_OND_DUPLA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_FEFCO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_FEFCO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(string grp_id, int value)
        {
            var query = _query.UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(string grp_id, int value)
        {
            var query = _query.UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PREFIXO_ID_PRODUTO(string grp_id, string value)
        {
            var query = _query.UpdateGRP_PREFIXO_ID_PRODUTO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_COLUNA_CAIXA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_COLUNA_CAIXA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_COLUNA_CHAPA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_COLUNA_CHAPA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_MULLEN(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_MULLEN(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TENDENCIA_TOLERANCIA_PEDIDO(string grp_id, int value)
        {
            var query = _query.UpdateGRP_TENDENCIA_TOLERANCIA_PEDIDO(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PERCENTUAL_PERDA_MEDIA(string grp_id, Decimal value)
        {
            var query = _query.UpdateGRP_PERCENTUAL_PERDA_MEDIA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_FILTRA_SEQ_TRANS(string grp_id, int value)
        {
            var query = _query.UpdateGRP_FILTRA_SEQ_TRANS(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_IMG_CAIXA(string grp_id, string value)
        {
            var query = _query.UpdateGRP_IMG_CAIXA(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string grp_id, int value)
        {
            var query = _query.UpdateTenantID(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string grp_id, bool value)
        {
            var query = _query.UpdateDeleted(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string grp_id, DateTime value)
        {
            var query = _query.UpdateChanged(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string grp_id, int value)
        {
            var query = _query.UpdateUserId(grp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration