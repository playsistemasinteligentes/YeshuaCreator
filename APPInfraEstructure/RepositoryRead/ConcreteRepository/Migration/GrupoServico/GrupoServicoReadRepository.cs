using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class GrupoServicoReadRepository : IGrupoServicoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICurrentUser _currentUser;
       protected readonly IGrupoServicoQueryRead _query;

        public GrupoServicoReadRepository(IUnitOfWork unitOfWork, ICurrentUser currentUser,IGrupoServicoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command )
         {
            if (command is Command.Read.GrupoServicoReadCommand c)
                return getGrupoServico(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoServicoDTO> getGrupoServico(Command.Read.GrupoServicoReadCommand command )
        {
            var query = _query.GrupoServicoQuery(command );

                var itens = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoServicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoServicoTenantIDDTO> getGrupoServicoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoServicoTenantIDDTO> lista;
            var query = _query.GrupoServicoTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoServicoTenantIDDTO>(query.Query,query.Parameters) as List<GrupoServicoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoServicoTenantIDDTO> getGrupoServicoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoServicoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoServicoUserIdDTO> getGrupoServicoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoServicoUserIdDTO> lista;
            var query = _query.GrupoServicoUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoServicoUserIdDTO>(query.Query,query.Parameters) as List<GrupoServicoUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoServicoUserIdDTO> getGrupoServicoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoServicoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public GrupoServicoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

        public IEnumerable<GrupoServicoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoServicoDTO>(query.Query,query.Parameters) as List<GrupoServicoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration