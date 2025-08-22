using Dominio;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio
{
    public class Module
    {
        public Module(string key, string description)
        {
            Key = key;
            Description = description;
        }
        public Module(string key)
        {
            Key = key;
            Description = "";
            Existe = true;
        }
        public Descricao Description { get; set; }
        public bool Existe { get; }
        public bool Inserir { set; get; } = false;
        public string Key
        {
            get; set;
        }
        public List<Entity> Entities { get; set; } = new List<Entity>();

    }
}
