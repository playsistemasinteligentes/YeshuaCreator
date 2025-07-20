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
    public class ClinicaQueryWrite : QueryBase, IClinicaQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public ClinicaQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" INSERT INTO Clinica (Nome, Endereco, Telefone) OUTPUT INSERTED.Id VALUES(@Nome, @Endereco, @Telefone) ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
                Id = Clinica.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = entity.Endereco,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = entity.Telefone,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" DELETE FROM Clinica WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Clinica.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration