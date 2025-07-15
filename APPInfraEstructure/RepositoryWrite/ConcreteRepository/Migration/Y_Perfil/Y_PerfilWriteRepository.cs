using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_Perfil;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Perfil
{
    public class Y_PerfilWriteRepository : IY_PerfilWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_PerfilWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IY_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().InserirY_PerfilQuery(Y_Perfil);
        Y_Perfil.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IY_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().UpdateY_PerfilQuery(Y_Perfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IY_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().DeleteY_PerfilQuery(Y_Perfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IY_PerfilEntity entity)
        {
            var query = new Y_PerfilWriteQuery().UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration