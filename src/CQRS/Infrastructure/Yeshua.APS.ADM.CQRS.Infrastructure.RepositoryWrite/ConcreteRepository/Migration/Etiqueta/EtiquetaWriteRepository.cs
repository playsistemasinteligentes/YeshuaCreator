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

namespace Input.Repository.Etiqueta
{
    public partial class EtiquetaWriteRepository : IEtiquetaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEtiquetaQueryWrite _query; 

        public EtiquetaWriteRepository(IUnitOfWork unitOfWork,IEtiquetaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEtiquetaEntity Etiqueta)
        {
            var query = _query.InserirEtiquetaQuery(Etiqueta);
        Etiqueta.ETI_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEtiquetaEntity Etiqueta)
        {
            var query = _query.UpdateEtiquetaQuery(Etiqueta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEtiquetaEntity Etiqueta)
        {
            var query = _query.DeleteEtiquetaQuery(Etiqueta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_EMISSAO(int eti_id, DateTime value)
        {
            var query = _query.UpdateETI_EMISSAO(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_CODIGO_BARRAS(int eti_id, string value)
        {
            var query = _query.UpdateETI_CODIGO_BARRAS(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_SEQUENCIA(int eti_id, int value)
        {
            var query = _query.UpdateETI_SEQUENCIA(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_NUMERO_COPIAS(int eti_id, int value)
        {
            var query = _query.UpdateETI_NUMERO_COPIAS(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_STATUS(int eti_id, string value)
        {
            var query = _query.UpdateETI_STATUS(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_DATA_FABRICACAO(int eti_id, DateTime value)
        {
            var query = _query.UpdateETI_DATA_FABRICACAO(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_COD_BARRAS_ORIGINAL(int eti_id, string value)
        {
            var query = _query.UpdateETI_COD_BARRAS_ORIGINAL(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_OP_ORIGINAL(int eti_id, string value)
        {
            var query = _query.UpdateETI_OP_ORIGINAL(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int eti_id, string value)
        {
            var query = _query.UpdateMAQ_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIMP_ID(int eti_id, int value)
        {
            var query = _query.UpdateIMP_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int eti_id, int value)
        {
            var query = _query.UpdateUSE_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int eti_id, string value)
        {
            var query = _query.UpdateORD_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PRO_ID(int eti_id, string value)
        {
            var query = _query.UpdateROT_PRO_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int eti_id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int eti_id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_QUANTIDADE_PALETE(int eti_id, Decimal value)
        {
            var query = _query.UpdateETI_QUANTIDADE_PALETE(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_LOTE(int eti_id, string value)
        {
            var query = _query.UpdateETI_LOTE(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_SUB_LOTE(int eti_id, string value)
        {
            var query = _query.UpdateETI_SUB_LOTE(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_IMPRIMIR_DE(int eti_id, int value)
        {
            var query = _query.UpdateETI_IMPRIMIR_DE(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateETI_IMPRIMIR_ATE(int eti_id, int value)
        {
            var query = _query.UpdateETI_IMPRIMIR_ATE(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int eti_id, string value)
        {
            var query = _query.UpdateBOL_ID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int eti_id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int eti_id, int value)
        {
            var query = _query.UpdateTenantID(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int eti_id, bool value)
        {
            var query = _query.UpdateDeleted(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int eti_id, DateTime value)
        {
            var query = _query.UpdateChanged(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int eti_id, int value)
        {
            var query = _query.UpdateUserId(eti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration