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

namespace Input.Repository.BoletimEstudo
{
    public partial class BoletimEstudoWriteRepository : IBoletimEstudoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IBoletimEstudoQueryWrite _query; 

        public BoletimEstudoWriteRepository(IUnitOfWork unitOfWork,IBoletimEstudoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IBoletimEstudoEntity BoletimEstudo)
        {
            var query = _query.InserirBoletimEstudoQuery(BoletimEstudo);
        BoletimEstudo.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IBoletimEstudoEntity BoletimEstudo)
        {
            var query = _query.UpdateBoletimEstudoQuery(BoletimEstudo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IBoletimEstudoEntity BoletimEstudo)
        {
            var query = _query.DeleteBoletimEstudoQuery(BoletimEstudo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID_ORIGEM(int id, string value)
        {
            var query = _query.UpdateBOL_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_SOLVER(int id, string value)
        {
            var query = _query.UpdateBOL_SOLVER(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_INTEGRACAO(int id, string value)
        {
            var query = _query.UpdateBOL_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_SEQUENCIA(int id, Decimal value)
        {
            var query = _query.UpdateBOL_SEQUENCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAP_GRAMATURA_PROGRAMADO(int id, Decimal value)
        {
            var query = _query.UpdateGRP_PAP_GRAMATURA_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_ID_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL1_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_PAPEL1_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL2_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_PAPEL2_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL3_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_PAPEL3_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL4_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_PAPEL4_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_PAPEL5_PROGRAMADO(int id, string value)
        {
            var query = _query.UpdateGRP_PAPEL5_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_STATUS_INTERFACE(int id, string value)
        {
            var query = _query.UpdateBOL_STATUS_INTERFACE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_TIPO(int id, string value)
        {
            var query = _query.UpdateBOL_TIPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_FORMATO(int id, int value)
        {
            var query = _query.UpdateBOL_FORMATO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(int id, Decimal value)
        {
            var query = _query.UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_CUSTO_PAPEIS_REALIZADO(int id, Decimal value)
        {
            var query = _query.UpdateBOL_CUSTO_PAPEIS_REALIZADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateBOL_CUSTO_RESINA_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_REFILE_OBRIGATORIO(int id, int value)
        {
            var query = _query.UpdateBOL_REFILE_OBRIGATORIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration