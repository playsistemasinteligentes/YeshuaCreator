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

namespace Input.Repository.T_Favoritos
{
    public partial class T_FavoritosWriteRepository : IT_FavoritosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_FavoritosQueryWrite _query; 

        public T_FavoritosWriteRepository(IUnitOfWork unitOfWork,IT_FavoritosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_FavoritosEntity T_Favoritos)
        {
            var query = _query.InserirT_FavoritosQuery(T_Favoritos);
        T_Favoritos.IDFAVORITO =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_FavoritosEntity T_Favoritos)
        {
            var query = _query.UpdateT_FavoritosQuery(T_Favoritos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_FavoritosEntity T_Favoritos)
        {
            var query = _query.DeleteT_FavoritosQuery(T_Favoritos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int idfavorito, int value)
        {
            var query = _query.UpdateUSE_ID(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateID_INDICADOR(int idfavorito, int value)
        {
            var query = _query.UpdateID_INDICADOR(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int idfavorito, int value)
        {
            var query = _query.UpdateTenantID(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int idfavorito, bool value)
        {
            var query = _query.UpdateDeleted(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int idfavorito, DateTime value)
        {
            var query = _query.UpdateChanged(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int idfavorito, int value)
        {
            var query = _query.UpdateUserId(idfavorito, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration