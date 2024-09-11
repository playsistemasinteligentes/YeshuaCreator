using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entitys.Clinica
{
    public struct ClinicaEntity
    {
        public ClinicaEntity(Nome nomeFantasia, Nome razaoSocial)
        {
            //Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
        }

        public AutoIncremento Id { get; set; }
        public Nome NomeFantasia { get; set; }
        public Nome RazaoSocial { get; set; }

        public bool isValid()
        {
            return true;
        }
    }
}
