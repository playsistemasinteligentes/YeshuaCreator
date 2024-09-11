using Repositorio.Outputs.DTOs.ExecoesCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.ExecoesCalendario
{
    public interface IExecoesCalendarioReadRepository
    {
        public IEnumerable<ExecoesCalendarioDTO> GetAllExecoesCalendarios();
        public ExecoesCalendarioDTO GetById();
    }
}
