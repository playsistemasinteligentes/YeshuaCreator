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

namespace Input.Repository.MDFe
{
    public partial class MDFeWriteRepository : IMDFeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeQueryWrite _query; 

        public MDFeWriteRepository(IUnitOfWork unitOfWork,IMDFeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeEntity MDFe)
        {
            var query = _query.InserirMDFeQuery(MDFe);
        MDFe.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeEntity MDFe)
        {
            var query = _query.UpdateMDFeQuery(MDFe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeEntity MDFe)
        {
            var query = _query.DeleteMDFeQuery(MDFe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSerie(int id, int value)
        {
            var query = _query.UpdateSerie(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNumero(int id, int value)
        {
            var query = _query.UpdateNumero(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUfCarregamento(int id, string value)
        {
            var query = _query.UpdateUfCarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUfDescarregamento(int id, string value)
        {
            var query = _query.UpdateUfDescarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePlacaVeiculo(int id, string value)
        {
            var query = _query.UpdatePlacaVeiculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmitidoEm(int id, DateTime value)
        {
            var query = _query.UpdateEmitidoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAutorizadoEm(int id, DateTime value)
        {
            var query = _query.UpdateAutorizadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIniciadoEm(int id, DateTime value)
        {
            var query = _query.UpdateIniciadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEncerradoEm(int id, DateTime value)
        {
            var query = _query.UpdateEncerradoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCanceladoEm(int id, DateTime value)
        {
            var query = _query.UpdateCanceladoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSituacao(int id, int value)
        {
            var query = _query.UpdateSituacao(id, value);
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