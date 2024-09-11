using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Clinica
{
    public struct ClincaDTO : ICloneable
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
